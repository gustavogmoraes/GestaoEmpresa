namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    partial class FrmEstoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEstoque));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProdutos = new System.Windows.Forms.TabPage();
            this.txtQtyProgresso = new MetroFramework.Controls.MetroLabel();
            this.txtCronometroImportar = new MetroFramework.Controls.MetroLabel();
            this.metroProgressImportar = new MetroFramework.Controls.MetroProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.btnNovoProduto = new System.Windows.Forms.Button();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.tabHistorico = new System.Windows.Forms.TabPage();
            this.cbPesquisaPorProduto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPesquisaHistorico = new System.Windows.Forms.ComboBox();
            this.txtPesquisaHistorico = new System.Windows.Forms.TextBox();
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.colunaCodigoInteracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaTecnico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaQuantidadeInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaFinalidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaSituacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDetalharHist = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnRefreshHist = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNovaInteracao = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ScrollSelecao = new System.Windows.Forms.Panel();
            this.btnHistorico = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnCatalogo = new System.Windows.Forms.Button();
            this.ucSessaoSistema2 = new GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados.UCSessaoSistema();
            this.colunaCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaCodigoFabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPrecoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPrecoDistribuidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPrecoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDetalhar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1.SuspendLayout();
            this.tabProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.tabHistorico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabProdutos);
            this.tabControl1.Controls.Add(this.tabHistorico);
            this.tabControl1.Location = new System.Drawing.Point(-16, 104);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2366, 1227);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabProdutos
            // 
            this.tabProdutos.BackColor = System.Drawing.Color.Silver;
            this.tabProdutos.Controls.Add(this.txtQtyProgresso);
            this.tabProdutos.Controls.Add(this.txtCronometroImportar);
            this.tabProdutos.Controls.Add(this.metroProgressImportar);
            this.tabProdutos.Controls.Add(this.button1);
            this.tabProdutos.Controls.Add(this.btnExportarExcel);
            this.tabProdutos.Controls.Add(this.btnRefresh);
            this.tabProdutos.Controls.Add(this.pictureBox3);
            this.tabProdutos.Controls.Add(this.txtPesquisa);
            this.tabProdutos.Controls.Add(this.btnNovoProduto);
            this.tabProdutos.Controls.Add(this.dgvProdutos);
            this.tabProdutos.Location = new System.Drawing.Point(8, 39);
            this.tabProdutos.Margin = new System.Windows.Forms.Padding(6);
            this.tabProdutos.Name = "tabProdutos";
            this.tabProdutos.Padding = new System.Windows.Forms.Padding(6);
            this.tabProdutos.Size = new System.Drawing.Size(2350, 1180);
            this.tabProdutos.TabIndex = 0;
            this.tabProdutos.Text = "tabProdutos";
            this.tabProdutos.Click += new System.EventHandler(this.tabProdutos_Click);
            // 
            // txtQtyProgresso
            // 
            this.txtQtyProgresso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQtyProgresso.AutoSize = true;
            this.txtQtyProgresso.BackColor = System.Drawing.Color.Silver;
            this.txtQtyProgresso.Location = new System.Drawing.Point(1694, 4);
            this.txtQtyProgresso.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.txtQtyProgresso.Name = "txtQtyProgresso";
            this.txtQtyProgresso.Size = new System.Drawing.Size(26, 19);
            this.txtQtyProgresso.TabIndex = 15;
            this.txtQtyProgresso.Text = "?/?";
            this.txtQtyProgresso.UseCustomBackColor = true;
            this.txtQtyProgresso.Visible = false;
            // 
            // txtCronometroImportar
            // 
            this.txtCronometroImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCronometroImportar.AutoSize = true;
            this.txtCronometroImportar.Location = new System.Drawing.Point(1694, 38);
            this.txtCronometroImportar.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.txtCronometroImportar.Name = "txtCronometroImportar";
            this.txtCronometroImportar.Size = new System.Drawing.Size(40, 19);
            this.txtCronometroImportar.TabIndex = 14;
            this.txtCronometroImportar.Text = "00:00";
            this.txtCronometroImportar.UseCustomBackColor = true;
            this.txtCronometroImportar.Visible = false;
            // 
            // metroProgressImportar
            // 
            this.metroProgressImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroProgressImportar.Location = new System.Drawing.Point(1296, 19);
            this.metroProgressImportar.Margin = new System.Windows.Forms.Padding(6);
            this.metroProgressImportar.Name = "metroProgressImportar";
            this.metroProgressImportar.Size = new System.Drawing.Size(378, 44);
            this.metroProgressImportar.TabIndex = 13;
            this.metroProgressImportar.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.ImportFromExcel;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1966, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 62);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.export_spreadsheet_512;
            this.btnExportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcel.Location = new System.Drawing.Point(2046, 12);
            this.btnExportarExcel.Margin = new System.Windows.Forms.Padding(6);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(64, 62);
            this.btnExportarExcel.TabIndex = 11;
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(2140, 12);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 62);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Silver;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(16, 21);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 46);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.ForeColor = System.Drawing.Color.Silver;
            this.txtPesquisa.Location = new System.Drawing.Point(92, 17);
            this.txtPesquisa.Margin = new System.Windows.Forms.Padding(6);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(1014, 44);
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
            this.btnNovoProduto.Location = new System.Drawing.Point(2216, 12);
            this.btnNovoProduto.Margin = new System.Windows.Forms.Padding(6);
            this.btnNovoProduto.Name = "btnNovoProduto";
            this.btnNovoProduto.Size = new System.Drawing.Size(64, 62);
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
            this.colunaPrecoDistribuidor,
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
            this.dgvProdutos.Location = new System.Drawing.Point(-72, 75);
            this.dgvProdutos.Margin = new System.Windows.Forms.Padding(6);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.RowHeadersWidth = 82;
            this.dgvProdutos.Size = new System.Drawing.Size(2370, 1090);
            this.dgvProdutos.TabIndex = 0;
            this.dgvProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellContentClick);
            this.dgvProdutos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellDoubleClick);
            this.dgvProdutos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvProdutos_CellPainting);
            this.dgvProdutos.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvProdutos_ColumnWidthChanged);
            // 
            // tabHistorico
            // 
            this.tabHistorico.BackColor = System.Drawing.Color.Silver;
            this.tabHistorico.Controls.Add(this.cbPesquisaPorProduto);
            this.tabHistorico.Controls.Add(this.label3);
            this.tabHistorico.Controls.Add(this.cbPesquisaHistorico);
            this.tabHistorico.Controls.Add(this.txtPesquisaHistorico);
            this.tabHistorico.Controls.Add(this.dgvHistorico);
            this.tabHistorico.Controls.Add(this.btnRefreshHist);
            this.tabHistorico.Controls.Add(this.pictureBox1);
            this.tabHistorico.Controls.Add(this.btnNovaInteracao);
            this.tabHistorico.Location = new System.Drawing.Point(8, 39);
            this.tabHistorico.Margin = new System.Windows.Forms.Padding(6);
            this.tabHistorico.Name = "tabHistorico";
            this.tabHistorico.Padding = new System.Windows.Forms.Padding(6);
            this.tabHistorico.Size = new System.Drawing.Size(2350, 1180);
            this.tabHistorico.TabIndex = 1;
            this.tabHistorico.Text = "tabHistorico";
            this.tabHistorico.Click += new System.EventHandler(this.tabHistorico_Click);
            // 
            // cbPesquisaPorProduto
            // 
            this.cbPesquisaPorProduto.Enabled = false;
            this.cbPesquisaPorProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPesquisaPorProduto.ForeColor = System.Drawing.Color.Silver;
            this.cbPesquisaPorProduto.FormattingEnabled = true;
            this.cbPesquisaPorProduto.Location = new System.Drawing.Point(1828, 13);
            this.cbPesquisaPorProduto.Margin = new System.Windows.Forms.Padding(6);
            this.cbPesquisaPorProduto.Name = "cbPesquisaPorProduto";
            this.cbPesquisaPorProduto.Size = new System.Drawing.Size(286, 45);
            this.cbPesquisaPorProduto.TabIndex = 17;
            this.cbPesquisaPorProduto.Text = "Pesquisar por produto...";
            this.cbPesquisaPorProduto.Visible = false;
            this.cbPesquisaPorProduto.DropDown += new System.EventHandler(this.cbPesquisaPorProduto_DropDown);
            this.cbPesquisaPorProduto.SelectedIndexChanged += new System.EventHandler(this.cbPesquisaPorProduto_SelectedIndexChanged);
            this.cbPesquisaPorProduto.TextChanged += new System.EventHandler(this.cbPesquisaPorProduto_TextChanged);
            this.cbPesquisaPorProduto.Click += new System.EventHandler(this.cbPesquisaPorProduto_Click);
            this.cbPesquisaPorProduto.Leave += new System.EventHandler(this.cbPesquisaPorProduto_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1146, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 37);
            this.label3.TabIndex = 15;
            this.label3.Text = "Pesquisar por";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cbPesquisaHistorico
            // 
            this.cbPesquisaHistorico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPesquisaHistorico.FormattingEnabled = true;
            this.cbPesquisaHistorico.Items.AddRange(new object[] {
            "Observação",
            "Origem",
            "Destino",
            "Horário",
            "Número de Série",
            "Produto"});
            this.cbPesquisaHistorico.Location = new System.Drawing.Point(1374, 13);
            this.cbPesquisaHistorico.Margin = new System.Windows.Forms.Padding(6);
            this.cbPesquisaHistorico.Name = "cbPesquisaHistorico";
            this.cbPesquisaHistorico.Size = new System.Drawing.Size(400, 45);
            this.cbPesquisaHistorico.TabIndex = 14;
            this.cbPesquisaHistorico.SelectedIndexChanged += new System.EventHandler(this.cbPesquisaHistorico_SelectedIndexChanged);
            // 
            // txtPesquisaHistorico
            // 
            this.txtPesquisaHistorico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaHistorico.ForeColor = System.Drawing.Color.Silver;
            this.txtPesquisaHistorico.Location = new System.Drawing.Point(92, 17);
            this.txtPesquisaHistorico.Margin = new System.Windows.Forms.Padding(6);
            this.txtPesquisaHistorico.Name = "txtPesquisaHistorico";
            this.txtPesquisaHistorico.Size = new System.Drawing.Size(1014, 44);
            this.txtPesquisaHistorico.TabIndex = 12;
            this.txtPesquisaHistorico.Text = "Pesquisar...";
            this.txtPesquisaHistorico.Click += new System.EventHandler(this.txtPesquisaHistorico_Click);
            this.txtPesquisaHistorico.TextChanged += new System.EventHandler(this.txtPesquisaHistorico_TextChanged);
            this.txtPesquisaHistorico.Leave += new System.EventHandler(this.txtPesquisaHistorico_Leave);
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
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaCodigoInteracao,
            this.colunaTipo,
            this.colunaTecnico,
            this.colunaProduto,
            this.colunaQuantidadeInt,
            this.colunaOrigem,
            this.colunaDestino,
            this.colunaFinalidade,
            this.colunaSituacao,
            this.colunaValor,
            this.colunaHorario,
            this.colunaDetalharHist});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistorico.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHistorico.GridColor = System.Drawing.Color.Silver;
            this.dgvHistorico.Location = new System.Drawing.Point(-74, 75);
            this.dgvHistorico.Margin = new System.Windows.Forms.Padding(6);
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistorico.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHistorico.RowHeadersWidth = 82;
            this.dgvHistorico.Size = new System.Drawing.Size(2370, 1090);
            this.dgvHistorico.TabIndex = 0;
            this.dgvHistorico.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorico_CellContentClick);
            this.dgvHistorico.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorico_CellDoubleClick);
            this.dgvHistorico.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvHistorico_CellPainting);
            // 
            // colunaCodigoInteracao
            // 
            this.colunaCodigoInteracao.HeaderText = "";
            this.colunaCodigoInteracao.MinimumWidth = 10;
            this.colunaCodigoInteracao.Name = "colunaCodigoInteracao";
            this.colunaCodigoInteracao.ReadOnly = true;
            this.colunaCodigoInteracao.Visible = false;
            this.colunaCodigoInteracao.Width = 200;
            // 
            // colunaTipo
            // 
            this.colunaTipo.FillWeight = 85F;
            this.colunaTipo.HeaderText = "Tipo";
            this.colunaTipo.MinimumWidth = 10;
            this.colunaTipo.Name = "colunaTipo";
            this.colunaTipo.ReadOnly = true;
            this.colunaTipo.Width = 110;
            // 
            // colunaTecnico
            // 
            this.colunaTecnico.HeaderText = "Técnico";
            this.colunaTecnico.MinimumWidth = 10;
            this.colunaTecnico.Name = "colunaTecnico";
            this.colunaTecnico.ReadOnly = true;
            this.colunaTecnico.Width = 200;
            // 
            // colunaProduto
            // 
            this.colunaProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaProduto.HeaderText = "Produto";
            this.colunaProduto.MinimumWidth = 10;
            this.colunaProduto.Name = "colunaProduto";
            this.colunaProduto.ReadOnly = true;
            // 
            // colunaQuantidadeInt
            // 
            this.colunaQuantidadeInt.HeaderText = "Qtd.";
            this.colunaQuantidadeInt.MinimumWidth = 10;
            this.colunaQuantidadeInt.Name = "colunaQuantidadeInt";
            this.colunaQuantidadeInt.ReadOnly = true;
            this.colunaQuantidadeInt.Width = 50;
            // 
            // colunaOrigem
            // 
            this.colunaOrigem.HeaderText = "Origem";
            this.colunaOrigem.MinimumWidth = 10;
            this.colunaOrigem.Name = "colunaOrigem";
            this.colunaOrigem.ReadOnly = true;
            this.colunaOrigem.Width = 230;
            // 
            // colunaDestino
            // 
            this.colunaDestino.HeaderText = "Destino";
            this.colunaDestino.MinimumWidth = 10;
            this.colunaDestino.Name = "colunaDestino";
            this.colunaDestino.ReadOnly = true;
            this.colunaDestino.Width = 230;
            // 
            // colunaFinalidade
            // 
            this.colunaFinalidade.HeaderText = "Finalidade";
            this.colunaFinalidade.MinimumWidth = 10;
            this.colunaFinalidade.Name = "colunaFinalidade";
            this.colunaFinalidade.ReadOnly = true;
            this.colunaFinalidade.Width = 200;
            // 
            // colunaSituacao
            // 
            this.colunaSituacao.HeaderText = "Situação";
            this.colunaSituacao.MinimumWidth = 10;
            this.colunaSituacao.Name = "colunaSituacao";
            this.colunaSituacao.ReadOnly = true;
            this.colunaSituacao.Width = 200;
            // 
            // colunaValor
            // 
            this.colunaValor.HeaderText = "Valor";
            this.colunaValor.MinimumWidth = 10;
            this.colunaValor.Name = "colunaValor";
            this.colunaValor.ReadOnly = true;
            this.colunaValor.Width = 90;
            // 
            // colunaHorario
            // 
            this.colunaHorario.HeaderText = "Horário";
            this.colunaHorario.MinimumWidth = 10;
            this.colunaHorario.Name = "colunaHorario";
            this.colunaHorario.ReadOnly = true;
            this.colunaHorario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colunaHorario.Width = 125;
            // 
            // colunaDetalharHist
            // 
            this.colunaDetalharHist.HeaderText = "";
            this.colunaDetalharHist.MinimumWidth = 10;
            this.colunaDetalharHist.Name = "colunaDetalharHist";
            this.colunaDetalharHist.ReadOnly = true;
            this.colunaDetalharHist.Width = 30;
            // 
            // btnRefreshHist
            // 
            this.btnRefreshHist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshHist.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.refresh;
            this.btnRefreshHist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefreshHist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshHist.Location = new System.Drawing.Point(2140, 12);
            this.btnRefreshHist.Margin = new System.Windows.Forms.Padding(6);
            this.btnRefreshHist.Name = "btnRefreshHist";
            this.btnRefreshHist.Size = new System.Drawing.Size(64, 62);
            this.btnRefreshHist.TabIndex = 16;
            this.btnRefreshHist.UseVisualStyleBackColor = true;
            this.btnRefreshHist.Click += new System.EventHandler(this.btnRefreshHist_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 21);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // btnNovaInteracao
            // 
            this.btnNovaInteracao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovaInteracao.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.add;
            this.btnNovaInteracao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNovaInteracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaInteracao.Location = new System.Drawing.Point(2216, 12);
            this.btnNovaInteracao.Margin = new System.Windows.Forms.Padding(6);
            this.btnNovaInteracao.Name = "btnNovaInteracao";
            this.btnNovaInteracao.Size = new System.Drawing.Size(64, 62);
            this.btnNovaInteracao.TabIndex = 11;
            this.btnNovaInteracao.UseVisualStyleBackColor = true;
            this.btnNovaInteracao.Click += new System.EventHandler(this.btnNovaInteracao_Click);
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
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(2290, 104);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 1242);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ScrollSelecao
            // 
            this.ScrollSelecao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollSelecao.BackColor = System.Drawing.Color.SteelBlue;
            this.ScrollSelecao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScrollSelecao.Location = new System.Drawing.Point(14, 19);
            this.ScrollSelecao.Margin = new System.Windows.Forms.Padding(6);
            this.ScrollSelecao.Name = "ScrollSelecao";
            this.ScrollSelecao.Size = new System.Drawing.Size(20, 202);
            this.ScrollSelecao.TabIndex = 0;
            this.ScrollSelecao.Paint += new System.Windows.Forms.PaintEventHandler(this.ScrollSelecao_Paint);
            // 
            // btnHistorico
            // 
            this.btnHistorico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorico.BackColor = System.Drawing.Color.DimGray;
            this.btnHistorico.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHistorico.BackgroundImage")));
            this.btnHistorico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHistorico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorico.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorico.ForeColor = System.Drawing.Color.DimGray;
            this.btnHistorico.Location = new System.Drawing.Point(36, 265);
            this.btnHistorico.Margin = new System.Windows.Forms.Padding(6);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(236, 204);
            this.btnHistorico.TabIndex = 1;
            this.btnHistorico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHistorico.UseVisualStyleBackColor = false;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(34, 412);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(714, 79);
            this.label2.TabIndex = 3;
            this.label2.Text = "_________________";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 185);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(714, 79);
            this.label1.TabIndex = 2;
            this.label1.Text = "_________________";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::GS.GestaoEmpresa.Properties.Resources.BoxBlueShort;
            this.pictureBox2.InitialImage = global::GS.GestaoEmpresa.Properties.Resources.BoxBlueShort;
            this.pictureBox2.Location = new System.Drawing.Point(8, 15);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(136, 96);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnCatalogo
            // 
            this.btnCatalogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCatalogo.BackColor = System.Drawing.Color.DimGray;
            this.btnCatalogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCatalogo.BackgroundImage")));
            this.btnCatalogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCatalogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCatalogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalogo.ForeColor = System.Drawing.Color.DimGray;
            this.btnCatalogo.Location = new System.Drawing.Point(2332, 137);
            this.btnCatalogo.Margin = new System.Windows.Forms.Padding(6);
            this.btnCatalogo.Name = "btnCatalogo";
            this.btnCatalogo.Size = new System.Drawing.Size(236, 206);
            this.btnCatalogo.TabIndex = 0;
            this.btnCatalogo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCatalogo.UseVisualStyleBackColor = false;
            this.btnCatalogo.Click += new System.EventHandler(this.btnCatalogo_Click);
            // 
            // ucSessaoSistema2
            // 
            this.ucSessaoSistema2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSessaoSistema2.BackColor = System.Drawing.Color.SteelBlue;
            this.ucSessaoSistema2.Location = new System.Drawing.Point(-8, -8);
            this.ucSessaoSistema2.Margin = new System.Windows.Forms.Padding(12);
            this.ucSessaoSistema2.Name = "ucSessaoSistema2";
            this.ucSessaoSistema2.Size = new System.Drawing.Size(2578, 127);
            this.ucSessaoSistema2.TabIndex = 5;
            this.ucSessaoSistema2.Load += new System.EventHandler(this.ucSessaoSistema2_Load);
            // 
            // colunaCodigo
            // 
            this.colunaCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaCodigo.HeaderText = "Código";
            this.colunaCodigo.MinimumWidth = 10;
            this.colunaCodigo.Name = "colunaCodigo";
            this.colunaCodigo.ReadOnly = true;
            this.colunaCodigo.Width = 75;
            // 
            // colunaCodigoFabricante
            // 
            this.colunaCodigoFabricante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaCodigoFabricante.HeaderText = "Código do fabricante";
            this.colunaCodigoFabricante.MinimumWidth = 10;
            this.colunaCodigoFabricante.Name = "colunaCodigoFabricante";
            this.colunaCodigoFabricante.ReadOnly = true;
            this.colunaCodigoFabricante.Width = 186;
            // 
            // colunaStatus
            // 
            this.colunaStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colunaStatus.HeaderText = "Status";
            this.colunaStatus.MinimumWidth = 10;
            this.colunaStatus.Name = "colunaStatus";
            this.colunaStatus.ReadOnly = true;
            this.colunaStatus.Width = 153;
            // 
            // colunaNome
            // 
            this.colunaNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaNome.HeaderText = "Nome";
            this.colunaNome.MinimumWidth = 10;
            this.colunaNome.Name = "colunaNome";
            this.colunaNome.ReadOnly = true;
            // 
            // colunaDescricao
            // 
            this.colunaDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaDescricao.HeaderText = "Observaçoes";
            this.colunaDescricao.MinimumWidth = 10;
            this.colunaDescricao.Name = "colunaDescricao";
            this.colunaDescricao.ReadOnly = true;
            // 
            // colunaPrecoCompra
            // 
            this.colunaPrecoCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaPrecoCompra.HeaderText = "Preço de Compra";
            this.colunaPrecoCompra.MinimumWidth = 10;
            this.colunaPrecoCompra.Name = "colunaPrecoCompra";
            this.colunaPrecoCompra.ReadOnly = true;
            this.colunaPrecoCompra.Width = 120;
            // 
            // colunaPrecoDistribuidor
            // 
            this.colunaPrecoDistribuidor.HeaderText = "Preço Distribuidor";
            this.colunaPrecoDistribuidor.MinimumWidth = 10;
            this.colunaPrecoDistribuidor.Name = "colunaPrecoDistribuidor";
            this.colunaPrecoDistribuidor.ReadOnly = true;
            this.colunaPrecoDistribuidor.Width = 200;
            // 
            // colunaPrecoVenda
            // 
            this.colunaPrecoVenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaPrecoVenda.HeaderText = "Preço de Venda";
            this.colunaPrecoVenda.MinimumWidth = 10;
            this.colunaPrecoVenda.Name = "colunaPrecoVenda";
            this.colunaPrecoVenda.ReadOnly = true;
            this.colunaPrecoVenda.Width = 115;
            // 
            // colunaQuantidade
            // 
            this.colunaQuantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaQuantidade.HeaderText = "Qtd. em estoque";
            this.colunaQuantidade.MinimumWidth = 10;
            this.colunaQuantidade.Name = "colunaQuantidade";
            this.colunaQuantidade.ReadOnly = true;
            this.colunaQuantidade.Width = 125;
            // 
            // colunaDetalhar
            // 
            this.colunaDetalhar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaDetalhar.HeaderText = "";
            this.colunaDetalhar.MinimumWidth = 10;
            this.colunaDetalhar.Name = "colunaDetalhar";
            this.colunaDetalhar.ReadOnly = true;
            this.colunaDetalhar.Width = 30;
            // 
            // FrmEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(2568, 1310);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ucSessaoSistema2);
            this.Controls.Add(this.btnCatalogo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estoque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEstoque_FormClosing);
            this.Load += new System.EventHandler(this.frmEstoque_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabProdutos.ResumeLayout(false);
            this.tabProdutos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.tabHistorico.ResumeLayout(false);
            this.tabHistorico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProdutos;
        private System.Windows.Forms.TabPage tabHistorico;
        private System.Windows.Forms.Button btnCatalogo;
        private System.Windows.Forms.Button btnHistorico;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private Persistencia.BancoDeDados.UCSessaoSistema ucSessaoSistema1;
        private System.Windows.Forms.Button btnNovoProduto;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ScrollSelecao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.Button btnRefreshHist;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPesquisaHistorico;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtPesquisaHistorico;
        private System.Windows.Forms.Button btnNovaInteracao;
        private System.Windows.Forms.ComboBox cbPesquisaPorProduto;
        private Persistencia.BancoDeDados.UCSessaoSistema ucSessaoSistema2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnExportarExcel;
        public MetroFramework.Controls.MetroLabel txtCronometroImportar;
        public MetroFramework.Controls.MetroProgressBar metroProgressImportar;
        public System.Windows.Forms.Button button1;
        public MetroFramework.Controls.MetroLabel txtQtyProgresso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodigoInteracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaTecnico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaQuantidadeInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrigem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaFinalidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaSituacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaHorario;
        private System.Windows.Forms.DataGridViewButtonColumn colunaDetalharHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodigoFabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPrecoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPrecoDistribuidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPrecoVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaQuantidade;
        private System.Windows.Forms.DataGridViewButtonColumn colunaDetalhar;
    }
}