using System;
using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Validador;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos.Base;
using GS.GestaoEmpresa.Solucao.UI;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using System.Linq;

namespace GS.GestaoEmpresa.Solucao.Negocio.Servicos
{
    public class ServicoDeProduto : ServicoHistoricoPadrao<Produto, ValidadorDeProduto, RepositorioDeProduto>, IDisposable
    {
        #region Implementação padrão

        protected override Action AcaoSucessoValidacaoDeCadastro(Produto produto)
        {
            return () => 
            { 
                produto.QuantidadeEmEstoque = 0;
            };
        }

        protected override Action AcaoSucessoValidacaoDeEdicao(Produto item)
        {
            return null;
        }

        protected override Action AcaoSucessoValidacaoDeExclusao(int codigo)
        {
            return null;
        }

        #endregion

        public int ConsulteQuantidade(int codigo)
        {
            using (var repositorioDeProduto = new RepositorioDeProduto())
            {
                return repositorioDeProduto.ConsulteQuantidade(codigo);
            }
        }

        public void AltereQuantidadeDeProduto(int codigoDoProduto, int novaQuantidade)
        {
            using (var repositorioDeProduto = new RepositorioDeProduto())
            {
                repositorioDeProduto.AltereQuantidadeDeProduto(codigoDoProduto, novaQuantidade);

                var formEstoque = GerenciadorDeViews.ObtenhaIndependente<frmEstoque>();
                if (formEstoque == null) return;

                var produto = Consulte(codigoDoProduto);
                formEstoque.RecarregueProdutoEspecifico(produto);
            }
        }

        public List<Produto> ConsulteTodosParaAterrissagem()
        {
            return Repositorio.ConsulteTodos(seletor: x => new Produto
            {
                Codigo = x.Codigo,
                CodigoDoFabricante = x.CodigoDoFabricante,
                Nome = x.Nome,
                Observacao = x.Observacao,
                PrecoDeCompra = x.PrecoDeCompra,
                PrecoDeVenda = x.PrecoDeVenda,
                QuantidadeEmEstoque = x.QuantidadeEmEstoque,
                Status = x.Status
            })
            .OrderBy(x => x.Nome)
            .ToList();
        }

        public override Produto Consulte(int codigo)
        {
            var produto = base.Consulte(codigo);
            produto.PorcentagemDeLucro *= 100;

            return produto;
        }

        public override IList<Inconsistencia> Salve(Produto item, EnumTipoDeForm tipoDeForm)
        {
            item.PorcentagemDeLucro /= 100;

            var inconsistencias = base.Salve(item, tipoDeForm);

            item.PorcentagemDeLucro *= 100;

            return inconsistencias;
        }
    }
}       
