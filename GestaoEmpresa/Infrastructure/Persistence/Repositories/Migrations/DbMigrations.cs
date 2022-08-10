using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Business.Converters;
using GS.GestaoEmpresa.Business.Objects.Core;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Business.Services;
using GS.GestaoEmpresa.Persistence.RavenDB;
using GS.GestaoEmpresa.Persistence.Repositories;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Operations;
using Raven.Client.Documents.Queries;

namespace GS.GestaoEmpresa.Infrastructure.Persistence.Repositories.Migrations
{
    public class DbMigrations
    {
        public async Task Interactions_2022_02_03()
        {
            await MigrateUsers();
            await MigrateConfig();
            await MigrateProductQuantities();
            await MigrateProducts();
            await MigrateInteractions();
            await CorrectQuantityConsistency();

            async Task MigrateConfig()
            {
                var session = RavenHelper.OpenSession();
                var configs = session.Query<Configuracao>(collectionName: "Configuracoes").ToList();
                var cfgRepo = new ConfigurationRepository();
                foreach (var x in configs)
                {
                    await cfgRepo.InsertAsync(new Configuration
                    {
                        Code = x.Codigo,
                        DefaultSaleProfitPercentage = x.PorcentagemDeLucroPadrao,
                        ProtegeTaxPercentage = x.PorcentagemImpostoProtege
                    });

                    session.Delete(x);
                }

                session.SaveChanges();
            }

            async Task MigrateProducts()
            {
                var sessionBulk = RavenHelper.OpenSession();
                sessionBulk.PatchByQuery(
                    @"from Produtos
                      update {
                        this.Status = ""Active""
                      }");
                sessionBulk.SaveChanges();

                var prodConvert = new ProductConverter();
                await prodConvert.ConvertAll();
            }

            async Task MigrateProductQuantities()
            {
                var session = RavenHelper.OpenAsyncSession();
                var productQuantities = await session.Query<ProdutoQuantidade>().OrderBy(x => x.Codigo).ToListAsync();
                var productQuantityRepository = new ProductQuantityRepository();

                foreach (var x in productQuantities)
                {
                    var session2 = RavenHelper.OpenAsyncSession();
                    await productQuantityRepository.InsertAsync(new ProductQuantity
                    {
                        ProductCode = x.Codigo,
                        Quantity = x.Quantidade
                    });

                    session2.Delete(x.Id);
                    await session2.SaveChangesAsync();
                }
            }

            async Task CorrectQuantityConsistency()
            {
                using var session = RavenHelper.OpenAsyncSession();
                var productQuantities = await session.Query<ProductQuantity>().ToListAsync();
                var products = await session.Query<Product>()
                    .Select(x => x.Code)
                    .ToListAsync();

                var missingProductQuantities = products
                    .Where(prod => productQuantities.All(x => x.ProductCode != prod))
                    .ToList();

                foreach (var prod in missingProductQuantities)
                {
                    var internalSession = RavenHelper.OpenAsyncSession();
                    await internalSession.StoreAsync(new ProductQuantity
                    {
                        ProductCode = prod,
                        Quantity = 0
                    });

                    await internalSession.SaveChangesAsync();
                }

                using var interactionService = new InteractionService();
                var duplicates = (await session.Query<ProductQuantity>().ToListAsync()).GroupBy(x => x.ProductCode).Where(x => x.Count() > 1).ToList();

                foreach (var duplicate in duplicates)
                {
                    var somaFinal = (await interactionService.QueryAllInteractionsByProductAsync(duplicate.Key)).FinalSum();

                    var quantidadeCorreta = duplicate.Where(x => x.Quantity == somaFinal).FirstOrDefault();
                    var duplicatesToRemove = duplicate.ToList().Except(new[] { quantidadeCorreta }).ToList();

                    foreach(var x in duplicatesToRemove)
                    {
                        var internalSession = RavenHelper.OpenAsyncSession();
                        internalSession.Delete(x);

                        await internalSession.SaveChangesAsync();
                    }
                }
            }

            async Task MigrateUsers()
            {
                var sessionBulk = RavenHelper.OpenAsyncSession();
                await sessionBulk.PatchByQueryAsync(
                    @"from Usuarios
                      update {
                        this.Status = ""Active"",
                        this.UISettings = null
                      }");
                
                await sessionBulk.SaveChangesAsync();

                var session = RavenHelper.OpenAsyncSession();
                var users = await session.Query<Usuario>().ToListAsync();
                var userRepo = new UserRepository();

                foreach(var x in users)
                {
                    await userRepo.InsertAsync(new User
                    {
                        Code = x.Codigo,
                        Name = x.Nome,
                        UISettings = null,
                        Status = x.Status,
                        Password = Convert.ToInt32(x.Senha)
                    });

                    session.Delete(x);
                }

                await session.SaveChangesAsync();
            }

            async Task MigrateInteractions()
            {
                var sessionBulk = RavenHelper.OpenAsyncSession();
                await sessionBulk.PatchByQueryAsync(
                    @"from Interacoes
                      update {
                        this.Produto.Status = ""Active""
                      }");

                await sessionBulk.SaveChangesAsync();

                var interactionRepository = new InteractionRepository();
                await interactionRepository.MigrateAsync();
            }
        }
    }
}
