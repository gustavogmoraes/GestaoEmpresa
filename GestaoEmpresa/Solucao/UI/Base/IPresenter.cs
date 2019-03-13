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
        string IdInstancia { get; set; }

        IView View { get; set; }

        IConceito Model { get; set; }

        void CarregueControlesComModel();

        void CarregueModelComControles();

        DialogResult ExibaPromptConfirmacao(string mensagem);

        void MinimizarView(object sender, EventArgs eventArgs);

        void FecharView(object sender, EventArgs eventArgs);

        void HabiliteControles(IList<string> excecoes = null);

        void DesabiliteControles(IList<string> excecoes = null);
    }
}
