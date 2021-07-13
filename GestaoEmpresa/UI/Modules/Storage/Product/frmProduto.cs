using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using GS.GestaoEmpresa.Business.Enumerators.Default;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Business.Services;
using GS.GestaoEmpresa.Business.Objects;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.UI.Base;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class frmProduto : Form, IView
    {
        private EnumBotoesForm _switchBotaoEditarSalvar;

        private EnumBotoesForm _switchBotaoCancelarExcluir;

        public IPresenter Presenter { get; set; }

        public void MinimizeFormCall(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void CloseFormCall(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void SetBorderStyle()
        {
            //BorderStyle = MetroFormBorderStyle.FixedSingle;
        }

        public FormType FormType { get; set; }

        private enum EnumBotoesForm
        {
            Editar,
            Salvar,

            Cancelar,
            Excluir
        }

        public CultureInfo Cultura = new CultureInfo("pt-BR");

        public frmProduto()
        {
            InitializeComponent();

            InicializeBotoes(FormType.Insert);
            FormType = FormType.Insert;
            cbStatus.Text = "Ativo";
            txtCodigo.Text = "Novo";
            cbVigencia.Enabled = false;
            txtLineVigencia.Enabled = false;
        }

        public frmProduto(Product produto, int quantidade)
        {
            InitializeComponent();

            InicializeBotoes(FormType.Detail);
            FormType = FormType.Detail;

            CarregueControlesProduto(produto, quantidade);
            CarregueComboDeVigencias(produto.Code);
            SelecioneUltimaVigencia();
            DesabiliteControles();
        }

        private void CarregueControlesProduto(Product produto, int quantidade)
        {
            CarregueControlesComObjeto(produto);
            txtLineQuantidadeEstoque.Text = quantidade.ToString();
        }

        private void frmProduto_Load(object sender, EventArgs e)
        {

        }

        private void SelecioneUltimaVigencia()
        {
            cbVigencia.SelectedIndex = 0;
        }

        #region Métodos Específicos

        private void AjustePrecosNaTela(Control controleGatilho)
        {
            if (controleGatilho == txtPrecoDeVenda)
            {
                var precoDeCompra = txtPrecoDeCompra.Valor;
                var precoDeVenda = txtPrecoDeVenda.Valor;

                var porcentagemDeLucro = (precoDeVenda / precoDeCompra) - 1;

                if (porcentagemDeLucro <= 0)
                {
                    txtPorcentagemDeLucro.Valor = 0;
                    return;
                }

                //txtPorcentagemDeLucro.Valor = Math.Round(porcentagemDeLucro * 100, 2);
            }

            if (controleGatilho == txtPorcentagemDeLucro)
            {
                var precoDeCompra = txtPrecoDeCompra.Valor;
                var porcentagemDeLucro = txtPorcentagemDeLucro.Valor / 100;

                var precoDeVenda = precoDeCompra * (1 + porcentagemDeLucro);

                if (precoDeVenda <= 0)
                {
                    txtPrecoDeVenda.Valor = 0;
                    return;
                }

                txtPrecoDeVenda.Valor = precoDeVenda;
            }
        }

        #endregion

        #region Métodos de Formulário

        protected void PreenchaCodigoComProximoDisponivel()
        {
            int proximoCodigo;
            using (var servicoDeProduto = new ProductService())
                proximoCodigo = servicoDeProduto.GetNextAvailableCode();

            if (proximoCodigo == 0)
            {
                MessageBox.Show(Mensagens.ERRO);
                return;
            }

            txtCodigo.Text = proximoCodigo.ToString();
        }

        protected void cbVigencia_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbVigencia.SelectedIndex == -1) return;

            Product produto = null;
            using (var servicoDeProduto = new ProductService())
                produto = servicoDeProduto.Query(
                    int.Parse(txtCodigo.Text.Trim()), DateTime.Parse(cbVigencia.SelectedItem.ToString(), Cultura));

            if(produto != null) CarregueControlesComObjeto(produto);
        }

        protected void CarregueComboDeVigencias(int codigo)
        {
            cbVigencia.Items.Clear();

            var listaDeVigencias = new List<DateTime>();
            using (var servicoDeProduto = new ProductService())
            {
                listaDeVigencias = servicoDeProduto.QueryRevisions(codigo).ToList();
            }

            foreach (var vigencia in listaDeVigencias)
            {
                cbVigencia.Items.Add(vigencia.ToString(Cultura));
            }
        }

        protected void CarregueControlesComObjeto(Product objeto)
        {
            txtCodigo.Text = objeto.Code.ToString();
            txtCodigoFabricante.Text = objeto.ManufacturerCode ?? string.Empty;
            txtMarca.Text = objeto.Manufacturer ?? string.Empty;
            txtNome.Text = objeto.Name ?? string.Empty;
            txtObservacoes.Text = objeto.Notes ?? string.Empty;
            txtQuantidadeMinima.Text = objeto.MinimumQuantityToAlert.ToString();
            txtPorcentagemDeLucro.Valor = objeto.ProfitPercentage;
            txtPrecoDeCompra.Valor = objeto.PurchasePrice;
            txtPrecoDeVenda.Valor = objeto.SalePrice;
            cbStatus.SelectedItem = objeto.Status.ToString();
            chkAvisar.Checked = objeto.AlertQuantity;
            
        }

        protected Product CarregueObjetoComControles()
        {
            var produto = new Product();

            produto.Code = int.Parse(txtCodigo.Text.Trim());
            produto.ManufacturerCode = txtCodigoFabricante.Text.Trim();
            produto.Manufacturer= txtMarca.Text.Trim();
            produto.Name = txtNome.Text.Trim();
            produto.Notes = txtObservacoes.Text.Trim();
            produto.PurchasePrice = txtPrecoDeCompra.Valor;
            produto.SalePrice = txtPrecoDeVenda.Valor;
            produto.ProfitPercentage = txtPorcentagemDeLucro.Valor;
            produto.Status = cbStatus.SelectedIndex != -1
                           ? (EnumStatusToggle)cbStatus.SelectedIndex + 1
                           : EnumStatusToggle.Active;

            produto.MinimumQuantityToAlert = !string.IsNullOrEmpty(txtQuantidadeMinima.Text.Trim())
                                              ? int.Parse(txtQuantidadeMinima.Text.Trim())
                                              : 0;
            produto.AlertQuantity = chkAvisar.Checked;

            return produto;
        }

        protected void HabiliteControles()
        {
            chkAvisar.Enabled = true;

            txtCodigo.Enabled = true;
            txtLineCodigo.Enabled = true;

            txtCodigoFabricante.Enabled = true;
            txtLineCodigoFabricante.Enabled = true;

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
            lblSimboloPorcentagemLucro.Enabled = true;

            txtPrecoDeCompra.Enabled = true;
            lblCifraoPrecoCompra.Enabled = true;

            txtPrecoDeVenda.Enabled = true;
            lblCifraoPrecoVenda.Enabled = true;
        }

        protected void DesabiliteControles()
        {
            chkAvisar.Enabled = false;

            txtCodigo.Enabled = false;
            txtLineCodigo.Enabled = false;

            txtCodigoFabricante.Enabled = false;
            txtLineCodigoFabricante.Enabled = false;

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
            lblSimboloPorcentagemLucro.Enabled = false;

            txtPrecoDeCompra.Enabled = false;
            lblCifraoPrecoCompra.Enabled = false;

            txtPrecoDeVenda.Enabled = false;
            lblCifraoPrecoVenda.Enabled = false;
        }

        private void InicializeBotoes(FormType tipoDeFormType)
        {
            switch (tipoDeFormType)
            {
                case FormType.Insert:
                    btnCancelarExcluir.Enabled = false;
                    btnCancelarExcluir.Visible = false;

                    txtLineQuantidadeEstoque.Enabled = false;
                    txtQuantidadeEmEstoque.Enabled = false;

                    btnEditarSalvar.Image = Properties.Resources.floppy_icon;
                    _switchBotaoEditarSalvar = EnumBotoesForm.Salvar;
                    break;

                case FormType.Update:
                    btnCancelarExcluir.Enabled = true;
                    btnCancelarExcluir.Visible = true;
                    btnCancelarExcluir.Image = Properties.Resources.cancel_icon;
                    _switchBotaoCancelarExcluir = EnumBotoesForm.Cancelar;

                    btnEditarSalvar.Image = Properties.Resources.floppy_icon;
                    _switchBotaoEditarSalvar = EnumBotoesForm.Salvar;

                    txtLineQuantidadeEstoque.Enabled = true;
                    txtQuantidadeEmEstoque.Enabled = true;

                    break;

                case FormType.Detail:
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
                    InicializeBotoes(FormType.Update);
                    FormType = FormType.Update;
                    break;

                case EnumBotoesForm.Salvar:
                    if (string.IsNullOrEmpty(txtCodigo.Text) || txtCodigo.Text == "Novo")
                    {
                        PreenchaCodigoComProximoDisponivel();
                    }

                    var produto = CarregueObjetoComControles();

                    var listaDeInconsistencias = new List<Inconsistencia>();
                    var quantidade = 0;

                    using (var servicoDeProduto = new ProductService())
                    {
                        listaDeInconsistencias = servicoDeProduto.Save(produto, FormType).ToList();

                        quantidade = servicoDeProduto.ConsulteQuantidade(produto.Code);
                    }

                    if (listaDeInconsistencias.Count == 0)
                    {
                        if (FormType == FormType.Insert)
                        {
                            GerenciadorDeViews.ObtenhaIndependente<FrmEstoque>()
                                .AdicioneNovoProdutoNaGrid(produto, 0);
                            MessageBox.Show(Mensagens.X_FOI_CADASTRADO_COM_SUCESSO("Produto"));
                        }
                        else
                        {
                            GerenciadorDeViews.ObtenhaIndependente<FrmEstoque>().RecarregueProdutoEspecifico(produto, quantidade);
                            MessageBox.Show(Mensagens.X_FOI_ATUALIZADO_COM_SUCESSO("Produto"));
                        }

                        InicializeBotoes(FormType.Detail);
                        FormType = FormType.Update;
                        DesabiliteControles();
                        CarregueComboDeVigencias(produto.Code);
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
                    InicializeBotoes(FormType.Detail);
                    FormType = FormType.Detail;

                    Product produto;
                    using (var servicoDeProduto = new ProductService())
                    {
                        produto = servicoDeProduto.Query(int.Parse(txtCodigo.Text.Trim()));
                    }

                    CarregueControlesComObjeto(produto);
                    DesabiliteControles();
                    cbVigencia.Enabled = true;
                    txtLineVigencia.Enabled = true;
                    CarregueComboDeVigencias(produto.Code);
                    SelecioneUltimaVigencia();
                    break;

                case EnumBotoesForm.Excluir:
                    var resultado = MessageBox.Show(Mensagens.TEM_CERTEZA_QUE_DESEJA_EXCLUIR_ESSE_X("produto"), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        var codigoDoProduto = int.Parse(txtCodigo.Text);

                        var listaDeInconsistenciasExclusao = new List<Inconsistencia>();
                        using (var servicoDeProduto = new ProductService())
                        {
                            listaDeInconsistenciasExclusao = servicoDeProduto.Delete(codigoDoProduto).ToList();
                        }

                        if (listaDeInconsistenciasExclusao.Count == 0)
                        {
                            MessageBox.Show(Mensagens.O_X_FOI_EXCLUIDO_COM_SUCESSO("produto"));
                            this.Close();
                        }
                        else
                        {
                            foreach(var inconsistencia in listaDeInconsistenciasExclusao)
                            {
                                MessageBox.Show(inconsistencia.Mensagem);
                            }
                        }
                    }
                    else if (resultado == DialogResult.No)
                    {
                       // Não faz nada
                    }
                    break;
            }
        }

        private void txtPorcentagemDeLucro_TextChanged(object sender, EventArgs e)
        {
            if (txtPorcentagemDeLucro.Text.All(x => GSUtilitarios.EhDigitoOuPonto(x)))
            {
                return;
            }
            else
            {
                txtPorcentagemDeLucro.Text = txtPorcentagemDeLucro.Text.Trim().Remove(txtPorcentagemDeLucro.Text.Length - 1);
            }
        }

        private void txtQuantidadeMinima_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantidadeMinima.Text.All(char.IsDigit))
            {
                return;
            }
            else
            {
                txtQuantidadeMinima.Text = txtQuantidadeMinima.Text.Trim().Remove(txtQuantidadeMinima.Text.Length - 1);
            }
        }

        private void txtQuantidadeEmEstoque_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantidadeEmEstoque.Text.All(char.IsDigit))
            {
                return;
            }
            else
            {
                txtQuantidadeEmEstoque.Text = txtQuantidadeEmEstoque.Text.Trim().Remove(txtQuantidadeEmEstoque.Text.Length - 1);
            }
        }

        private void txtPrecoDeVenda_Leave(object sender, EventArgs e)
        {
            if (txtPrecoDeVenda.Valor > 0)
                AjustePrecosNaTela(sender as Control);
        }

        private void txtPorcentagemDeLucro_Leave(object sender, EventArgs e)
        {
            if (txtPorcentagemDeLucro.Valor > 0)
                AjustePrecosNaTela(sender as Control);
        }

        public string InstanceId { get; set; }
        public bool IsRendering { get; set; }

        public void ApagueInstancia()
        {
            //GerenciadorDeViews.Delete<frmProduto>(InstanceId);
        }

        private void frmProduto_FormClosed(object sender, FormClosedEventArgs e)
        {
            ApagueInstancia();
        }

        public void MaximizeFormCall(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
