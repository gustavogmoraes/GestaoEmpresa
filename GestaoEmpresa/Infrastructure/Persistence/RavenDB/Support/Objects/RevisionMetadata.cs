using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Infrastructure.Persistence.RavenDB.Support.Objects
{
    public class RevisionMetadata
    {
        public DateTime DateTime { get; set; }

        public string ChangeVector { get; set; }
    }
}
