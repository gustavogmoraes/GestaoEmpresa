using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Business.Enumerators.Default;
using LinqToExcel;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.UnidadeIntelbras;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.Business.Objects.Core;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Persistence.Repositories;
using GS.GestaoEmpresa.Business.Services.Base;
using GS.GestaoEmpresa.Business.Validators;
using GS.GestaoEmpresa.Infrastructure.Persistence.Repositories;
using GS.GestaoEmpresa.Persistence.RavenDB;
using GS.GestaoEmpresa.UI.Modules.Storage.Storage;
using Raven.Client.Documents.Linq;

namespace GS.GestaoEmpresa.Business.Services
{
    public class ProductService : BaseServiceWithRevision<Product, ProductValidator, ProductRepository>, IDisposable
    {
        private readonly ProductRepository _productRepository;
        private readonly ProductQuantityRepository _productQuantityRepository;
        private readonly ConfigurationRepository _configurationRepository;

        #region Default Implementation

        protected override Action CreateValidationSucceeded(Product produto) => () =>
        {
            using var session = RavenHelper.OpenSession();
            session.Store(new ProdutoQuantidade { Codigo = produto.Code, Quantidade = 0 });
            session.SaveChanges();
        };

        protected override Action UpdateValidationSucceeded(Product item)
        {
            return null;
        }

        protected override Action DeleteValidationSucceeded(int codigo) => () =>
        {
            using var session = RavenHelper.OpenSession();
            var produtoQtd = session.Query<ProdutoQuantidade>()
                .Where(x => x.Codigo == codigo)
                .ToList();

            produtoQtd.ForEach(session.Delete);

            session.SaveChanges();
        };

        #endregion

        public ProductService()
        {
            _productQuantityRepository = new ProductQuantityRepository();
            _productRepository = new ProductRepository();
            _configurationRepository = new ConfigurationRepository();
        }

        public int QueryQuantity(int code)
        {
            return _productRepository.QueryQuantity(code);
        }

        public async Task<Dictionary<int, int>> QueryQuantityAsync(IList<int> codes)
        {
            return await _productQuantityRepository.QueryQuantitiesAsync(codes);
        }

        public async Task UpdateProductQuantityAsync(int productCode, int newQuantity)
        {
            var productQuantity = await _productQuantityRepository.QueryFirstAsync(x => x.ProductCode == productCode);
            productQuantity.Quantity = newQuantity;
            await _productQuantityRepository.UpdateAsync(productQuantity);

        }

        private static Expression<Func<Product, object>> LandingPageProductSelector => x => new Product
        {
            Code = x.Code,
            Manufacturer = x.Manufacturer,
            ManufacturerCode = x.ManufacturerCode,
            Name = x.Name,
            Notes = x.Notes,
            PurchasePrice = x.PurchasePrice,
            SalePrice = x.SalePrice,
            IntelbrasPrice = x.IntelbrasPrice,
            DistributorPrice = x.DistributorPrice,
            ProfitPercentage = x.ProfitPercentage,
            Status = x.Status,
            AlsoKnownAs = x.AlsoKnownAs,
            LocationInStorage = x.LocationInStorage
        };

        private static readonly Expression<Func<Product, object>>[] DefaultPropertiesToSearch =
        {
            x => x.Name, x => x.AlsoKnownAs, x => x.Code, 
            x => x.ManufacturerCode, x => x.Manufacturer, x => x.LocationInStorage
        };

        public List<Product> QueryForLandingPage(
            out Dictionary<int, int> quantities,
            bool onlyActives = true,
            Expression<Func<Product, bool>> whereFilter = null,
            Expression<Func<Product, object>> resultSelector = null,
            int takeQuantity = 500,
            string searchTerm = null,
            Expression<Func<Product, object>>[] propertiesToSearch = null) 
        {
            var selector = resultSelector ?? LandingPageProductSelector;

            var propsToSearch = propertiesToSearch ?? DefaultPropertiesToSearch;
            var products = Task.Run(() => Repository
                .QueryAsync(searchTerm, propsToSearch, selector, takeQuantity)).Result
                .ToList();

            var productsCodes = products.Select(x => x.Code).ToList();
            quantities = Task.Run(() => _productQuantityRepository.QueryQuantitiesAsync(productsCodes)).Result;

            return products;
        }

        public override async Task<IList<Error>> SaveAsync(Product item, FormType formType)
        {
            var inconsistencies = await base.SaveAsync(item, formType);

            return inconsistencies;
        }

        public async Task<Product> QueryFirst(Expression<Func<Product, bool>> whereFilter)
        {
            return await _productRepository.QueryFirstAsync(whereFilter);
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

        private static void SetupProgressBar(StorageView caller)
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

        private static void UpdateProgressBar(ref int totalAdded, int[] items, List<dynamic> totalItems, StorageView caller)
        {
            totalAdded++;

            var text = $"{totalAdded}/{totalItems.Count}";
            caller.Invoke((MethodInvoker)delegate { caller.txtQtyProgresso.Text = text; });

            if (totalAdded.IsAny(items))
            {
                caller.Invoke((MethodInvoker)delegate { caller.metroProgressImportar.Value += 1; });
            }
        }

        public async Task<Tuple<int, int>> ImportIntelbrasSpreadsheet(string filePath, StorageView caller)
        {
            var productRepository = new RepositorioDeProduto();
            SetupProgressBar(caller);

            var configuration = await _configurationRepository.GetOnlyAsync();

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

        private static Produto GetNewProduct(dynamic item, Configuration systemConfig)
        {
            var newProduct = new Produto
            {
                Nome = ((string)item.Nome).ToCustomTitleCase(),
                Fabricante = "Intelbras",
                Status = EnumStatusToggle.Active,
                CodigoDoFabricante = ((string)item.CodigoDoProduto).Trim(),
                Unidade = UnidadeIntelbras.ObtenhaPorNome(item.Unidade),
                PrecoNaIntelbras = GSExtensions.ObtenhaMonetario(item.PrecoDeCompra),
                Ipi = ((string)item.Ipi).Replace("%", string.Empty).ToDecimal(),
                PrecoDistribuidor = GSExtensions.ObtenhaMonetario(item.PrecoDistribuidor),
                PorcentagemDeLucro = systemConfig.DefaultSaleProfitPercentage,
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
