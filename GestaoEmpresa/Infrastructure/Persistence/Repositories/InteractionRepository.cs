using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using System.Linq.Expressions;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Persistence.RavenDB;
using GS.GestaoEmpresa.Persistence.Repositories.Base;

namespace GS.GestaoEmpresa.Persistence.Repositories
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
    }
}
