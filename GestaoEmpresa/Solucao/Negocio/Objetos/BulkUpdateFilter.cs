using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class BulkUpdateFilter
    {
        public string Manufacturer { get; set; }

        public decimal? SellingProfitPercentage { get; set; }

        public decimal? FinalConsumerProfitPercentage { get; set; }
    }
}
