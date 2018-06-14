using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
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

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class frmInteracao : Form, IFormPadrao<Interacao>
    {
        private int _codigoInteracao { get; set; }

        private decimal _valor { get; set; }

        public List<CampoDeTela> ListaDeCampos
        {
            get
            {
                return new List<CampoDeTela>()
                {
                    new CampoDeTela("QuantidadeInterada", txtQuantidade, txtLineQuantidadeEstoque),
                    new CampoDeTela("Origem", txtOrigem, txtLineOrigem),
                    new CampoDeTela("Destino", txtDestino, txtLineDestino)
                };
                
            }
        }

        public frmInteracao()
        {
            InitializeComponent();

            InicializeBotoes(EnumTipoDeForm.Cadastro, ref btnEditarSalvar, ref btnCancelarExcluir, ref _switchBotaoEditarSalvar, ref _switchBotaoCancelarExcluir);
            _tipoDoForm = EnumTipoDeForm.Cadastro;
            cbTipo.Text = "Ativo";
            txtHorario.Enabled = false;
            txtLineHorario.Enabled = false;
        }

        public frmInteracao(Interacao interacao)
        {
            InitializeComponent();

            InicializeBotoes(EnumTipoDeForm.Detalhamento, ref btnEditarSalvar, ref btnCancelarExcluir, ref _switchBotaoEditarSalvar, ref _switchBotaoCancelarExcluir);
            _tipoDoForm = EnumTipoDeForm.Detalhamento;

            CarregueControlesComObjeto(interacao);
            DesabiliteControles();
            _codigoInteracao = interacao.Codigo;
        }

        #region FormPadrao

        protected CultureInfo Cultura = new CultureInfo("pt-BR");

        protected EnumBotoesForm _switchBotaoEditarSalvar;

        protected EnumBotoesForm _switchBotaoCancelarExcluir;

        protected EnumTipoDeForm _tipoDoForm;

        protected List<Inconsistencia> _listaDeInconsistencias { get; set; }

        protected virtual void HabiliteControles()
        {
            foreach (Control controle in (this as Form).Controls)
            {
                controle.Enabled = true;
            }
        }

        protected virtual void DesabiliteControles()
        {
            foreach (Control controle in (this as Form).Controls)
            {
                controle.Enabled = false;
            }
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
                listaDeProdutos = servicoDeProduto.ConsulteTodosOsProdutos();
            }

            PreenchaComboBoxPesquisaComProdutos(listaDeProdutos);

            InicializeInconsistencias();
        }

        public void RealizeValidacoesDeTela()
        {
            if (cbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Um tipo deve ser selecionado");
                return;
            }

            if (cbProduto.SelectedIndex == -1)
            {
                MessageBox.Show("Um produto deve ser selecionado");
                return;
            }
        }

        public void CarregueControlesComObjeto(Interacao objeto)
        {
            txtDescricao.Text = objeto.Descricao ?? string.Empty;
            txtObservacoes.Text = objeto.Observacao ?? string.Empty;
            txtQuantidade.Text = objeto.QuantidadeInterada.ToString();
            GStxtValor.Valor = objeto.ValorInteracao;
            cbTipo.SelectedItem = objeto.TipoInteracao.ToString();
            txtOrigem.Text = objeto.Origem ?? string.Empty;
            txtDestino.Text = objeto.Destino ?? string.Empty;
            cbProduto.Text = objeto.Produto.Nome.Trim();
            chkAtualizar.Checked = objeto.AtualizarValorDoProdutoNoCatalogo;
        }

        public Interacao CarregueObjetoComControles()
        {
            var interacao = new Interacao();
            
            interacao.Descricao = txtDescricao.Text.Trim();
            interacao.Observacao = txtObservacoes.Text.Trim();
            interacao.ValorInteracao = GStxtValor.Valor;
            interacao.AtualizarValorDoProdutoNoCatalogo = chkAtualizar.Checked;
            interacao.TipoInteracao = (EnumTipoInteracao)cbTipo.SelectedIndex + 1;
            interacao.QuantidadeInterada = !string.IsNullOrEmpty(txtQuantidade.Text.Trim())
                                         ? int.Parse(txtQuantidade.Text.Trim())
                                         : 0;
            interacao.Origem = txtOrigem.Text.Trim();
            interacao.Destino = txtDestino.Text.Trim();

            var listaDeProdutos = new List<Produto>();
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                listaDeProdutos = servicoDeProduto.ConsulteTodosOsProdutos();
            }

            interacao.Produto = listaDeProdutos.Find(x => x.Nome.Trim() == cbProduto.Text.Trim());

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

                    if (inconsistencia.NomeDaPropriedadeValidada == "ValorInteracao")
                    {
                        GStxtValor.ListaDeInconsistencias = new List<Inconsistencia> { inconsistencia };
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
                    _tipoDoForm = EnumTipoDeForm.Edicao;
                    break;

                case EnumBotoesForm.Salvar:
                    var interacao = CarregueObjetoComControles();

                    RealizeValidacoesDeTela();

                    var horario = DateTime.Now;
                    txtHorario.Text = horario.ToString(Cultura);

                    using (var servicoDeInteracao = new ServicoDeInteracao())
                    {
                        _listaDeInconsistencias = servicoDeInteracao.Salve(interacao, _tipoDoForm, horario);
                    }

                    if (_listaDeInconsistencias.Count == 0)
                    {
                        MessageBox.Show(Mensagens.X_FOI_CADASTRADO_COM_SUCESSO("Entrada/Saída"));
                        InicializeBotoes(EnumTipoDeForm.Detalhamento, ref btnEditarSalvar, ref btnCancelarExcluir, ref _switchBotaoEditarSalvar, ref _switchBotaoCancelarExcluir);
                        _tipoDoForm = EnumTipoDeForm.Edicao;
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
                    _tipoDoForm = EnumTipoDeForm.Detalhamento;

                    Interacao interacao;
                    using (var servicoDeInteracao = new ServicoDeInteracao())
                    {
                        interacao = servicoDeInteracao.Consulte(_codigoInteracao);
                    }

                    CarregueControlesComObjeto(interacao);
                    DesabiliteControles();
                    break;

                case EnumBotoesForm.Excluir:
                    //Prompt de certeza
                    using (var servicoDeInteracao = new ServicoDeInteracao())
                    {
                        //servicoDeInteracao.Exclua();
                        //Retorno dessa função deve validar se pode excluir
                        //Se tudo der certo, mensagem de sucesso e fecha
                        this.Close();
                    }
                    break;
            }
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipo.Text == "Saída")
            {
                lblValor.Enabled = false;
                GStxtValor.Enabled = false;
                chkAtualizar.Enabled = false;
            }
            else
            {
                lblValor.Enabled = true;
                GStxtValor.Enabled = true;
                chkAtualizar.Enabled = true;
            }
        }
    }
}
