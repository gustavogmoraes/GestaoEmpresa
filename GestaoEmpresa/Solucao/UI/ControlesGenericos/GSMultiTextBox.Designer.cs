using MetroFramework.Controls;

namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    partial class GSMultiTextBox
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
            this.txtTexto = new MetroFramework.Controls.MetroTextBox();
            this.btnRemover = new MetroFramework.Controls.MetroButton();
            this.btnAdicionar = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // txtTexto
            // 
            this.txtTexto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtTexto.CustomButton.Image = null;
            this.txtTexto.CustomButton.Location = new System.Drawing.Point(362, 2);
            this.txtTexto.CustomButton.Name = "";
            this.txtTexto.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.txtTexto.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTexto.CustomButton.TabIndex = 1;
            this.txtTexto.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTexto.CustomButton.UseSelectable = true;
            this.txtTexto.CustomButton.Visible = false;
            this.txtTexto.ForeColor = System.Drawing.Color.Black;
            this.txtTexto.Lines = new string[0];
            this.txtTexto.Location = new System.Drawing.Point(2, 4);
            this.txtTexto.MaxLength = 100;
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.PasswordChar = '\0';
            this.txtTexto.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTexto.SelectedText = "";
            this.txtTexto.SelectionLength = 0;
            this.txtTexto.SelectionStart = 0;
            this.txtTexto.ShortcutsEnabled = true;
            this.txtTexto.Size = new System.Drawing.Size(382, 22);
            this.txtTexto.TabIndex = 105;
            this.txtTexto.TabStop = false;
            this.txtTexto.UseSelectable = true;
            this.txtTexto.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTexto.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTexto_KeyDown);
            // 
            // btnRemover
            // 
            this.btnRemover.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnRemover.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.delete;
            this.btnRemover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemover.Location = new System.Drawing.Point(388, 3);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(24, 23);
            this.btnRemover.TabIndex = 106;
            this.btnRemover.UseSelectable = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnAdicionar.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.add;
            this.btnAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdicionar.Location = new System.Drawing.Point(418, 3);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(24, 23);
            this.btnAdicionar.TabIndex = 107;
            this.btnAdicionar.UseSelectable = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // GSMultiTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.txtTexto);
            this.Name = "GSMultiTextBox";
            this.Size = new System.Drawing.Size(449, 30);
            this.ResumeLayout(false);

        }

        #endregion
        public MetroTextBox txtTexto;
        private MetroButton btnRemover;
        private MetroButton btnAdicionar;
    }
}
