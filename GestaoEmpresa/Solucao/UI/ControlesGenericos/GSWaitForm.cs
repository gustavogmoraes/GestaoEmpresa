using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
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
            GerenciadorDeViews.ObtenhaPrincipal().Invoke((MethodInvoker)delegate
            {
                _form.Show();
            });

            processing ??= () => { };
            postProcessing ??= () => { };

            Task.Run(processing).ContinueWith(x =>
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(700));

                GerenciadorDeViews.ObtenhaPrincipal().Invoke((MethodInvoker)delegate
                {
                    postProcessing();
                    _form.Hide();
                });
            },
            TaskScheduler.Default);
        }
    }
}
