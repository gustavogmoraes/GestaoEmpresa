using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using System;
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
    public partial class frmInteracao : Form
    {
        private int _codigoInteracao { get; set; }

        private decimal _valor { get; set; }

        private EnumBotoesForm _switchBotaoEditarSalvar;

        private EnumBotoesForm _switchBotaoCancelarExcluir;

        private EnumTipoDeForm _tipoDoForm;

        public List<Control> ListaDeControles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public CultureInfo Cultura = new CultureInfo("pt-BR");

        public frmInteracao()
        {
            InitializeComponent();

            InicializeBotoes(EnumTipoDeForm.Cadastro);
            _tipoDoForm = EnumTipoDeForm.Cadastro;
            cbTipo.Text = "Ativo";
            txtHorario.Enabled = false;
            txtLineHorario.Enabled = false;
        }

        public frmInteracao(Interacao interacao)
        {
            InitializeComponent();

            InicializeBotoes(EnumTipoDeForm.Detalhamento);
            _tipoDoForm = EnumTipoDeForm.Detalhamento;

            CarregueControlesComObjeto(interacao);
            DesabiliteControles();
            _codigoInteracao = interacao.Codigo;
        }

        private void frmInteracao_Load(object sender, EventArgs e)
        {

        }

        #region Métodos Específicos

        #endregion

        #region Métodos de Formulário

        protected void CarregueControlesComObjeto(Interacao objeto)
        {
            txtDescricao.Text = objeto.Descricao ?? string.Empty;
            txtObservacoes.Text = objeto.Observacao ?? string.Empty;
            txtQuantidade.Text = objeto.QuantidadeInterada.ToString();
            txtValor.Text = objeto.ValorInteracao.ToString();
            cbTipo.SelectedItem = objeto.TipoInteracao.ToString();
            txtOrigem.Text = objeto.Origem ?? string.Empty;
            txtDestino.Text = objeto.Destino ?? string.Empty;
            cbProduto.Text = objeto.Produto.Nome.Trim();
        }

        protected Interacao CarregueObjetoComControles()
        {
            var interacao = new Interacao();

            interacao.Descricao = txtDescricao.Text.Trim();
            interacao.Observacao = txtObservacoes.Text.Trim();
            interacao.ValorInteracao = !string.IsNullOrEmpty(txtValor.Text.Trim())
                                     ? decimal.Parse(txtValor.Text.Trim())
                                     : 0;
            interacao.TipoInteracao = (EnumTipoInteracao)cbTipo.SelectedIndex + 1;
            interacao.QuantidadeInterada = !string.IsNullOrEmpty(txtQuantidade.Text.Trim())
                                          ? int.Parse(txtQuantidade.Text.Trim())
                                          : 0;
            interacao.Origem = txtDescricao.Text.Trim();
            interacao.Destino = txtDescricao.Text.Trim();

            var listaDeProdutos = new List<Produto>();
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                listaDeProdutos = servicoDeProduto.ConsulteTodosOsProdutos();
            }

            interacao.Produto = listaDeProdutos.Find(x => x.Nome.Trim() == cbProduto.Text.Trim());

            return interacao;
        }

        protected void HabiliteControles()
        {
            txtDescricao.Enabled = true;
            txtLineDescricao.Enabled = true;

            txtObservacoes.Enabled = true;
            txtLineObservacoes.Enabled = true;

            txtQuantidade.Enabled = true;
            txtLineQuantidadeEstoque.Enabled = true;

            cbTipo.Enabled = true;
            txtLineTipo.Enabled = true;

            txtValor.Enabled = true;
            txtLinePrecoCompra.Enabled = true;
            lblCifraoPrecoCompra.Enabled = true;

            txtOrigem.Enabled = true;
            txtDestino.Enabled = true;

            txtDestino.Enabled = true;
            txtLineDestino.Enabled = true;

            txtHorario.Enabled = true;
            txtLineHorario.Enabled = true;
        }

        protected void DesabiliteControles()
        {
            txtDescricao.Enabled = false;
            txtLineDescricao.Enabled = false;

            txtObservacoes.Enabled = false;
            txtLineObservacoes.Enabled = false;

            txtQuantidade.Enabled = false;
            txtLineQuantidadeEstoque.Enabled = false;

            cbTipo.Enabled = false;
            txtLineTipo.Enabled = false;

            txtValor.Enabled = false;
            txtLinePrecoCompra.Enabled = false;
            lblCifraoPrecoCompra.Enabled = false;

            txtOrigem.Enabled = false;
            txtDestino.Enabled = false;

            txtDestino.Enabled = false;
            txtLineDestino.Enabled = false;

            txtHorario.Enabled = false;
            txtLineHorario.Enabled = false;
        }

        private void InicializeBotoes(EnumTipoDeForm tipoDeForm)
        {
            switch (tipoDeForm)
            {
                case EnumTipoDeForm.Cadastro:
                    btnCancelarExcluir.Enabled = false;
                    btnCancelarExcluir.Visible = false;

                    btnEditarSalvar.Image = Properties.Resources.floppy_icon;
                    _switchBotaoEditarSalvar = EnumBotoesForm.Salvar;
                    break;

                case EnumTipoDeForm.Edicao:
                    btnCancelarExcluir.Enabled = true;
                    btnCancelarExcluir.Visible = true;
                    btnCancelarExcluir.Image = Properties.Resources.cancel_icon;
                    _switchBotaoCancelarExcluir = EnumBotoesForm.Cancelar;

                    btnEditarSalvar.Image = Properties.Resources.floppy_icon;
                    _switchBotaoEditarSalvar = EnumBotoesForm.Salvar;
                    break;

                case EnumTipoDeForm.Detalhamento:
                    btnCancelarExcluir.Enabled = true;
                    btnCancelarExcluir.Visible = true;
                    btnCancelarExcluir.Image = Properties.Resources.delete;
                    _switchBotaoCancelarExcluir = EnumBotoesForm.Excluir;

                    btnEditarSalvar.Image = Properties.Resources.edit_512;
                    _switchBotaoEditarSalvar = EnumBotoesForm.Editar;
                    break;
            }

            btnEditarSalvar.Refresh();
            btnCancelarExcluir.Refresh();
        }

        #endregion

        private enum EnumBotoesForm
        {
            Editar,
            Salvar,

            Cancelar,
            Excluir
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtValor.Text))
            {
                txtValor.Text = 0.ToString();
            }

            _valor = decimal.Parse(txtValor.Text.Replace(',', '.'));
            txtValor.Text = txtValor.Text.Replace(',', '.');
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            if (txtValor.Text.All(x => GSUtilitarios.EhDigitoOuPonto(x)))
            {
                return;
            }
            else
            {
                txtValor.Text = txtValor.Text.Trim().Remove(txtValor.Text.Length - 1);
            }
        }

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
            var listaDeProdutos = new List<Produto>();

            using (var servicoDeProduto = new ServicoDeProduto())
            {
                listaDeProdutos = servicoDeProduto.ConsulteTodosOsProdutos();
            }

            var pesquisa = cbProduto.Text.Trim();

            if (pesquisa == string.Empty)
            {
                PreenchaComboBoxPesquisaComProdutos(listaDeProdutos);
            }
            else
            {
                var listaFiltrada = new List<Produto>();
                listaFiltrada = listaDeProdutos.FindAll(x => x.Nome.ToUpper()
                                                                   .Contains(pesquisa.ToUpper()));

                PreenchaComboBoxPesquisaComProdutos(listaFiltrada);
            }
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
                    InicializeBotoes(EnumTipoDeForm.Edicao);
                    _tipoDoForm = EnumTipoDeForm.Edicao;
                    break;

                case EnumBotoesForm.Salvar:
                    var interacao = CarregueObjetoComControles();

                    if (cbTipo.SelectedIndex == -1)
                    {
                        MessageBox.Show("Um tipo deve ser selecionado");
                        return;
                    }

                    var horario = DateTime.Now;
                    txtHorario.Text = horario.ToString(Cultura);

                    var listaDeInconsistencias = new List<Inconsistencia>();

                    using (var servicoDeInteracao = new ServicoDeInteracao())
                        listaDeInconsistencias = servicoDeInteracao.Salve(interacao, _tipoDoForm, horario);

                    if (listaDeInconsistencias.Count == 0)
                    {
                        MessageBox.Show(Mensagens.INTERACAO_CADASTRADA_COM_SUCESSO);
                        InicializeBotoes(EnumTipoDeForm.Detalhamento);
                        _tipoDoForm = EnumTipoDeForm.Edicao;
                        DesabiliteControles();
                        return;
                    }

                    foreach (var inconsistencia in listaDeInconsistencias)
                    {
                        MessageBox.Show(inconsistencia.Mensagem);
                        //Invoke metodo para destacar o form, ou então fazer um destaque automático
                    }
                    break;
            }
        }

        private void btnCancelarExcluir_Click(object sender, EventArgs e)
        {
            switch (_switchBotaoCancelarExcluir)
            {
                case EnumBotoesForm.Cancelar:
                    InicializeBotoes(EnumTipoDeForm.Detalhamento);
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
    }
}
