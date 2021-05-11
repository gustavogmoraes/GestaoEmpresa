using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;

namespace GS.GestaoEmpresa.Solucao.Negocio.Interfaces
{
    public interface IEntityWithRevision : IEntity
    {
        DateTime RevisionStartTime { get; set; }

        bool Current { get; set; }

        EnumStatusToggle Status { get; set; }
    }
}
