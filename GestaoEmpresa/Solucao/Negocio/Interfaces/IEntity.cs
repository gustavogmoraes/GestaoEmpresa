using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Persistencia.Interfaces;

namespace GS.GestaoEmpresa.Solucao.Negocio.Interfaces
{
    public interface IEntity : IRavenDbDocument
    {
        int Code { get; set; }
    }
}
