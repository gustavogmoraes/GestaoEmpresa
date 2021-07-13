using System;
using System.Collections.Generic;
using GS.GestaoEmpresa.Business.Interfaces;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Objects;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns.Estoque;

namespace GS.GestaoEmpresa.Business.Objects.Storage
{
    public class Interaction : IEntity, IObjectWithRavenAttachments
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


        /// <summary>
        /// Nota fiscal
        /// </summary>
        public string InvoiceNumber { get; set; }

        public string Technician { get; set; }

        public string Goal { get; set; }

        public string Situation { get; set; }

        public DateTime? ReturnTime { get; set; }
        public string OrderOfServiceNumber { get; set; }
        public string Notes { get; set; }
    }
}
