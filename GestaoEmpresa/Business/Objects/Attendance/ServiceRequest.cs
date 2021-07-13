using System;
using GS.GestaoEmpresa.Business.Objects.Core;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Objects;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;

namespace GS.GestaoEmpresa.Business.Objects.Attendance
{
    public class ServiceRequest : RavenDbDocumentWithRevision
    {

        public string Descricao { get; set; }

        // Horário de abertura da SA
        public DateTime OpenTime { get; set; }

        // Horário agendado para visita
        public DateTime ScheduledTime { get; set; }

        public Client Client { get; set; }

        public string Requester { get; set; }

        public string ResponsibleContact { get; set; }

        public Employee ResponsibleTechnician { get; set; }

        public int /*Atendimento*/ ModeloDeAtendimento { get; set; }

        public decimal ValorAcordado { get; set; }

        // Em minutos
        public int TempoEstimado { get; set; }
    }
}
