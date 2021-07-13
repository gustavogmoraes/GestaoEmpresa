using GS.GestaoEmpresa.Persistence.RavenDbSupport.Objects;

namespace GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces
{
    public interface IObjectWithRavenAttachments
    {
        RavenAttachments RavenAttachments { get; set; }
    }
}
