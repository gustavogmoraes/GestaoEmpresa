using System.Collections.Generic;

namespace GS.GestaoEmpresa.Business.Objects.Storage
{
    public class SubInteraction
    {
        public Product Product { get; set; }

        public int InteractedQuantity { get; set; }

        public int? AuxiliaryQuantity { get; set; }

        public decimal? UnitaryPrice { get; set; }

        public bool UpdateUnitaryPriceAtProductCatalog { get; set; }

        public decimal? TotalPrice { get; set; }

        public bool InformsSerialNumber { get; set; }

        public List<string> SerialNumbers { get; set; }
    }
}
