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
        public int WaitingMilliSeconds { get; set; }
        Timer waitingTimer;

        public GSAssistenteDeDigitacao(int waitingMilliSeconds = 650)
        {
            WaitingMilliSeconds = waitingMilliSeconds;
            waitingTimer = new Timer(p =>
            {
                Idled(this, EventArgs.Empty);
            });
        }
        public void TextChanged()
        {
            waitingTimer.Change(WaitingMilliSeconds, Timeout.Infinite);
        }
    }
}
