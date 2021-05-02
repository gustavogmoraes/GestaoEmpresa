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
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.UI.Base;
using MoreLinq;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using MetroFramework.Forms;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class frmInteracao : Form, IView
    {
        private int _codigoInteracao { get; set; }

        private decimal _valor { get; set; }

        public frmInteracao()
        {
            InitializeComponent();
            InicializeAssistentesDigitacao();

            InicializeBotoes(EnumTipoDeForm.Cadastro, ref btnEditarSalvar, ref btnCancelarExcluir, ref _switchBotaoEditarSalvar, ref _switchBotaoCancelarExcluir);
            TipoDeForm = EnumTipoDeForm.Cadastro;
            cbTipo.Text = "Ativo";
            
            txtLineHorario.Enabled = true;
            

            dateHorario.Value = DateTime.Now;
        }

        public frmInteracao(Interacao interacao)
        {
            InitializeComponent();
            InicializeAssistentesDigitacao();

            TipoDeForm = EnumTipoDeForm.Detalhamento;

            IsRendering = true;

            CarregueControlesComObjeto(interacao);
            DesabiliteControles();
            InicializeBotoes(EnumTipoDeForm.Detalhamento, ref btnEditarSalvar, ref btnCancelarExcluir, ref _switchBotaoEditarSalvar, ref _switchBotaoCancelarExcluir);
            _codigoInteracao = interacao.Codigo;

            IsRendering = false;
        }

        private GsTypingAssistant CbProdutoAssistente { get; set; }

        private void InicializeAssistentesDigitacao()
        {
            IsRendering = true;
            CbProdutoAssistente = new GsTypingAssistant();
            CbProdutoAssistente.Idled += CbProdutoAssistant_Idled;
            IsRendering = false;
        }

        #region FormPadrao

        public void SetBorderStyle()
        {
            //BorderStyle = MetroFormBorderStyle.FixedSingle;
        }

        public IPresenter Presenter { get; set; }
        public void MinimizeFormCall(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void CloseFormCall(object sender, EventArgs e)
        {
            GerenciadorDeViews.Exclua(typeof(frmInteracao), InstanceId);
        }

        public void MaximizeFormCall(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                return;
            }

            WindowState = FormWindowState.Maximized;
        }

        protected CultureInfo Cultura = new CultureInfo("pt-BR");

        protected EnumBotoesForm _switchBotaoEditarSalvar;

        protected EnumBotoesForm _switchBotaoCancelarExcluir;

        public EnumTipoDeForm TipoDeForm { get; set; }

        protected List<Inconsistencia> _listaDeInconsistencias { get; set; }

        protected virtual void HabiliteControles()
        {
            Controls.OfType<Control>().ForEach(x => x.Enabled = true);

            var situacaoEhDiferenteDeDevolvidoParaSaida = cbTipo.SelectedItem.ToString() == "Saída" &&
                                                          (cbSituacao.SelectedItem == null ||
                                                           cbSituacao.SelectedItem?.ToString() != "Devolvido");

            if (!situacaoEhDiferenteDeDevolvidoParaSaida)
            {
                return;
            }

            DesabiliteControles();

            cbSituacao.Enabled = true;
            txtLineSituacao.Enabled = true;

            dtpDevolucao.Enabled = true;
            dtpTimeDevolucao.Enabled = true;

            txtObservacoes.Enabled = true;
            txtLineObservacoes.Enabled = true;
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

            GStxtValor.Enabled = false;
            txtNumeroDaNotaFiscal.Enabled = false;

            foreach(Control controle in flpNumerosDeSerie.Controls)
            {
                controle.Controls.Find("btnAdicionar", false)[0].Visible = false;
                controle.Controls.Find("txtTexto", false)[0].Enabled = false;
                controle.Controls.Find("txtLineTexto", false)[0].Enabled = false;
            }

            flpNumerosDeSerie.Enabled = true;

            btnCancelarExcluir.Enabled = true;

            var situacaoEhDiferenteDeDevolvidoParaSaida = cbTipo.SelectedItem.ToString() == "Saída" && 
                                                          (cbSituacao.SelectedItem == null || 
                                                           cbSituacao.SelectedItem?.ToString() != "Devolvido");
            btnEditarSalvar.Enabled = situacaoEhDiferenteDeDevolvidoParaSaida;
            btnEditarSalvar.Visible = situacaoEhDiferenteDeDevolvidoParaSaida;

            cbSituacao.Enabled = false;
            txtLineSituacao.Enabled = false;

            cbFinalidade.Enabled = false;
            txtLineFinalidade.Enabled = false;

            txtOrdemDeServico.Enabled = false;
            txtLineOS.Enabled = false;

            label12.Enabled = false;
            dtpDevolucao.Enabled = false;
            dtpTimeDevolucao.Enabled = false;
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

        private int? CodigoProdutoCarregado { get; set; }
        
        public void CarregueControlesComObjeto(Interacao objeto)
        {
            IdInteracao = objeto?.Id;
            _codigoInteracao = objeto.Codigo;
            CodigoProdutoCarregado = objeto?.Produto.Codigo;
            cbTipo.SelectedIndex = (int)objeto.TipoDeInteracao - 1;
            txtObservacoes.Text = objeto.Observacao ?? string.Empty;
            txtQuantidade.Text = objeto.QuantidadeInterada.ToString();
            txtQuantidadeAux.Text = (objeto.QuantidadeAuxiliar ?? new int?()).ToString();
            GStxtValor.Valor = objeto.ValorInteracao;
            txtOrigem.Text = objeto.Origem ?? string.Empty;
            txtDestino.Text = objeto.Destino ?? string.Empty;
            cbProduto.Text = objeto.Produto?.Nome.Trim();
            chkAtualizar.Checked = objeto.AtualizarValorDoProdutoNoCatalogo;
            txtNumeroDaNotaFiscal.Text = objeto.NumeroDaNota;
            txtTecnico.Text = objeto.Tecnico;
            cbFinalidade.SelectedItem = objeto.Finalidade;
            cbSituacao.SelectedItem = objeto.Situacao;
            if (objeto.Situacao == "Devolvido")
            {
                dtpDevolucao.Value = objeto.HorarioDevolucao.GetValueOrDefault();
                dtpDevolucao.Value = objeto.HorarioDevolucao.GetValueOrDefault();
            }

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
                        flpNumerosDeSerie.Controls.Add(new GSMultiTextBox
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

        private string IdInteracao { get; set; }

        public Interacao CarregueObjetoComControles()
        {
            var interacao = new Interacao
            {
                Codigo = _codigoInteracao,
                Id = IdInteracao,
                Observacao = txtObservacoes.Text.Trim(),
                ValorInteracao = GStxtValor.Valor.GetValueOrDefault(),
                AtualizarValorDoProdutoNoCatalogo = chkAtualizar.Checked,
                TipoDeInteracao = (EnumTipoDeInteracao)cbTipo.SelectedIndex + 1,
                QuantidadeInterada = !string.IsNullOrEmpty(txtQuantidade.Text.Trim())
                                   ? int.Parse(txtQuantidade.Text.Trim())
                                   : 0,
                QuantidadeAuxiliar = !string.IsNullOrEmpty(txtQuantidadeAux.Text.Trim())
                                   ? int.Parse(txtQuantidadeAux.Text.Trim())
                                   : new int?(),
                Origem = txtOrigem.Text.Trim(),
                Destino = txtDestino.Text.Trim(),
                NumeroDaNota = txtNumeroDaNotaFiscal.Text.Trim(),
                HorarioProgramado = dateData.MergeValue(dateHorario).RemoveMs(),
                Finalidade = cbFinalidade.SelectedItem?.ToString(),
                Situacao = cbSituacao.SelectedItem?.ToString(),
                HorarioDevolucao = cbSituacao.SelectedItem?.ToString() == "Devolvido"
                                 ? (DateTime?)dtpDevolucao.MergeValue(dtpTimeDevolucao)
                                 : null,
                Tecnico = txtTecnico.Text
            };

            using (var servicoDeProduto = new ServicoDeProduto())
            {
                int codigoProduto = CodigoProdutoCarregado.GetValueOrDefault();
                var horarioProgramado = dateData.MergeValue(dateHorario).RemoveMs();

                interacao.Produto = servicoDeProduto.Consulte(codigoProduto, horarioProgramado, false) ?? servicoDeProduto.Consulte(codigoProduto, false);
            }

            if (chkInformarNumeroDeSerie.Checked)
            {
                interacao.InformaNumeroDeSerie = true;

                //Carregando números de série
                foreach (var multiTextBox in flpNumerosDeSerie.Controls)
                {
                    var valor = (multiTextBox as GSMultiTextBox)?.Texto;
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
            if(IsRendering)
            {
                return;
            }

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

        private void PreenchaComboBoxPesquisaComProdutos(List<dynamic> produtos)
        {
            cbProduto.Items.Clear();
            cbProduto.DisplayMember = "Nome";

            foreach (var produto in produtos)
            {
                cbProduto.Items.Add(produto);
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
                        _codigoInteracao = interacao.Codigo;
                    }

                    if (_listaDeInconsistencias.Count == 0)
                    {
                        MessageBox.Show(Mensagens.X_FOI_CADASTRADO_COM_SUCESSO("Entrada/Saída"));
                        InicializeBotoes(EnumTipoDeForm.Detalhamento, ref btnEditarSalvar, ref btnCancelarExcluir, ref _switchBotaoEditarSalvar, ref _switchBotaoCancelarExcluir);
                        TipoDeForm = EnumTipoDeForm.Edicao;
                        DesabiliteControles();

                        var formEstoque = GerenciadorDeViews.ObtenhaIndependente<FrmEstoque>();
                        formEstoque.btnRefreshHist_Click(null, null);
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
                                Close();
                                var formEstoque = GerenciadorDeViews.ObtenhaIndependente<FrmEstoque>();
                                formEstoque.btnRefreshHist_Click(null, null);
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

                        lblValor.Enabled = true;
                        GStxtValor.Enabled = true;
                        chkAtualizar.Enabled = false;

                        lblQuantidadeAux.Visible = false;
                        txtLineQuantidadeAux.Visible = false;
                        txtQuantidadeAux.Visible = false;

                        // Tem que ser feito pra evitar inconsistencias
                        chkAtualizar.Checked = false;
                        chkAtualizar.Visible = false;

                        AtualizeValorComODoProduto();

                        break;

                    case "Entrada":
                        lblQuantidadeEstoque.Text = "Quantidade";

                        lblValor.Enabled = true;
                        GStxtValor.Enabled = true;
                        chkAtualizar.Enabled = true;

                        lblQuantidadeAux.Visible = false;
                        txtLineQuantidadeAux.Visible = false;
                        txtQuantidadeAux.Visible = false;

                        //chkAtualizar.Checked = true;
                        chkAtualizar.Visible = true;

                        AtualizeValorComODoProduto();
                        break;

                    case "Base de troca":
                        lblValor.Enabled = false;
                        GStxtValor.Enabled = false;
                        chkAtualizar.Enabled = false;
                        chkAtualizar.Visible = true;

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
            if(IsRendering)
            {
                return;
            }

            var listaDeProdutos = new List<Produto>();
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                if(cbProduto.SelectedItem == null)
                {
                    return;
                }

                int codigoProduto = Convert.ToInt32(((dynamic)cbProduto.SelectedItem).Codigo);
                CodigoProdutoCarregado = codigoProduto;

                var horarioProgramado = GSUtilitarios.ObtenhaDateTimeCompletoDePickers(dateData, dateHorario).RemoveMs();

                var produto = servicoDeProduto.Consulte(codigoProduto, horarioProgramado);
                if (produto == null)
                {
                    return;
                }

                decimal valorASerAtribuido = 0;
                switch ((EnumTipoDeInteracao)cbTipo.SelectedIndex + 1)
                {
                    case EnumTipoDeInteracao.ENTRADA:
                        valorASerAtribuido = produto.PrecoDeCompra.GetValueOrDefault();
                        break;

                    case EnumTipoDeInteracao.SAIDA:
                        valorASerAtribuido = produto.PrecoDeVenda.GetValueOrDefault();
                        break;
                }

                GStxtValor.Valor = valorASerAtribuido;
            }
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
            if(IsRendering)
            {
                return;
            }

            AtualizeValorComODoProduto();
        }

        private void chkInformarNumeroDeSerie_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInformarNumeroDeSerie.Checked)
            {
                label1.Enabled = true;
                flpNumerosDeSerie.Enabled = true;
                flpNumerosDeSerie.Controls.OfType<GSMultiTextBox>().First().txtTexto.Focus();
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

        public string InstanceId { get; set; }
        public bool IsRendering { get; set; }

        public void ApagueInstancia()
        {
            //GerenciadorDeViews.Exclua<frmInteracao>(IdInstancia);
        }

        private void cbProduto_TextChanged(object sender, EventArgs e)
        {
            if(IsRendering)
            {
                return;
            }

            // Significa que o input foi feito por usuario
            if(cbProduto.SelectedIndex < 0)
            {
                CbProdutoAssistente.TextChanged();
            }
        }

        void CbProdutoAssistant_Idled(object sender, EventArgs e)
        {
            if(IsRendering)
            {
                return;
            }

            Invoke(new MethodInvoker(() =>
            {
                cbProduto.AutoCompleteMode = AutoCompleteMode.None;
                var textoParaPesquisar = cbProduto.Text.Trim().ToLowerInvariant();
                if(string.IsNullOrEmpty(textoParaPesquisar))
                {
                    cbProduto.Items.Clear();
                    cbProduto.DisplayMember = "Nome";

                    var produtos = ConsulteProdutos(textoParaPesquisar);
                    if (produtos != null && produtos.Any())
                    {
                        cbProduto.Items.AddRange(produtos.Cast<object>().ToArray());
                    }

                    cbProduto.SelectionStart = cbProduto.Text.Length;

                    return;
                }

                cbProduto.Items.Clear();

                var produtosPes = ConsulteProdutos(textoParaPesquisar);
                if (produtosPes.Any())
                {
                    cbProduto.Items.AddRange(produtosPes.Cast<object>().ToArray());
                    cbProduto.DisplayMember = "Nome";
                    cbProduto.Focus();
                    cbProduto.DroppedDown = true;
                    IsRendering = true;
                    cbProduto.SelectedIndex = -1;
                    cbProduto.Text = textoParaPesquisar;
                    IsRendering = false;
                    cbProduto.Cursor = Cursors.Default;
                }
                cbProduto.SelectionStart = cbProduto.Text.Length;
            }));
        }

        private static List<Produto> ConsulteProdutos(string textoParaPesquisar)
        {
            var servicoDeProduto = new ServicoDeProduto();

            var produtos = servicoDeProduto.ConsulteTodosParaAterrissagem(out var quantidades, resultSelector: SeletorCombo, searchTerm: textoParaPesquisar)
                .OrderBy(x => x.Nome)
                .ToList();
            return produtos;
        }

        private static Expression<Func<Produto, object>> SeletorCombo => x => new Produto
        {
            Codigo = x.Codigo,
            Nome = x.Nome
        };

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cbSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbSituacao.SelectedItem)
            {
                case "Devolvido":
                    panelDevolucao.Visible = true;
                    break;
                default:
                    panelDevolucao.Visible = false;
                    break;
            }
        }
    }
}
