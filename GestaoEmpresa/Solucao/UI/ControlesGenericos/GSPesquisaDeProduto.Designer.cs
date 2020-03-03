namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    partial class GSPesquisaDeProduto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvItensPesquisa = new System.Windows.Forms.DataGridView();
            this.colunaOrcaCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaCodigoFabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaPrecoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaPrecoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaSelecionar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensPesquisa)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItensPesquisa
            // 
            this.dgvItensPesquisa.AllowUserToAddRows = false;
            this.dgvItensPesquisa.AllowUserToDeleteRows = false;
            this.dgvItensPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItensPesquisa.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItensPesquisa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItensPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensPesquisa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaOrcaCodigo,
            this.colunaOrcaNome,
            this.colunaCodigoFabricante,
            this.colunaOrcaPrecoCompra,
            this.colunaOrcaPrecoVenda,
            this.colunaOrcaSelecionar});
            this.dgvItensPesquisa.GridColor = System.Drawing.Color.Silver;
            this.dgvItensPesquisa.Location = new System.Drawing.Point(0, 0);
            this.dgvItensPesquisa.Name = "dgvItensPesquisa";
            this.dgvItensPesquisa.ReadOnly = true;
            this.dgvItensPesquisa.RowHeadersVisible = false;
            this.dgvItensPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItensPesquisa.Size = new System.Drawing.Size(800, 150);
            this.dgvItensPesquisa.TabIndex = 60;
            this.dgvItensPesquisa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItensPesquisa_CellContentClick);
            this.dgvItensPesquisa.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItensPesquisa_RowEnter);
            this.dgvItensPesquisa.Leave += new System.EventHandler(this.dgvItensPesquisa_Leave);
            // 
            // colunaOrcaCodigo
            // 
            this.colunaOrcaCodigo.HeaderText = "";
            this.colunaOrcaCodigo.Name = "colunaOrcaCodigo";
            this.colunaOrcaCodigo.ReadOnly = true;
            this.colunaOrcaCodigo.Visible = false;
            // 
            // colunaOrcaNome
            // 
            this.colunaOrcaNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaOrcaNome.HeaderText = "Nome / Descrição";
            this.colunaOrcaNome.Name = "colunaOrcaNome";
            this.colunaOrcaNome.ReadOnly = true;
            // 
            // colunaCodigoFabricante
            // 
            this.colunaCodigoFabricante.HeaderText = "Código do Fabricante";
            this.colunaCodigoFabricante.Name = "colunaCodigoFabricante";
            this.colunaCodigoFabricante.ReadOnly = true;
            // 
            // colunaOrcaPrecoCompra
            // 
            this.colunaOrcaPrecoCompra.HeaderText = "Preço de compra";
            this.colunaOrcaPrecoCompra.Name = "colunaOrcaPrecoCompra";
            this.colunaOrcaPrecoCompra.ReadOnly = true;
            this.colunaOrcaPrecoCompra.Width = 150;
            // 
            // colunaOrcaPrecoVenda
            // 
            this.colunaOrcaPrecoVenda.HeaderText = "Preço de venda";
            this.colunaOrcaPrecoVenda.Name = "colunaOrcaPrecoVenda";
            this.colunaOrcaPrecoVenda.ReadOnly = true;
            this.colunaOrcaPrecoVenda.Width = 150;
            // 
            // colunaOrcaSelecionar
            // 
            this.colunaOrcaSelecionar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaOrcaSelecionar.HeaderText = "";
            this.colunaOrcaSelecionar.Name = "colunaOrcaSelecionar";
            this.colunaOrcaSelecionar.ReadOnly = true;
            this.colunaOrcaSelecionar.Width = 30;
            // 
            // GSPesquisaDeProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvItensPesquisa);
            this.Name = "GSPesquisaDeProduto";
            this.Size = new System.Drawing.Size(800, 150);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensPesquisa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvItensPesquisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodigoFabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaPrecoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaPrecoVenda;
        private System.Windows.Forms.DataGridViewButtonColumn colunaOrcaSelecionar;
    }
}
