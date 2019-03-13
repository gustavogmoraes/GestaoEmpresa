using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestaoEmpresa.GS.GestaoEmpresa.GS.GestaoEmpresa.UI.Principal;
using GS.GestaoEmpresa.Solucao.UI.Base;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class frmInteracao : Form, IView
    {
        private int _codigoInteracao { get; set; }

        private decimal _valor { get; set; }

        public frmInteracao()
        {
            InitializeComponent();

            InicializeBotoes(EnumTipoDeForm.Cadastro, ref btnEditarSalvar, ref btnCancelarExcluir, ref _switchBotaoEditarSalvar, ref _switchBotaoCancelarExcluir);
            TipoDeForm = EnumTipoDeForm.Cadastro;
            cbTipo.Text = "Ativo";
            
            txtLineHorario.Enabled = true;
            dateHorario.Value = DateTime.Now;
        }

        public frmInteracao(Interacao interacao)
        {
            InitializeComponent();

            TipoDeForm = EnumTipoDeForm.Detalhamento;

            CarregueControlesComObjeto(interacao);
            DesabiliteControles();
            InicializeBotoes(EnumTipoDeForm.Detalhamento, ref btnEditarSalvar, ref btnCancelarExcluir, ref _switchBotaoEditarSalvar, ref _switchBotaoCancelarExcluir);
            _codigoInteracao = interacao.Codigo;
        }

        #region FormPadrao

        public IPresenter Presenter { get; set; }
        public void ChamadaMinimizarForm(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ChamadaFecharForm(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected CultureInfo Cultura = new CultureInfo("pt-BR");

        protected EnumBotoesForm _switchBotaoEditarSalvar;

        protected EnumBotoesForm _switchBotaoCancelarExcluir;

        public EnumTipoDeForm TipoDeForm { get; set; }

        protected List<Inconsistencia> _listaDeInconsistencias { get; set; }

        protected virtual void HabiliteControles()
        {
            var controles = (this as Form).Controls;

            foreach (Control controle in controles)
            {
                controle.Enabled = true;
            }
        }

        protected virtual void DesabiliteControles()
        {
            cbTipo.Enabled = false;
            txtLineTipo.Enabled = false;

            txtQuantidade.Enabled = false;
            txtLineQuantidadeEstoque.Enabled = false;

            txtQuantidadeAux.Enabled = false;
            txtLineQuantidadeAux.Enabled = false;

            txtNumeroDaNotaFiscal.Enabled = false;

            txtObservacoes.Enabled = false;
            txtLineObservacoes.Enabled = false;

            cbProduto.Enabled = false;
            txtLineProduto.Enabled = false;

            txtOrigem.Enabled = false;
            txtLineOrigem.Enabled = false;

            txtDestino.Enabled = false;
            txtLineDestino.Enabled = false;

            dateHorario.Enabled = false;
            dateData.Enabled = false;

            chkAtualizar.Enabled = false;
            chkInformarNumeroDeSerie.Enabled = false;

            foreach(Control controle in flpNumerosDeSerie.Controls)
            {
                controle.Controls.Find("btnAdicionar", false)[0].Visible = false;
                controle.Controls.Find("txtTexto", false)[0].Enabled = false;
                controle.Controls.Find("txtLineTexto", false)[0].Enabled = false;
            }

            flpNumerosDeSerie.Enabled = true;
            btnCancelarExcluir.Enabled = true;
            btnEditarSalvar.Enabled = false;
            btnEditarSalvar.Visible = false;
        }

        protected void InicializeBotoes(EnumTipoDeForm tipoDeForm,
                                        ref PictureBox btnEditarSalvar,
                                        ref PictureBox btnCancelarExcluir,
                                        ref EnumBotoesForm switchBotaoEditarSalvar,
                                        ref EnumBotoesForm switchBotaoCancelarExcluir)
        {
            switch (tipoDeForm)
            {
                case EnumTipoDeForm.Cadastro:
                    btnCancelarExcluir.Enabled = false;
                    btnCancelarExcluir.Visible = false;

                    btnEditarSalvar.Image = Properties.Resources.floppy_icon;
                    switchBotaoEditarSalvar = EnumBotoesForm.Salvar;
                    break;

                case EnumTipoDeForm.Edicao:
                    btnCancelarExcluir.Enabled = true;
                    btnCancelarExcluir.Visible = true;
                    btnCancelarExcluir.Image = Properties.Resources.cancel_icon;
                    switchBotaoCancelarExcluir = EnumBotoesForm.Cancelar;

                    btnEditarSalvar.Image = Properties.Resources.floppy_icon;
                    switchBotaoEditarSalvar = EnumBotoesForm.Salvar;
                    break;

                case EnumTipoDeForm.Detalhamento:
                    btnCancelarExcluir.Enabled = true;
                    btnCancelarExcluir.Visible = true;
                    btnCancelarExcluir.Image = Properties.Resources.delete;
                    switchBotaoCancelarExcluir = EnumBotoesForm.Excluir;

                    btnEditarSalvar.Image = Properties.Resources.edit_512;
                    switchBotaoEditarSalvar = EnumBotoesForm.Editar;
                    break;
            }

            btnEditarSalvar.Refresh();
            btnCancelarExcluir.Refresh();
        }

        #endregion

        private void frmInteracao_Load(object sender, EventArgs e)
        {
            var listaDeProdutos = new List<Produto>();
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                listaDeProdutos = servicoDeProduto.ConsulteTodos().ToList();
            }

            PreenchaComboBoxPesquisaComProdutos(listaDeProdutos);
            
            switch(TipoDeForm)
            {
                case EnumTipoDeForm.Cadastro:
                    cbTipo.SelectedIndex = 0;
                    break;

                case EnumTipoDeForm.Detalhamento:
                    if (cbTipo.SelectedIndex == ((int)EnumTipoDeInteracao.BASE_DE_TROCA - 1))
                    {
                        txtLineQuantidadeAux.Visible = true;
                        txtQuantidadeAux.Visible = true;
                        lblQuantidadeAux.Visible = true;
                    }
                    break;
            }

            InicializeInconsistencias();
        }
        
        public void CarregueControlesComObjeto(Interacao objeto)
        {
            cbTipo.SelectedIndex = (int)objeto.TipoDeInteracao - 1;
            txtObservacoes.Text = objeto.Observacao ?? string.Empty;
            txtQuantidade.Text = objeto.QuantidadeInterada.ToString();
            txtQuantidadeAux.Text = (objeto.QuantidadeAuxiliar ?? new int?()).ToString();
            GStxtValor.Valor = objeto.ValorInteracao;
            txtOrigem.Text = objeto.Origem ?? string.Empty;
            txtDestino.Text = objeto.Destino ?? string.Empty;
            cbProduto.Text = objeto.Produto.Nome.Trim();
            chkAtualizar.Checked = objeto.AtualizarValorDoProdutoNoCatalogo;
            txtNumeroDaNotaFiscal.Text = objeto.NumeroDaNota;

            dateData.Value = objeto.HorarioProgramado;
            dateHorario.Value = objeto.HorarioProgramado;

            if (objeto.InformaNumeroDeSerie)
            {
                chkInformarNumeroDeSerie.Checked = true;
                foreach (var numero in objeto.NumerosDeSerie)
                {
                    if (numero == objeto.NumerosDeSerie.FirstOrDefault())
                    {
                        GSMultiTextBox.Texto = numero;
                    }
                    else
                    {
                        flpNumerosDeSerie.Controls.Add(
                            new GSMultiTextBox()
                            {
                                Texto = numero
                            });
                    }
                }
            }
            else
            {
                chkInformarNumeroDeSerie.Checked = false;
            }
        }

        public Interacao CarregueObjetoComControles()
        {
            var interacao = new Interacao();
            interacao.Observacao = txtObservacoes.Text.Trim();
            interacao.ValorInteracao = GStxtValor.Valor;
            interacao.AtualizarValorDoProdutoNoCatalogo = chkAtualizar.Checked;
            interacao.TipoDeInteracao = (EnumTipoDeInteracao)cbTipo.SelectedIndex + 1;
            interacao.QuantidadeInterada = !string.IsNullOrEmpty(txtQuantidade.Text.Trim())
                                         ? int.Parse(txtQuantidade.Text.Trim())
                                         : 0;
            interacao.QuantidadeAuxiliar = !string.IsNullOrEmpty(txtQuantidadeAux.Text.Trim())
                                         ? new int?(int.Parse(txtQuantidadeAux.Text.Trim()))
                                         : new int?();
            interacao.Origem = txtOrigem.Text.Trim();
            interacao.Destino = txtDestino.Text.Trim();
            interacao.NumeroDaNota = txtNumeroDaNotaFiscal.Text.Trim();
            interacao.HorarioProgramado = GSUtilitarios.ObtenhaDateTimeCompletoDePickers(dateData, dateHorario);

            var listaDeProdutos = new List<Produto>();
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                listaDeProdutos = servicoDeProduto.ConsulteTodos().ToList();
            }

            interacao.Produto = listaDeProdutos.Find(x => x.Nome.Trim() == cbProduto.Text.Trim());
            
            if (chkInformarNumeroDeSerie.Checked)
            {
                interacao.InformaNumeroDeSerie = true;

                //Carregando números de série
                foreach (var multiTextBox in flpNumerosDeSerie.Controls)
                {
                    var valor = (multiTextBox as GSMultiTextBox).Texto;

                    if (!string.IsNullOrEmpty(valor))
                    {
                        interacao.NumerosDeSerie.Add(valor);
                    }
                }
            }
            else
            {
                interacao.InformaNumeroDeSerie = false;
            }

            return interacao;
        }

        protected void InicializeInconsistencias()
        {
            //Despintar os controles
            //foreach (Control controle in (this as Form).Controls)
            //{
            //    controle.ForeColor = Color.Silver;
            //}

            if (_listaDeInconsistencias == null)
            {
                _listaDeInconsistencias = new List<Inconsistencia>();
            }

            if (_listaDeInconsistencias.Count == 0)
            {
                return;
            }

            if (_listaDeInconsistencias.Count > 0)
            {
                foreach (var inconsistencia in _listaDeInconsistencias)
                {
                    //FlowLayoutPanel.Add(
                    //    new Label()
                    //    {
                    //        Text = string.Format("{0}, ", inconsistencia.Mensagem)
                    //    });

                    MessageBox.Show(inconsistencia.Mensagem);

                    if (inconsistencia.NomeDaPropriedadeValidada == "ValorInteracao")
                    {
                        //GStxtValor.ListaDeInconsistencias = new List<Inconsistencia> { inconsistencia };
                    }
                }
}
        }

        // --------------------------------------------------------------------------------------------------------------------------------

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantidade.Text.All(char.IsDigit))
            {
                return;
            }
            else
            {
                txtQuantidade.Text = txtQuantidade.Text.Trim().Remove(txtQuantidade.Text.Length - 1);
            }
        }

        private void cbProduto_DropDown(object sender, EventArgs e)
        {
            //var listaDeProdutos = new List<Produto>();

            //using (var servicoDeProduto = new ServicoDeProduto())
            //{
            //    listaDeProdutos = servicoDeProduto.ConsulteTodosOsProdutos();
            //}

            //var pesquisa = cbProduto.Text.Trim();

            //if (pesquisa == string.Empty)
            //{
            //    PreenchaComboBoxPesquisaComProdutos(listaDeProdutos);
            //}
            //else
            //{
            //    var listaFiltrada = new List<Produto>();
            //    listaFiltrada = listaDeProdutos.FindAll(x => x.Nome.ToUpper()
            //                                                       .Contains(pesquisa.ToUpper()));

            //    PreenchaComboBoxPesquisaComProdutos(listaFiltrada);
            //}
        }

        private void PreenchaComboBoxPesquisaComProdutos(List<Produto> produtos)
        {
            cbProduto.Items.Clear();

            foreach (var produto in produtos)
            {
                cbProduto.Items.Add(produto.Nome);
            }
        }

        private void btnEditarSalvar_Click(object sender, EventArgs e)
        {
            switch (_switchBotaoEditarSalvar)
            {
                case EnumBotoesForm.Editar:
                    HabiliteControles();
                    InicializeBotoes(EnumTipoDeForm.Edicao, ref btnEditarSalvar, ref btnCancelarExcluir, ref _switchBotaoEditarSalvar, ref _switchBotaoCancelarExcluir);
                    TipoDeForm = EnumTipoDeForm.Edicao;
                    break;

                case EnumBotoesForm.Salvar:
                    var interacao = CarregueObjetoComControles();
                    
                    // Valida entradas sem valores
                    // Ver pra colocar no validador
                    if (((EnumTipoDeInteracao)cbTipo.SelectedIndex + 1) == EnumTipoDeInteracao.ENTRADA &&
                        GStxtValor.Valor == 0)
                    {
                        var resultado = MessageBox.Show(Mensagens.TEM_CERTEZA_QUE_QUER_DAR_ENTRADA_SEM_VALOR, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultado == DialogResult.Yes)
                        {
                           //Não faz nada
                        }
                        else if (resultado == DialogResult.No)
                        {
                           GStxtValor.Focus();
                           return;
                        }
                    }

                    interacao.Horario = DateTime.Now;
                    //txtHorario.Text = horario.ToString(Cultura);

                    using (var servicoDeInteracao = new ServicoDeInteracao())
                    {
                        _listaDeInconsistencias = servicoDeInteracao.Salve(interacao, TipoDeForm).ToList();
                    }

                    if (_listaDeInconsistencias.Count == 0)
                    {
                        MessageBox.Show(Mensagens.X_FOI_CADASTRADO_COM_SUCESSO("Entrada/Saída"));
                        InicializeBotoes(EnumTipoDeForm.Detalhamento, ref btnEditarSalvar, ref btnCancelarExcluir, ref _switchBotaoEditarSalvar, ref _switchBotaoCancelarExcluir);
                        TipoDeForm = EnumTipoDeForm.Edicao;
                        DesabiliteControles();
                        return;
                    }

                    InicializeInconsistencias();
                    break;
            }
        }

        private void btnCancelarExcluir_Click(object sender, EventArgs e)
        {
            switch (_switchBotaoCancelarExcluir)
            {
                case EnumBotoesForm.Cancelar:
                    InicializeBotoes(EnumTipoDeForm.Detalhamento, ref btnEditarSalvar, ref btnCancelarExcluir, ref _switchBotaoEditarSalvar, ref _switchBotaoCancelarExcluir);
                    TipoDeForm = EnumTipoDeForm.Detalhamento;

                    Interacao interacao;
                    using (var servicoDeInteracao = new ServicoDeInteracao())
                    {
                        interacao = servicoDeInteracao.Consulte(_codigoInteracao);
                    }

                    CarregueControlesComObjeto(interacao);
                    DesabiliteControles();
                    break;

                case EnumBotoesForm.Excluir:
                    var resultado = MessageBox.Show($"Tem certeza que deseja excluir essa interação?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        using (var servicoDeInteracao = new ServicoDeInteracao())
                        {
                            var inconsistencias = servicoDeInteracao.Exclua(_codigoInteracao);

                            if (inconsistencias.Count > 0)
                            {
                                foreach (var inconsitencia in inconsistencias)
                                {
                                    MessageBox.Show(inconsitencia.Mensagem);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Interação excluída com sucesso!");
                                this.Close();
                            }
                        }
                    }
                    break;
            }
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TipoDeForm != EnumTipoDeForm.Detalhamento)
            {
                switch (cbTipo.Text)
                {
                    case "Saída":
                        lblQuantidadeEstoque.Text = "Quantidade";

                        lblValor.Enabled = false;
                        GStxtValor.Enabled = false;
                        chkAtualizar.Enabled = false;

                        lblQuantidadeAux.Visible = false;
                        txtLineQuantidadeAux.Visible = false;
                        txtQuantidadeAux.Visible = false;

                        // Tem que ser feito pra evitar inconsistencias
                        chkAtualizar.Checked = false;
                        GStxtValor.Valor = 0;
                        break;

                    case "Entrada":
                        lblQuantidadeEstoque.Text = "Quantidade";

                        lblValor.Enabled = true;
                        GStxtValor.Enabled = true;
                        chkAtualizar.Enabled = true;

                        lblQuantidadeAux.Visible = false;
                        txtLineQuantidadeAux.Visible = false;
                        txtQuantidadeAux.Visible = false;

                        chkAtualizar.Checked = true;
                        AtualizeValorComODoProduto();
                        break;

                    case "Base de troca":
                        lblValor.Enabled = false;
                        GStxtValor.Enabled = false;
                        chkAtualizar.Enabled = false;

                        lblQuantidadeEstoque.Text = "Qtd. Entrada";

                        lblQuantidadeAux.Visible = true;
                        txtLineQuantidadeAux.Visible = true;
                        txtQuantidadeAux.Visible = true;

                        // Tem que ser feito pra evitar inconsistencias
                        chkAtualizar.Checked = false;
                        GStxtValor.Valor = 0;
                        break;
                }
            }
        }

        private void AtualizeValorComODoProduto()
        {
            var listaDeProdutos = new List<Produto>();
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                listaDeProdutos = servicoDeProduto.ConsulteTodos().ToList();
            }

            var produto = listaDeProdutos.Find(x => x.Nome.Trim() == cbProduto.Text);
            if (produto == null)
            {
                return;
            }
                
            decimal valorASerAtribuido = 0;
            switch ((EnumTipoDeInteracao)cbTipo.SelectedIndex + 1)
            {
                case EnumTipoDeInteracao.ENTRADA:
                    valorASerAtribuido = produto.PrecoDeCompra;
                    break;

                case EnumTipoDeInteracao.SAIDA:
                    valorASerAtribuido = produto.PrecoDeVenda;
                    break;
            }

            GStxtValor.Valor = valorASerAtribuido;
        }

        private void btnAdicionarNumeroDeSerie_Click(object sender, EventArgs e)
        {
            flpNumerosDeSerie.Controls.Add(
                new TextBox()
                {
                    AccessibleRole = AccessibleRole.Default,
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.Silver,
                    ForeColor = Color.Black,
                    Visible = true,
                    Enabled = true,
                    Font = new Font("Century Gothic", 14.25f),
                    Size = new Size(462, 24),
                });
        }

        private void txtOrigem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLineOrigem_Click(object sender, EventArgs e)
        {

        }

        private void cbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizeValorComODoProduto();
        }

        private void chkInformarNumeroDeSerie_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInformarNumeroDeSerie.Checked)
            {
                label1.Enabled = true;
                flpNumerosDeSerie.Enabled = true;
            }
            else
            {
                label1.Enabled = false;
                flpNumerosDeSerie.Enabled = false;
            }
        }

        private void txtQuantidadeAux_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantidadeAux.Text.All(char.IsDigit))
            {
                return;
            }
            else
            {
                txtQuantidadeAux.Text = txtQuantidadeAux.Text.Trim().Remove(txtQuantidadeAux.Text.Length - 1);
            }
        }

        private void txtNumeroDaNotaFiscal_TextChanged(object sender, EventArgs e)
        {
            if (txtNumeroDaNotaFiscal.Text.All(char.IsDigit))
            {
                return;
            }
            else
            {
                txtNumeroDaNotaFiscal.Text = txtNumeroDaNotaFiscal.Text.Trim().Remove(txtNumeroDaNotaFiscal.Text.Length - 1);
            }
        }

        public string IdInstancia { get; set; }

        public void ApagueInstancia()
        {
            //GerenciadorDeViews.Exclua<frmInteracao>(IdInstancia);
        }
    }
}
