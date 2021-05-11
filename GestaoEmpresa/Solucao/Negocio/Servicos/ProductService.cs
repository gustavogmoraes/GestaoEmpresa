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
    public class ProductService : BaseServiceWithRevision<Produto, ProductValidator, RepositorioDeProduto>, IDisposable
    {
        #region Default Implementation

        protected override Action AcaoSucessoValidacaoDeCadastro(Produto produto) => () =>
        {
            using var session = RavenHelper.OpenSession();
            session.Store(new ProdutoQuantidade { Codigo = produto.Codigo, Quantidade = 0 });
            session.SaveChanges();
        };

        protected override Action AcaoSucessoValidacaoDeEdicao(Produto item)
        {
            return null;
        }

        protected override Action AcaoSucessoValidacaoDeExclusao(int codigo) => () =>
        {
            using var session = RavenHelper.OpenSession();
            var produtoQtd = session.Query<ProdutoQuantidade>()
                .Where(x => x.Codigo == codigo)
                .ToList();

            produtoQtd.ForEach(session.Delete);

            session.SaveChanges();
        };

        #endregion

        public int ConsulteQuantidade(int codigo)
        {
            using var repositorioDeProduto = new RepositorioDeProduto();
            return repositorioDeProduto.ConsulteQuantidade(codigo);
        }

        public Dictionary<int, int> ConsulteQuantidade(IList<int> codigos)
        {
            using (var repositorioDeProduto = new RepositorioDeProduto())
            {
                return repositorioDeProduto.ConsulteQuantidade(codigos);
            }
        }

        public void AltereQuantidadeDeProduto(int codigoDoProduto, int novaQuantidade)
        {
            using (var repositorioDeProduto = new RepositorioDeProduto())
            {
                repositorioDeProduto.AltereQuantidadeDeProduto(codigoDoProduto, novaQuantidade);

                var formEstoque = GerenciadorDeViews.ObtenhaIndependente<FrmEstoque>();
                if (formEstoque == null) return;

                var produto = QueryFirst(codigoDoProduto);
                formEstoque.RecarregueProdutoEspecifico(produto, ConsulteQuantidade(codigoDoProduto));
            }
        }

        private static Expression<Func<Produto, object>> LandingPageProductSelector => x => new Produto
        {
            Codigo = x.Codigo,
            Fabricante = x.Fabricante,
            CodigoDoFabricante = x.CodigoDoFabricante,
            Nome = x.Nome,
            Observacao = x.Observacao,
            PrecoDeCompra = x.PrecoDeCompra,
            PrecoDeVenda = x.PrecoDeVenda,
            PrecoNaIntelbras =  x.PrecoNaIntelbras,
            PrecoDistribuidor = x.PrecoDistribuidor,
            PrecoSugeridoConsumidorFinal = x.PrecoSugeridoConsumidorFinal,
            PorcentagemDeLucro = x.PorcentagemDeLucro,
            Status = x.Status,
            TambemConhecidoComo = x.TambemConhecidoComo,
            LocalizacaoNoEstoque = x.LocalizacaoNoEstoque
        };

        private static readonly Expression<Func<Produto, object>>[] DefaultPropertiesToSearch =
        {
            x => x.Nome, x=> x.TambemConhecidoComo, x => x.Codigo, 
            x => x.CodigoDoFabricante, x => x.Fabricante, x => x.LocalizacaoNoEstoque
        };

        public List<Produto> QueryForLandingPage(
            out Dictionary<int, int> quantities,
            bool onlyActives = true,
            Expression<Func<Produto, bool>> whereFilter = null,
            Expression<Func<Produto, object>> resultSelector = null,
            int takeQuantity = 500,
            string searchTerm = null,
            Expression<Func<Produto, object>>[] propertiesToSearch = null) 
        {
            var selector = resultSelector ?? LandingPageProductSelector;

            var products = Repositorio.ConsulteTodos(
                onlyActives,
                whereFilter, 
                selector, 
                takeQuantity, 
                searchTerm, 
                propertiesToSearch: propertiesToSearch ?? DefaultPropertiesToSearch)
                .ToList();

            var productsCodes = products.Select(x => x.Codigo).ToList();
            quantities = Repositorio.ConsulteQuantidade(productsCodes);

            return products;
        }

        public override IList<Inconsistencia> Salve(Produto item, EnumTipoDeForm tipoDeForm)
        {
            var inconsistencies = base.Salve(item, tipoDeForm);

            return inconsistencies;
        }

        public Produto QueryFirst(Expression<Func<Produto, bool>> whereFilter)
        {
            using var productRepo = new RepositorioDeProduto();
            return productRepo.Consulte(whereFilter);
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

        private static List<dynamic> ReadXlsItems(string filePath)
        {
            const string nomeWorksheet = "Tabela de Preços";
            const int indexLinhaDoCabecalho = 6;

            var columns = new[]
            {
                "Unidade", "Código Produto", "Descrição do Produto",
                "Estado/UF/Região", "IPI", "PV", "PSD", "PSCF"
            };

            Dictionary<string, int> columnMappings;
            using (var excelQueryFactory = new ExcelQueryFactory(filePath))
            {
                var headerRow = excelQueryFactory.Worksheet(nomeWorksheet)
                    .Skip(indexLinhaDoCabecalho - 1)
                    .ToList()
                    .FirstOrDefault();

                columnMappings = columns.ToDictionary(
                    x => x,
                    x =>
                    {
                        var cell = headerRow.FirstOrDefault(y => y.Value.ToString() == x);
                        return headerRow.IndexOf(cell);
                    });
            }

            using (var excelQueryFactory = new ExcelQueryFactory(filePath))
            {
                return excelQueryFactory.Worksheet(nomeWorksheet)
                    .Skip(indexLinhaDoCabecalho)
                    .Select(RowSelectorForIntelbrasImport(columnMappings))
                    .ToList()
                    .Where(x => x.UF == "GO")
                    .ToList();
            }
        }

        private static Expression<Func<Row, dynamic>> RowSelectorForIntelbrasImport(Dictionary<string, int> columnMappings)
        {
            return row => new
            {
                Unidade = row[columnMappings["Unidade"]].ToString().Trim(),
                CodigoDoProduto = row[columnMappings["Código Produto"]].ToString().Trim(),
                Nome = row[columnMappings["Descrição do Produto"]].ToString().Trim(),
                UF = row[columnMappings["Estado/UF/Região"]].ToString().Trim(),
                Ipi = row[columnMappings["IPI"]].ToString().Trim(),
                PrecoDeCompra = row[columnMappings["PV"]].ToString().Trim(),
                PrecoDistribuidor = row[columnMappings["PSD"]].ToString().Trim(),
                Pscf = row[columnMappings["PSCF"]].ToString().Trim()
            };
        }

        private static void SetupProgressBar(FrmEstoque caller)
        {
            caller.Invoke((MethodInvoker)delegate
            {
                caller.btnImportarTabelaPrecosIntelbras.Enabled = false;

                caller.metroProgressImportar.Visible = true;
                caller.metroProgressImportar.Value = 1;

                caller.txtQtyProgresso.Visible = true;
                caller.txtCronometroImportar.Visible = true;

                caller.txtQtyProgresso.Text = "Lendo planilha";
            });
        }

        private static void UpdateProgressBar(ref int totalAdded, int[] items, List<dynamic> totalItems, FrmEstoque caller)
        {
            totalAdded++;

            var text = $"{totalAdded}/{totalItems.Count}";
            caller.Invoke((MethodInvoker)delegate { caller.txtQtyProgresso.Text = text; });

            if (totalAdded.IsAny(items))
            {
                caller.Invoke((MethodInvoker)delegate { caller.metroProgressImportar.Value += 1; });
            }
        }

        public Tuple<int, int> ImportIntelbrasSpreadsheet(string filePath, FrmEstoque caller)
        {
            var productRepository = new RepositorioDeProduto();

            SetupProgressBar(caller);

            var configuration = new RepositorioDeConfiguracao().ObtenhaUnica();

            var importedItems = ReadXlsItems(filePath);
            var progressRange = GSExtensions.GetProgressRange(importedItems.Count);
            var persistedItems = productRepository.ConsulteTodos(takeQuantity: int.MaxValue, withAttachments: true);

            var totalAdded = 0;

            var concurrentQueue = new ConcurrentQueue<dynamic>(importedItems
                .Distinct()
                .ToList());

            var itemsToAdd = new ConcurrentBag<Produto>();
            var itemsToUpdate = new ConcurrentBag<Produto>();
            
            var keepTaskRunning = true;
            GSExtensions.ParallelWhile(() => keepTaskRunning, () =>
            {
                keepTaskRunning = concurrentQueue.TryDequeue(out var item);
                if(!keepTaskRunning)
                {
                    return;
                }

                UpdateProgressBar(ref totalAdded, progressRange, importedItems, caller);

                if (((string)item.PrecoDeCompra).IsAny("R$ -", "-") ||
                    ((string)item.PrecoDistribuidor).IsAny("R$ -", "-"))
                {
                    return;
                }

                var intelbrasProductCode = (string)item.CodigoDoProduto;
                
                var persistedProduct = persistedItems.FirstOrDefault(x => x.CodigoDoFabricante?.Trim() == intelbrasProductCode.Trim());
                if (persistedProduct != null)
                {
                    var worksheetPrice = ((string)item.PrecoDeCompra).ObtenhaMonetario();
                    var worksheetIpi = Convert.ToDecimal(((string)item.Ipi).Replace("%", string.Empty));

                    if (persistedProduct.PrecoNaIntelbras == worksheetPrice && persistedProduct.Ipi == worksheetIpi)
                    {
                        return;
                    }

                    LoadProduct(persistedProduct, item);
                    itemsToUpdate.Add(persistedProduct);

                    return;
                }

                itemsToAdd.Add(GetNewProduct(item, configuration));
            });

            if(itemsToAdd.Any())
            {
                foreach(var item in itemsToAdd)
                {
                    item.ImportadoViaPlanilha = true;
                }

                productRepository.MassInsert(itemsToAdd.ToList());
            }

            if (itemsToUpdate.Any())
            {
                foreach (var item in itemsToUpdate)
                {
                    item.ImportadoViaPlanilha = true;
                }

                productRepository.MassUpdate(itemsToUpdate.ToList());
            }

            return new Tuple<int, int>(itemsToUpdate.Count, itemsToAdd.Count);
        }

        private static void LoadProduct(Produto persistedProduct, dynamic item)
        {
            persistedProduct.Nome = item.Nome;
            persistedProduct.Fabricante = "Intelbras";
            persistedProduct.Unidade = UnidadeIntelbras.ObtenhaPorNome(item.Unidade);
            persistedProduct.PrecoNaIntelbras = GSExtensions.ObtenhaMonetario(item.PrecoDeCompra);
            persistedProduct.Ipi = ((string)item.Ipi).Replace("%", string.Empty).ToDecimal();
            persistedProduct.CalculePrecoDeCompraComBaseNoPrecoDaIntelbras();
            persistedProduct.CalculePrecoDeVenda();
            persistedProduct.CalculePrecoDeVendaDistribuidor();
            persistedProduct.PrecoDistribuidor = GSExtensions.ObtenhaMonetario(item.PrecoDistribuidor);
            persistedProduct.PrecoSugeridoConsumidorFinal = GSExtensions.ObtenhaMonetario(item.Pscf);
        }

        private static Produto GetNewProduct(dynamic item, Configuracoes systemConfig)
        {
            var newProduct = new Produto
            {
                Nome = ((string)item.Nome).ToCustomTitleCase(),
                Fabricante = "Intelbras",
                Status = EnumStatusToggle.Ativo,
                CodigoDoFabricante = ((string)item.CodigoDoProduto).Trim(),
                Unidade = UnidadeIntelbras.ObtenhaPorNome(item.Unidade),
                PrecoNaIntelbras = GSExtensions.ObtenhaMonetario(item.PrecoDeCompra),
                Ipi = ((string)item.Ipi).Replace("%", string.Empty).ToDecimal(),
                PrecoDistribuidor = GSExtensions.ObtenhaMonetario(item.PrecoDistribuidor),
                PorcentagemDeLucro = systemConfig.PorcentagemDeLucroPadrao,
                PrecoSugeridoConsumidorFinal = GSExtensions.ObtenhaMonetario(item.Pscf),
                PorcentagemDeLucroDistribuidor = 30.0M
        };

            newProduct.CalculePrecoDeCompraComBaseNoPrecoDaIntelbras();
            newProduct.CalculePrecoDeVenda();
            newProduct.CalculePrecoDeVendaDistribuidor();

            return newProduct;
        }
    }
}       
