using System;
using GS.GestaoEmpresa.Infrastructure.Persistence.RavenDB.Support.Interfaces;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;

namespace GS.GestaoEmpresa.Business.Interfaces
{
    public interface IConceitoComHistorico : IEntity
    {
        DateTime Vigencia { get; set; }

        bool Atual { get; set; }

        EnumStatusToggle Status { get; set; }
    }
}
