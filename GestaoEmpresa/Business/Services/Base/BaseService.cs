using System;
using System.Collections.Generic;
using System.Linq;
using GS.GestaoEmpresa.Business.Enumerators.Default;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Business.Interfaces;
using GS.GestaoEmpresa.Business.Validators.Base;
using GS.GestaoEmpresa.Infrastructure.Persistence.RavenDB.Support.Interfaces;
using GS.GestaoEmpresa.Infrastructure.Persistence.Repositories.Base;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Business.Services.Base
{
    public abstract class BaseService<TEntity, TValidator, TRepository> : IBaseService, IDisposable
        where TEntity : class, IEntity, new()
        where TValidator : BaseValidator<TEntity>, IDisposable, new()
        where TRepository : RepositoryBase<TEntity>, new()
    {
        private TValidator _validator;
        protected TValidator Validator
        {
            get => _validator ??= new TValidator();
            set => _validator = value;
        }

        protected TRepository _repository;
        protected TRepository Repository
        {
            get => _repository ??= new TRepository();
            set => _repository = value;
        }

        public async Task<TEntity> QueryFirstAsync(int code) => await Repository.QueryFirstAsync(code);

        public async Task<IList<TEntity>> QueryAllAsync() => await Repository.QueryAllAsync();

        protected abstract Action CreateValidationSucceeded(TEntity item);

        protected abstract Action UpdateValidationSucceeded(TEntity item);

        protected abstract Action DeleteValidationSucceeded(int code);

        public async Task<IList<Error>> SaveAsync(TEntity item, FormType formType)
        {
            List<Error> errors;

            switch (formType)
            {
                case FormType.Insert:
                    errors = (await Validator.ValidateCreateAsync(item)).ToList();
                    if (errors.Count == 0)
                    {
                        var action = CreateValidationSucceeded(item);
                        action?.Invoke();

                        await Repository.InsertAsync(item);
                    }

                    break;

                case FormType.Update:
                    errors = (await Validator.ValidateUpdateAsync(item)).ToList();
                    if (errors.Count == 0)
                    {
                        var action = UpdateValidationSucceeded(item);
                        action?.Invoke();

                        await Repository.UpdateAsync(item);
                    }
                        
                    break;

                case FormType.Detail:
                default:
                    throw new ArgumentOutOfRangeException(nameof(formType), formType, null);
            }

            return errors;
        }

        public async Task<IList<Error>> Delete(int code)
        {
            var inconsistencias = await Validator.ValidateDeleteAsync(code);

            if (inconsistencias.Count == 0)
            {
                var acao = DeleteValidationSucceeded(code);
                if (acao != null) acao.Invoke();

                await Repository.DeleteAsync(code);
            }
                

            return inconsistencias;
        }

        public void Dispose()
        {
            if (_validator != null)
            {
                _validator.Dispose();
            }

            if (_repository != null)
            {
                _repository = null;
            }
        }
    }
}
