using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    public partial class GSWaitForm : Form
    {
        public Action Worker { get; set; }

        public GSWaitForm(Action worker)
        {
            InitializeComponent();

            Worker = worker ?? throw new ArgumentNullException();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Task.Run(() => { Invoke((MethodInvoker)delegate { Worker(); }); }).ContinueWith(x =>
            //{
            //    //Thread.Sleep(1000);
            //    Invoke((MethodInvoker)Close);
            //});

            Task.Factory
                .StartNew(Worker)
                .ContinueWith(
                    x =>
                    {
                        this.Close();
                    },
                    TaskScheduler.FromCurrentSynchronizationContext());

        }
    }
}
