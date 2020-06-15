using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    public partial class GSWaitForm : Form
    {
        public GSWaitForm()
        {
            InitializeComponent();
        }

        static GSWaitForm()
        {
            _form = new GSWaitForm
            {
                TopMost = true,
                WindowState = FormWindowState.Normal
            };
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
