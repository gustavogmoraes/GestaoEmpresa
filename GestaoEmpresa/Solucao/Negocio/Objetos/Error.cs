using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class Error
    {
        public string Module { get; set; }

        public string View { get; set; }

        public object ValidatedConcept { get; set; }

        public PropertyInfo ValidatedProperty { get; set; }

        public string Message { get; set; }

        public string NameOfValidatedProperty { get; set; }

        public string ValidatedPropertyDescription { get; set; }
    }
}
