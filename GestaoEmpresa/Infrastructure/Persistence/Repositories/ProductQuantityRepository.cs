using System;
using System.Collections.Generic;
using System.Linq;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Persistence.RavenDB;
using GS.GestaoEmpresa.Persistence.Repositories.Base;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client.Documents.Linq;

namespace GS.GestaoEmpresa.Infrastructure.Persistence.Repositories
{
    public class ProductQuantityRepository : RepositoryBase<ProductQuantity>
    {
        public Dictionary<int, int> QueryQuantities(IList<int> productsCodes)
        {
            using var ravenSession = RavenHelper.OpenSession();
            return ravenSession
                .Query<ProductQuantity>()
                .Where(x => x.ProductCode.In(productsCodes))
                .ToDictionary(x => x.ProductCode, x => x.Quantity);
        }

        public int QueryQuantity(int productCode)
        {
            using var ravenSession = RavenHelper.OpenSession();
            var document = ravenSession
                .Query<ProductQuantity>()
                .FirstOrDefault(x => x.ProductCode == productCode);

            return document.IsNotNull() 
                // ReSharper disable once PossibleNullReferenceException
                ? document.Quantity 
                : 0;
        }
    }
}
