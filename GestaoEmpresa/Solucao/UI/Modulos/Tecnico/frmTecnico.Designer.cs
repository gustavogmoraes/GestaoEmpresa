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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTecnico));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ScrollSelecao = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabProdutosLab = new System.Windows.Forms.TabPage();
            this.lblPesquisarPor = new System.Windows.Forms.Label();
            this.cbFiltro = new System.Windows.Forms.ComboBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.dgvProdutosLab = new System.Windows.Forms.DataGridView();
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
            this.cbPesquisaPorProduto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPesquisaHistorico = new System.Windows.Forms.ComboBox();
            this.txtPesquisaHistorico = new System.Windows.Forms.TextBox();
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.colunaCodigoInteracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaObservacaoInteracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaQuantidadeInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDetalharHist = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnFluxoLab = new System.Windows.Forms.Button();
            this.btnHistorico = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnNovoProduto = new System.Windows.Forms.Button();
            this.btnRefreshHist = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNovaInteracao = new System.Windows.Forms.Button();
            this.ucSessaoSistema3 = new GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados.UCSessaoSistema();
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabProdutosLab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosLab)).BeginInit();
            this.tabHistorico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.panel1.Controls.Add(this.btnHistorico);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1148, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 647);
            this.panel1.TabIndex = 8;
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
            this.tabProdutosLab.Controls.Add(this.btnRefresh);
            this.tabProdutosLab.Controls.Add(this.lblPesquisarPor);
            this.tabProdutosLab.Controls.Add(this.cbFiltro);
            this.tabProdutosLab.Controls.Add(this.pictureBox3);
            this.tabProdutosLab.Controls.Add(this.txtPesquisa);
            this.tabProdutosLab.Controls.Add(this.btnNovoProduto);
            this.tabProdutosLab.Controls.Add(this.dgvProdutosLab);
            this.tabProdutosLab.Location = new System.Drawing.Point(4, 22);
            this.tabProdutosLab.Name = "tabProdutosLab";
            this.tabProdutosLab.Padding = new System.Windows.Forms.Padding(3);
            this.tabProdutosLab.Size = new System.Drawing.Size(1170, 612);
            this.tabProdutosLab.TabIndex = 0;
            this.tabProdutosLab.Text = "tabProdutosLab";
            // 
            // lblPesquisarPor
            // 
            this.lblPesquisarPor.AutoSize = true;
            this.lblPesquisarPor.BackColor = System.Drawing.Color.Silver;
            this.lblPesquisarPor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisarPor.Location = new System.Drawing.Point(573, 14);
            this.lblPesquisarPor.Name = "lblPesquisarPor";
            this.lblPesquisarPor.Size = new System.Drawing.Size(106, 20);
            this.lblPesquisarPor.TabIndex = 9;
            this.lblPesquisarPor.Text = "Pesquisar por";
            // 
            // cbFiltro
            // 
            this.cbFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFiltro.FormattingEnabled = true;
            this.cbFiltro.Items.AddRange(new object[] {
            "Código",
            "Nome",
            "Código do fabricante"});
            this.cbFiltro.Location = new System.Drawing.Point(687, 7);
            this.cbFiltro.Name = "cbFiltro";
            this.cbFiltro.Size = new System.Drawing.Size(202, 28);
            this.cbFiltro.TabIndex = 8;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.ForeColor = System.Drawing.Color.Silver;
            this.txtPesquisa.Location = new System.Drawing.Point(46, 9);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(509, 26);
            this.txtPesquisa.TabIndex = 6;
            this.txtPesquisa.Text = "Pesquisar...";
            // 
            // dgvProdutosLab
            // 
            this.dgvProdutosLab.AllowUserToAddRows = false;
            this.dgvProdutosLab.AllowUserToDeleteRows = false;
            this.dgvProdutosLab.AllowUserToOrderColumns = true;
            this.dgvProdutosLab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProdutosLab.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProdutosLab.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProdutosLab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutosLab.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgvProdutosLab.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProdutosLab.GridColor = System.Drawing.Color.Silver;
            this.dgvProdutosLab.Location = new System.Drawing.Point(-36, 39);
            this.dgvProdutosLab.Name = "dgvProdutosLab";
            this.dgvProdutosLab.ReadOnly = true;
            this.dgvProdutosLab.Size = new System.Drawing.Size(1180, 567);
            this.dgvProdutosLab.TabIndex = 0;
            this.dgvProdutosLab.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellContentClick);
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
            this.tabHistorico.Location = new System.Drawing.Point(4, 22);
            this.tabHistorico.Name = "tabHistorico";
            this.tabHistorico.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistorico.Size = new System.Drawing.Size(1170, 612);
            this.tabHistorico.TabIndex = 1;
            this.tabHistorico.Text = "tabHistorico";
            // 
            // cbPesquisaPorProduto
            // 
            this.cbPesquisaPorProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPesquisaPorProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPesquisaPorProduto.Enabled = false;
            this.cbPesquisaPorProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPesquisaPorProduto.ForeColor = System.Drawing.Color.Silver;
            this.cbPesquisaPorProduto.FormattingEnabled = true;
            this.cbPesquisaPorProduto.Location = new System.Drawing.Point(914, 7);
            this.cbPesquisaPorProduto.Name = "cbPesquisaPorProduto";
            this.cbPesquisaPorProduto.Size = new System.Drawing.Size(145, 28);
            this.cbPesquisaPorProduto.TabIndex = 17;
            this.cbPesquisaPorProduto.Text = "Pesquisar por produto...";
            this.cbPesquisaPorProduto.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(573, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Pesquisar por";
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
            this.cbPesquisaHistorico.Location = new System.Drawing.Point(687, 7);
            this.cbPesquisaHistorico.Name = "cbPesquisaHistorico";
            this.cbPesquisaHistorico.Size = new System.Drawing.Size(202, 28);
            this.cbPesquisaHistorico.TabIndex = 14;
            // 
            // txtPesquisaHistorico
            // 
            this.txtPesquisaHistorico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisaHistorico.ForeColor = System.Drawing.Color.Silver;
            this.txtPesquisaHistorico.Location = new System.Drawing.Point(46, 9);
            this.txtPesquisaHistorico.Name = "txtPesquisaHistorico";
            this.txtPesquisaHistorico.Size = new System.Drawing.Size(509, 26);
            this.txtPesquisaHistorico.TabIndex = 12;
            this.txtPesquisaHistorico.Text = "Pesquisar...";
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
            this.colunaHorario,
            this.colunaTipo,
            this.colunaProduto,
            this.colunaObservacaoInteracao,
            this.colunaQuantidadeInt,
            this.colunaValor,
            this.colunaOrigem,
            this.colunaDestino,
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
            this.dgvHistorico.Location = new System.Drawing.Point(-37, 39);
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
            this.dgvHistorico.Size = new System.Drawing.Size(1180, 567);
            this.dgvHistorico.TabIndex = 0;
            // 
            // colunaCodigoInteracao
            // 
            this.colunaCodigoInteracao.HeaderText = "";
            this.colunaCodigoInteracao.Name = "colunaCodigoInteracao";
            this.colunaCodigoInteracao.ReadOnly = true;
            this.colunaCodigoInteracao.Visible = false;
            // 
            // colunaHorario
            // 
            this.colunaHorario.HeaderText = "Horário";
            this.colunaHorario.Name = "colunaHorario";
            this.colunaHorario.ReadOnly = true;
            this.colunaHorario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colunaHorario.Width = 125;
            // 
            // colunaTipo
            // 
            this.colunaTipo.FillWeight = 85F;
            this.colunaTipo.HeaderText = "Tipo";
            this.colunaTipo.Name = "colunaTipo";
            this.colunaTipo.ReadOnly = true;
            this.colunaTipo.Width = 110;
            // 
            // colunaProduto
            // 
            this.colunaProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaProduto.HeaderText = "Produto";
            this.colunaProduto.Name = "colunaProduto";
            this.colunaProduto.ReadOnly = true;
            // 
            // colunaObservacaoInteracao
            // 
            this.colunaObservacaoInteracao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaObservacaoInteracao.HeaderText = "Observação";
            this.colunaObservacaoInteracao.Name = "colunaObservacaoInteracao";
            this.colunaObservacaoInteracao.ReadOnly = true;
            // 
            // colunaQuantidadeInt
            // 
            this.colunaQuantidadeInt.HeaderText = "Qtd.";
            this.colunaQuantidadeInt.Name = "colunaQuantidadeInt";
            this.colunaQuantidadeInt.ReadOnly = true;
            this.colunaQuantidadeInt.Width = 50;
            // 
            // colunaValor
            // 
            this.colunaValor.HeaderText = "Valor";
            this.colunaValor.Name = "colunaValor";
            this.colunaValor.ReadOnly = true;
            this.colunaValor.Width = 90;
            // 
            // colunaOrigem
            // 
            this.colunaOrigem.HeaderText = "Origem";
            this.colunaOrigem.Name = "colunaOrigem";
            this.colunaOrigem.ReadOnly = true;
            this.colunaOrigem.Width = 120;
            // 
            // colunaDestino
            // 
            this.colunaDestino.HeaderText = "Destino";
            this.colunaDestino.Name = "colunaDestino";
            this.colunaDestino.ReadOnly = true;
            this.colunaDestino.Width = 120;
            // 
            // colunaDetalharHist
            // 
            this.colunaDetalharHist.HeaderText = "";
            this.colunaDetalharHist.Name = "colunaDetalharHist";
            this.colunaDetalharHist.ReadOnly = true;
            this.colunaDetalharHist.Width = 30;
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
            // btnFluxoLab
            // 
            this.btnFluxoLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFluxoLab.BackColor = System.Drawing.Color.DimGray;
            this.btnFluxoLab.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFluxoLab.BackgroundImage")));
            this.btnFluxoLab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFluxoLab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFluxoLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFluxoLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFluxoLab.ForeColor = System.Drawing.Color.DimGray;
            this.btnFluxoLab.Location = new System.Drawing.Point(17, 10);
            this.btnFluxoLab.Name = "btnFluxoLab";
            this.btnFluxoLab.Size = new System.Drawing.Size(118, 107);
            this.btnFluxoLab.TabIndex = 9;
            this.btnFluxoLab.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFluxoLab.UseVisualStyleBackColor = false;
            this.btnFluxoLab.Click += new System.EventHandler(this.btnFluxoLab_Click);
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
            this.btnHistorico.Location = new System.Drawing.Point(17, 138);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(118, 106);
            this.btnHistorico.TabIndex = 1;
            this.btnHistorico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHistorico.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(1065, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(32, 32);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.UseVisualStyleBackColor = true;
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
            // btnNovoProduto
            // 
            this.btnNovoProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovoProduto.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.add;
            this.btnNovoProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNovoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoProduto.Location = new System.Drawing.Point(1103, 6);
            this.btnNovoProduto.Name = "btnNovoProduto";
            this.btnNovoProduto.Size = new System.Drawing.Size(32, 32);
            this.btnNovoProduto.TabIndex = 5;
            this.btnNovoProduto.UseVisualStyleBackColor = true;
            this.btnNovoProduto.Click += new System.EventHandler(this.btnNovoProduto_Click_1);
            // 
            // btnRefreshHist
            // 
            this.btnRefreshHist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshHist.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.refresh;
            this.btnRefreshHist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefreshHist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshHist.Location = new System.Drawing.Point(1065, 6);
            this.btnRefreshHist.Name = "btnRefreshHist";
            this.btnRefreshHist.Size = new System.Drawing.Size(32, 32);
            this.btnRefreshHist.TabIndex = 16;
            this.btnRefreshHist.UseVisualStyleBackColor = true;
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
            // btnNovaInteracao
            // 
            this.btnNovaInteracao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovaInteracao.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.add;
            this.btnNovaInteracao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNovaInteracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaInteracao.Location = new System.Drawing.Point(1103, 6);
            this.btnNovaInteracao.Name = "btnNovaInteracao";
            this.btnNovaInteracao.Size = new System.Drawing.Size(32, 32);
            this.btnNovaInteracao.TabIndex = 11;
            this.btnNovaInteracao.UseVisualStyleBackColor = true;
            // 
            // ucSessaoSistema3
            // 
            this.ucSessaoSistema3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSessaoSistema3.BackColor = System.Drawing.Color.SteelBlue;
            this.ucSessaoSistema3.Location = new System.Drawing.Point(-1, -1);
            this.ucSessaoSistema3.Name = "ucSessaoSistema3";
            this.ucSessaoSistema3.Size = new System.Drawing.Size(1289, 66);
            this.ucSessaoSistema3.TabIndex = 6;
            // 
            // frmTecnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 681);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ucSessaoSistema3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl2);
            this.Name = "frmTecnico";
            this.Text = "frmTecnico";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabProdutosLab.ResumeLayout(false);
            this.tabProdutosLab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosLab)).EndInit();
            this.tabHistorico.ResumeLayout(false);
            this.tabHistorico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Persistencia.BancoDeDados.UCSessaoSistema ucSessaoSistema3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ScrollSelecao;
        private System.Windows.Forms.Button btnHistorico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFluxoLab;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabProdutosLab;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblPesquisarPor;
        private System.Windows.Forms.ComboBox cbFiltro;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnNovoProduto;
        private System.Windows.Forms.DataGridView dgvProdutosLab;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodigoFabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPrecoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPrecoVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaQuantidade;
        private System.Windows.Forms.DataGridViewButtonColumn colunaDetalhar;
        private System.Windows.Forms.TabPage tabHistorico;
        private System.Windows.Forms.ComboBox cbPesquisaPorProduto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPesquisaHistorico;
        private System.Windows.Forms.TextBox txtPesquisaHistorico;
        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodigoInteracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaHorario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaObservacaoInteracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaQuantidadeInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrigem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaDestino;
        private System.Windows.Forms.DataGridViewButtonColumn colunaDetalharHist;
        private System.Windows.Forms.Button btnRefreshHist;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNovaInteracao;
    }
}