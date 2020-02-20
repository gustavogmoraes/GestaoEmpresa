namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    partial class GSForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GSForm));
            this.btnCancelarExcluir = new System.Windows.Forms.PictureBox();
            this.btnEditarSalvar = new System.Windows.Forms.PictureBox();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gsTopBorder1 = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSTopBorder();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).BeginInit();
            this.panelTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelarExcluir
            // 
            this.btnCancelarExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarExcluir.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarExcluir.ErrorImage")));
            this.btnCancelarExcluir.Image = global::GS.GestaoEmpresa.Properties.Resources.cancel_icon;
            this.btnCancelarExcluir.Location = new System.Drawing.Point(558, 28);
            this.btnCancelarExcluir.Name = "btnCancelarExcluir";
            this.btnCancelarExcluir.Size = new System.Drawing.Size(33, 26);
            this.btnCancelarExcluir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCancelarExcluir.TabIndex = 39;
            this.btnCancelarExcluir.TabStop = false;
            this.btnCancelarExcluir.Click += new System.EventHandler(this.btnCancelarExcluir_Click);
            // 
            // btnEditarSalvar
            // 
            this.btnEditarSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarSalvar.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnEditarSalvar.ErrorImage")));
            this.btnEditarSalvar.Image = global::GS.GestaoEmpresa.Properties.Resources.floppy_icon;
            this.btnEditarSalvar.InitialImage = null;
            this.btnEditarSalvar.Location = new System.Drawing.Point(516, 26);
            this.btnEditarSalvar.Name = "btnEditarSalvar";
            this.btnEditarSalvar.Size = new System.Drawing.Size(32, 30);
            this.btnEditarSalvar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnEditarSalvar.TabIndex = 38;
            this.btnEditarSalvar.TabStop = false;
            this.btnEditarSalvar.Click += new System.EventHandler(this.btnEditarSalvar_Click);
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelTitulo.Controls.Add(this.lblTitulo);
            this.panelTitulo.Controls.Add(this.gsTopBorder1);
            this.panelTitulo.Controls.Add(this.btnEditarSalvar);
            this.panelTitulo.Controls.Add(this.btnCancelarExcluir);
            this.panelTitulo.Location = new System.Drawing.Point(-2, -5);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(610, 62);
            this.panelTitulo.TabIndex = 52;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(19, 26);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 57);
            this.lblTitulo.TabIndex = 54;
            // 
            // gsTopBorder1
            // 
            this.gsTopBorder1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gsTopBorder1.Location = new System.Drawing.Point(3, -1);
            this.gsTopBorder1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gsTopBorder1.Name = "gsTopBorder1";
            this.gsTopBorder1.Size = new System.Drawing.Size(605, 26);
            this.gsTopBorder1.TabIndex = 53;
            // 
            // GSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = ((System.Drawing.Image)(resources.GetObject("$this.BackImage")));
            this.BackMaxSize = 1500;
            this.ClientSize = new System.Drawing.Size(599, 710);
            this.Controls.Add(this.panelTitulo);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Movable = false;
            this.Name = "GSForm";
            this.Padding = new System.Windows.Forms.Padding(23, 78, 23, 26);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.SystemShadow;
            this.Load += new System.EventHandler(this.GSForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.PictureBox btnCancelarExcluir;
        public System.Windows.Forms.PictureBox btnEditarSalvar;
        protected System.Windows.Forms.Label lblTitulo;
        protected System.Windows.Forms.Panel panelTitulo;
        protected ControlesGenericos.GSTopBorder gsTopBorder1;
    }
}