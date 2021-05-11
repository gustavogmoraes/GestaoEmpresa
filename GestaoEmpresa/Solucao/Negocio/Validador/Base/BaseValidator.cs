using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;

namespace GS.GestaoEmpresa.Solucao.Negocio.Validador.Base
{
    public abstract class BaseValidator<TEntity>
        where TEntity : IEntity, new()
    {
        public abstract IList<Inconsistencia> ValidateCreate(TEntity item);

        public abstract IList<Inconsistencia> ValidateUpdate(TEntity item);

        public abstract IList<Inconsistencia> ValidateDelete(int code);
    }
}
