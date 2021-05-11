using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Estoque
{
    public class Product : IEntityWithRevision, IObjectWithRavenAttachments
    {
        public string Id { get; set; }

        public int Code { get; set; }

        public DateTime RevisionStartTime { get; set; }

        public bool Current { get; set; }

        public EnumStatusToggle Status { get; set; }

        public RavenAttachments RavenAttachments { get; set; }
    }
}
