﻿using System.Collections.Generic;
using GS.GestaoEmpresa.Business.Interfaces;
using GS.GestaoEmpresa.Infrastructure.Persistence.RavenDB.Support.Interfaces;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;

namespace GS.GestaoEmpresa.Business.Validators.Base
{
    public abstract class BaseValidator<TEntity>
        where TEntity : IEntity, new()
    {
        public abstract IList<Error> ValidateCreate(TEntity item);

        public abstract IList<Error> ValidateUpdate(TEntity item);

        public abstract IList<Error> ValidateDelete(int code);
    }
}
