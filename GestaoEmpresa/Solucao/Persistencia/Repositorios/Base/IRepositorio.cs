using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public interface IRepositorio<TConceito>
        where TConceito : IConceito
    {
        TConceito Consulte(int codigo);

        void Exclua(int codigo);
    }
}
