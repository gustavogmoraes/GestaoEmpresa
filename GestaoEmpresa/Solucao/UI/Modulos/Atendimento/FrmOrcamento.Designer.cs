namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento
{
    partial class FrmOrcamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrcamento));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.lblItensOrcados = new MetroFramework.Controls.MetroLabel();
            this.dgvServicosOrcados = new System.Windows.Forms.DataGridView();
            this.gbDadosCliente = new System.Windows.Forms.GroupBox();
            this.metroTextBox4 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox3 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtNomeCliente = new MetroFramework.Controls.MetroTextBox();
            this.lblNomeCliente = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.lblVigencia = new MetroFramework.Controls.MetroLabel();
            this.dgvProdutosOrcados = new System.Windows.Forms.DataGridView();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.lblDivisoria = new System.Windows.Forms.Label();
            this.dgvItensPesquisa = new System.Windows.Forms.DataGridView();
            this.colunaOrcadosCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaSequencial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaNomeDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colunaOrcaCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaCodigoFabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaRemover = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colunaCodigoPesquisa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaCodigoFabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaPrecoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaPrecoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaSelecionar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).BeginInit();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicosOrcados)).BeginInit();
            this.gbDadosCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosOrcados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensPesquisa)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelarExcluir
            // 
            this.btnCancelarExcluir.Location = new System.Drawing.Point(1121, 28);
            // 
            // btnEditarSalvar
            // 
            this.btnEditarSalvar.Location = new System.Drawing.Point(1079, 26);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(117, 30);
            this.lblTitulo.Text = "Orçamento";
            // 
            // panelTitulo
            // 
            this.panelTitulo.Controls.Add(this.lblVigencia);
            this.panelTitulo.Controls.Add(this.metroComboBox1);
            this.panelTitulo.Size = new System.Drawing.Size(1204, 62);
            this.panelTitulo.Controls.SetChildIndex(this.metroComboBox1, 0);
            this.panelTitulo.Controls.SetChildIndex(this.lblVigencia, 0);
            this.panelTitulo.Controls.SetChildIndex(this.btnCancelarExcluir, 0);
            this.panelTitulo.Controls.SetChildIndex(this.btnEditarSalvar, 0);
            this.panelTitulo.Controls.SetChildIndex(this.gsTopBorder1, 0);
            this.panelTitulo.Controls.SetChildIndex(this.lblTitulo, 0);
            // 
            // gsTopBorder1
            // 
            this.gsTopBorder1.Size = new System.Drawing.Size(1201, 26);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Silver;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(12, 412);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 54;
            this.pictureBox3.TabStop = false;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.ForeColor = System.Drawing.Color.Silver;
            this.txtPesquisa.Location = new System.Drawing.Point(50, 410);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(1142, 26);
            this.txtPesquisa.TabIndex = 53;
            this.txtPesquisa.Text = "Pesquisar...";
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            this.txtPesquisa.Enter += new System.EventHandler(this.txtPesquisa_Enter);
            this.txtPesquisa.Leave += new System.EventHandler(this.txtPesquisa_Leave);
            // 
            // lblItensOrcados
            // 
            this.lblItensOrcados.AutoSize = true;
            this.lblItensOrcados.BackColor = System.Drawing.SystemColors.Control;
            this.lblItensOrcados.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblItensOrcados.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblItensOrcados.Location = new System.Drawing.Point(12, 164);
            this.lblItensOrcados.Name = "lblItensOrcados";
            this.lblItensOrcados.Size = new System.Drawing.Size(149, 25);
            this.lblItensOrcados.TabIndex = 57;
            this.lblItensOrcados.Text = "Serviços Orçados";
            this.lblItensOrcados.UseCustomBackColor = true;
            // 
            // dgvServicosOrcados
            // 
            this.dgvServicosOrcados.AllowUserToAddRows = false;
            this.dgvServicosOrcados.AllowUserToDeleteRows = false;
            this.dgvServicosOrcados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServicosOrcados.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicosOrcados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServicosOrcados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicosOrcados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaOrcaCodigo,
            this.colunaOrcaCodigoFabricante,
            this.colunaOrcaNome,
            this.colunaOrcaValorUnitario,
            this.colunaOrcaValorTotal,
            this.colunaOrcaRemover});
            this.dgvServicosOrcados.GridColor = System.Drawing.Color.Silver;
            this.dgvServicosOrcados.Location = new System.Drawing.Point(12, 196);
            this.dgvServicosOrcados.Name = "dgvServicosOrcados";
            this.dgvServicosOrcados.ReadOnly = true;
            this.dgvServicosOrcados.RowHeadersVisible = false;
            this.dgvServicosOrcados.Size = new System.Drawing.Size(1180, 181);
            this.dgvServicosOrcados.TabIndex = 59;
            // 
            // gbDadosCliente
            // 
            this.gbDadosCliente.BackColor = System.Drawing.SystemColors.Control;
            this.gbDadosCliente.Controls.Add(this.metroTextBox4);
            this.gbDadosCliente.Controls.Add(this.metroLabel4);
            this.gbDadosCliente.Controls.Add(this.metroTextBox3);
            this.gbDadosCliente.Controls.Add(this.metroLabel3);
            this.gbDadosCliente.Controls.Add(this.metroTextBox2);
            this.gbDadosCliente.Controls.Add(this.metroLabel2);
            this.gbDadosCliente.Controls.Add(this.metroTextBox1);
            this.gbDadosCliente.Controls.Add(this.metroLabel1);
            this.gbDadosCliente.Controls.Add(this.txtNomeCliente);
            this.gbDadosCliente.Controls.Add(this.lblNomeCliente);
            this.gbDadosCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDadosCliente.Location = new System.Drawing.Point(12, 62);
            this.gbDadosCliente.Name = "gbDadosCliente";
            this.gbDadosCliente.Size = new System.Drawing.Size(1180, 94);
            this.gbDadosCliente.TabIndex = 60;
            this.gbDadosCliente.TabStop = false;
            this.gbDadosCliente.Text = "Dados do Cliente";
            // 
            // metroTextBox4
            // 
            // 
            // 
            // 
            this.metroTextBox4.CustomButton.Image = null;
            this.metroTextBox4.CustomButton.Location = new System.Drawing.Point(239, 1);
            this.metroTextBox4.CustomButton.Name = "";
            this.metroTextBox4.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox4.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox4.CustomButton.TabIndex = 1;
            this.metroTextBox4.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox4.CustomButton.UseSelectable = true;
            this.metroTextBox4.CustomButton.Visible = false;
            this.metroTextBox4.Lines = new string[0];
            this.metroTextBox4.Location = new System.Drawing.Point(802, 56);
            this.metroTextBox4.MaxLength = 32767;
            this.metroTextBox4.Name = "metroTextBox4";
            this.metroTextBox4.PasswordChar = '\0';
            this.metroTextBox4.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox4.SelectedText = "";
            this.metroTextBox4.SelectionLength = 0;
            this.metroTextBox4.SelectionStart = 0;
            this.metroTextBox4.ShortcutsEnabled = true;
            this.metroTextBox4.Size = new System.Drawing.Size(261, 23);
            this.metroTextBox4.TabIndex = 9;
            this.metroTextBox4.UseCustomBackColor = true;
            this.metroTextBox4.UseSelectable = true;
            this.metroTextBox4.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox4.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(746, 60);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(54, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Cidade:";
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // metroTextBox3
            // 
            // 
            // 
            // 
            this.metroTextBox3.CustomButton.Image = null;
            this.metroTextBox3.CustomButton.Location = new System.Drawing.Point(239, 1);
            this.metroTextBox3.CustomButton.Name = "";
            this.metroTextBox3.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox3.CustomButton.TabIndex = 1;
            this.metroTextBox3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox3.CustomButton.UseSelectable = true;
            this.metroTextBox3.CustomButton.Visible = false;
            this.metroTextBox3.Lines = new string[0];
            this.metroTextBox3.Location = new System.Drawing.Point(128, 56);
            this.metroTextBox3.MaxLength = 32767;
            this.metroTextBox3.Name = "metroTextBox3";
            this.metroTextBox3.PasswordChar = '\0';
            this.metroTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox3.SelectedText = "";
            this.metroTextBox3.SelectionLength = 0;
            this.metroTextBox3.SelectionStart = 0;
            this.metroTextBox3.ShortcutsEnabled = true;
            this.metroTextBox3.Size = new System.Drawing.Size(261, 23);
            this.metroTextBox3.TabIndex = 7;
            this.metroTextBox3.UseCustomBackColor = true;
            this.metroTextBox3.UseSelectable = true;
            this.metroTextBox3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(63, 60);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(60, 19);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Telefone:";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // metroTextBox2
            // 
            // 
            // 
            // 
            this.metroTextBox2.CustomButton.Image = null;
            this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(239, 1);
            this.metroTextBox2.CustomButton.Name = "";
            this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox2.CustomButton.TabIndex = 1;
            this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox2.CustomButton.UseSelectable = true;
            this.metroTextBox2.CustomButton.Visible = false;
            this.metroTextBox2.Lines = new string[0];
            this.metroTextBox2.Location = new System.Drawing.Point(463, 56);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.SelectionLength = 0;
            this.metroTextBox2.SelectionStart = 0;
            this.metroTextBox2.ShortcutsEnabled = true;
            this.metroTextBox2.Size = new System.Drawing.Size(261, 23);
            this.metroTextBox2.TabIndex = 5;
            this.metroTextBox2.UseCustomBackColor = true;
            this.metroTextBox2.UseSelectable = true;
            this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(407, 60);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(50, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "e-mail:";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(239, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(891, 17);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(261, 23);
            this.metroTextBox1.TabIndex = 3;
            this.metroTextBox1.UseCustomBackColor = true;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(709, 21);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(176, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Nome do responsável (A/C):";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // txtNomeCliente
            // 
            // 
            // 
            // 
            this.txtNomeCliente.CustomButton.Image = null;
            this.txtNomeCliente.CustomButton.Location = new System.Drawing.Point(533, 1);
            this.txtNomeCliente.CustomButton.Name = "";
            this.txtNomeCliente.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNomeCliente.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNomeCliente.CustomButton.TabIndex = 1;
            this.txtNomeCliente.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNomeCliente.CustomButton.UseSelectable = true;
            this.txtNomeCliente.CustomButton.Visible = false;
            this.txtNomeCliente.Lines = new string[0];
            this.txtNomeCliente.Location = new System.Drawing.Point(128, 18);
            this.txtNomeCliente.MaxLength = 32767;
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.PasswordChar = '\0';
            this.txtNomeCliente.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNomeCliente.SelectedText = "";
            this.txtNomeCliente.SelectionLength = 0;
            this.txtNomeCliente.SelectionStart = 0;
            this.txtNomeCliente.ShortcutsEnabled = true;
            this.txtNomeCliente.Size = new System.Drawing.Size(555, 23);
            this.txtNomeCliente.TabIndex = 1;
            this.txtNomeCliente.UseCustomBackColor = true;
            this.txtNomeCliente.UseSelectable = true;
            this.txtNomeCliente.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNomeCliente.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Location = new System.Drawing.Point(10, 21);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(113, 19);
            this.lblNomeCliente.TabIndex = 0;
            this.lblNomeCliente.Text = "Nome do Cliente:";
            this.lblNomeCliente.UseCustomBackColor = true;
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Location = new System.Drawing.Point(729, 27);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(315, 29);
            this.metroComboBox1.TabIndex = 61;
            this.metroComboBox1.UseSelectable = true;
            // 
            // lblVigencia
            // 
            this.lblVigencia.AutoSize = true;
            this.lblVigencia.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblVigencia.Location = new System.Drawing.Point(652, 31);
            this.lblVigencia.Name = "lblVigencia";
            this.lblVigencia.Size = new System.Drawing.Size(77, 25);
            this.lblVigencia.TabIndex = 62;
            this.lblVigencia.Text = "Vigência";
            this.lblVigencia.UseCustomBackColor = true;
            // 
            // dgvProdutosOrcados
            // 
            this.dgvProdutosOrcados.AllowUserToAddRows = false;
            this.dgvProdutosOrcados.AllowUserToDeleteRows = false;
            this.dgvProdutosOrcados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProdutosOrcados.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProdutosOrcados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProdutosOrcados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutosOrcados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaOrcadosCodigo,
            this.colunaOrcaSequencial,
            this.dataGridViewTextBoxColumn5,
            this.colunaOrcaNomeDescricao,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewButtonColumn1});
            this.dgvProdutosOrcados.GridColor = System.Drawing.Color.Silver;
            this.dgvProdutosOrcados.Location = new System.Drawing.Point(12, 637);
            this.dgvProdutosOrcados.Name = "dgvProdutosOrcados";
            this.dgvProdutosOrcados.ReadOnly = true;
            this.dgvProdutosOrcados.RowHeadersVisible = false;
            this.dgvProdutosOrcados.Size = new System.Drawing.Size(1180, 194);
            this.dgvProdutosOrcados.TabIndex = 64;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BackColor = System.Drawing.SystemColors.Control;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(12, 609);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(157, 25);
            this.metroLabel5.TabIndex = 63;
            this.metroLabel5.Text = "Produtos Orçados";
            this.metroLabel5.UseCustomBackColor = true;
            // 
            // metroButton1
            // 
            this.metroButton1.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.add;
            this.metroButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.metroButton1.Location = new System.Drawing.Point(1157, 161);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(35, 33);
            this.metroButton1.TabIndex = 65;
            this.metroButton1.UseSelectable = true;
            // 
            // lblDivisoria
            // 
            this.lblDivisoria.AutoSize = true;
            this.lblDivisoria.BackColor = System.Drawing.SystemColors.Control;
            this.lblDivisoria.Location = new System.Drawing.Point(-4, 380);
            this.lblDivisoria.Name = "lblDivisoria";
            this.lblDivisoria.Size = new System.Drawing.Size(1368, 17);
            this.lblDivisoria.TabIndex = 68;
            this.lblDivisoria.Text = resources.GetString("lblDivisoria.Text");
            // 
            // dgvItensPesquisa
            // 
            this.dgvItensPesquisa.AllowUserToAddRows = false;
            this.dgvItensPesquisa.AllowUserToDeleteRows = false;
            this.dgvItensPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItensPesquisa.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItensPesquisa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvItensPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensPesquisa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaCodigoPesquisa,
            this.dataGridViewTextBoxColumn2,
            this.colunaCodigoFabricante,
            this.colunaOrcaPrecoCompra,
            this.colunaOrcaPrecoVenda,
            this.colunaOrcaSelecionar});
            this.dgvItensPesquisa.GridColor = System.Drawing.Color.Silver;
            this.dgvItensPesquisa.Location = new System.Drawing.Point(12, 442);
            this.dgvItensPesquisa.Name = "dgvItensPesquisa";
            this.dgvItensPesquisa.ReadOnly = true;
            this.dgvItensPesquisa.RowHeadersVisible = false;
            this.dgvItensPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItensPesquisa.Size = new System.Drawing.Size(1180, 164);
            this.dgvItensPesquisa.TabIndex = 69;
            this.dgvItensPesquisa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItensPesquisa_CellContentClick);
            // 
            // colunaOrcadosCodigo
            // 
            this.colunaOrcadosCodigo.HeaderText = "";
            this.colunaOrcadosCodigo.Name = "colunaOrcadosCodigo";
            this.colunaOrcadosCodigo.ReadOnly = true;
            this.colunaOrcadosCodigo.Visible = false;
            // 
            // colunaOrcaSequencial
            // 
            this.colunaOrcaSequencial.HeaderText = "Sequencial";
            this.colunaOrcaSequencial.Name = "colunaOrcaSequencial";
            this.colunaOrcaSequencial.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Quantidade";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // colunaOrcaNomeDescricao
            // 
            this.colunaOrcaNomeDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaOrcaNomeDescricao.HeaderText = "Nome / Descricao";
            this.colunaOrcaNomeDescricao.Name = "colunaOrcaNomeDescricao";
            this.colunaOrcaNomeDescricao.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            dataGridViewCellStyle5.NullValue = "0.00";
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn4.HeaderText = "Valor Unitário";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn6.HeaderText = "Valor Total";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Width = 30;
            // 
            // colunaOrcaCodigo
            // 
            this.colunaOrcaCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaOrcaCodigo.HeaderText = "Sequencial";
            this.colunaOrcaCodigo.Name = "colunaOrcaCodigo";
            this.colunaOrcaCodigo.ReadOnly = true;
            this.colunaOrcaCodigo.Width = 75;
            // 
            // colunaOrcaCodigoFabricante
            // 
            this.colunaOrcaCodigoFabricante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaOrcaCodigoFabricante.HeaderText = "Quantidade";
            this.colunaOrcaCodigoFabricante.Name = "colunaOrcaCodigoFabricante";
            this.colunaOrcaCodigoFabricante.ReadOnly = true;
            this.colunaOrcaCodigoFabricante.Width = 186;
            // 
            // colunaOrcaNome
            // 
            this.colunaOrcaNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaOrcaNome.HeaderText = "Descrição";
            this.colunaOrcaNome.Name = "colunaOrcaNome";
            this.colunaOrcaNome.ReadOnly = true;
            // 
            // colunaOrcaValorUnitario
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colunaOrcaValorUnitario.DefaultCellStyle = dataGridViewCellStyle2;
            this.colunaOrcaValorUnitario.HeaderText = "Valor Unitário";
            this.colunaOrcaValorUnitario.Name = "colunaOrcaValorUnitario";
            this.colunaOrcaValorUnitario.ReadOnly = true;
            this.colunaOrcaValorUnitario.Width = 150;
            // 
            // colunaOrcaValorTotal
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colunaOrcaValorTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.colunaOrcaValorTotal.HeaderText = "Valor Total";
            this.colunaOrcaValorTotal.Name = "colunaOrcaValorTotal";
            this.colunaOrcaValorTotal.ReadOnly = true;
            // 
            // colunaOrcaRemover
            // 
            this.colunaOrcaRemover.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaOrcaRemover.HeaderText = "";
            this.colunaOrcaRemover.Name = "colunaOrcaRemover";
            this.colunaOrcaRemover.ReadOnly = true;
            this.colunaOrcaRemover.Width = 30;
            // 
            // colunaCodigoPesquisa
            // 
            this.colunaCodigoPesquisa.HeaderText = "";
            this.colunaCodigoPesquisa.Name = "colunaCodigoPesquisa";
            this.colunaCodigoPesquisa.ReadOnly = true;
            this.colunaCodigoPesquisa.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Nome / Descrição";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // colunaCodigoFabricante
            // 
            this.colunaCodigoFabricante.HeaderText = "Cód. Fabricante";
            this.colunaCodigoFabricante.Name = "colunaCodigoFabricante";
            this.colunaCodigoFabricante.ReadOnly = true;
            this.colunaCodigoFabricante.Width = 130;
            // 
            // colunaOrcaPrecoCompra
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colunaOrcaPrecoCompra.DefaultCellStyle = dataGridViewCellStyle8;
            this.colunaOrcaPrecoCompra.HeaderText = "Preço de compra";
            this.colunaOrcaPrecoCompra.Name = "colunaOrcaPrecoCompra";
            this.colunaOrcaPrecoCompra.ReadOnly = true;
            this.colunaOrcaPrecoCompra.Width = 150;
            // 
            // colunaOrcaPrecoVenda
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colunaOrcaPrecoVenda.DefaultCellStyle = dataGridViewCellStyle9;
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
            // FrmOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 850);
            this.Controls.Add(this.dgvItensPesquisa);
            this.Controls.Add(this.dgvServicosOrcados);
            this.Controls.Add(this.lblDivisoria);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.dgvProdutosOrcados);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.gbDadosCliente);
            this.Controls.Add(this.lblItensOrcados);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtPesquisa);
            this.Name = "FrmOrcamento";
            this.Text = "FrmOrcamento";
            this.Controls.SetChildIndex(this.txtPesquisa, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.lblItensOrcados, 0);
            this.Controls.SetChildIndex(this.gbDadosCliente, 0);
            this.Controls.SetChildIndex(this.metroLabel5, 0);
            this.Controls.SetChildIndex(this.dgvProdutosOrcados, 0);
            this.Controls.SetChildIndex(this.metroButton1, 0);
            this.Controls.SetChildIndex(this.panelTitulo, 0);
            this.Controls.SetChildIndex(this.lblDivisoria, 0);
            this.Controls.SetChildIndex(this.dgvServicosOrcados, 0);
            this.Controls.SetChildIndex(this.dgvItensPesquisa, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicosOrcados)).EndInit();
            this.gbDadosCliente.ResumeLayout(false);
            this.gbDadosCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosOrcados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensPesquisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.TextBox txtPesquisa;
        private MetroFramework.Controls.MetroLabel lblItensOrcados;
        public System.Windows.Forms.DataGridView dgvServicosOrcados;
        private System.Windows.Forms.GroupBox gbDadosCliente;
        private MetroFramework.Controls.MetroLabel lblNomeCliente;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroLabel lblVigencia;
        public System.Windows.Forms.DataGridView dgvProdutosOrcados;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton metroButton1;
        public MetroFramework.Controls.MetroTextBox txtNomeCliente;
        public MetroFramework.Controls.MetroTextBox metroTextBox4;
        public MetroFramework.Controls.MetroTextBox metroTextBox3;
        public MetroFramework.Controls.MetroTextBox metroTextBox2;
        private System.Windows.Forms.Label lblDivisoria;
        public System.Windows.Forms.DataGridView dgvItensPesquisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaCodigoFabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaValorUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaValorTotal;
        private System.Windows.Forms.DataGridViewButtonColumn colunaOrcaRemover;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcadosCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaSequencial;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaNomeDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodigoPesquisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodigoFabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaPrecoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaPrecoVenda;
        private System.Windows.Forms.DataGridViewButtonColumn colunaOrcaSelecionar;
    }
}