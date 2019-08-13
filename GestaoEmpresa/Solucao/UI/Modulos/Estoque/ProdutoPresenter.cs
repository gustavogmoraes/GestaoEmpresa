using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.UI.Base;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public sealed class ProdutoPresenter : Presenter<frmProdutoMetro>
    {
        public ProdutoPresenter()
        {
            TesteMap<Produto>(model => model.Codigo, view => view.txtCodigo);

            MapeieControles(
                new Dictionary<Expression<Func<Produto, object>>, Expression<Func<frmProdutoMetro, Control>>>
                {
                    { model => model.Codigo, view => view.txtCodigo },
                    { model => model.Vigencia, view => view.cbVigencia },
                    { model => model.Status, view => view.toggleStatus },
                    { model => model.Nome, view => view.txtNome },
                    { model => model.Observacao, view => view.txtObservacoes },
                    { model => model.Fabricante, view => view.txtMarca },
                    { model => model.CodigoDoFabricante, view => view.txtCodigoFabricante },
                    { model => model.QuantidadeMinimaParaAviso, view => view.txtQuantidadeMinima },
                    { model => model.QuantidadeEmEstoque, view => view.txtQuantidadeEmEstoque },
                    { model => model.AvisarQuantidade, view => view.chkAvisarQuantidade },
                    { model => model.CodigoDeBarras, view => view.txtCodigoDeBarras },
                    { model => model.PrecoDeCompra, view => view.txtPrecoDeCompra },
                    { model => model.PrecoDeVenda, view => view.txtPrecoDeVenda },
                    { model => model.PorcentagemDeLucro, view => view.txtPorcentagemLucro }
                });
        }

        public IList<Inconsistencia> Salve()
        {
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                return servicoDeProduto.Salve((Produto)Model, View.TipoDeForm);
            }
        }
    }
}
