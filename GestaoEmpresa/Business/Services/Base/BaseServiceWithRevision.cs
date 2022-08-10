using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Business.Enumerators.Default;
using GS.GestaoEmpresa.Business.Interfaces;
using GS.GestaoEmpresa.Business.Validators.Base;
using GS.GestaoEmpresa.Infrastructure.Persistence.Repositories.Base;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Objects;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;

namespace GS.GestaoEmpresa.Business.Services.Base
{
    public abstract class BaseServiceWithRevision<TEntity, TValidator, TRepository> : IServiceWithRevision, IBaseService, IDisposable
        where TEntity : RavenDbDocumentWithRevision, IEntityWithRevision, new()
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

        public async Task<TEntity> QueryFirstAsync(int code, DateTime revisionDate, bool withAttachments = true) => 
            await Repository.QueryFirstAsync(code, revisionDate, withAttachments);

        public async Task<TEntity> QueryFirstAsync(int code, bool withAttachments = true) => 
            await Repository.QueryFirstAsync(code, withAttachments);

        public async Task<IList<TEntity>> ConsulteTodos() => await Repository.QueryAllAsync();

        public virtual async Task<int> GetNextAvailableCodeAsync() => 
            await Repository.GetNextAvailableCodeAsync();

        public virtual async Task<IList<int>> GetNextAvailableCodes(int quantity) => 
            await Repository.GetNextAvailableCodesAsync(quantity);

        protected abstract Action CreateValidationSucceeded(TEntity item);

        protected abstract Action UpdateValidationSucceeded(TEntity item);

        protected abstract Action DeleteValidationSucceeded(int code);

        public virtual async Task<IList<Error>> SaveAsync(TEntity item, FormType formType)
        {
            var inconsistencias = new List<Error>();

            switch (formType)
            {
                case FormType.Insert:
                    inconsistencias = (await Validator.ValidateCreateAsync(item)).ToList();
                    if (inconsistencias.Count == 0)
                    {
                        var acao = CreateValidationSucceeded(item);
                        if (acao != null) acao.Invoke();

                        await Repository.InsertAsync(item);
                    }

                    break;

                case FormType.Update:
                    inconsistencias = (await Validator.ValidateUpdateAsync(item)).ToList();
                    if (inconsistencias.Count == 0)
                    {
                        var acao = UpdateValidationSucceeded(item);
                        if (acao != null) acao.Invoke();

                        await Repository.UpdateAsync(item);
                    }

                    break;
            }

            return inconsistencias;
        }

        public virtual async Task<IList<Error>> DeleteAsync(int code)
        {
            var errors = await Validator.ValidateDeleteAsync(code);
            if (!errors.Any())
            {
                var acao = DeleteValidationSucceeded(code);
                if (acao != null) acao.Invoke();

                await Repository.DeleteAsync(code);
            }


            return errors;
        }

        public async Task<IList<DateTime>> QueryRevisionsAsync(string id) => 
            (await Repository.QueryRevisionsAsync(id)).Select(x => x.DateTime).ToList();

        public async Task<IList<DateTime>> QueryRevisions(int code)
        {
            var documentId = await Repository.RetrieveIdAsync(code);
            return await QueryRevisionsAsync(documentId);
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
