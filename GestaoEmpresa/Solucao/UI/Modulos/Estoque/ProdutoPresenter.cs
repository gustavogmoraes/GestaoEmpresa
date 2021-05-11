using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public sealed class ProdutoPresenter : Presenter<Produto, FrmProdutoMetro>
    {
        public ProdutoPresenter()
        {
            MapControl(model => model.Codigo, view => view.txtCodigo);
            MapControl(model => model.RevisionStartDateTime, view => view.cbValidity);
            MapControl(model => model.Status, view => view.toggleStatus);
            MapControl(model => model.Nome, view => view.txtNome);
            MapControl(model => model.Observacao, view => view.txtObservacoes);
            MapControl(model => model.Fabricante, view => view.txtMarca);
            MapControl(model => model.CodigoDoFabricante, view => view.txtCodigoFabricante);
            MapControl(model => model.QuantidadeMinimaParaAviso, view => view.txtQuantidadeMinima);
            MapControl(model => model.AvisarQuantidade, view => view.chkAvisarQuantidade);
            MapControl(model => model.CodigoDeBarras, view => view.txtCodigoDeBarras);
            MapControl(model => model.PrecoDeCompra, view => view.txtMPrecoDeCompra);
            MapControl(model => model.PrecoDeVenda, view => view.txtMPrecoDeVenda);
            MapControl(model => model.PorcentagemDeLucro, view => view.txtMLucro);
            MapControl(model => model.Ipi, view => view.txtMPorcentagemIpi);
            MapControl(model => model.PrecoNaIntelbras, view => view.txtMPrecoNaIntelbras);
            MapControl(model => model.PrecoDistribuidor, view => view.txtMPrecoSugeridoRevenda);
            MapControl(model => model.PrecoSugeridoConsumidorFinal, view => view.txtMPscf);
            MapControl(model => model.PorcentagemDeLucroDistribuidor, view => view.txtMPorcentagemDeLucroConsumidorFinal);
            MapControl(model => model.RavenAttachments, view => view.gsImageAttacher1);
            MapControl(model => model.TambemConhecidoComo, view => view.txtTambemConhecidoComo);
            MapControl(model => model.LocalizacaoNoEstoque, view => view.txtLocalizacao);
        }

        public IList<Inconsistencia> Salve()
        {
            using (var servicoDeProduto = new ProductService())
            {
                return servicoDeProduto.Salve(Model, View.TipoDeForm);
            }
        }

        public IList<Inconsistencia> Exclua(int codigo)
        {
            using (var servicoDeProduto = new ProductService())
            {
                return servicoDeProduto.Exclua(codigo);
            }
        }

        public void RecarregueVigencia(DateTime dataVigencia)
        {
            GSWaitForm.Mostrar(
                () =>
                {
                    using var servicoDeProduto = new ProductService();
                    var vigenciaConsultada = servicoDeProduto.Consulte(Model.Codigo, dataVigencia);
                    Model = vigenciaConsultada;

                    View.Invoke((MethodInvoker)delegate
                    {
                        View.IsRendering = true;

                        View.Presenter?.FillControlsWithModel();
                        View.IsRendering = true;

                        View.cbValidity.SelectedItem = dataVigencia.ToString("dd/MM/yyyy HH:mm:ss");
                        View.txtQuantidadeEmEstoque.Text = servicoDeProduto.ConsulteQuantidade(vigenciaConsultada.Codigo).ToString();

                        View.IsRendering = false;
                    });
                });
        }

        public Produto Consulte(int codigo)
        {
            using var servicoDeProduto = new ProductService();
            return servicoDeProduto.QueryFirst(codigo);
        }

        public override void FillControlsWithModel(bool reloading = false)
        {
            base.FillControlsWithModel(reloading);

            using var servico = new ProductService();
            var quantidade = servico.ConsulteQuantidade(Model.Codigo);
            View.txtQuantidadeEmEstoque.Text = quantidade.ToString();
        }
    }
}
