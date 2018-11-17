using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.Conceito;
using System.Collections.Generic;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public interface IRepositorioConceitoComPortador<TConceito>
        where TConceito : class
    {
        void Salve(Conceito conceito, int codigoPortador, IList<TConceito> listaDeConceito);

        IList<TConceito> Consulte(Conceito conceito, int codigoPortador);

        void Exclua(Conceito conceito, int codigoPortador);
    }
}
