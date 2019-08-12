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

        public static void Mostrar(Form caller, [Optional]Action processamento, [Optional]Action posProcessamento)
        {
            var form = new GSWaitForm
            {
                TopMost = true,
                WindowState = FormWindowState.Normal
            };

            caller.Invoke((MethodInvoker) delegate { form.Show(); });

            if (processamento == null)
            {
                processamento = () => { };
            }

            if (posProcessamento == null)
            {
                posProcessamento = () => { };
            }

            var task = Task.Run(processamento);

            Task.WhenAll(task).ContinueWith(x =>
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(700));

                caller.Invoke((MethodInvoker) delegate
                {
                    posProcessamento();

                    form.Hide();
                    form.Close();
                    form.Dispose();
                });
            },
            TaskContinuationOptions.RunContinuationsAsynchronously);
        }
    }
}
