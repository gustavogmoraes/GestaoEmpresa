using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class FrmProdutoMetro : GSForm, IView
    {
        public FrmProdutoMetro()
        {
            InitializeComponent();

            lblTitulo.BackColor = Color.Empty;
        }

        private CultureInfo _culture = new CultureInfo("pt-BR");

        protected override void ChamadaSalvar(object sender, EventArgs e)
        {
            var result = (Presenter as ProdutoPresenter)?.Salve();
            if(result.Any())
            {
                result.ToList().ForEach(x => MessageBox.Show(x.Mensagem, "Inconsistência"));
                return;
            }

            var cadastroOuAtualizacao = TipoDeForm == EnumTipoDeForm.Cadastro ? "Cadastrado" : "Atualizado";
            MessageBox.Show($"{cadastroOuAtualizacao} com sucesso!", "Resultado");

            GSWaitForm.Mostrar(this, () =>
            {
                Invoke((MethodInvoker)delegate
                {
                    TipoDeForm = EnumTipoDeForm.Detalhamento;
                    Presenter.ViewCarregada();
                });
            });
        }

        protected override void ChamadaExclusao(object sender, EventArgs e)
        {
            var result = (Presenter as ProdutoPresenter)?.Exclua(Presenter.Model.Codigo);
            if (result.Any())
            {
                result.ToList().ForEach(x => MessageBox.Show(x.Mensagem, "Inconsistência"));

                return;
            }

            MessageBox.Show("Excluído com sucesso!", "Resultado");
            Presenter.FecharView(sender, e);
        }
        protected override void ChamadaEditarOnClick(object sender, EventArgs e)
        {
            EstahRenderizando = true;
            TipoDeForm = EnumTipoDeForm.Edicao;
            Presenter.HabiliteControles(new[] { txtQuantidadeEmEstoque.Name });
            EstahRenderizando = false;
        }

        private void TxtCodigoDeBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.IsAny(Keys.Return, Keys.Enter))
            {
                txtNome.Focus();
            }
        }

        private void cbVigencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(EstahRenderizando)
            {
                return;
            }

            var dataVigencia = DateTime.ParseExact((string)cbVigencia.SelectedItem, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            ((ProdutoPresenter) Presenter).RecarregueVigencia(dataVigencia);
        }

        private void txtPorcentagemLucro_Leave(object sender, EventArgs e)
        {
            CalculeEPreenchaPrecoDeVenda();
        }

        private void CalculeEPreenchaPrecoDeVenda()
        {
            if (txtMPrecoDeCompra.Value != 0 &&
                txtMLucro.Value != 0)
            {
                var precoCompra = txtMPrecoDeCompra.Value.GetValueOrDefault();
                txtMPrecoDeCompra.Value = precoCompra;

                var y = txtMLucro.Value.GetValueOrDefault() / 100;
                var k = precoCompra * y;
                var z = precoCompra + k;

                txtMPrecoDeVenda.Value = Math.Round(z, 2);
            }
        }

        private void txtPrecoDeCompra_Leave(object sender, EventArgs e)
        {
            CalculeEPreenchaPrecoDeVenda();
        }

        private void txtMLucro_Leave(object sender, EventArgs e)
        {
            CalculeEPreenchaPrecoDeVenda();
        }

        private void txtMPrecoDeCompra_Load(object sender, EventArgs e)
        {

        }
    }
}
