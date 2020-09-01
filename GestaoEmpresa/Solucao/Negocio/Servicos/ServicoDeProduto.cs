using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToExcel;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.UnidadeIntelbras;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos.Base;
using GS.GestaoEmpresa.Solucao.Negocio.Validador;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.UI;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.Negocio.Servicos
{
    public class ServicoDeProduto : ServicoHistoricoPadrao<Produto, ValidadorDeProduto, RepositorioDeProduto>, IDisposable
    {
        #region Default Implementation

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
            PrecoDistribuidor = x.PrecoDistribuidor,
            PrecoSugeridoConsumidorFinal = x.PrecoSugeridoConsumidorFinal,
            QuantidadeEmEstoque = x.QuantidadeEmEstoque,
            Status = x.Status
        };

        private static readonly Expression<Func<Produto, object>>[] DefaultPropertiesToSearch =
            { x => x.Nome, x => x.Codigo, x => x.CodigoDoFabricante, x => x.Fabricante };

        public List<Produto> ConsulteTodosParaAterrissagem(
            Expression<Func<Produto, bool>> whereFilter = null,
            Expression<Func<Produto, object>> resultSelector = null,
            int takeQuantity = 500,
            string searchTerm = null,
            Expression<Func<Produto, object>>[] propertiesToSearch = null) 
        {
            return Repositorio.ConsulteTodos(whereFilter, resultSelector ?? SeletorProdutoAterrissagem, takeQuantity, searchTerm, propertiesToSearch: propertiesToSearch ?? DefaultPropertiesToSearch)
                //.OrderBy(x  => x.Nome)
                .ToList();
        }

        public override Produto Consulte(int codigo)
        {
            var produto = base.Consulte(codigo);

            return produto;
        }

        public override IList<Inconsistencia> Salve(Produto item, EnumTipoDeForm tipoDeForm)
        {
            if(tipoDeForm == EnumTipoDeForm.Edicao)
            {
                item.QuantidadeEmEstoque = ConsulteQuantidade(item.Codigo).GetValueOrDefault();
            }

            var inconsistencias = base.Salve(item, tipoDeForm);

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

        private List<dynamic> LeiaItensDoXls(string caminhoArquivo)
        {
            const string nomeWorksheet = "Tabela de Preços";
            const int indexLinhaDoCabecalho = 7;
            const int indexUnidade = 1;
            const int indexCodigoDoProduto = 2;
            const int indexNome = 3;
            const int indexUf = 7;
            const int indexIpi = 8;
            const int indexPrecoCompra = 10;
            const int indexPrecoDistribuidor = 12;
            const int indexPscf = 13;

            using (var excelQueryFactory = new ExcelQueryFactory(caminhoArquivo))
            {
                return excelQueryFactory.Worksheet(nomeWorksheet)
                        .Skip(indexLinhaDoCabecalho)
                        .Select(linha => (dynamic)new
                        {
                            Unidade = linha[indexUnidade].ToString().Trim(),
                            CodigoDoProduto = linha[indexCodigoDoProduto].ToString().Trim(),
                            Nome = linha[indexNome].ToString().Trim(),
                            UF = linha[indexUf].ToString().Trim(),
                            Ipi = linha[indexIpi].ToString().Trim(),
                            PrecoDeCompra = linha[indexPrecoCompra].ToString().Trim(),
                            PrecoDistribuidor = linha[indexPrecoDistribuidor].ToString().Trim(),
                            Pscf = linha[indexPscf].ToString().Trim()
                        })
                        .ToList() // Execute query on EQF and enumerate results
                        .Where(x => x.UF.ToString() == "GO") // Get only those from Goias
                        .ToList();
            }
        }

        private void SetupProgressBar(FrmEstoque caller)
        {
            caller.Invoke((MethodInvoker)delegate
            {
                caller.button1.Enabled = false;

                caller.metroProgressImportar.Visible = true;
                caller.metroProgressImportar.Value = 1;

                caller.txtQtyProgresso.Visible = true;
                caller.txtCronometroImportar.Visible = true;

                caller.txtQtyProgresso.Text = "Lendo planilha";
            });
        }

        private void UpdateProgressBar(ref int totalAdded, int[] items, List<dynamic> totalItems, FrmEstoque caller)
        {
            totalAdded++;

            var text = $"{totalAdded}/{totalItems.Count}";
            caller.Invoke((MethodInvoker)delegate { caller.txtQtyProgresso.Text = text; });

            if (totalAdded.IsAny(items))
            {
                caller.Invoke((MethodInvoker)delegate { caller.metroProgressImportar.Value += 1; });
            }
        }

        public Tuple<int, int> ImportePlanilhaIntelbras(string caminhoArquivo, FrmEstoque caller)
        {
            var repositorioDeProduto = new RepositorioDeProduto();

            SetupProgressBar(caller);

            var configuracao = new RepositorioDeConfiguracao().ObtenhaUnica();

            var importedItems = LeiaItensDoXls(caminhoArquivo);
            var progressRange = GSExtensions.GetProgressRange(importedItems.Count);
            var persistedItems = repositorioDeProduto.ConsulteTodos(takeQuantity: int.MaxValue);

            var totalAdded = 0;

            var concurrentQueue = new ConcurrentQueue<dynamic>(importedItems
                .Where(x => !((object)x).AnyPropertyIsNull())
                .Distinct()
                .ToList());

            var itemsToAdd = new ConcurrentBag<Produto>();
            var itemsToUpdate = new ConcurrentBag<Produto>();
            
            var KeepRunningTask = true;
            GSExtensions.ParallelWhile(() => KeepRunningTask, () =>
            {
                KeepRunningTask = concurrentQueue.TryDequeue(out var item);
                if(!KeepRunningTask)
                {
                    return;
                }

                UpdateProgressBar(ref totalAdded, progressRange, importedItems, caller);

                if (((string)item.PrecoDeCompra).IsAny("R$ -", "-") ||
                    ((string)item.PrecoDistribuidor).IsAny("R$ -", "-"))
                {
                    return;
                }

                var codigoDoProdutoIntelbras = (string)item.CodigoDoProduto;
                
                var produtoPersistido = persistedItems.FirstOrDefault(x => x.CodigoDoFabricante == codigoDoProdutoIntelbras.Trim());
                if (produtoPersistido != null)
                {
                    if (produtoPersistido.PrecoNaIntelbras == ((string)item.PrecoDeCompra).ObtenhaMonetario() &&
                        produtoPersistido.Ipi == Convert.ToDecimal(((string)item.Ipi).Replace("%", string.Empty)))
                    {
                        return;
                    }

                    PreenchaProduto(produtoPersistido, item, configuracao);
                    itemsToUpdate.Add(produtoPersistido);

                    return;
                }

                itemsToAdd.Add(ObtenhaNovoProduto(item, configuracao));
            });

            if(itemsToAdd.Any())
            {
                repositorioDeProduto.MassInsert(itemsToAdd.ToList());
            }

            if (itemsToUpdate.Any())
            {
                repositorioDeProduto.MassUpdate(itemsToUpdate.ToList());
            }

            return new Tuple<int, int>(itemsToUpdate.Count, itemsToAdd.Count);
        }

        private static void PreenchaProduto(Produto produtoPersistido, dynamic item, Configuracoes configuracao)
        {
            produtoPersistido.Nome = item.Nome;
            produtoPersistido.Fabricante = "Intelbras";
            produtoPersistido.Unidade = UnidadeIntelbras.ObtenhaPorNome(item.Unidade);
            produtoPersistido.PrecoNaIntelbras = GSExtensions.ObtenhaMonetario(item.PrecoDeCompra);
            produtoPersistido.Ipi = ((string)item.Ipi).Replace("%", string.Empty).ToDecimal();
            produtoPersistido.CalculePrecoDeCompraComBaseNoPrecoDaIntelbras();
            produtoPersistido.CalculePrecoDeVenda();
            produtoPersistido.CalculePrecoDeVendaDistribuidor();
            produtoPersistido.PrecoDistribuidor = GSExtensions.ObtenhaMonetario(item.PrecoDistribuidor);
            produtoPersistido.PrecoSugeridoConsumidorFinal = GSExtensions.ObtenhaMonetario(item.Pscf);
        }

        private static Produto ObtenhaNovoProduto(dynamic item, Configuracoes configuracao)
        {
            var novoProduto = new Produto
            {
                Nome = ((string)item.Nome).ToCustomTitleCase(),
                Fabricante = "Intelbras",
                Status = EnumStatusToggle.Ativo,
                CodigoDoFabricante = ((string)item.CodigoDoProduto).Trim(),
                Unidade = UnidadeIntelbras.ObtenhaPorNome(item.Unidade),
                PrecoNaIntelbras = GSExtensions.ObtenhaMonetario(item.PrecoDeCompra),
                Ipi = ((string)item.Ipi).Replace("%", string.Empty).ToDecimal(),
                PrecoDistribuidor = GSExtensions.ObtenhaMonetario(item.PrecoDistribuidor),
                PorcentagemDeLucro = configuracao.PorcentagemDeLucroPadrao,
                PrecoSugeridoConsumidorFinal = GSExtensions.ObtenhaMonetario(item.Pscf),
                PorcentagemDeLucroDistribuidor = 30.0M
        };

            novoProduto.CalculePrecoDeCompraComBaseNoPrecoDaIntelbras();
            novoProduto.CalculePrecoDeVenda();
            novoProduto.CalculePrecoDeVendaDistribuidor();

            return novoProduto;
        }
    }
}       
