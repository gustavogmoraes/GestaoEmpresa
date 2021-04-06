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
        string IdInstancia { get; set; }

        EnumTipoDeForm TipoDeForm { get; set; }

        IPresenter Presenter { get; set; }

        bool EstahRenderizando { get; set; }

        void Show();

        void Dispose();

        void ChamadaMinimizarForm(object sender, EventArgs e);

        void ChamadaFecharForm(object sender, EventArgs e);

        void ChamadaMaximizarForm(object sender, EventArgs e);
    }
}
