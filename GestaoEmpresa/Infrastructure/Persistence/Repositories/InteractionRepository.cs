using System.Linq;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Business.Converters;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Infrastructure.Persistence.Repositories.Base;
using GS.GestaoEmpresa.Persistence.RavenDB;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using Raven.Client.Documents;
using Raven.Client.Documents.Operations;
using Raven.Client.Documents.Queries;

namespace GS.GestaoEmpresa.Infrastructure.Persistence.Repositories
{
    public class InteractionRepository : RepositoryBase<Interaction>
    {
        public bool CheckIfSerialNumberIsInDatabase(string serialNumber)
        {
            using var ravenDbSession = RavenHelper.OpenSession();
            return ravenDbSession.Query<Interacao>()
                .Where(x => x.InformaNumeroDeSerie && x.NumerosDeSerie.Any())
                .Any(x => x.NumerosDeSerie.Contains(serialNumber));
        }

        public async Task MigrateAsync()
        {
            using var ravenDbSession = RavenHelper.OpenAsyncSession();
            var oldObjs = await ravenDbSession.Query<Interacao>().ToListAsync();

            var interactionConverter = new InteractionConverter();

            var newObjs = oldObjs.Select(interactionConverter.Convert).ToList();
            foreach(var x in newObjs)
            {
                await InsertAsync(x);
            }

            RavenHelper.OpenSession().DeleteByQuery("from Interacoes");
        }
    }
}
