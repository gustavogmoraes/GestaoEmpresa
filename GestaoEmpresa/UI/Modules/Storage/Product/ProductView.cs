using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Business.Enumerators.Default;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.UI.Base;
using GS.GestaoEmpresa.UI.GenericControls;
using GS.GestaoEmpresa.UI.Modules.Storage.Product;
using MetroFramework.Forms;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class ProductView : GSForm, IView
    {
        public ProductView()
        {
            InitializeComponent();

            lblTitulo.BackColor = Color.Empty;
        }

        private CultureInfo _culture = new CultureInfo("pt-BR");

        protected new void SetBorderStyle()
        {
            BorderStyle = MetroFormBorderStyle.FixedSingle;
        }

        protected override async Task SaveCall(object sender, EventArgs e)
        {
            var result = await (Presenter as ProductPresenter)?.SaveAsync();
            if (result.IsNotNull() && result!.Any())
            {
                result.ToList().ForEach(x => MessageBox.Show(x.Message, "Inconsistência"));
                return;
            }

            var insertionOrUpdate = FormType == FormType.Insert ? "Cadastrado" : "Atualizado";
            MessageBox.Show($"{insertionOrUpdate} com sucesso!", "Resultado");

            GSWaitForm.Mostrar(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    FormType = FormType.Detail;
                    Presenter.ViewDidLoad();
                });
            });
        }

        protected override void DeleteCall(object sender, EventArgs e)
        {
            var result = (Presenter as ProductPresenter)?.Exclua(Presenter.Model.Code).Result;
            if (result.Any())
            {
                result.ToList().ForEach(x => MessageBox.Show(x.Message, "Inconsistência"));

                return;
            }

            MessageBox.Show("Excluído com sucesso!", "Resultado");
            Presenter.CloseView(sender, e);
        }

        protected override void ChamadaEditarOnClick(object sender, EventArgs e)
        {
            IsRendering = true;
            FormType = FormType.Update;
            Presenter.EnableControls(new[] { txtQuantidadeEmEstoque.Name });
            IsRendering = false;
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
            if(IsRendering)
            {
                return;
            }

            var dataVigencia = DateTime.ParseExact((string)cbValidity.SelectedItem, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            ((ProductPresenter) Presenter).ReloadRevision(dataVigencia);
        }

        private void txtPorcentagemLucro_Leave(object sender, EventArgs e)
        {
            CalculeEPreenchaPrecoDeVenda();
        }

        public void CalculeEPreenchaPrecoDeVenda()
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

        public void CalculeEPreenchaPrecoDeCompra()
        {
            if (txtMPrecoNaIntelbras.Value == 0 || txtMPorcentagemIpi.Value == 0)
            {
                return;
            }

            var precoIntelbras = txtMPrecoNaIntelbras.Value.GetValueOrDefault();

            var y = txtMPorcentagemIpi.Value.GetValueOrDefault() / 100;
            var k = precoIntelbras * y;
            var z = precoIntelbras + k;

            txtMPrecoDeCompra.Value = Math.Round(z, 2);
        }

        public void CalculeEPreenchaPrecoConsumidorFinal()
        {
            if (txtMPrecoSugeridoRevenda.Value == 0 || txtMPorcentagemDeLucroConsumidorFinal.Value == 0)
            {
                return;
            }

            var precoRevenda = txtMPrecoSugeridoRevenda.Value.GetValueOrDefault();

            var y = txtMPorcentagemIpi.Value.GetValueOrDefault() / 100;
            var k = precoRevenda * y;
            var z = precoRevenda + k;

            txtMPscf.Value = Math.Round(z, 2);
        }

        private void txtPrecoDeCompra_Leave(object sender, EventArgs e)
        {
            CalculeEPreenchaPrecoDeVenda();
        }

        private void txtMLucro_Leave(object sender, EventArgs e)
        {
            CalculeEPreenchaPrecoDeVenda();
        }


        private void txtMPrecoNaIntelbras_Leave(object sender, EventArgs e)
        {
            CalculeEPreenchaPrecoDeCompra();
        }

        private void txtMPorcentagemIpi_Leave(object sender, EventArgs e)
        {
            CalculeEPreenchaPrecoDeCompra();
        }

        private void txtMPrecoSugeridoRevenda_Leave(object sender, EventArgs e)
        {
            CalculeEPreenchaPrecoConsumidorFinal();
        }

        private void txtMPorcentagemDeLucroConsumidorFinal_Leave(object sender, EventArgs e)
        {
            CalculeEPreenchaPrecoConsumidorFinal();
        }
    }
}
