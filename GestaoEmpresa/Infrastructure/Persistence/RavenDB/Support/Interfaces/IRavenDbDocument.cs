using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces
{
    public interface IRavenDbDocument
    {
        string Id { get; set; }
    }
}
