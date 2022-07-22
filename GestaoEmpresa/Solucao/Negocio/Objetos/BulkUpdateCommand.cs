using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class BulkUpdateCommand
    {
        public BulkUpdateFilter Filter { get; set; }
        public decimal? SellingProfitPercentage { get; internal set; }
        public decimal? FinalConsumerProfitPercentage { get; internal set; }
    }
}
