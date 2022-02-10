using System.Linq;
using GS.GestaoEmpresa.Business.Converters;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Infrastructure.Persistence.Repositories.Base;
using GS.GestaoEmpresa.Persistence.RavenDB;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;

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

        public void Migrate()
        {
            using var ravenDbSession = RavenHelper.OpenSession();
            var oldObjs = ravenDbSession.Query<Interacao>().ToList();

            var interactionConverter = new InteractionConverter();

            var newObjs = oldObjs.Select(interactionConverter.Convert).ToList();
            newObjs.ForEach(x =>
            {
                Insert(x);
            });
        }
    }
}
