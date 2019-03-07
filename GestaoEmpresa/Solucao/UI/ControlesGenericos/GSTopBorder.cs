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
                SendMessage(this.ParentForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        public GSTopBorder()
        {
            InitializeComponent();
        }

        private void GSTopBorder_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            ParentForm.WindowState = FormWindowState.Minimized;
        }
    }
}
