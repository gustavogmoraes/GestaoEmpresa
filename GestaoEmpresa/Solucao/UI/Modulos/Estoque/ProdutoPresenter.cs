using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public sealed class ProdutoPresenter : Presenter<Produto, frmProdutoMetro>, IPresenter
    {
        public ProdutoPresenter()
        {
            MapeieControle(model => model.Codigo, view => view.txtCodigo);
            MapeieControle(model => model.Vigencia, view => view.cbVigencia);
            MapeieControle(model => model.Status, view => view.toggleStatus);
            MapeieControle(model => model.Nome, view => view.txtNome);
            MapeieControle(model => model.Observacao, view => view.txtObservacoes);
            MapeieControle(model => model.Fabricante, view => view.txtMarca);
            MapeieControle(model => model.CodigoDoFabricante, view => view.txtCodigoFabricante);
            MapeieControle(model => model.QuantidadeMinimaParaAviso, view => view.txtQuantidadeMinima);
            MapeieControle(model => model.QuantidadeEmEstoque, view => view.txtQuantidadeEmEstoque);
            MapeieControle(model => model.AvisarQuantidade, view => view.chkAvisarQuantidade);
            MapeieControle(model => model.CodigoDeBarras, view => view.txtCodigoDeBarras);
            MapeieControle(model => model.PrecoDeCompra, view => view.txtPrecoDeCompra);
            MapeieControle(model => model.PrecoDeVenda, view => view.txtPrecoDeVenda);
            MapeieControle(model => model.PorcentagemDeLucro, view => view.txtPorcentagemLucro);
            MapeieControle(model => model.Ipi, view => view.txtPorcentagemIpi);
            MapeieControle(model => model.PrecoNaIntelbras, view => view.txtPrecoNaIntelbras);
            MapeieControle(model => model.PrecoSugeridoRevenda, view => view.txtPrecoSugeridoRevenda);
        }

        public IList<Inconsistencia> Salve()
        {
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                return servicoDeProduto.Salve((Produto)Model, View.TipoDeForm);
            }
        }

        public IList<Inconsistencia> Exclua(int codigo)
        {
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                return servicoDeProduto.Exclua(codigo);
            }
        }

        public void RecarregueVigencia(DateTime dataVigencia)
        {
            GSWaitForm.Mostrar(
                View,
                () =>
                {
                    using (var servicoDeProduto = new ServicoDeProduto())
                    {
                        var vigenciaConsultada = servicoDeProduto.Consulte(Model.Codigo, dataVigencia);
                        Model = vigenciaConsultada;

                        View.Invoke((MethodInvoker)delegate
                        {
                            CarregueControlesComModel();

                            View.EstahRenderizando = true;
                            View.cbVigencia.SelectedItem = dataVigencia.ToString("dd/MM/yyyy HH:mm:ss");
                        });
                    }
                });
        }

        public Produto Consulte(int codigo)
        {
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                return servicoDeProduto.Consulte(codigo);
            }
        }
    }
}
