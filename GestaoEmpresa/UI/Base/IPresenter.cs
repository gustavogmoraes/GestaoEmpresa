using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Infrastructure.Persistence.RavenDB.Support.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;

namespace GS.GestaoEmpresa.UI.Base
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

        Task<IList<Error>> SaveAsync();
    }
}
