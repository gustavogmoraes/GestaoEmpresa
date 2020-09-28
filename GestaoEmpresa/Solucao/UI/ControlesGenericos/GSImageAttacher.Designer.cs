namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    partial class GSImageAttacher
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GSImageAttacher));
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.tabAdd = new System.Windows.Forms.TabPage();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl.SuspendLayout();
            this.tabAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl.Controls.Add(this.tabAdd);
            this.tabControl.FontWeight = MetroFramework.MetroTabControlWeight.Bold;
            this.tabControl.HotTrack = true;
            this.tabControl.ItemSize = new System.Drawing.Size(54, 20);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(200, 163);
            this.tabControl.TabIndex = 0;
            this.tabControl.UseCustomBackColor = true;
            this.tabControl.UseSelectable = true;
            this.tabControl.Click += new System.EventHandler(this.tabControl_Click);
            // 
            // tabAdd
            // 
            this.tabAdd.Controls.Add(this.metroLabel1);
            this.tabAdd.Location = new System.Drawing.Point(4, 24);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Size = new System.Drawing.Size(192, 135);
            this.tabAdd.TabIndex = 0;
            this.tabAdd.Tag = "tabAdd";
            this.tabAdd.Text = "+";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(8, 8);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(152, 38);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Clique no + acima para \r\nadicionar uma imagem";
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.WrapToLine = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // GSImageAttacher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tabControl);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.LightGray;
            this.Name = "GSImageAttacher";
            this.Size = new System.Drawing.Size(198, 161);
            this.tabControl.ResumeLayout(false);
            this.tabAdd.ResumeLayout(false);
            this.tabAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public MetroFramework.Controls.MetroTabControl tabControl;
        private System.Windows.Forms.TabPage tabAdd;
        public System.Windows.Forms.OpenFileDialog openFileDialog;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}
