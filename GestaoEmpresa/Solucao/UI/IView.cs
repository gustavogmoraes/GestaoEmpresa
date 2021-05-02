using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.UI.Base;

namespace GS.GestaoEmpresa.Solucao.UI
{
    public interface IView
    {
        string InstanceId { get; set; }

        EnumTipoDeForm TipoDeForm { get; set; }

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
