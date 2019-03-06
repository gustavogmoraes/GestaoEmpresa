using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.Conceito;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;

namespace GS.GestaoEmpresa.Solucao.Negocio.Validador.Base
{
    public abstract class ValidadorPadrao<TConceito>
        where TConceito : IConceito, new()
    {
        public abstract IList<Inconsistencia> ValideCadastro(TConceito item);

        public abstract IList<Inconsistencia> ValideEdicao(TConceito item);

        public abstract IList<Inconsistencia> ValideExclusao(int codigo);
    }
}
