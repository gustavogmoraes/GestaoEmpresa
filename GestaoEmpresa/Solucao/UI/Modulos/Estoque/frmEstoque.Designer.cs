namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    partial class frmEstoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstoque));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProdutos = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblPesquisarPor = new System.Windows.Forms.Label();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.btnNovoProduto = new System.Windows.Forms.Button();
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
            this.tabHistorico = new System.Windows.Forms.TabPage();
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.btnCatalogo = new System.Windows.Forms.Button();
            this.btnHistorico = new System.Windows.Forms.Button();
            this.ucSessaoSistema1 = new GS.GestaoEmpresa.Solucao.Mapeador.BancoDeDados.UCSessaoSistema();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ScrollSelecao = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefreshHist = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPesquisaHistorico = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtPesquisaHistorico = new System.Windows.Forms.TextBox();
            this.btnNovaInteracao = new System.Windows.Forms.Button();
            this.cbPesquisaPorProduto = new System.Windows.Forms.ComboBox();
            this.colunaHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDescricaoInteracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaQuantidadeInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDetalharHist = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1.SuspendLayout();
            this.tabProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.tabHistorico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabProdutos);
            this.tabControl1.Controls.Add(this.tabHistorico);
            this.tabControl1.Location = new System.Drawing.Point(-8, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1183, 638);
            this.tabControl1.TabIndex = 0;
            // 
            // tabProdutos
            // 
            this.tabProdutos.BackColor = System.Drawing.Color.Silver;
            this.tabProdutos.Controls.Add(this.btnRefresh);
            this.tabProdutos.Controls.Add(this.lblPesquisarPor);
            this.tabProdutos.Controls.Add(this.cbFiltro);
            this.tabProdutos.Controls.Add(this.pictureBox3);
            this.tabProdutos.Controls.Add(this.txtPesquisa);
            this.tabProdutos.Controls.Add(this.btnNovoProduto);
            this.tabProdutos.Controls.Add(this.dgvProdutos);
            this.tabProdutos.Location = new System.Drawing.Point(4, 22);
            this.tabProdutos.Name = "tabProdutos";
            this.tabProdutos.Padding = new System.Windows.Forms.Padding(3);
            this.tabProdutos.Size = new System.Drawing.Size(1175, 612);
            this.tabProdutos.TabIndex = 0;
            this.tabProdutos.Text = "tabProdutos";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(1070, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(32, 32);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblPesquisarPor
            // 
            this.lblPesquisarPor.AutoSize = true;
            this.lblPesquisarPor.BackColor = System.Drawing.Color.Silver;
            this.lblPesquisarPor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisarPor.Location = new System.Drawing.Point(573, 14);
            this.lblPesquisarPor.Name = "lblPesquisarPor";
            this.lblPesquisarPor.Size = new System.Drawing.Size(111, 21);
            this.lblPesquisarPor.TabIndex = 9;
            this.lblPesquisarPor.Text = "Pesquisar por";
            // 
            // cbFiltro
            // 
            this.cbFiltro.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Items.AddRange(new object[] {
            "Código",
            "Nome",
            "Código do fabricante"});
            this.cbFiltro.Location = new System.Drawing.Point(687, 7);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(202, 29);
            this.cbFiltro.TabIndex = 8;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Silver;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(8, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.ForeColor = System.Drawing.Color.Silver;
            this.txtPesquisa.Location = new System.Drawing.Point(46, 9);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(509, 27);
            this.txtPesquisa.TabIndex = 6;
            this.txtPesquisa.Text = "Pesquisar...";
            this.txtPesquisa.Click += new System.EventHandler(this.txtPesquisa_Click);
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            this.txtPesquisa.Leave += new System.EventHandler(this.txtPesquisa_Leave);
            // 
            // btnNovoProduto
            // 
            this.btnNovoProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovoProduto.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.add;
            this.btnNovoProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNovoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoProduto.Location = new System.Drawing.Point(1108, 6);
            this.btnNovoProduto.Name = "btnNovoProduto";
            this.btnNovoProduto.Size = new System.Drawing.Size(32, 32);
            this.btnNovoProduto.TabIndex = 5;
            this.btnNovoProduto.UseVisualStyleBackColor = true;
            this.btnNovoProduto.Click += new System.EventHandler(this.btnNovoProduto_Click);
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProdutos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProdutos.GridColor = System.Drawing.Color.Silver;
            this.dgvProdutos.Location = new System.Drawing.Point(-36, 39);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.Size = new System.Drawing.Size(1185, 567);
            this.dgvProdutos.TabIndex = 0;
            this.dgvProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellContentClick);
            this.dgvProdutos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellDoubleClick);
            this.dgvProdutos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvProdutos_CellPainting);
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
            this.colunaCodigoFabricante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
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
            this.colunaStatus.Width = 84;
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
            // tabHistorico
            // 
            this.tabHistorico.BackColor = System.Drawing.Color.Silver;
            this.tabHistorico.Controls.Add(this.cbPesquisaPorProduto);
            this.tabHistorico.Controls.Add(this.btnRefreshHist);
            this.tabHistorico.Controls.Add(this.label3);
            this.tabHistorico.Controls.Add(this.cbPesquisaHistorico);
            this.tabHistorico.Controls.Add(this.pictureBox1);
            this.tabHistorico.Controls.Add(this.txtPesquisaHistorico);
            this.tabHistorico.Controls.Add(this.btnNovaInteracao);
            this.tabHistorico.Controls.Add(this.dgvHistorico);
            this.tabHistorico.Location = new System.Drawing.Point(4, 22);
            this.tabHistorico.Name = "tabHistorico";
            this.tabHistorico.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistorico.Size = new System.Drawing.Size(1175, 612);
            this.tabHistorico.TabIndex = 1;
            this.tabHistorico.Text = "tabHistorico";
            // 
            // dgvHistorico
            // 
            this.dgvHistorico.AllowUserToAddRows = false;
            this.dgvHistorico.AllowUserToDeleteRows = false;
            this.dgvHistorico.AllowUserToOrderColumns = true;
            this.dgvHistorico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorico.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaHorario,
            this.colunaTipo,
            this.colunaDescricaoInteracao,
            this.colunaProduto,
            this.colunaQuantidadeInt,
            this.colunaValor,
            this.colunaOrigem,
            this.colunaDestino,
            this.colunaDetalharHist});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistorico.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistorico.GridColor = System.Drawing.Color.Silver;
            this.dgvHistorico.Location = new System.Drawing.Point(-37, 39);
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorico.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHistorico.Size = new System.Drawing.Size(1185, 567);
            this.dgvHistorico.TabIndex = 0;
            this.dgvHistorico.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorico_CellContentClick);
            this.dgvHistorico.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvHistorico_CellPainting);
            // 
            // btnCatalogo
            // 
            this.btnCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCatalogo.BackColor = System.Drawing.Color.DimGray;
            this.btnCatalogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCatalogo.BackgroundImage")));
            this.btnCatalogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCatalogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCatalogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalogo.ForeColor = System.Drawing.Color.DimGray;
            this.btnCatalogo.Location = new System.Drawing.Point(1166, 71);
            this.btnCatalogo.Name = "btnCatalogo";
            this.btnCatalogo.Size = new System.Drawing.Size(118, 107);
            this.btnCatalogo.TabIndex = 0;
            this.btnCatalogo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCatalogo.UseVisualStyleBackColor = false;
            this.btnCatalogo.Click += new System.EventHandler(this.btnCatalogo_Click);
            // 
            // btnHistorico
            // 
            this.btnHistorico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorico.BackColor = System.Drawing.Color.DimGray;
            this.btnHistorico.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHistorico.BackgroundImage")));
            this.btnHistorico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHistorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorico.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorico.ForeColor = System.Drawing.Color.DimGray;
            this.btnHistorico.Location = new System.Drawing.Point(18, 138);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(118, 106);
            this.btnHistorico.TabIndex = 1;
            this.btnHistorico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHistorico.UseVisualStyleBackColor = false;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // ucSessaoSistema1
            // 
            this.ucSessaoSistema1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSessaoSistema1.BackColor = System.Drawing.Color.SteelBlue;
            this.ucSessaoSistema1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucSessaoSistema1.Location = new System.Drawing.Point(0, -3);
            this.ucSessaoSistema1.Name = "ucSessaoSistema1";
            this.ucSessaoSistema1.Size = new System.Drawing.Size(1285, 66);
            this.ucSessaoSistema1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ScrollSelecao);
            this.panel1.Controls.Add(this.btnHistorico);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1145, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 647);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.label2.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "_________________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "_________________";
            // 
            // btnRefreshHist
            // 
            this.btnRefreshHist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshHist.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.refresh;
            this.btnRefreshHist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefreshHist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshHist.Location = new System.Drawing.Point(1070, 6);
            this.btnRefreshHist.Name = "btnRefreshHist";
            this.btnRefreshHist.Size = new System.Drawing.Size(32, 32);
            this.btnRefreshHist.TabIndex = 16;
            this.btnRefreshHist.UseVisualStyleBackColor = true;
            this.btnRefreshHist.Click += new System.EventHandler(this.btnRefreshHist_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(573, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Pesquisar por";
            // 
            // cbPesquisaHistorico
            // 
            this.cbPesquisaHistorico.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPesquisaHistorico.FormattingEnabled = true;
            this.cbPesquisaHistorico.Items.AddRange(new object[] {
            "Descrição",
            "Origem",
            "Destino",
            "Produto"});
            this.cbPesquisaHistorico.Location = new System.Drawing.Point(687, 7);
            this.cbPesquisaHistorico.Name = "cbPesquisaHistorico";
            this.cbPesquisaHistorico.Size = new System.Drawing.Size(202, 29);
            this.cbPesquisaHistorico.TabIndex = 14;
            this.cbPesquisaHistorico.SelectedIndexChanged += new System.EventHandler(this.cbPesquisaHistorico_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // txtPesquisaHistorico
            // 
            this.txtPesquisaHistorico.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaHistorico.ForeColor = System.Drawing.Color.Silver;
            this.txtPesquisaHistorico.Location = new System.Drawing.Point(46, 9);
            this.txtPesquisaHistorico.Name = "txtPesquisaHistorico";
            this.txtPesquisaHistorico.Size = new System.Drawing.Size(509, 27);
            this.txtPesquisaHistorico.TabIndex = 12;
            this.txtPesquisaHistorico.Text = "Pesquisar...";
            this.txtPesquisaHistorico.Click += new System.EventHandler(this.txtPesquisaHistorico_Click);
            this.txtPesquisaHistorico.TextChanged += new System.EventHandler(this.txtPesquisaHistorico_TextChanged);
            this.txtPesquisaHistorico.Leave += new System.EventHandler(this.txtPesquisaHistorico_Leave);
            // 
            // btnNovaInteracao
            // 
            this.btnNovaInteracao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovaInteracao.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.add;
            this.btnNovaInteracao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNovaInteracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaInteracao.Location = new System.Drawing.Point(1108, 6);
            this.btnNovaInteracao.Name = "btnNovaInteracao";
            this.btnNovaInteracao.Size = new System.Drawing.Size(32, 32);
            this.btnNovaInteracao.TabIndex = 11;
            this.btnNovaInteracao.UseVisualStyleBackColor = true;
            this.btnNovaInteracao.Click += new System.EventHandler(this.btnNovaInteracao_Click);
            // 
            // cbPesquisaPorProduto
            // 
            this.cbPesquisaPorProduto.Enabled = false;
            this.cbPesquisaPorProduto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPesquisaPorProduto.ForeColor = System.Drawing.Color.Silver;
            this.cbPesquisaPorProduto.FormattingEnabled = true;
            this.cbPesquisaPorProduto.Location = new System.Drawing.Point(914, 7);
            this.cbPesquisaPorProduto.Name = "cbPesquisaPorProduto";
            this.cbPesquisaPorProduto.Size = new System.Drawing.Size(145, 29);
            this.cbPesquisaPorProduto.TabIndex = 17;
            this.cbPesquisaPorProduto.Text = "Pesquisar por produto...";
            this.cbPesquisaPorProduto.Visible = false;
            this.cbPesquisaPorProduto.DropDown += new System.EventHandler(this.cbPesquisaPorProduto_DropDown);
            this.cbPesquisaPorProduto.SelectedIndexChanged += new System.EventHandler(this.cbPesquisaPorProduto_SelectedIndexChanged);
            this.cbPesquisaPorProduto.Click += new System.EventHandler(this.cbPesquisaPorProduto_Click);
            this.cbPesquisaPorProduto.Leave += new System.EventHandler(this.cbPesquisaPorProduto_Leave);
            // 
            // colunaHorario
            // 
            this.colunaHorario.HeaderText = "Horário";
            this.colunaHorario.Name = "colunaHorario";
            this.colunaHorario.ReadOnly = true;
            this.colunaHorario.Width = 150;
            // 
            // colunaTipo
            // 
            this.colunaTipo.HeaderText = "Tipo";
            this.colunaTipo.Name = "colunaTipo";
            this.colunaTipo.ReadOnly = true;
            // 
            // colunaDescricaoInteracao
            // 
            this.colunaDescricaoInteracao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaDescricaoInteracao.HeaderText = "Descrição";
            this.colunaDescricaoInteracao.Name = "colunaDescricaoInteracao";
            this.colunaDescricaoInteracao.ReadOnly = true;
            // 
            // colunaProduto
            // 
            this.colunaProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaProduto.HeaderText = "Produto";
            this.colunaProduto.Name = "colunaProduto";
            this.colunaProduto.ReadOnly = true;
            // 
            // colunaQuantidadeInt
            // 
            this.colunaQuantidadeInt.HeaderText = "Quantidade";
            this.colunaQuantidadeInt.Name = "colunaQuantidadeInt";
            this.colunaQuantidadeInt.ReadOnly = true;
            this.colunaQuantidadeInt.Width = 150;
            // 
            // colunaValor
            // 
            this.colunaValor.HeaderText = "Valor";
            this.colunaValor.Name = "colunaValor";
            this.colunaValor.ReadOnly = true;
            // 
            // colunaOrigem
            // 
            this.colunaOrigem.HeaderText = "Origem";
            this.colunaOrigem.Name = "colunaOrigem";
            this.colunaOrigem.ReadOnly = true;
            // 
            // colunaDestino
            // 
            this.colunaDestino.HeaderText = "Destino";
            this.colunaDestino.Name = "colunaDestino";
            this.colunaDestino.ReadOnly = true;
            // 
            // colunaDetalharHist
            // 
            this.colunaDetalharHist.HeaderText = "";
            this.colunaDetalharHist.Name = "colunaDetalharHist";
            this.colunaDetalharHist.ReadOnly = true;
            this.colunaDetalharHist.Width = 30;
            // 
            // frmEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1284, 681);
            this.Controls.Add(this.ucSessaoSistema1);
            this.Controls.Add(this.btnCatalogo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estoque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEstoque_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabProdutos.ResumeLayout(false);
            this.tabProdutos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.tabHistorico.ResumeLayout(false);
            this.tabHistorico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProdutos;
        private System.Windows.Forms.TabPage tabHistorico;
        private System.Windows.Forms.Button btnCatalogo;
        private System.Windows.Forms.Button btnHistorico;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private Mapeador.BancoDeDados.UCSessaoSistema ucSessaoSistema1;
        private System.Windows.Forms.Button btnNovoProduto;
        private System.Windows.Forms.Label lblPesquisarPor;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ScrollSelecao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodigoFabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPrecoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPrecoVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaQuantidade;
        private System.Windows.Forms.DataGridViewButtonColumn colunaDetalhar;
        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.Button btnRefreshHist;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPesquisaHistorico;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtPesquisaHistorico;
        private System.Windows.Forms.Button btnNovaInteracao;
        private System.Windows.Forms.ComboBox cbPesquisaPorProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaHorario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaDescricaoInteracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaQuantidadeInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrigem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaDestino;
        private System.Windows.Forms.DataGridViewButtonColumn colunaDetalharHist;
    }
}