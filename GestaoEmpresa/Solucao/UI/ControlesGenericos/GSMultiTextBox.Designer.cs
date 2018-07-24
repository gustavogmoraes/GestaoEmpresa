﻿namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
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
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.txtLineMultiTextBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.add;
            this.btnAdicionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdicionar.Location = new System.Drawing.Point(386, 1);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(32, 30);
            this.btnAdicionar.TabIndex = 0;
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.delete;
            this.btnRemover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemover.Location = new System.Drawing.Point(419, 1);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(32, 30);
            this.btnRemover.TabIndex = 1;
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Visible = false;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // txtTexto
            // 
            this.txtTexto.BackColor = System.Drawing.Color.Silver;
            this.txtTexto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTexto.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexto.ForeColor = System.Drawing.Color.Black;
            this.txtTexto.Location = new System.Drawing.Point(0, 3);
            this.txtTexto.MaxLength = 100;
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(382, 24);
            this.txtTexto.TabIndex = 105;
            // 
            // txtLineMultiTextBox
            // 
            this.txtLineMultiTextBox.AutoSize = true;
            this.txtLineMultiTextBox.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineMultiTextBox.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineMultiTextBox.Location = new System.Drawing.Point(-6, -10);
            this.txtLineMultiTextBox.Name = "txtLineMultiTextBox";
            this.txtLineMultiTextBox.Size = new System.Drawing.Size(400, 44);
            this.txtLineMultiTextBox.TabIndex = 106;
            this.txtLineMultiTextBox.Text = "____________________";
            // 
            // GSMultiTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.txtLineMultiTextBox);
            this.Name = "GSMultiTextBox";
            this.Size = new System.Drawing.Size(451, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Label txtLineMultiTextBox;
    }
}
