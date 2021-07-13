namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    partial class GSLocationAttacher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GSLocationAttacher));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAbrir = new MetroFramework.Controls.MetroButton();
            this.btnCopiar = new MetroFramework.Controls.MetroButton();
            this.btnSubstituir = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(6, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnAbrir
            // 
            this.btnAbrir.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnAbrir.Location = new System.Drawing.Point(68, 21);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(53, 23);
            this.btnAbrir.TabIndex = 1;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.UseSelectable = true;
            // 
            // btnCopiar
            // 
            this.btnCopiar.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnCopiar.Location = new System.Drawing.Point(131, 21);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(60, 23);
            this.btnCopiar.TabIndex = 2;
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.UseSelectable = true;
            // 
            // btnSubstituir
            // 
            this.btnSubstituir.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnSubstituir.Location = new System.Drawing.Point(200, 21);
            this.btnSubstituir.Name = "btnSubstituir";
            this.btnSubstituir.Size = new System.Drawing.Size(84, 23);
            this.btnSubstituir.TabIndex = 3;
            this.btnSubstituir.Text = "Substituir";
            this.btnSubstituir.UseSelectable = true;
            // 
            // GSLocationAttacher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnSubstituir);
            this.Controls.Add(this.btnCopiar);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GSLocationAttacher";
            this.Size = new System.Drawing.Size(289, 59);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton btnAbrir;
        private MetroFramework.Controls.MetroButton btnCopiar;
        private MetroFramework.Controls.MetroButton btnSubstituir;
    }
}
