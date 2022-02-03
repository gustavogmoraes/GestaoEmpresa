using System.Collections.Generic;
using GS.GestaoEmpresa.Business.Interfaces;
using GS.GestaoEmpresa.Infrastructure.Persistence.RavenDB.Support.Interfaces;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;

namespace GS.GestaoEmpresa.Business.Objects.Attendance
{
    public class Client : Pessoa, IConceitoComPendencia, IEntity
    {

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
