using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Business.Converters;
using GS.GestaoEmpresa.Business.Objects.Core;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Persistence.RavenDB;
using GS.GestaoEmpresa.Persistence.Repositories;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client.Documents.Linq;

namespace GS.GestaoEmpresa.Infrastructure.Persistence.Repositories.Migrations
{
    public class DbMigrations
    {
        public void Interactions_2022_02_03()
        {
            MigrateUsers();
            MigrateConfig();
            MigrateProducts();
            MigrateProductQuantities();
            MigrateInteractions();

            void MigrateConfig()
            {
                var session = RavenHelper.OpenSession();
                var configs = session.Query<Configuracao>(collectionName: "Configuracoes").ToList();
                var cfgRepo = new ConfigurationRepository();
                foreach (var x in configs)
                {
                    cfgRepo.Insert(new Configuration
                    {
                        Code = x.Codigo,
                        DefaultSaleProfitPercentage = x.PorcentagemDeLucroPadrao,
                        ProtegeTaxPercentage = x.PorcentagemImpostoProtege
                    });

                    session.Delete(x);
                }

                session.SaveChanges();
            }

            void MigrateProductQuantities()
            {
                var session = RavenHelper.OpenSession();
                var pq = session.Query<ProdutoQuantidade>().OrderBy(x => x.Codigo).ToList();
                var productQuantityRepository = new ProductQuantityRepository();
                pq.ForEach(x =>
                {
                    var session2 = RavenHelper.OpenSession();
                    productQuantityRepository.Insert(new ProductQuantity
                    {
                        ProductCode = x.Codigo,
                        Quantity = x.Quantidade
                    });

                    session2.Delete(x.Id);
                    session2.SaveChanges();
                });
            }

            void MigrateProducts()
            {
                var sessionBulk = RavenHelper.OpenSession();
                sessionBulk.PatchByQuery(
                    @"from Produtos
                      update {
                      this.Status = ""Active""
                      }");
                sessionBulk.SaveChanges();

                var prodConvert = new ProductConverter();
                prodConvert.ConvertAll();
            }

            void MigrateUsers()
            {
                var sessionBulk = RavenHelper.OpenSession();
                sessionBulk.PatchByQuery(
                    @"from Usuarios
                      update {
                      this.Status = ""Active""
                      }");
                
                sessionBulk.SaveChanges();

                var session = RavenHelper.OpenSession();
                var users = session.Query<Usuario>().ToList();
                var userRepo = new UserRepository();
                users.ForEach(x =>
                {
                    userRepo.Insert(new User
                    {
                        Code = x.Codigo,
                        Name = x.Nome,
                        UISettings = null,
                        Status = x.Status,
                        Password = Convert.ToInt32(x.Senha)
                    });

                    session.Delete(x);
                });

                session.SaveChanges();
            }

            void MigrateInteractions()
            {
                var sessionBulk = RavenHelper.OpenSession();
                sessionBulk.PatchByQuery(
                    @"from Interacoes
                  update {
                    this.Produto.Status = ""Active""
                  }");
                sessionBulk.SaveChanges();
                var interactionRepository = new InteractionRepository();
                interactionRepository.Migrate();
            }
        }
    }
}
