using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Business.Interfaces
{
    public interface IServiceWithRevision : IDisposable
    {
        Task<IList<DateTime>> QueryRevisionsAsync(string id);
    }
}
