using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GS.GestaoEmpresa.Business.Interfaces;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces;
using GS.GestaoEmpresa.UI.Base;

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
