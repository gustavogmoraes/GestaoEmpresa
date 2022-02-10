using System.Linq;
using GS.GestaoEmpresa.Business.Objects.Core;
using GS.GestaoEmpresa.Infrastructure.Persistence.Repositories.Base;

namespace GS.GestaoEmpresa.Persistence.Repositories
{
    public class ConfigurationRepository : RepositoryBase<Configuration>
    {
        public Configuration ObtenhaUnica() => Query().FirstOrDefault();
    }
}
