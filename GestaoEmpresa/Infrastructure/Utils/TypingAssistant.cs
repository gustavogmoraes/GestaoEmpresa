using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Utilitarios
{
    public class GsTypingAssistant
    {
        public event EventHandler Idled = delegate { };
        public int WaitingMs { get; set; }

        private readonly Timer _timer;  

        public GsTypingAssistant(int dueTime = 650)
        {       
            WaitingMs = dueTime;

            _timer = new Timer(x => { Idled(this, EventArgs.Empty); });
        }

        public GsTypingAssistant(TimeSpan dueTime)
        {
            WaitingMs = Convert.ToInt32(dueTime.TotalMilliseconds);

            _timer = new Timer(x => { Idled(this, EventArgs.Empty); });
        }

        public void TextChanged()
        {
            _timer.Change(WaitingMs, Timeout.Infinite);
        }
    }
}
