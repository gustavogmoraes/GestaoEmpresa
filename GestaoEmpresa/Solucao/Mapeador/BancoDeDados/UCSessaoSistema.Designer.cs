namespace GS.GestaoEmpresa.Solucao.Mapeador.BancoDeDados
{
    partial class UCSessaoSistema
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
            this.lblNome = new System.Windows.Forms.Label();
            this.lblModulo = new System.Windows.Forms.Label();
            this.pbModulo = new System.Windows.Forms.PictureBox();
            this.lblUsr = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbModulo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(225, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(0, 20);
            this.lblNome.TabIndex = 1;
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModulo.ForeColor = System.Drawing.Color.White;
            this.lblModulo.Location = new System.Drawing.Point(76, 12);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(146, 42);
            this.lblModulo.TabIndex = 2;
            this.lblModulo.Text = "Módulo";
            // 
            // pbModulo
            // 
            this.pbModulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbModulo.Location = new System.Drawing.Point(1, 4);
            this.pbModulo.Name = "pbModulo";
            this.pbModulo.Size = new System.Drawing.Size(69, 65);
            this.pbModulo.TabIndex = 3;
            this.pbModulo.TabStop = false;
            // 
            // lblUsr
            // 
            this.lblUsr.AutoSize = true;
            this.lblUsr.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsr.ForeColor = System.Drawing.Color.White;
            this.lblUsr.Location = new System.Drawing.Point(261, 40);
            this.lblUsr.Name = "lblUsr";
            this.lblUsr.Size = new System.Drawing.Size(83, 23);
            this.lblUsr.TabIndex = 4;
            this.lblUsr.Text = "Usuário:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(341, 41);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(0, 22);
            this.lblUsuario.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(261, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Empresa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(353, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mega Telecomunicações";
            // 
            // UCSessaoSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblUsr);
            this.Controls.Add(this.pbModulo);
            this.Controls.Add(this.lblModulo);
            this.Controls.Add(this.lblNome);
            this.Name = "UCSessaoSistema";
            this.Size = new System.Drawing.Size(1280, 66);
            this.Load += new System.EventHandler(this.UCSessaoSistema_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbModulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.PictureBox pbModulo;
        private System.Windows.Forms.Label lblUsr;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
