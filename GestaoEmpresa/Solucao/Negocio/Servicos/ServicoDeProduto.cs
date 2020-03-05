using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            PrecoNaIntelbras =  x.PrecoNaIntelbras,
            PrecoSugeridoRevenda = x.PrecoSugeridoRevenda,
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

        public static void KeepTimeRunning(Stopwatch stopwatch, Form form, Label label)
        {
            Task.Run(() =>
            {
                while (stopwatch.IsRunning)
                {
                    form.Invoke((MethodInvoker)delegate
                    {
                        label.Text = stopwatch.Elapsed.ToString("g").Substring(2, 5);
                    });

                    Thread.Sleep(250);
                }
            });
        }

        public void ImportePlanilhaIntelbras(string caminhoArquivo, FrmEstoque caller)
        {
            //var allLatest = new List<Produto>();
            //using (var session = RavenHelper.OpenSession())
            //{
            //    var allLatestProducts =
            //        session.Query<Produto>().Where(x =>
            //            x.Atual &&
            //            x.Fabricante == "Intelbras" &&
            //            !string.IsNullOrEmpty(x.CodigoDoFabricante)).ToList();

            //    allLatest.AddRange(allLatestProducts);

            //    session.Query<Produto>().Where(x =>
            //        x.Fabricante == "Intelbras" &&
            //            !string.IsNullOrEmpty(x.CodigoDoFabricante)).ToList().ForEach(y =>
            //            session.Delete(y));
            //    session.SaveChanges();
            //}

            caller.Invoke((MethodInvoker) delegate
            {
                caller.button1.Enabled = false;

                caller.metroProgressImportar.Visible = true;
                caller.metroProgressImportar.Value = 1;

                caller.txtQtyProgresso.Visible = true;
                caller.txtCronometroImportar.Visible = true;

                caller.txtQtyProgresso.Text = "Lendo planilha";
            });
            //

            const string nomeWorksheet = "Tabela de Preços";
            const int indexLinhaDoCabecalho = 7;
            const int indexUnidade = 1;
            const int indexCodigoDoProduto = 2;
            const int indexNome = 3;
            const int indexUf = 7;
            const int indexIpi = 8;
            const int indexPrecoCompra = 10;
            const int indexPrecoRevenda = 12;
            const int indexPscf = 13;

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
                        PrecoRevenda = linha[indexPrecoRevenda].ToString().Trim(),
                        Pscf = linha[indexPscf].ToString().Trim()
                    })
                    .ToList() // Execute query on EQF and enumerate results
                    .Where(x => x.UF.ToString() == "GO") // Get only those from Goiás
                    .ToList();

                // Progress bar
                var totalAdded = 0;

                var items = GSExtensions.GetProgressRange(totalItems.Count);
                //

                totalItems.Where(x => !x.AnyPropertyIsNull())
                    .Distinct()
                    .ForEach(item =>
                    {
                        // Progress bar reactivity
                        totalAdded ++;
                        caller.Invoke((MethodInvoker)delegate { caller.txtQtyProgresso.Text = $"{totalAdded}/{totalItems.Count}"; });

                        if (totalAdded.IsAny(items))
                        {
                            caller.Invoke((MethodInvoker) delegate {caller.metroProgressImportar.Value += 1;});
                        }
                        //

                        if (item.PrecoDeCompra.IsAny("R$ -", "-") || 
                            item.PrecoRevenda.IsAny("R$ -", "-"))
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

                            var novoProduto = ObtenhaNovoProduto(item, configuracao/*, allLatest*/);
                            repositorioDeProduto.Insira(novoProduto);
                        }
                    });
            }
        }

        private static void PreenchaProduto(Produto produtoPersistido, dynamic item, Configuracoes configuracao)
        {
            produtoPersistido.Nome = item.Nome;
            produtoPersistido.Fabricante = "Intelbras";
            produtoPersistido.Unidade = UnidadeIntelbras.ObtenhaPorNome(item.Unidade);
            produtoPersistido.PrecoNaIntelbras = GSExtensions.ObtenhaMonetario(item.PrecoDeCompra);
            produtoPersistido.Ipi = ((string)item.Ipi).Replace("%", string.Empty).ToDecimal().DivideBy(100);
            produtoPersistido.PrecoDeCompra = produtoPersistido.PrecoNaIntelbras +
                                                produtoPersistido.PrecoNaIntelbras * produtoPersistido.Ipi +
                                              produtoPersistido.PrecoNaIntelbras * CalculeValorDoProtege(produtoPersistido.Ipi);

            produtoPersistido.CalculePrecoDeVenda();

            produtoPersistido.PrecoSugeridoRevenda = GSExtensions.ObtenhaMonetario(item.PrecoRevenda);
            produtoPersistido.PrecoSugeridoConsumidorFinal = GSExtensions.ObtenhaMonetario(item.Pscf);
            produtoPersistido.Lucro2 = Convert.ToDecimal(0.30);
        }

        private static decimal CalculeValorDoProtege(decimal ipi)
        {
            switch (ipi)
            {
                case 4 / 100M:
                    return 7.87M / 100M;

                case 7 / 100M:
                case 12 / 100M:
                    return 4.49M / 100M;

                default:
                    return 4.49M / 100M;
            }
        }

        private static Produto ObtenhaNovoProduto(dynamic item, Configuracoes configuracao/*, List<Produto> latestProducts*/)
        {
            var novoProduto = new Produto
            {
                Nome = ((string)item.Nome).ToCustomTitleCase(),
                Fabricante = "Intelbras",
                Status = EnumStatusToggle.Ativo,
                CodigoDoFabricante = item.CodigoDoProduto,
                Unidade = UnidadeIntelbras.ObtenhaPorNome(item.Unidade),
                PrecoNaIntelbras = GSExtensions.ObtenhaMonetario(item.PrecoDeCompra),
                Ipi = ((string)item.Ipi).Replace("%", string.Empty).ToDecimal().DivideBy(100),
                PrecoSugeridoRevenda = GSExtensions.ObtenhaMonetario(item.PrecoRevenda),
                PorcentagemDeLucro = configuracao.PorcentagemDeLucroPadrao
            };
            
            novoProduto.PrecoDeCompra = novoProduto.PrecoNaIntelbras +
                                        novoProduto.PrecoNaIntelbras * novoProduto.Ipi +
                                        novoProduto.PrecoNaIntelbras * CalculeValorDoProtege(novoProduto.Ipi);

            novoProduto.PrecoSugeridoConsumidorFinal = GSExtensions.ObtenhaMonetario(item.Pscf);
            novoProduto.Lucro2 = Convert.ToDecimal(0.30);

            novoProduto.CalculePrecoDeVenda();

            novoProduto.CalculePrecoDeVendaConsumidor();

            //novoProduto.Atual = true;
            //var latestThis = latestProducts.FirstOrDefault(x => x.CodigoDoFabricante == novoProduto.CodigoDoFabricante);

            //novoProduto.QuantidadeEmEstoque = latestThis.QuantidadeEmEstoque;
            //novoProduto.QuantidadeMinimaParaAviso = latestThis.QuantidadeMinimaParaAviso;
            //novoProduto.Observacao = latestThis.Observacao;
            //novoProduto.Vigencia = DateTime.Now;

            return novoProduto;
        }
    }
}       
