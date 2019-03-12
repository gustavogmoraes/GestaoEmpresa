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
        EnumTipoDeForm TipoDeForm { get; set; }

        IPresenter Presenter { get; set; }

        void Show();

        void Dispose();
    }
}
