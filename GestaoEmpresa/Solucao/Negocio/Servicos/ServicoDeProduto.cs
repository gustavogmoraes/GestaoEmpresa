using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Validador;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos.Base;
using GS.GestaoEmpresa.Solucao.UI;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.UnidadeIntelbras;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using LinqToExcel;
using LinqToExcel.Domain;
using MoreLinq;
using OfficeOpenXml;

namespace GS.GestaoEmpresa.Solucao.Negocio.Servicos
{
    public class ServicoDeProduto : ServicoHistoricoPadrao<Produto, ValidadorDeProduto, RepositorioDeProduto>, IDisposable
    {
        #region Implementa��o padr�o

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

        public int? ConsulteQuantidade(int codigo)
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

                var formEstoque = GerenciadorDeViews.ObtenhaIndependente<FrmEstoque>();
                if (formEstoque == null) return;

                var produto = Consulte(codigoDoProduto);
                formEstoque.RecarregueProdutoEspecifico(produto);
            }
        }

        private static Expression<Func<Produto, object>> SeletorProdutoAterrissagem => x => new Produto
        {
            Codigo = x.Codigo,
            CodigoDoFabricante = x.CodigoDoFabricante,
            Nome = x.Nome,
            Observacao = x.Observacao,
            PrecoDeCompra = x.PrecoDeCompra,
            PrecoDeVenda = x.PrecoDeVenda,
            QuantidadeEmEstoque = x.QuantidadeEmEstoque,
            Status = x.Status
        };

        public List<Produto> ConsulteTodosParaAterrissagem()
        {
            return Repositorio.ConsulteTodos(SeletorProdutoAterrissagem)
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public List<Produto> ConsulteTodosParaAterrissagem(Expression<Func<Produto, bool>> filtro)
        {
            return Repositorio.ConsulteTodos(SeletorProdutoAterrissagem, filtro)
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public List<Produto> ConsulteTodosParaAterrissagem(Expression<Func<Produto, object>> propriedade, string pesquisa)
        {
            return Repositorio.ConsulteTodos(SeletorProdutoAterrissagem, propriedade, pesquisa)
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public List<Produto> ConsulteTodosParaAterrissagem(string pesquisa, params Expression<Func<Produto, object>>[] propriedades) 
        {
            return Repositorio.ConsulteTodos(SeletorProdutoAterrissagem, pesquisa, propriedades).ToList();
        }

        public override Produto Consulte(int codigo)
        {
            var produto = base.Consulte(codigo);
            produto.PorcentagemDeLucro *= 100;
            produto.Ipi *= 100;

            return produto;
        }

        public override IList<Inconsistencia> Salve(Produto item, EnumTipoDeForm tipoDeForm)
        {
            item.PorcentagemDeLucro /= 100;
            item.Ipi /= 100;

            var inconsistencias = base.Salve(item, tipoDeForm);

            item.PorcentagemDeLucro *= 100;
            item.Ipi *= 100;

            return inconsistencias;
        }

        public Produto Consulte(Expression<Func<Produto, bool>> filtro)
        {
            using (var repositorioDeProduto = new RepositorioDeProduto())
            {
                return repositorioDeProduto.Consulte(filtro);
            }
        }

        public void ImportePlanilhaIntelbras(string caminhoArquivo)
        {
            const string nomeWorksheet = "Tabela de Pre�os";
            const int indexLinhaDoCabecalho = 7;
            const int indexUnidade = 1;
            const int indexCodigoDoProduto = 2;
            const int indexNome = 3;
            const int indexUf = 7;
            const int indexIpi = 8;
            const int indexPrecoCompra = 10;
            const int indexPrecoRevenda = 12;

            using (var excelQueryFactory = new ExcelQueryFactory(caminhoArquivo))
            {
                var configuracao = new RepositorioDeConfiguracao().ObtenhaUnica();

                var totalItems =
                excelQueryFactory.Worksheet(nomeWorksheet)
                    .Skip(indexLinhaDoCabecalho)
                    .Select(linha => new
                    {
                        Unidade = linha[indexUnidade].ToString().Trim(),
                        CodigoDoProduto = linha[indexCodigoDoProduto].ToString().Trim(),
                        Nome = linha[indexNome].ToString().Trim(),
                        UF = linha[indexUf].ToString().Trim(),
                        Ipi = linha[indexIpi].ToString().Trim(),
                        PrecoDeCompra = linha[indexPrecoCompra].ToString().Trim(),
                        PrecoRevenda = linha[indexPrecoRevenda].ToString().Trim()
                    })
                    .ToList(); // Execute query on EQF and enumerate results

                totalItems.Where(x => x.UF == "GO" && !x.AnyPropertyIsNull())
                    .Distinct()
                    .ForEach(item =>
                    {
                        if (item.PrecoDeCompra == "R$ -" || 
                            item.PrecoRevenda == "R$ -")
                        {
                            return;
                        }

                        using (var repositorioDeProduto = new RepositorioDeProduto(RavenHelper.OpenSession()))
                        {
                            var produtoPersistido = repositorioDeProduto.Consulte(x => x.CodigoDoFabricante == item.CodigoDoProduto);
                            if (produtoPersistido != null)
                            {
                                if (produtoPersistido.PrecoNaIntelbras == item.PrecoDeCompra.ObtenhaMonetario())
                                {
                                    return;
                                }

                                PreenchaProduto(produtoPersistido, item, configuracao);
                                repositorioDeProduto.Atualize(produtoPersistido);

                                return;
                            }

                            var novoProduto = ObtenhaNovoProduto(item, configuracao);
                            repositorioDeProduto.Insira(novoProduto);
                        }
                    });
            }
        }

        private static void PreenchaProduto(Produto produtoPersistido, dynamic item, Configuracoes configuracao)
        {
            produtoPersistido.Nome = item.Nome.Value.ToString();
            produtoPersistido.Fabricante = "Intelbras";
            produtoPersistido.Unidade = UnidadeIntelbras.ObtenhaPorNome(item.Unidade.Value.ToString());
            produtoPersistido.PrecoNaIntelbras = GSExtensions.ObtenhaMonetario(item.PrecoDeCompra);
            produtoPersistido.Ipi = Convert.ToDecimal((string) item.Ipi.Value.ToString().Replace("%", string.Empty)) / 100;
            produtoPersistido.PrecoDeCompra = produtoPersistido.PrecoNaIntelbras +
                                                produtoPersistido.PrecoNaIntelbras * produtoPersistido.Ipi +
                                              produtoPersistido.PrecoNaIntelbras * configuracao.PorcentagemImpostoProtege;

            produtoPersistido.CalculePrecoDeVenda();

            produtoPersistido.PrecoSugeridoRevenda = GSExtensions.ObtenhaMonetario(item.PrecoRevenda);
        }

        private static Produto ObtenhaNovoProduto(dynamic item, Configuracoes configuracao)
        {
            var novoProduto = new Produto
            {
                Nome = GSExtensions.ToCustomTitleCase(item.Nome.Value.ToString().Trim()),
                Fabricante = "Intelbras",
                Status = EnumStatusToggle.Ativo,
                CodigoDoFabricante = item.CodigoDoProduto.Value.ToString().Trim(),
                Unidade = UnidadeIntelbras.ObtenhaPorNome(item.Unidade.Value.ToString()),
                PrecoNaIntelbras = GSExtensions.ObtenhaMonetario(item.PrecoDeCompra),
                Ipi = Convert.ToDecimal((string) item.Ipi.Value.ToString().Replace("%", string.Empty)) / 100,
                PrecoSugeridoRevenda = GSExtensions.ObtenhaMonetario(item.PrecoRevenda),
                PorcentagemDeLucro = configuracao.PorcentagemDeLucroPadrao
            };

            novoProduto.PrecoDeCompra = novoProduto.PrecoNaIntelbras +
                                        (novoProduto.PrecoNaIntelbras * novoProduto.Ipi) +
                                        (novoProduto.PrecoNaIntelbras *
                                         configuracao.PorcentagemImpostoProtege);

            novoProduto.CalculePrecoDeVenda();

            return novoProduto;
        }
    }
}       
