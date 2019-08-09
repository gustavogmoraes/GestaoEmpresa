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

        public Action PostAction { get; set; }

        public Form View { get; set; }

        public GSWaitForm(Form view, Action worker, Action postAction)
        {
            InitializeComponent();

            View = view ?? throw new ArgumentNullException();
            Worker = worker ?? throw new ArgumentNullException();
            PostAction = postAction ?? throw new ArgumentNullException();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Run(Worker).ContinueWith(x =>
            {
                View.Invoke((MethodInvoker) delegate { PostAction(); });
                Invoke((MethodInvoker)Close);
            });

            //Task.Run(() => { Invoke((MethodInvoker)delegate { Worker(); }); }).ContinueWith(x =>
            //{
            //    Thread.Sleep(2000);
            //    Invoke((MethodInvoker)Close);
            //});

            //Task.Factory
            //    .StartNew(Worker)
            //    .ContinueWith(
            //        x => { View.Invoke((MethodInvoker) delegate
            //        {
            //            PostAction();
            //            Close();
            //        }); },
            //        TaskScheduler.FromCurrentSynchronizationContext());

        }
    }
}
