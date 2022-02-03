using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.UI.Base;

namespace GS.GestaoEmpresa.UI.GenericControls
{
    public partial class GSWaitForm : Form
    {
        static GSWaitForm()
        {
            _form = new GSWaitForm
            {
                TopMost = true,
                WindowState = FormWindowState.Normal
            };
        }

        public GSWaitForm()
        {
            InitializeComponent();
        }

        private static GSWaitForm _form { get; set; }

        public static void Mostrar([Optional]Action processing, [Optional]Action postProcessing)
        {
            ViewManager.GetMain().Invoke((MethodInvoker)delegate
            {
                _form.Show();
            });

            processing ??= () => { };
            postProcessing ??= () => { };

            Task.Run(processing).ContinueWith(x =>
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(700));

                ViewManager.GetMain().Invoke((MethodInvoker)delegate
                {
                    postProcessing();
                    _form.Hide();
                });
            },
            TaskScheduler.Default);
        }
    }
}
