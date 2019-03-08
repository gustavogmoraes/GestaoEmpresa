using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.UI
{
    public interface IView
    {
        string IdInstancia { get; set; }

        void ApagueInstancia();
    }
}
