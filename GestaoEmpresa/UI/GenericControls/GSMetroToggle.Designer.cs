namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    partial class GSMetroToggle
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
            this.metroToggle = new MetroFramework.Controls.MetroToggle();
            this.txtTexto = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroToggle
            // 
            this.metroToggle.AutoSize = true;
            this.metroToggle.Checked = true;
            this.metroToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroToggle.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.metroToggle.Location = new System.Drawing.Point(30, 12);
            this.metroToggle.Name = "metroToggle";
            this.metroToggle.Size = new System.Drawing.Size(80, 17);
            this.metroToggle.TabIndex = 0;
            this.metroToggle.Text = "On";
            this.metroToggle.UseCustomBackColor = true;
            this.metroToggle.UseSelectable = true;
            this.metroToggle.CheckedChanged += new System.EventHandler(this.metroToggle_CheckedChanged);
            // 
            // txtTexto
            // 
            this.txtTexto.AutoSize = true;
            this.txtTexto.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.txtTexto.Location = new System.Drawing.Point(11, 13);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(41, 19);
            this.txtTexto.TabIndex = 1;
            this.txtTexto.Text = "Ativo";
            this.txtTexto.UseCustomBackColor = true;
            // 
            // GSMetroToggle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.metroToggle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GSMetroToggle";
            this.Size = new System.Drawing.Size(121, 40);
            this.UseCustomBackColor = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroToggle metroToggle;
        private MetroFramework.Controls.MetroLabel txtTexto;
    }
}
