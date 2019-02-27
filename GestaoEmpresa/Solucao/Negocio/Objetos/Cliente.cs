using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;
using System.Collections.Generic;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class Cliente : Pessoa
    {
		public bool Status {get; set;}

		public string NomeFantasia { get; set; }

        public string Descricao { get; set; }

        public string RG {get; set;}

        public string InscricaoEstadual {get; set;}

        public string InscricaoMunicipal { get; set; }
		
        public int Grupo {get; set;}

        public bool Contrato {get; set;}

        public string Observacao { get; set; }

        public List<Email> Emails { get; set; }
    }
}
