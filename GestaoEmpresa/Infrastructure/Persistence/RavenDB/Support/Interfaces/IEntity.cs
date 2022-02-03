using GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces;

namespace GS.GestaoEmpresa.Infrastructure.Persistence.RavenDB.Support.Interfaces
{
    public interface IEntity : IRavenDbDocument, IObjectWithRavenAttachments
    {
        int Code { get; set; }
    }
}
