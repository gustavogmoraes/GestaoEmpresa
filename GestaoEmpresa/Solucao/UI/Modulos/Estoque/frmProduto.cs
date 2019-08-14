using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
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
using GS.GestaoEmpresa.Solucao.UI.Base;
using Sparrow.Utils;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class frmProduto : Form, IView
    {
        private EnumBotoesForm _switchBotaoEditarSalvar;

        private EnumBotoesForm _switchBotaoCancelarExcluir;

        public IPresenter Presenter { get; set; }

        public void ChamadaMinimizarForm(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ChamadaFecharForm(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public EnumTipoDeForm TipoDeForm { get; set; }

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
            TipoDeForm = EnumTipoDeForm.Cadastro;
            cbStatus.Text = "Ativo";
            txtCodigo.Text = "Novo";
            cbVigencia.Enabled = false;
            txtLineVigencia.Enabled = false;
        }

        public frmProduto(Produto produto)
        {
            InitializeComponent();

            InicializeBotoes(EnumTipoDeForm.Detalhamento);
            TipoDeForm = EnumTipoDeForm.Detalhamento;

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

                txtPorcentagemDeLucro.Valor = Math.Round(porcentagemDeLucro * 100, 2);
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
            if (cbVigencia.SelectedIndex == -1) return;

            Produto produto = null;
            using (var servicoDeProduto = new ServicoDeProduto())
                produto = servicoDeProduto.Consulte(int.Parse(txtCodigo.Text.Trim()), DateTime.Parse(cbVigencia.SelectedItem.ToString(), Cultura));

            if(produto != null) CarregueControlesComObjeto(produto);
        }

        protected void CarregueComboDeVigencias(int codigo)
        {
            cbVigencia.Items.Clear();

            var listaDeVigencias = new List<DateTime>();
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                listaDeVigencias = servicoDeProduto.ConsulteVigencias(codigo).ToList();
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
            txtMarca.Text = objeto.Fabricante ?? string.Empty;
            txtNome.Text = objeto.Nome ?? string.Empty;
            txtObservacoes.Text = objeto.Observacao ?? string.Empty;
            txtQuantidadeEmEstoque.Text = objeto.QuantidadeEmEstoque.ToString();
            txtQuantidadeMinima.Text = objeto.QuantidadeMinimaParaAviso.ToString();
            txtPorcentagemDeLucro.Valor = objeto.PorcentagemDeLucro * 100;
            txtPrecoDeCompra.Valor = objeto.PrecoDeCompra;
            txtPrecoDeVenda.Valor = objeto.PrecoDeVenda;
            cbStatus.SelectedItem = objeto.Status.ToString();
            chkAvisar.Checked = objeto.AvisarQuantidade;
            
        }

        protected Produto CarregueObjetoComControles()
        {
            var produto = new Produto();

            produto.Codigo = int.Parse(txtCodigo.Text.Trim());
            produto.CodigoDoFabricante = txtCodigoFabricante.Text.Trim();
            produto.Fabricante = txtMarca.Text.Trim();
            produto.Nome = txtNome.Text.Trim();
            produto.Observacao = txtObservacoes.Text.Trim();
            produto.PrecoDeCompra = txtPrecoDeCompra.Valor;
            produto.PrecoDeVenda = txtPrecoDeVenda.Valor;
            produto.PorcentagemDeLucro = Math.Round(txtPorcentagemDeLucro.Valor / 100, 2);
            produto.Status = cbStatus.SelectedIndex != -1
                           ? (EnumStatusToggle)cbStatus.SelectedIndex + 1
                           : EnumStatusToggle.Ativo;

            produto.QuantidadeEmEstoque = ! string.IsNullOrEmpty(txtQuantidadeEmEstoque.Text)
                                        ? Convert.ToInt32(txtQuantidadeEmEstoque.Text)
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

        private void InicializeBotoes(EnumTipoDeForm tipoDeForm)
        {
            switch (tipoDeForm)
            {
                case EnumTipoDeForm.Cadastro:
                    btnCancelarExcluir.Enabled = false;
                    btnCancelarExcluir.Visible = false;

                    txtLineQuantidadeEstoque.Enabled = false;
                    txtQuantidadeEmEstoque.Enabled = false;

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

                    txtLineQuantidadeEstoque.Enabled = true;
                    txtQuantidadeEmEstoque.Enabled = true;

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
                    TipoDeForm = EnumTipoDeForm.Edicao;
                    break;

                case EnumBotoesForm.Salvar:
                    if (string.IsNullOrEmpty(txtCodigo.Text) || txtCodigo.Text == "Novo")
                    {
                        PreenchaCodigoComProximoDisponivel();
                    }

                    var produto = CarregueObjetoComControles();

                    var listaDeInconsistencias = new List<Inconsistencia>();

                    using (var servicoDeProduto = new ServicoDeProduto())
                        listaDeInconsistencias = servicoDeProduto.Salve(produto, TipoDeForm).ToList();

                    if (listaDeInconsistencias.Count == 0)
                    {
                        if (TipoDeForm == EnumTipoDeForm.Cadastro)
                        {
                            GerenciadorDeViews.ObtenhaIndependente<frmEstoque>().AdicioneNovoProdutoNaGrid(produto);
                            MessageBox.Show(Mensagens.X_FOI_CADASTRADO_COM_SUCESSO("Produto"));
                        }
                        else
                        {
                            GerenciadorDeViews.ObtenhaIndependente<frmEstoque>().RecarregueProdutoEspecifico(produto);
                            MessageBox.Show(Mensagens.X_FOI_ATUALIZADO_COM_SUCESSO("Produto"));
                        }

                        InicializeBotoes(EnumTipoDeForm.Detalhamento);
                        TipoDeForm = EnumTipoDeForm.Edicao;
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
                    TipoDeForm = EnumTipoDeForm.Detalhamento;

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
                            listaDeInconsistenciasExclusao = servicoDeProduto.Exclua(codigoDoProduto).ToList();
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

        public string IdInstancia { get; set; }

        public void ApagueInstancia()
        {
            //GerenciadorDeViews.Exclua<frmProduto>(IdInstancia);
        }

        private void frmProduto_FormClosed(object sender, FormClosedEventArgs e)
        {
            ApagueInstancia();
        }
    }
}
