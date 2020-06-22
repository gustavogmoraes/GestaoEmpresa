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

        public static void Mostrar(Form caller, [Optional]Action processamento, [Optional]Action posProcessamento)
        {
            caller.Invoke((MethodInvoker) delegate { _form.Show(); });

            if (processamento == null) { processamento = () => { }; }
            if (posProcessamento == null) { posProcessamento = () => { }; }

            _ = Task.Run(processamento).ContinueWith(x =>
              {
                  Thread.Sleep(TimeSpan.FromMilliseconds(700));
                  _ = caller.Invoke((MethodInvoker)delegate
                  {
                      posProcessamento();

                      _form.Hide();
                  });
              },
              TaskContinuationOptions.RunContinuationsAsynchronously);
        }
    }
}
