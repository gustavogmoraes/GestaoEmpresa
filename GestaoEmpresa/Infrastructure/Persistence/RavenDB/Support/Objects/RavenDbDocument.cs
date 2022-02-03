using GS.GestaoEmpresa.Business.Interfaces;
using GS.GestaoEmpresa.Infrastructure.Persistence.RavenDB.Support.Interfaces;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;

namespace GS.GestaoEmpresa.Persistence.RavenDbSupport.Objects
{
    public class RavenDbDocument : IEntity
    {
        public string Id { get; set; }

        public int Code { get; set; }

        public RavenAttachments RavenAttachments { get; set; }
    }
}
