namespace GS.GestaoEmpresa.Solucao.UI
{
    partial class GSTextBoxMonetaria
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
            this.components = new System.ComponentModel.Container();
            this.lblCifrao = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtLine = new System.Windows.Forms.Label();
            this.pbErro = new System.Windows.Forms.PictureBox();
            this.ttErro = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbErro)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCifrao
            // 
            this.lblCifrao.AutoSize = true;
            this.lblCifrao.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCifrao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCifrao.Location = new System.Drawing.Point(9, 4);
            this.lblCifrao.Name = "lblCifrao";
            this.lblCifrao.Size = new System.Drawing.Size(33, 22);
            this.lblCifrao.TabIndex = 98;
            this.lblCifrao.Text = "R$";
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.Color.Silver;
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtValor.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(43, 4);
            this.txtValor.MaxLength = 8;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(126, 24);
            this.txtValor.TabIndex = 95;
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            // 
            // txtLine
            // 
            this.txtLine.AutoSize = true;
            this.txtLine.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLine.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLine.Location = new System.Drawing.Point(-5, -10);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(191, 44);
            this.txtLine.TabIndex = 97;
            this.txtLine.Text = "_________";
            // 
            // pbErro
            // 
            this.pbErro.Enabled = false;
            this.pbErro.Image = global::GS.GestaoEmpresa.Properties.Resources.error_icon;
            this.pbErro.Location = new System.Drawing.Point(181, 5);
            this.pbErro.Name = "pbErro";
            this.pbErro.Size = new System.Drawing.Size(32, 26);
            this.pbErro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbErro.TabIndex = 99;
            this.pbErro.TabStop = false;
            this.pbErro.Visible = false;
            // 
            // ttErro
            // 
            this.ttErro.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // GSTextBoxMonetaria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.pbErro);
            this.Controls.Add(this.lblCifrao);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtLine);
            this.Name = "GSTextBoxMonetaria";
            this.Size = new System.Drawing.Size(220, 36);
            ((System.ComponentModel.ISupportInitialize)(this.pbErro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCifrao;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label txtLine;
        private System.Windows.Forms.PictureBox pbErro;
        private System.Windows.Forms.ToolTip ttErro;
    }
}
