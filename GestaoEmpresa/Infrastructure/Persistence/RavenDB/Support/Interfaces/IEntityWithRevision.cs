using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Infrastructure.Persistence.RavenDB.Support.Interfaces;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using Newtonsoft.Json;

namespace GS.GestaoEmpresa.Business.Interfaces
{
    public interface IEntityWithRevision : IEntity
    {
        [JsonIgnore]
        DateTime RevisionStartTime { get; set; }

        [JsonIgnore]
        bool Current { get; set; }

        EnumStatusToggle Status { get; set; }
    }
}
