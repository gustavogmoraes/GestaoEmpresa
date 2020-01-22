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
using OfficeOpenXml;

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

        private Expression<Func<Produto, object>> SeletorProdutoAterrissagem => x => new Produto
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

        public Produto Consulte(Expression<Func<Produto, bool>> filtro)
        {
            using (var repositorioDeProduto = new RepositorioDeProduto())
            {
                return repositorioDeProduto.Consulte(filtro);
            }
        }

        public Task ImportePlanilhaIntelbras(string caminhoArquivo)
        {
            const string nomeWorksheet = "Tabela de Preços";
            const int indexUnidade = 1;
            const int indexCodigoDoProduto = 2;
            const int indexNome = 3;
            const int indexUf = 7;
            const int indexIpi = 8;
            const int indexPrecoCompra = 10;
            const int indexPrecoRevenda = 11;

            using (var excelQueryFactory = new ExcelQueryFactory(caminhoArquivo))
            {
                var worksheet = excelQueryFactory.Worksheet(nomeWorksheet);
                var items = worksheet.Skip(7).Select(x => new
                {
                    Unidade = x[indexUnidade],
                    CodigoDoProduto = x[indexCodigoDoProduto],
                    Nome = x[indexNome],
                    UF = x[indexUf],
                    Ipi = x[indexIpi],
                    PrecoDeCompra = x[indexPrecoCompra],
                    PrecoRevenda = x[indexPrecoRevenda]
                }).ToList()
                    .Where(x => ((string)x.UF).Trim() == "GO")
                    .Distinct()
                    .ToList();

                var repositorioDeProduto = new RepositorioDeProduto();
                var repositorioDeConfiguracoes = new RepositorioDeConfiguracao();

                var configuracao = repositorioDeConfiguracoes.ObtenhaUnica();

                items.ForEach(item =>
                {
                    var produtoPersistido = repositorioDeProduto.Consulte(x =>
                        x.CodigoDoFabricante == item.CodigoDoProduto.Value.ToString().Trim());

                    if (produtoPersistido != null)
                    {
                        produtoPersistido.Nome = item.Nome.Value.ToString();
                        produtoPersistido.Fabricante = "Intelbras";
                        produtoPersistido.Unidade = UnidadeIntelbras.ObtenhaPorNome(item.Unidade.Value.ToString());
                        produtoPersistido.PrecoNaIntelbras = Convert.ToDecimal(item.PrecoDeCompra.Value.ToString().Replace("R$ ", string.Empty));
                        produtoPersistido.Ipi = Convert.ToDecimal(item.Ipi.Value.ToString().Replace("%", string.Empty)) / 100;
                        produtoPersistido.PrecoDeCompra = produtoPersistido.PrecoNaIntelbras +
                                                          (produtoPersistido.PrecoNaIntelbras * produtoPersistido.Ipi) +
                                                          (produtoPersistido.PrecoNaIntelbras * configuracao.PorcentagemImpostoProtege);

                        produtoPersistido.CalculePrecoDeVenda();

                        produtoPersistido.PrecoSugeridoRevenda = Convert.ToDecimal(item.PrecoRevenda.Value.ToString().Replace("R$ ", string.Empty));

                        repositorioDeProduto.Atualize(produtoPersistido);

                        return;
                    }

                    var novoProduto = new Produto
                    {
                        Nome = item.Nome.Value.ToString().Trim().ToCustomTitleCase(),
                        Fabricante = "Intelbras",
                        Status = EnumStatusToggle.Ativo,
                        CodigoDoFabricante = item.CodigoDoProduto.Value.ToString().Trim(),
                        Unidade = UnidadeIntelbras.ObtenhaPorNome(item.Unidade.Value.ToString()),
                        PrecoNaIntelbras = Convert.ToDecimal(item.PrecoDeCompra.Value.ToString().Replace("R$ ", string.Empty)),
                        Ipi = Convert.ToDecimal(item.Ipi.Value.ToString().Replace("%", string.Empty)) / 100,
                        PrecoSugeridoRevenda = Convert.ToDecimal(item.PrecoRevenda.Value.ToString().Replace("R$ ", string.Empty)),
                        PorcentagemDeLucro = configuracao.PorcentagemDeLucroPadrao
                    };

                    novoProduto.PrecoDeCompra = novoProduto.PrecoNaIntelbras +
                                                (novoProduto.PrecoNaIntelbras * novoProduto.Ipi) +
                                                (novoProduto.PrecoNaIntelbras * configuracao.PorcentagemImpostoProtege);

                    novoProduto.CalculePrecoDeVenda();

                    repositorioDeProduto.Insira(novoProduto);
                });
            }

            return Task.CompletedTask;
        }
    }
}       
