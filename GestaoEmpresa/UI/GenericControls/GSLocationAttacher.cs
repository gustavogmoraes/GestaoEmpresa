using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    public partial class GSLocationAttacher : UserControl
    {
        public string MapsLocation { get; set; }

        public GSLocationAttacher()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Task.Run(() =>
            //{
            //    while (!txtTexto.IsHandleCreated) { Thread.Sleep(100); }
            //    Invoke((MethodInvoker)delegate
            //    {
            //        txtTexto.Text = metroToggle.Checked
            //                      ? TextoOn ?? "Ativo"
            //                      : TextoOff ?? "Inativo";
            //    });
            //});
        }

        
    }
}
