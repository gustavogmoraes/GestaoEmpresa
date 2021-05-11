using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Properties;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;

namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    public interface IPresenter
    {
        string InstanceId { get; set; }

        IView View { get; set; }

        IEntity Model { get; set; }

        void FillControlsWithModel(bool reloading = false);

        void FillModelWithControls();

        DialogResult DisplayConfirmationPrompt(string message);

        void MinimizeView(object sender, EventArgs eventArgs);

        void CloseView(object sender, EventArgs eventArgs);

        void EnableControls(IList<string> exceptions = null);

        void DisableControls(IList<string> exceptions = null);

        void ViewDidLoad();
    }
}
