using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.UI.Base;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public class ProdutoPresenter : Presenter<Produto, frmProdutoMetro>
    {
        protected override Dictionary<Expression<Func<Produto, object>>, Expression<Func<frmProdutoMetro, Control>>> MapeamentoDeControles => 
            new Dictionary<Expression<Func<Produto, object>>, Expression<Func<frmProdutoMetro, Control>>>
            {
                { model => model.Codigo, view => view.txtCodigo },
                { model => model.Nome, view => view.txtNome }
            };
    }
}
