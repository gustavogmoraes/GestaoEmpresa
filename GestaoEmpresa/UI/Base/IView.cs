using System;
using GS.GestaoEmpresa.Business.Enumerators.Default;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.UI.Base;

namespace GS.GestaoEmpresa.UI.Base
{
    public interface IView
    {
        string InstanceId { get; set; }

        FormType FormType { get; set; }

        IPresenter Presenter { get; set; }

        bool IsRendering { get; set; }

        void SetBorderStyle();

        void Show();

        void Dispose();

        void MinimizeFormCall(object sender, EventArgs e);

        void CloseFormCall(object sender, EventArgs e);

        void MaximizeFormCall(object sender, EventArgs e);
    }
}
