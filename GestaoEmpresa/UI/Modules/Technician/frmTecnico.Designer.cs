namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Tecnico
{
    partial class frmTecnico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFluxoLab = new System.Windows.Forms.Button();
            this.ScrollSelecao = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabProdutosLab = new System.Windows.Forms.TabPage();
            this.tabHistorico = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.colunaCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaCodigoFabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPrecoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPrecoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDetalhar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabProdutosLab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnFluxoLab);
            this.panel1.Controls.Add(this.ScrollSelecao);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1148, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 647);
            this.panel1.TabIndex = 8;
            // 
            // btnFluxoLab
            // 
            this.btnFluxoLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFluxoLab.BackColor = System.Drawing.Color.DimGray;
            this.btnFluxoLab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFluxoLab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFluxoLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFluxoLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFluxoLab.ForeColor = System.Drawing.Color.White;
            this.btnFluxoLab.Location = new System.Drawing.Point(17, 10);
            this.btnFluxoLab.Name = "btnFluxoLab";
            this.btnFluxoLab.Size = new System.Drawing.Size(118, 107);
            this.btnFluxoLab.TabIndex = 9;
            this.btnFluxoLab.Text = "Controle de Laboratório";
            this.btnFluxoLab.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFluxoLab.UseVisualStyleBackColor = false;
            this.btnFluxoLab.Click += new System.EventHandler(this.btnFluxoLab_Click);
            // 
            // ScrollSelecao
            // 
            this.ScrollSelecao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollSelecao.BackColor = System.Drawing.Color.SteelBlue;
            this.ScrollSelecao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScrollSelecao.Location = new System.Drawing.Point(7, 10);
            this.ScrollSelecao.Name = "ScrollSelecao";
            this.ScrollSelecao.Size = new System.Drawing.Size(11, 106);
            this.ScrollSelecao.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "_________________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "_________________";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabProdutosLab);
            this.tabControl2.Controls.Add(this.tabHistorico);
            this.tabControl2.Location = new System.Drawing.Point(-1, 62);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1178, 638);
            this.tabControl2.TabIndex = 9;
            // 
            // tabProdutosLab
            // 
            this.tabProdutosLab.BackColor = System.Drawing.Color.Silver;
            this.tabProdutosLab.Controls.Add(this.dgvProdutos);
            this.tabProdutosLab.Location = new System.Drawing.Point(4, 22);
            this.tabProdutosLab.Name = "tabProdutosLab";
            this.tabProdutosLab.Padding = new System.Windows.Forms.Padding(3);
            this.tabProdutosLab.Size = new System.Drawing.Size(1170, 612);
            this.tabProdutosLab.TabIndex = 0;
            this.tabProdutosLab.Text = "tabControleLab";
            // 
            // tabHistorico
            // 
            this.tabHistorico.BackColor = System.Drawing.Color.Silver;
            this.tabHistorico.Location = new System.Drawing.Point(4, 22);
            this.tabHistorico.Name = "tabHistorico";
            this.tabHistorico.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistorico.Size = new System.Drawing.Size(1170, 612);
            this.tabHistorico.TabIndex = 1;
            this.tabHistorico.Text = "tabN";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::GS.GestaoEmpresa.Properties.Resources.TenicoBlueCerto2;
            this.pictureBox2.InitialImage = global::GS.GestaoEmpresa.Properties.Resources.BoxBlueShort;
            this.pictureBox2.Location = new System.Drawing.Point(11, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(68, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.AllowUserToOrderColumns = true;
            this.dgvProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProdutos.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProdutos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaCodigo,
            this.colunaCodigoFabricante,
            this.colunaStatus,
            this.colunaNome,
            this.colunaDescricao,
            this.colunaPrecoCompra,
            this.colunaPrecoVenda,
            this.colunaQuantidade,
            this.colunaDetalhar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProdutos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProdutos.GridColor = System.Drawing.Color.Silver;
            this.dgvProdutos.Location = new System.Drawing.Point(0, 39);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.Size = new System.Drawing.Size(1185, 567);
            this.dgvProdutos.TabIndex = 1;
            // 
            // colunaCodigo
            // 
            this.colunaCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaCodigo.HeaderText = "Código";
            this.colunaCodigo.Name = "colunaCodigo";
            this.colunaCodigo.ReadOnly = true;
            this.colunaCodigo.Width = 75;
            // 
            // colunaCodigoFabricante
            // 
            this.colunaCodigoFabricante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaCodigoFabricante.HeaderText = "Código do fabricante";
            this.colunaCodigoFabricante.Name = "colunaCodigoFabricante";
            this.colunaCodigoFabricante.ReadOnly = true;
            this.colunaCodigoFabricante.Width = 186;
            // 
            // colunaStatus
            // 
            this.colunaStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colunaStatus.HeaderText = "Status";
            this.colunaStatus.Name = "colunaStatus";
            this.colunaStatus.ReadOnly = true;
            this.colunaStatus.Width = 81;
            // 
            // colunaNome
            // 
            this.colunaNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaNome.HeaderText = "Nome";
            this.colunaNome.Name = "colunaNome";
            this.colunaNome.ReadOnly = true;
            // 
            // colunaDescricao
            // 
            this.colunaDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaDescricao.HeaderText = "Descrição";
            this.colunaDescricao.Name = "colunaDescricao";
            this.colunaDescricao.ReadOnly = true;
            // 
            // colunaPrecoCompra
            // 
            this.colunaPrecoCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaPrecoCompra.HeaderText = "Preço de Compra";
            this.colunaPrecoCompra.Name = "colunaPrecoCompra";
            this.colunaPrecoCompra.ReadOnly = true;
            this.colunaPrecoCompra.Width = 120;
            // 
            // colunaPrecoVenda
            // 
            this.colunaPrecoVenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaPrecoVenda.HeaderText = "Preço de Venda";
            this.colunaPrecoVenda.Name = "colunaPrecoVenda";
            this.colunaPrecoVenda.ReadOnly = true;
            this.colunaPrecoVenda.Width = 115;
            // 
            // colunaQuantidade
            // 
            this.colunaQuantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaQuantidade.HeaderText = "Quantidade em estoque";
            this.colunaQuantidade.Name = "colunaQuantidade";
            this.colunaQuantidade.ReadOnly = true;
            this.colunaQuantidade.Width = 125;
            // 
            // colunaDetalhar
            // 
            this.colunaDetalhar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaDetalhar.HeaderText = "";
            this.colunaDetalhar.Name = "colunaDetalhar";
            this.colunaDetalhar.ReadOnly = true;
            this.colunaDetalhar.Width = 30;
            // 
            // frmTecnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 681);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl2);
            this.Name = "frmTecnico";
            this.Text = "frmTecnico";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabProdutosLab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ScrollSelecao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFluxoLab;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabProdutosLab;
        private System.Windows.Forms.TabPage tabHistorico;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodigoFabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPrecoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPrecoVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaQuantidade;
        private System.Windows.Forms.DataGridViewButtonColumn colunaDetalhar;
    }
}