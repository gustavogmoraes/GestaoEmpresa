using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Estoque
{
    public class SubInteraction
    {
        public Product Product { get; set; }

        public int InteractedQuantity { get; set; }

        public int? AuxiliaryQuantity { get; set; }

        public int Quantity { get; set; }

        public decimal? UnitaryPrice { get; set; }

        public bool UpdateUnitaryPriceAtProductCatalog { get; set; }

        public decimal? TotalPrice { get; set; }

        public bool InformsSerialNumber { get; set; }

        public List<string> SerialNumbers { get; set; }
    }
}
