using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Orcamento
{
    public class ItemOrcamento
    {
        public string Id { get; set; }

        public TipoDeItemOrcamento Tipo { get; set; }

        public string Descricao { get; set; }

        public Produto Produto { get; set; }

        public decimal ValorUnitario { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorTotal { get; set; }

        public string Observacao { get; set; }
    }
}
