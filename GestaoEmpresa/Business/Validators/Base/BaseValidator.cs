using System.Collections.Generic;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Infrastructure.Persistence.RavenDB.Support.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;

namespace GS.GestaoEmpresa.Business.Validators.Base
{
    public abstract class BaseValidator<TEntity>
        where TEntity : IEntity, new()
    {
        public abstract Task<IList<Error>> ValidateCreateAsync(TEntity item);

        public abstract Task<IList<Error>> ValidateUpdateAsync(TEntity item);

        public abstract Task<IList<Error>> ValidateDeleteAsync(int code);
    }
}
