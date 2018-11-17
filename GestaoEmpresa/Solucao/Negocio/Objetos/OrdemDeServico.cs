using System;
using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class OrdemDeServico
    {
        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public SolicitacaoDeAtendimento SAVinculada { get; set; }

        public OrdemDeServico OrdemDeServicoAnteriorParaVincular { get; set; }

        // Assinatura
        public string ContatoResponsavelAssinatura { get; set; }

        public Colaborador TecnicoResponsavel { get; set; }

        public List<Colaborador> Auxiliares { get; set; }

        public List<LancamentoOS> Lancamentos { get; set; }

        public decimal ValorFinal { get; set; }

        public DateTime HorarioChegada { get; set; }

        public DateTime HorarioSaida { get; set; }

        // Em minutos
        public int TempoGasto { get; set; }
    }
}
