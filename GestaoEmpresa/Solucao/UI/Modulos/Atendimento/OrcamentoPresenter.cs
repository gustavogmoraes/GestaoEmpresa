#region Usings

using System.Linq.Expressions;
using Remotion.Utilities;

#region Core

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

#endregion

#region Ours

using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Orcamento;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using System;

#endregion

#endregion

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento
{
    public sealed class OrcamentoPresenter : Presenter<Orcamento, FrmOrcamento>
    {
        //#region Constructors

        //public OrcamentoPresenter()
        //{
        //    //MapControl(view => view.Cliente.Nome, view => view.txtNomeCliente);
        //}

        //#endregion

        //#region Private Methods

        //private int ObtenhaNovoSequencial()
        //{
        //    if (Model.Itens == null || !Model.Itens.Any())
        //    {
        //        return 1;
        //    }

        //    var allSequetials = Model.Itens
        //        .Select(x => x.Sequencial)
        //        .ToList();

        //    var leapSequencial = allSequetials.EncontreInteirosFaltandoEmUmaSequencia().FirstOrDefault();
        //    return leapSequencial != 0
        //        ? leapSequencial
        //        : allSequetials.Max() + 1;
        //}

        //private static object[] ObtenhaItemGridProdutoOrcado(int sequencial, Produto produto)
        //{
        //    var quantidade = 1;

        //    return new object[]
        //    {
        //        produto.Codigo,
        //        sequencial,
        //        quantidade,
        //        produto.Nome,
        //        produto.PrecoDeVenda.HasValue ? produto.PrecoDeVenda.GetValueOrDefault().ToMonetaryString() : string.Empty,
        //        produto.PrecoDeVenda.HasValue ? (produto.PrecoDeVenda.GetValueOrDefault() * quantidade).ToMonetaryString() : string.Empty
        //    };
        //}

        //private static object[] ObtenhaItemGridProdutoPesquisa(Produto produto)
        //{
        //    return new object[]
        //    {
        //        produto.Codigo,
        //        produto.Nome,
        //        produto.CodigoDoFabricante,
        //        produto.PrecoDeCompra.HasValue ? produto.PrecoDeCompra.GetValueOrDefault().ToMonetaryString() : string.Empty,
        //        produto.PrecoDeVenda.HasValue ? produto.PrecoDeVenda.GetValueOrDefault().ToMonetaryString() : string.Empty,
        //    };
        //}

        //#endregion

        //#region Public Methods

        //public void ConsulteEPreenchaGridDeProdutos(string searchTerm)
        //{
        //    using (var servicoDeProduto = new ServicoDeProduto())
        //    {
        //        var produtosPesquisados = servicoDeProduto.QueryForLandingPage(
        //            searchTerm: searchTerm, 
        //            propertiesToSearch: new Expression<Func<Produto, object>>[] { model => model.Nome, model => model.CodigoDoFabricante, model => model.Codigo});
        //        View.Invoke((MethodInvoker)delegate
        //        {
        //            View.dgvItensPesquisa.Rows.Clear();
        //            produtosPesquisados.ForEach(x => View.dgvItensPesquisa.Rows.Add(ObtenhaItemGridProdutoPesquisa(x)));
        //        });

        //    }
        //}

        //public void AdicioneProdutoOrcado(int codigo)
        //{
        //    using (var servicoDeProduto = new ServicoDeProduto())
        //    {
        //        var produto = servicoDeProduto.QueryFirst(codigo);
        //        var sequencial = ObtenhaNovoSequencial();

        //        if (Model.Itens == null)
        //        {
        //            Model.Itens = new List<ItemOrcamento>();
        //        }

        //        //Model.Itens.Add(new ItemOrcamento
        //        //{
        //        //    Tipo = TipoDeItemOrcamento.Produto,
        //        //    Sequencial = sequencial,
        //        //    Produto = produto,
        //        //    Quantidade = 1,
        //        //    ValorUnitario = produto.PrecoDeVenda
        //        //});

        //        View.dgvProdutosOrcados.Rows.Add(ObtenhaItemGridProdutoOrcado(sequencial, produto));
        //    }

        //    RefreshGrids();
        //}

        //public void RemovaProdutoOrcado(int sequencial)
        //{
        //    var rowsEnumerable = View.dgvProdutosOrcados.Rows.OfType<DataGridViewRow>();

        //    var row = rowsEnumerable.FirstOrDefault(x => x.Cells[0].Value.ToInt32() == sequencial);
        //    if (row != null)
        //    {
        //        View.dgvProdutosOrcados.Rows.RemoveAt(row.Index);
        //    }

        //    RefreshGrids();
        //}

        //public void RefreshGrids()
        //{

        //}

        //public void RecalculeProdutoOrcado(int rowIndex)
        //{
        //    //View.dgvProdutosOrcados.Rows[rowIndex].
        //}

        //#endregion
    }
}
