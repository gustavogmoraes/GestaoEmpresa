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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class frmProduto : Form
    {
        private decimal _precoDeCompra;

        private decimal _precoDeVenda;

        private EnumBotoesForm _switchBotaoEditarSalvar;

        private EnumBotoesForm _switchBotaoCancelarExcluir;

        public List<Control> ListaDeControles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public CultureInfo Cultura = new CultureInfo("pt-BR");

        public frmProduto()
        {
            InitializeComponent();

            InicializeBotoes(EnumTipoDeForm.Cadastro);
        }

        public frmProduto(Produto produto)
        {
            InitializeComponent();

            InicializeBotoes(EnumTipoDeForm.Detalhamento);

            CarregueControlesComObjeto(produto);
            CarregueComboDeVigencias(produto.Codigo);
            SelecioneUltimaVigencia();
            DesabiliteControles();
        }

        private void frmProduto_Load(object sender, EventArgs e)
        {

        }

        private void SelecioneUltimaVigencia()
        {
            cbVigencia.SelectedIndex = 0;
        }

        #region Métodos Específicos
       
        private void txtPrecoDeCompra_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrecoDeCompra.Text))
            {
                txtPrecoDeCompra.Text = 0.ToString();
            }

            _precoDeCompra = decimal.Parse(txtPrecoDeCompra.Text.Replace(',', '.'));
        }

        private void txtPrecoDeVenda_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrecoDeVenda.Text))
            {
                txtPrecoDeVenda.Text = 0.ToString();
                return;
            }

            _precoDeVenda = decimal.Parse(txtPrecoDeVenda.Text);

            if (decimal.Parse(txtPrecoDeVenda.Text.Trim()) > 0)
                AjustePrecosNaTela(sender as Control);
        }

        private void txtPorcentagemDeLucro_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPorcentagemDeLucro.Text))
            {
                txtPorcentagemDeLucro.Text = 0.ToString();
                return;
            }

            if (decimal.Parse(txtPorcentagemDeLucro.Text.Trim()) > 0)
                AjustePrecosNaTela(sender as Control);
        }

        private void AjustePrecosNaTela(Control controleGatilho)
        {
            if (controleGatilho == txtPrecoDeVenda)
            {
                var precoDeCompra = decimal.Parse(txtPrecoDeCompra.Text.Trim());
                var precoDeVenda = decimal.Parse(txtPrecoDeVenda.Text.Trim());

                var porcentagemDeLucro = (precoDeVenda / precoDeCompra) - 1;

                if (porcentagemDeLucro <= 0)
                {
                    txtPorcentagemDeLucro.Text = 0.ToString();
                    return;
                }

                txtPorcentagemDeLucro.Text = Math.Round(porcentagemDeLucro * 100, 2).ToString();
            }

            if (controleGatilho == txtPorcentagemDeLucro)
            {
                var precoDeCompra = decimal.Parse(txtPrecoDeCompra.Text.Trim());
                var porcentagemDeLucro = decimal.Parse(txtPorcentagemDeLucro.Text.Trim()) / 100;

                var precoDeVenda = precoDeCompra * (1 + porcentagemDeLucro);

                if (precoDeVenda <= 0)
                {
                    txtPrecoDeVenda.Text = 0.ToString();
                    return;
                }

                txtPrecoDeVenda.Text = GSUtilitarios.FormateDecimalParaMoeda(precoDeVenda);
            }
        }

        #endregion


        #region Métodos de Formulário

        protected void PreenchaCodigoComProximoDisponivel()
        {
            int proximoCodigo;
            using (var servicoDeProduto = new ServicoDeProduto())
                proximoCodigo = servicoDeProduto.ObtenhaProximoCodigoDisponivel();

            if (proximoCodigo == 0)
            {
                MessageBox.Show(Mensagens.ERRO);
                return;
            }

            txtCodigo.Text = proximoCodigo.ToString();
        }

        protected void cbVigencia_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbVigencia.SelectedIndex == -1)
            {
                return;
            }
            
            var produto = new Produto();

            using (var servicoDeProduto = new ServicoDeProduto())
            {
                produto = servicoDeProduto.Consulte(int.Parse(txtCodigo.Text.Trim()),
                                                    DateTime.Parse(cbVigencia.SelectedItem.ToString(), Cultura));
            }

            this.CarregueControlesComObjeto(produto);
        }

        protected void CarregueComboDeVigencias(int codigo)
        {
            cbVigencia.Items.Clear();

            var listaDeVigencias = new List<DateTime>();
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                listaDeVigencias = servicoDeProduto.ConsulteTodasAsVigenciasDeUmProduto(codigo);
            }

            foreach (var vigencia in listaDeVigencias)
            {
                cbVigencia.Items.Add(vigencia.ToString(Cultura));
            }
        }

        protected void CarregueControlesComObjeto(Produto objeto)
        {
            txtCodigo.Text = objeto.Codigo.ToString();
            txtCodigoFabricante.Text = objeto.CodigoDoFabricante ?? string.Empty;
            txtDescricao.Text = objeto.Descricao ?? string.Empty;
            txtMarca.Text = objeto.Fabricante ?? string.Empty;
            txtNome.Text = objeto.Nome ?? string.Empty;
            txtObservacoes.Text = objeto.Observacao ?? string.Empty;
            txtQuantidadeEmEstoque.Text = objeto.QuantidadeEmEstoque.ToString();
            txtQuantidadeMinima.Text = objeto.QuantidadeMinimaParaAviso.ToString();
            txtPorcentagemDeLucro.Text = Math.Round(objeto.PorcentagemDeLucro * 100, 2).ToString();
            txtPrecoDeCompra.Text = objeto.PrecoDeCompra.ToString();
            txtPrecoDeVenda.Text = objeto.PrecoDeVenda.ToString();
            cbStatus.SelectedItem = objeto.Status.ToString();
        }

        protected Produto CarregueObjetoComControles()
        {
            var produto = new Produto();

            produto.Codigo = int.Parse(txtCodigo.Text.Trim());
            produto.CodigoDoFabricante = txtCodigoFabricante.Text.Trim();
            produto.Descricao = txtDescricao.Text.Trim();
            produto.Fabricante = txtMarca.Text.Trim();
            produto.Nome = txtNome.Text.Trim();
            produto.Observacao = txtObservacoes.Text.Trim();
            produto.PrecoDeCompra = !string.IsNullOrEmpty(txtPrecoDeCompra.Text.Trim())
                                  ? decimal.Parse(txtPrecoDeCompra.Text.Trim())
                                  : 0;
            produto.PrecoDeVenda = !string.IsNullOrEmpty(txtPrecoDeVenda.Text.Trim())
                                 ? decimal.Parse(txtPrecoDeVenda.Text.Trim())
                                 : 0;
            produto.PorcentagemDeLucro = !string.IsNullOrEmpty(txtPorcentagemDeLucro.Text.Trim())
                                       ? decimal.Parse(txtPorcentagemDeLucro.Text.Trim()) / 100
                                       : 0;
            produto.Status = cbStatus.SelectedIndex != -1
                           ? (EnumStatusDoProduto)cbStatus.SelectedIndex + 1
                           : EnumStatusDoProduto.Ativo;
            produto.QuantidadeEmEstoque = !string.IsNullOrEmpty(txtQuantidadeEmEstoque.Text.Trim())
                                        ? int.Parse(txtQuantidadeEmEstoque.Text.Trim())
                                        : 0;
            produto.QuantidadeMinimaParaAviso = !string.IsNullOrEmpty(txtQuantidadeMinima.Text.Trim())
                                              ? int.Parse(txtQuantidadeMinima.Text.Trim())
                                              : 0;

            return produto;
        }

        protected void HabiliteControles()
        {
            txtCodigo.Enabled = true;
            txtLineCodigo.Enabled = true;

            txtCodigoFabricante.Enabled = true;
            txtLineCodigoFabricante.Enabled = true;

            txtDescricao.Enabled = true;
            txtLineDescricao.Enabled = true;

            txtMarca.Enabled = true;
            txtLineMarca.Enabled = true;

            txtNome.Enabled = true;
            txtLineNome.Enabled = true;

            txtObservacoes.Enabled = true;
            txtLineObservacoes.Enabled = true;

            txtQuantidadeEmEstoque.Enabled = true;
            txtLineQuantidadeEstoque.Enabled = true;

            txtQuantidadeMinima.Enabled = true;
            txtLineQuantidadeMinima.Enabled = true;

            cbStatus.Enabled = true;
            txtLineStatus.Enabled = true;

            txtPorcentagemDeLucro.Enabled = true;
            txtLinePorcentagemLucro.Enabled = true;
            lblSimboloPorcentagemLucro.Enabled = true;

            txtPrecoDeCompra.Enabled = true;
            txtLinePrecoCompra.Enabled = true;
            lblCifraoPrecoCompra.Enabled = true;

            txtPrecoDeVenda.Enabled = true;
            txtLinePrecoVenda.Enabled = true;
            lblCifraoPrecoVenda.Enabled = true;
        }

        protected void DesabiliteControles()
        {
            txtCodigo.Enabled = false;
            txtLineCodigo.Enabled = false;

            txtCodigoFabricante.Enabled = false;
            txtLineCodigoFabricante.Enabled = false;

            txtDescricao.Enabled = false;
            txtLineDescricao.Enabled = false;

            txtMarca.Enabled = false;
            txtLineMarca.Enabled = false;

            txtNome.Enabled = false;
            txtLineNome.Enabled = false;

            txtObservacoes.Enabled = false;
            txtLineObservacoes.Enabled = false;

            txtQuantidadeEmEstoque.Enabled = false;
            txtLineQuantidadeEstoque.Enabled = false;

            txtQuantidadeMinima.Enabled = false;
            txtLineQuantidadeMinima.Enabled = false;

            cbStatus.Enabled = false;
            txtLineStatus.Enabled = false;

            txtPorcentagemDeLucro.Enabled = false;
            txtLinePorcentagemLucro.Enabled = false;
            lblSimboloPorcentagemLucro.Enabled = false;

            txtPrecoDeCompra.Enabled = false;
            txtLinePrecoCompra.Enabled = false;
            lblCifraoPrecoCompra.Enabled = false;

            txtPrecoDeVenda.Enabled = false;
            txtLinePrecoVenda.Enabled = false;
            lblCifraoPrecoVenda.Enabled = false;
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

        private enum EnumTipoDeForm
        {
            Cadastro,
            Detalhamento,
            Edicao
        }


        #region TextBox Monetaria

        //private bool IsNumeric(int Val)
        //{
        //    return ((Val >= 48 && Val <= 57) || (Val == 8) || (Val == 46));
        //}

        //string str = "";

        //private void txtPrecoDeCompra_KeyDown_1(object sender, KeyEventArgs e)
        //{
        //    int KeyCode = e.KeyValue;

        //    if (!IsNumeric(KeyCode))
        //    {
        //        e.Handled = true;
        //        return;
        //    }
        //    else
        //    {
        //        e.Handled = true;
        //    }
        //    if (((KeyCode == 8) || (KeyCode == 46)) && (str.Length > 0))
        //    {
        //        str = str.Substring(0, str.Length - 1);
        //    }
        //    else if (!((KeyCode == 8) || (KeyCode == 46)))
        //    {
        //        str = str + Convert.ToChar(KeyCode);
        //    }
        //    if (str.Length == 0)
        //    {
        //        txtPrecoDeCompra.Text = "";
        //    }
        //    if (str.Length == 1)
        //    {
        //        txtPrecoDeCompra.Text = "0.0" + str;
        //    }
        //    else if (str.Length == 2)
        //    {
        //        txtPrecoDeCompra.Text = "0." + str;
        //    }
        //    else if (str.Length > 2)
        //    {
        //        txtPrecoDeCompra.Text = str.Substring(0, str.Length - 2) + "." +
        //                        str.Substring(str.Length - 2);
        //    }
        //}

        //private void txtPrecoDeCompra_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    e.Handled = true;
        //}

        #endregion

        private void btnEditarSalvar_Click_1(object sender, EventArgs e)
        {
            switch (_switchBotaoEditarSalvar)
            {
                case EnumBotoesForm.Editar:
                    HabiliteControles();
                    cbVigencia.SelectedIndex = -1;
                    cbVigencia.Enabled = false;
                    txtLineVigencia.Enabled = false;

                    txtCodigo.Enabled = false;
                    txtLineCodigo.Enabled = false;
                    InicializeBotoes(EnumTipoDeForm.Edicao);
                    break;

                case EnumBotoesForm.Salvar:
                    if (string.IsNullOrEmpty(txtCodigo.Text))
                    {
                        PreenchaCodigoComProximoDisponivel();
                    }

                    var produto = CarregueObjetoComControles();

                    var listaDeInconsistencias = new List<Inconsistencia>();

                    using (var servicoDeProduto = new ServicoDeProduto())
                        listaDeInconsistencias = servicoDeProduto.Salve(produto);

                    if (listaDeInconsistencias.Count == 0)
                    {
                        MessageBox.Show(Mensagens.PRODUTO_CADASTRADO_COM_SUCESSO);
                        InicializeBotoes(EnumTipoDeForm.Detalhamento);
                        DesabiliteControles();
                        CarregueComboDeVigencias(produto.Codigo);
                        SelecioneUltimaVigencia();
                        cbVigencia.Enabled = true;
                        txtLineVigencia.Enabled = true;
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

        private void btnCancelarExcluir_Click_1(object sender, EventArgs e)
        {
            switch (_switchBotaoCancelarExcluir)
            {
                case EnumBotoesForm.Cancelar:
                    InicializeBotoes(EnumTipoDeForm.Detalhamento);

                    Produto produto;
                    using (var servicoDeProduto = new ServicoDeProduto())
                    {
                        produto = servicoDeProduto.Consulte(int.Parse(txtCodigo.Text.Trim()));
                    }

                    CarregueControlesComObjeto(produto);
                    DesabiliteControles();
                    cbVigencia.Enabled = true;
                    txtLineVigencia.Enabled = true;
                    CarregueComboDeVigencias(produto.Codigo);
                    SelecioneUltimaVigencia();
                    break;

                case EnumBotoesForm.Excluir:
                    //Prompt de certeza
                    using (var servicoDeProduto = new ServicoDeProduto())
                    {
                        servicoDeProduto.Exclua();
                        //Retorno dessa funçã deve validar se pode excluir
                        //Se tudo der certo, mensagem de sucesso e fecha
                        this.Close();
                    }
                    break;
            }
        }

        private void txtPrecoDeCompra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
