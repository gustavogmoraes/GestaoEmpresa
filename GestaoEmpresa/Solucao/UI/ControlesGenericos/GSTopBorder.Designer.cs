namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    partial class GSTopBorder
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
            this.btnClose = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(409, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(17, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "x";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.Location = new System.Drawing.Point(392, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(17, 26);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.Text = "_";
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click_1);
            // 
            // GSTopBorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Name = "GSTopBorder";
            this.Size = new System.Drawing.Size(426, 26);
            this.Load += new System.EventHandler(this.GSTopBorder_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GSTopBorder_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label btnClose;
        private System.Windows.Forms.Label btnMinimize;
    }
}
