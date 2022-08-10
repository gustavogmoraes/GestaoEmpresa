using System.Linq;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Business.Objects.Core;
using GS.GestaoEmpresa.Infrastructure.Persistence.Repositories.Base;

namespace GS.GestaoEmpresa.Persistence.Repositories
{
    public class ConfigurationRepository : RepositoryBase<Configuration>
    {
        public async Task<Configuration> GetOnlyAsync() => (await QueryAllAsync()).FirstOrDefault();
    }
}
