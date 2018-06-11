using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.Negocio.Interfaces
{
    public interface IFormPadrao<TEntidade>
        where TEntidade : class
    {
        List <CampoDeTela> ListaDeCampos { get; }

        void CarregueControlesComObjeto(TEntidade objeto);

        TEntidade CarregueObjetoComControles();
    }
}
