using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos
{
    public class CampoDeTela
    {
        public string NomeDaPropriedade { get; set; }

        public Control ControleDoDado { get; set; }

        public Control ControleUnderLine { get; set; }

        public CampoDeTela(string nome, Control controleDoDado, Control controleUnderLine)
        {
            this.NomeDaPropriedade = nome;
            this.ControleDoDado = controleDoDado;
            this.ControleUnderLine = controleUnderLine;
        }
    }
}
