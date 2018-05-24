using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.UI
{
    public interface IFormPadrao<TEntidade>
        where TEntidade : class, new()
    {
        List<Control> ListaDeControles { get; set; }

        CultureInfo Cultura { get; }

        void CarregueComboDeVigencias(int codigo);

        void CarregueControlesComObjeto(TEntidade objeto);

        TEntidade CarregueObjetoComControles();

        void HabiliteControles();

        void DesabiliteControles();

        void HabiliteEdicao();

        void Salve();
    }
}
