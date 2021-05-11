using GS.GestaoEmpresa.Solucao.Persistencia.Interfaces;

namespace GS.GestaoEmpresa.Solucao.Negocio.Interfaces
{
    public interface IConceito : IRavenDbDocument
    {
        new int Codigo { get; set; }
    }
}
