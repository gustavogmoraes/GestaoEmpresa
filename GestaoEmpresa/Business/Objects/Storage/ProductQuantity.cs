using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Business.Interfaces;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Objects;

namespace GS.GestaoEmpresa.Business.Objects.Storage
{
    public class ProductQuantity : RavenDbDocument
    {
        public int ProductCode { get; set; }

        public int Quantity { get; set; }
    }
}
