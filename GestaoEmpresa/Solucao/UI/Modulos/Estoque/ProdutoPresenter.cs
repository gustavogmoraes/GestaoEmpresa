using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.UI.Base;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public class ProdutoPresenter : Presenter<frmProdutoMetro>
    {
        public ProdutoPresenter()
        {
            MapeieControles<Produto>(
                new Dictionary<Expression<Func<Produto, object>>, Expression<Func<frmProdutoMetro, Control>>>
                {
                    { model => model.Codigo, view => view.txtCodigo },
                    { model => model.Nome, view => view.txtNome }
                });
        }
    }
}
