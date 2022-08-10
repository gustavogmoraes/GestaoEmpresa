using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Infrastructure.Persistence.Repositories.Base;
using GS.GestaoEmpresa.Persistence.RavenDB;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;

namespace GS.GestaoEmpresa.Infrastructure.Persistence.Repositories
{
    public class ProductQuantityRepository : RepositoryBase<ProductQuantity>
    {
        public async Task<Dictionary<int, int>> QueryQuantitiesAsync(IList<int> productsCodes)
        {
            using var ravenSession = RavenHelper.OpenAsyncSession();
            var a = await ravenSession
                .Query<ProductQuantity>()
                .Where(x => x.ProductCode.In(productsCodes))
                .ToListAsync();

            return a.ToDictionary(x => x.ProductCode, x => x.Quantity);
        }

        public async Task<int> QueryQuantity(int productCode)
        {
            using var ravenSession = RavenHelper.OpenAsyncSession();
            var document = await ravenSession
                .Query<ProductQuantity>()
                .FirstOrDefaultAsync(x => x.ProductCode == productCode);

            return document.IsNotNull()
                ? document.Quantity 
                : 0;
        }
    }
}
