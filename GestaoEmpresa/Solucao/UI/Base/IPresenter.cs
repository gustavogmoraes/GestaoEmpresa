using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;

namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    public interface IPresenter
    {
        string IdInstancia { get; set; }

        IView View { get; set; }

        Type Model { get; set; }

        void CarregueControlesComModel();
    }
}
