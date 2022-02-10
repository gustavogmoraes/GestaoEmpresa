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

        public TEntity Query(int code)
        {
            return Repository.Query(code);
        }

        public IList<TEntity> ConsulteTodos()
        {
            return Repository.Query();
        }

        protected abstract Action CreateValidationSucceeded(TEntity item);

        protected abstract Action UpdateValidationSucceeded(TEntity item);

        protected abstract Action DeleteValidationSucceeded(int code);

        public IList<Error> Save(TEntity item, FormType formType)
        {
            List<Error> errors;

            switch (formType)
            {
                case FormType.Insert:
                    errors = Validator.ValidateCreate(item).ToList();
                    if (errors.Count == 0)
                    {
                        var action = CreateValidationSucceeded(item);
                        action?.Invoke();

                        Repository.Insert(item);
                    }

                    break;

                case FormType.Update:
                    errors = Validator.ValidateUpdate(item).ToList();
                    if (errors.Count == 0)
                    {
                        var action = UpdateValidationSucceeded(item);
                        action?.Invoke();

                        Repository.Update(item);
                    }
                        
                    break;

                case FormType.Detail:
                default:
                    throw new ArgumentOutOfRangeException(nameof(formType), formType, null);
            }

            return errors;
        }

        public IList<Error> Delete(int code)
        {
            var inconsistencias = Validator.ValidateDelete(code);

            if (inconsistencias.Count == 0)
            {
                var acao = DeleteValidationSucceeded(code);
                if (acao != null) acao.Invoke();

                Repository.Delete(code);
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
