using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Utilitarios
{
    public class GSAssistenteDeDigitacao
    {
        public event EventHandler Idled = delegate { };
        public int MilissegundosDeEspera { get; set; }
        Timer timer;

        public GSAssistenteDeDigitacao(int milissegundosDeEspera = 650)
        {
            MilissegundosDeEspera = milissegundosDeEspera;
            timer = new Timer(p =>
            {
                Idled(this, EventArgs.Empty);
            });
        }
        public void TextChanged()
        {
            timer.Change(MilissegundosDeEspera, Timeout.Infinite);
        }
    }
}
