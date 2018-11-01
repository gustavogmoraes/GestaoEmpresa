using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using System;
namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class SolicitacaoDeAtendimento : IConceito
    {
        public int Codigo { get; set; }

        public string Descricao { get; set; }

        // Horário de abertura da SA
        public DateTime Horario { get; set; }

        // Horário agendado para visita
        public DateTime HorarioAgendado { get; set; }

        public Cliente Cliente { get; set; }

        public string Solicitante { get; set; }

        public string ContatoResponsavel { get; set; }

        public Colaborador TecnicoResponsavel { get; set; }

        public int /*Atendimento*/ ModeloDeAtendimento { get; set; }

        public decimal ValorAcordado { get; set; }

        // Em minutos
        public int TempoEstimado { get; set; }
    }
}
