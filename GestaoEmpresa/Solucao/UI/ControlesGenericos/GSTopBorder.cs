using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.UI.Base;
using MetroFramework.Forms;

namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    public partial class GSTopBorder : UserControl
    {
        #region Draggable Form

        public const int WM_NCLBUTTONDOWN = 0xA1;

        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void GSTopBorder_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();

                // Temos que ativar o movable do Metro Form, senão ele não consegue mover
                // Salvamos o valor para volta-lo ao que ele é depois de mover
                var movable = ((MetroForm) ParentForm).Movable;
                ((MetroForm) ParentForm).Movable = true;

                SendMessage(ParentForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

                ((MetroForm) ParentForm).Movable = movable;
            }
        }

        #endregion

        public GSTopBorder()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            (ParentForm as IView).ChamadaFecharForm(sender, e);
        }

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            (ParentForm as IView).ChamadaMinimizarForm(sender, e);
        }
    }
}
