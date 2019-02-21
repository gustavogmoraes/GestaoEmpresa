namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    partial class frmExportarProdutos
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gridExportacao = new System.Windows.Forms.DataGridView();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renomearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportar = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.gridExportacao)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exportação de Produtos para planilha XLSx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(384, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Escolha as informações que deseja exportar:";
            // 
            // gridExportacao
            // 
            this.gridExportacao.AllowUserToAddRows = false;
            this.gridExportacao.AllowUserToDeleteRows = false;
            this.gridExportacao.AllowUserToOrderColumns = true;
            this.gridExportacao.AllowUserToResizeColumns = false;
            this.gridExportacao.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridExportacao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridExportacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridExportacao.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridExportacao.EnableHeadersVisualStyles = false;
            this.gridExportacao.Location = new System.Drawing.Point(26, 117);
            this.gridExportacao.Name = "gridExportacao";
            this.gridExportacao.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridExportacao.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridExportacao.RowHeadersVisible = false;
            this.gridExportacao.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridExportacao.Size = new System.Drawing.Size(749, 217);
            this.gridExportacao.TabIndex = 4;
            this.gridExportacao.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridExportacao_CellMouseDown);
            this.gridExportacao.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.gridExportacao_ColumnAdded);
            // 
            // txtBox
            // 
            this.txtBox.BackColor = System.Drawing.Color.DarkGreen;
            this.txtBox.ForeColor = System.Drawing.Color.White;
            this.txtBox.Location = new System.Drawing.Point(26, 369);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(100, 20);
            this.txtBox.TabIndex = 5;
            this.txtBox.Visible = false;
            this.txtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyDown);
            this.txtBox.Leave += new System.EventHandler(this.txtBox_Leave_1);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renomearToolStripMenuItem,
            this.deletarToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.ShowImageMargin = false;
            this.contextMenuStrip.Size = new System.Drawing.Size(104, 48);
            // 
            // renomearToolStripMenuItem
            // 
            this.renomearToolStripMenuItem.Name = "renomearToolStripMenuItem";
            this.renomearToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.renomearToolStripMenuItem.Text = "Renomear";
            this.renomearToolStripMenuItem.Click += new System.EventHandler(this.renomearToolStripMenuItem_Click_1);
            // 
            // deletarToolStripMenuItem
            // 
            this.deletarToolStripMenuItem.Name = "deletarToolStripMenuItem";
            this.deletarToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.deletarToolStripMenuItem.Text = "Deletar";
            this.deletarToolStripMenuItem.Click += new System.EventHandler(this.deletarToolStripMenuItem_Click_1);
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Location = new System.Drawing.Point(691, 359);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(84, 30);
            this.btnExportar.TabIndex = 6;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // frmExportarProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.gridExportacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmExportarProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportar Produtos";
            this.Load += new System.EventHandler(this.frmExportarProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridExportacao)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridExportacao;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem renomearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletarToolStripMenuItem;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}