using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    public interface IPresenter
    {
        IView View { get; set; }
    }
}
