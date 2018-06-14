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

        private EnumTipoDeForm _tipoDoForm;

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

            InicializeBotoes(EnumTipoDeForm.Cadastro);
            _tipoDoForm = EnumTipoDeForm.Cadastro;
            cbStatus.Text = "Ativo";
            txtCodigo.Text = "Novo";
            cbVigencia.Enabled = false;
            txtLineVigencia.Enabled = false;
        }

        public frmProduto(Produto produto)
        {
            InitializeComponent();

            InicializeBotoes(EnumTipoDeForm.Detalhamento);
            _tipoDoForm = EnumTipoDeForm.Detalhamento;

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
            txtPrecoDeCompra.Text = txtPrecoDeCompra.Text.Replace(',', '.');
        }

        private void txtPrecoDeVenda_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrecoDeVenda.Text))
            {
                txtPrecoDeVenda.Text = 0.ToString();
                return;
            }

            _precoDeVenda = decimal.Parse(txtPrecoDeVenda.Text.Replace(',', '.'));
            txtPrecoDeVenda.Text = txtPrecoDeVenda.Text.Replace(',', '.');

            if (decimal.Parse(txtPrecoDeVenda.Text.Trim().Replace(',', '.')) > 0)
                AjustePrecosNaTela(sender as Control);
        }

        private void txtPorcentagemDeLucro_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPorcentagemDeLucro.Text))
            {
                txtPorcentagemDeLucro.Text = 0.ToString();
                return;
            }

            if (decimal.Parse(txtPorcentagemDeLucro.Text.Trim().Replace(',', '.')) > 0)
                AjustePrecosNaTela(sender as Control);

            txtPorcentagemDeLucro.Text = txtPorcentagemDeLucro.Text.Trim().Replace(',', '.');
        }

        private void AjustePrecosNaTela(Control controleGatilho)
        {
            

            //if (controleGatilho == txtPrecoDeVenda)
            //{
            //    var precoDeCompra = decimal.Parse(txtPrecoDeCompra.Text.Trim().Replace(',', '.'));
            //    var precoDeVenda = decimal.Parse(txtPrecoDeVenda.Text.Trim().Replace(',', '.'));

            //    var porcentagemDeLucro = (precoDeVenda / precoDeCompra) - 1;

            //    if (porcentagemDeLucro <= 0)
            //    {
            //        txtPorcentagemDeLucro.Text = 0.ToString();
            //        return;
            //    }

            //    txtPorcentagemDeLucro.Text = Math.Round(porcentagemDeLucro * 100, 2).ToString();
            //}

            //if (controleGatilho == txtPorcentagemDeLucro)
            //{
            //    var precoDeCompra = decimal.Parse(txtPrecoDeCompra.Text.Trim().Replace(',', '.'));
            //    var porcentagemDeLucro = decimal.Parse(txtPorcentagemDeLucro.Text.Trim().Replace(',', '.')) / 100;

            //    var precoDeVenda = precoDeCompra * (1 + porcentagemDeLucro);

            //    if (precoDeVenda <= 0)
            //    {
            //        txtPrecoDeVenda.Text = 0.ToString();
            //        return;
            //    }

            //    txtPrecoDeVenda.Text = precoDeVenda.ToString();
            //}
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
                MessageBox.Show(Mensagens.ERRO());
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
            chkAvisar.Checked = objeto.AvisarQuantidade;
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
            produto.AvisarQuantidade = chkAvisar.Checked;

            return produto;
        }

        protected void HabiliteControles()
        {
            chkAvisar.Enabled = true;

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
            chkAvisar.Enabled = false;

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
                    _tipoDoForm = EnumTipoDeForm.Edicao;
                    break;

                case EnumBotoesForm.Salvar:
                    if (string.IsNullOrEmpty(txtCodigo.Text) || txtCodigo.Text == "Novo")
                    {
                        PreenchaCodigoComProximoDisponivel();
                    }

                    var produto = CarregueObjetoComControles();

                    var listaDeInconsistencias = new List<Inconsistencia>();

                    using (var servicoDeProduto = new ServicoDeProduto())
                        listaDeInconsistencias = servicoDeProduto.Salve(produto, _tipoDoForm);

                    if (listaDeInconsistencias.Count == 0)
                    {
                        MessageBox.Show(Mensagens.X_FOI_CADASTRADO_COM_SUCESSO("Produto"));
                        InicializeBotoes(EnumTipoDeForm.Detalhamento);
                        _tipoDoForm = EnumTipoDeForm.Edicao;
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
                    _tipoDoForm = EnumTipoDeForm.Detalhamento;

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
                    var resultado = MessageBox.Show(Mensagens.TEM_CERTEZA_QUE_DESEJA_EXCLUIR_ESSE_X("produto"), "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        var codigoDoProduto = int.Parse(txtCodigo.Text);

                        var listaDeInconsistenciasExclusao = new List<Inconsistencia>();
                        using (var servicoDeProduto = new ServicoDeProduto())
                        {
                            listaDeInconsistenciasExclusao = servicoDeProduto.Exclua(codigoDoProduto);
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

        private void txtPrecoDeCompra_TextChanged(object sender, EventArgs e)
        {
            if(txtPrecoDeCompra.Text.All(x => GSUtilitarios.EhDigitoOuPonto(x)))
            {
                return;
            }
            else
            {
                txtPrecoDeCompra.Text = txtPrecoDeCompra.Text.Trim().Remove(txtPrecoDeCompra.Text.Length - 1);
            }
        }

        private void txtPrecoDeVenda_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecoDeVenda.Text.All(x => GSUtilitarios.EhDigitoOuPonto(x)))
            {
                return;
            }
            else
            {
                txtPrecoDeVenda.Text = txtPrecoDeVenda.Text.Trim().Remove(txtPrecoDeVenda.Text.Length - 1);
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
    }
}
