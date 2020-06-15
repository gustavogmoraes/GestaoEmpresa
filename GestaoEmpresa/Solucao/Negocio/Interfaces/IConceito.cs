using GS.GestaoEmpresa.Solucao.Persistencia.Interfaces;

namespace GS.GestaoEmpresa.Solucao.Negocio.Interfaces
{
    public interface IConceito : IRavenDbDocument
    {
        int Codigo { get; set; }
    }
}
