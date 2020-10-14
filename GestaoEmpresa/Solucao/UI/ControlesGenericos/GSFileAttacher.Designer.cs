namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    partial class GSFileAttacher
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
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
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(353, 101);
            this.tabControl.TabIndex = 1;
            this.tabControl.UseCustomBackColor = true;
            this.tabControl.UseSelectable = true;
            this.tabControl.Click += new System.EventHandler(this.tabControl_Click);
            // 
            // tabAdd
            // 
            this.tabAdd.Controls.Add(this.metroLabel1);
            this.tabAdd.Location = new System.Drawing.Point(4, 24);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Size = new System.Drawing.Size(345, 73);
            this.tabAdd.TabIndex = 0;
            this.tabAdd.Tag = "tabAdd";
            this.tabAdd.Text = "+";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(8, 8);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(277, 38);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Clique no + acima para adicionar um arquivo\r\n";
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.WrapToLine = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // GSFileAttacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "GSFileAttacher";
            this.Size = new System.Drawing.Size(362, 108);
            this.tabControl.ResumeLayout(false);
            this.tabAdd.ResumeLayout(false);
            this.tabAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public MetroFramework.Controls.MetroTabControl tabControl;
        private System.Windows.Forms.TabPage tabAdd;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        public System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
