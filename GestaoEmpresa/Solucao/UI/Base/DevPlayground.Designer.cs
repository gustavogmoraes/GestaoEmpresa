namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    partial class DevPlayground
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
            this.btnExecuteQuery = new MetroFramework.Controls.MetroButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQuery = new ICSharpCode.TextEditor.TextEditorControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExecuteQuery
            // 
            this.btnExecuteQuery.Location = new System.Drawing.Point(261, 253);
            this.btnExecuteQuery.Name = "btnExecuteQuery";
            this.btnExecuteQuery.Size = new System.Drawing.Size(246, 37);
            this.btnExecuteQuery.TabIndex = 1;
            this.btnExecuteQuery.Text = "Execute Query";
            this.btnExecuteQuery.UseSelectable = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtQuery);
            this.groupBox1.Controls.Add(this.btnExecuteQuery);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 410);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "C# RavenQuery Tester";
            // 
            // txtQuery
            // 
            this.txtQuery.IsReadOnly = false;
            this.txtQuery.Location = new System.Drawing.Point(50, 35);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(707, 200);
            this.txtQuery.TabIndex = 2;
            // 
            // DevPlayground
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 575);
            this.Controls.Add(this.groupBox1);
            this.Name = "DevPlayground";
            this.Text = "DevPlayground";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnExecuteQuery;
        private System.Windows.Forms.GroupBox groupBox1;
        private ICSharpCode.TextEditor.TextEditorControl txtQuery;
    }
}