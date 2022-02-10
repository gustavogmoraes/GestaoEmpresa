using System.Linq;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Infrastructure.Persistence.Repositories.Base;
using GS.GestaoEmpresa.Persistence.RavenDB;

namespace GS.GestaoEmpresa.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : RepositoryBase<Product>
    {
        /// <summary>
        /// Queries product quantity.
        /// </summary>
        /// <param name="code">The product code.</param>
        /// <returns>The product quantity</returns>
        public int QueryQuantity(int code)
        {
            using var ravenSession = RavenHelper.OpenSession();
            return ravenSession.Query<ProductQuantity>().FirstOrDefault(x => x.ProductCode == code)!.Quantity;
        }
    }
}
