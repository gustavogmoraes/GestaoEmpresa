using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public class EstoquePresenter : Presenter<frmEstoque>
    {
        public void RecarregueProdutoEspecifico(Produto produto)
        {
            GerenciadorDeViews.Obtenha<EstoquePresenter>().View.RecarregueProdutoEspecifico(produto);
        }

        public void AdicioneNovoProdutoNaGrid(Produto produto)
        {
            GerenciadorDeViews.Obtenha<EstoquePresenter>().View.AdicioneNovoProdutoNaGrid(produto);
        }
    }
}
