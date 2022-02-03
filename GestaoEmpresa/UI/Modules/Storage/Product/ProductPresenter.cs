using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GS.GestaoEmpresa.Business.Services;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.UI.GenericControls;

namespace GS.GestaoEmpresa.UI.Modules.Storage.Product
{
    public sealed class ProductPresenter : Presenter<Business.Objects.Storage.Product, FrmProdutoMetro>
    {
        public ProductPresenter()
        {
            MapControl(model => model.Code, view => view.txtCodigo);
            MapControl(model => model.RevisionStartDateTime, view => view.cbValidity);
            MapControl(model => model.Status, view => view.toggleStatus);
            MapControl(model => model.Name, view => view.txtNome);
            MapControl(model => model.Notes, view => view.txtObservacoes);
            MapControl(model => model.Manufacturer, view => view.txtMarca);
            MapControl(model => model.ManufacturerCode, view => view.txtCodigoFabricante);
            MapControl(model => model.MinimumQuantityToAlert, view => view.txtQuantidadeMinima);
            MapControl(model => model.AlertQuantity, view => view.chkAvisarQuantidade);
            MapControl(model => model.BarCode, view => view.txtCodigoDeBarras);
            MapControl(model => model.PurchasePrice, view => view.txtMPrecoDeCompra);
            MapControl(model => model.SalePrice, view => view.txtMPrecoDeVenda); ;
            MapControl(model => model.ProfitPercentage, view => view.txtMLucro);
            MapControl(model => model.Ipi, view => view.txtMPorcentagemIpi);
            MapControl(model => model.IntelbrasPrice, view => view.txtMPrecoNaIntelbras);
            MapControl(model => model.DistributorPrice, view => view.txtMPrecoSugeridoRevenda);
            MapControl(model => model.FinalCostumerSuggestedPrice, view => view.txtMPscf);
            MapControl(model => model.DistributorPriceProfiPercent, view => view.txtMPorcentagemDeLucroConsumidorFinal);
            MapControl(model => model.RavenAttachments, view => view.gsImageAttacher1);
            MapControl(model => model.AlsoKnownAs, view => view.txtTambemConhecidoComo);
            MapControl(model => model.LocationInStorage, view => view.txtLocalizacao);
        }

        public IList<Inconsistencia> Salve()
        {
            using (var servicoDeProduto = new ProductService())
            {
                return servicoDeProduto.Save(Model, View.FormType);
            }
        }

        public IList<Inconsistencia> Exclua(int codigo)
        {
            using (var servicoDeProduto = new ProductService())
            {
                return servicoDeProduto.Delete(codigo);
            }
        }

        public void RecarregueVigencia(DateTime dataVigencia)
        {
            GSWaitForm.Mostrar(
                () =>
                {
                    using var servicoDeProduto = new ProductService();
                    var vigenciaConsultada = servicoDeProduto.Query(Model.Code, dataVigencia);
                    Model = vigenciaConsultada;

                    View.Invoke((MethodInvoker)delegate
                    {
                        View.IsRendering = true;

                        View.Presenter?.FillControlsWithModel();
                        View.IsRendering = true;

                        View.cbValidity.SelectedItem = dataVigencia.ToString("dd/MM/yyyy HH:mm:ss");
                        View.txtQuantidadeEmEstoque.Text = servicoDeProduto.ConsulteQuantidade(vigenciaConsultada.Code).ToString();

                        View.IsRendering = false;
                    });
                });
        }

        public Business.Objects.Storage.Product Consulte(int codigo)
        {
            using var servicoDeProduto = new ProductService();
            return servicoDeProduto.Query(codigo);
        }

        public override void FillControlsWithModel(bool reloading = false)
        {
            base.FillControlsWithModel(reloading);

            using var servico = new ProductService();
            var quantidade = servico.ConsulteQuantidade(Model.Code);
            View.txtQuantidadeEmEstoque.Text = quantidade.ToString();
        }
    }
}
