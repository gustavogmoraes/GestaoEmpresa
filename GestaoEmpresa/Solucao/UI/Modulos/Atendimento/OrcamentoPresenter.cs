using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Orcamento;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento
{
    public sealed class OrcamentoPresenter : Presenter<Orcamento, FrmOrcamento>
    {
        

        public OrcamentoPresenter()
        {
            MapeieControle(view => view.Cliente.Nome, view => view.txtNomeCliente);
        }

        public void ConsulteEPreenchaGridDeProdutos(string searchTerm)
        {
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                var produtosPesquisados = servicoDeProduto.ConsulteTodosParaAterrissagem(searchTerm, model => model.Nome, model => model.CodigoDoFabricante, model => model.Codigo);
                View.Invoke((MethodInvoker) delegate
                {
                    produtosPesquisados.ForEach(x => View.dgvItensPesquisa.Rows.Add(ObtenhaItemGridProdutoPesquisa(x)));
                });
                
            }
        }

        private int ObtenhaNovoSequencial()
        {
            if (Model.Itens == null || !Model.Itens.Any())
            {
                return 1;
            }

            var allSequetials = Model.Itens
                .Select(x => x.Sequencial)
                .ToList();

            var leapSequencial = allSequetials.EncontreInteirosFaltandoEmUmaSequencia().FirstOrDefault();
            return leapSequencial != 0
                ? leapSequencial
                : allSequetials.Max() + 1;
        }

        public void AdicioneProdutoOrcado(int codigo)
        {
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                var produto = servicoDeProduto.Consulte(codigo);
                var sequencial = ObtenhaNovoSequencial();

                if (Model.Itens == null)
                {
                    Model.Itens = new List<ItemOrcamento>();
                }

                Model.Itens.Add(new ItemOrcamento
                {
                    Tipo = TipoDeItemOrcamento.Produto,
                    Sequencial = sequencial,
                    Produto = produto,
                    Quantidade = 1,
                    ValorUnitario = produto.PrecoDeCompra
                });

                View.dgvProdutosOrcados.Rows.Add(ObtenhaItemGridProdutoOrcado(sequencial, produto));
            }
        }

        private void SincronizeItensListaDoModelComGrid()
        {

        }

        private static object[] ObtenhaItemGridProdutoOrcado(int sequencial, Produto produto)
        {
            var quantidade = 1;

            return new object[]
            {
                produto.Codigo,
                sequencial,
                quantidade,
                produto.Nome,
                produto.PrecoDeVenda.ToMonetaryString(),
                (produto.PrecoDeVenda * quantidade).ToMonetaryString()
            };
        }

        private static object[] ObtenhaItemGridProdutoPesquisa(Produto produto)
        {
            return new object[]
            {
                produto.Codigo,
                produto.Nome,
                produto.CodigoDoFabricante,
                produto.PrecoDeCompra.ToMonetaryString(),
                produto.PrecoDeVenda.ToMonetaryString(),
            };
        }
    }
}
