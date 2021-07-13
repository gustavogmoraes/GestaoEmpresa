using System.Collections.Generic;
using GS.GestaoEmpresa.Business.Objects.Attendance;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Objects;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Orcamento
{
    public class Orcamento : RavenDbDocumentWithRevision
    {
        public int Sequencial { get; set; }

        public string Descricao { get; set; }

        public Client Client { get; set; }

        public List<ItemOrcamento> Itens { get; set; }
    }
}
