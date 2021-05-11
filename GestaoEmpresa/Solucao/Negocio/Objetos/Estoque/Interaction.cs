using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns.Estoque;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Estoque
{
    public class Interaction : IEntity
    {
        public string Id { get; set; }

        public int Code { get; set; }
            
        public RavenAttachments RavenAttachments { get; set; }

        public InteractionType InteractionType { get; set; }

        public DateTime Time { get; set; }

        public DateTime ScheduledTime { get; set; }

        public List<SubInteraction> SubInteractions { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public string Observation { get; set; }

        /// <summary>
        /// Nota fiscal
        /// </summary>
        public string InvoiceNumber { get; set; }

        public string Technician { get; set; }

        public string Goal { get; set; }

        public string Situation { get; set; }

        public DateTime? ReturnTime { get; set; }
        
    }
}
