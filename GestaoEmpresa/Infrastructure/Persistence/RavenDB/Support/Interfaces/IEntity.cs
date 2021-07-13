namespace GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces
{
    public interface IEntity : IRavenDbDocument, IObjectWithRavenAttachments
    {
        int Code { get; set; }
    }
}
