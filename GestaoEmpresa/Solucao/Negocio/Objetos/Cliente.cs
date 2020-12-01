using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;
using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class Cliente : Pessoa, IConceitoComPendencia
    {
        public bool Status { get; set; }

        public string RazaoSocial { get; set; }

        public string Descricao { get; set; }

        public string RG { get; set; }

        public string InscricaoEstadual { get; set; }

        public string InscricaoMunicipal { get; set; }

        public bool Contrato { get; set; }

        public string Observacao { get; set; }

        public bool CadastroPendente { get; set; }

        public string RamoDoNegocio { get; set; }

        public List<Unidade> Unidades { get; set; }
    }
}
