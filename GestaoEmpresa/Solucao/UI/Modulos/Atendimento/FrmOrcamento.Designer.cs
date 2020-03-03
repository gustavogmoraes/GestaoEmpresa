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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.lblItensOrcados = new MetroFramework.Controls.MetroLabel();
            this.dgvItensOrcados = new System.Windows.Forms.DataGridView();
            this.colunaOrcaCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaCodigoFabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaRemover = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.BtnAdicionarProduto = new MetroFramework.Controls.MetroButton();
            this.colunaOrcadosCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaSequencial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaOrcaNomeDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).BeginInit();
            this.panelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensOrcados)).BeginInit();
            this.gbDadosCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.pictureBox3.Location = new System.Drawing.Point(175, 420);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 54;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.ForeColor = System.Drawing.Color.Silver;
            this.txtPesquisa.Location = new System.Drawing.Point(213, 418);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(935, 26);
            this.txtPesquisa.TabIndex = 53;
            this.txtPesquisa.Text = "Pesquisar...";
            this.txtPesquisa.Visible = false;
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
            this.lblItensOrcados.Location = new System.Drawing.Point(12, 206);
            this.lblItensOrcados.Name = "lblItensOrcados";
            this.lblItensOrcados.Size = new System.Drawing.Size(149, 25);
            this.lblItensOrcados.TabIndex = 57;
            this.lblItensOrcados.Text = "Serviços Orçados";
            this.lblItensOrcados.UseCustomBackColor = true;
            // 
            // dgvItensOrcados
            // 
            this.dgvItensOrcados.AllowUserToAddRows = false;
            this.dgvItensOrcados.AllowUserToDeleteRows = false;
            this.dgvItensOrcados.AllowUserToOrderColumns = true;
            this.dgvItensOrcados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItensOrcados.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItensOrcados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItensOrcados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensOrcados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaOrcaCodigo,
            this.colunaOrcaCodigoFabricante,
            this.colunaOrcaNome,
            this.colunaOrcaValorUnitario,
            this.colunaOrcaValorTotal,
            this.colunaOrcaRemover});
            this.dgvItensOrcados.GridColor = System.Drawing.Color.Silver;
            this.dgvItensOrcados.Location = new System.Drawing.Point(12, 238);
            this.dgvItensOrcados.Name = "dgvItensOrcados";
            this.dgvItensOrcados.ReadOnly = true;
            this.dgvItensOrcados.RowHeadersVisible = false;
            this.dgvItensOrcados.Size = new System.Drawing.Size(1180, 170);
            this.dgvItensOrcados.TabIndex = 59;
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
            this.colunaOrcaValorUnitario.HeaderText = "Valor Unitário";
            this.colunaOrcaValorUnitario.Name = "colunaOrcaValorUnitario";
            this.colunaOrcaValorUnitario.ReadOnly = true;
            this.colunaOrcaValorUnitario.Width = 150;
            // 
            // colunaOrcaValorTotal
            // 
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
            this.gbDadosCliente.Location = new System.Drawing.Point(12, 99);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaOrcadosCodigo,
            this.colunaOrcaSequencial,
            this.dataGridViewTextBoxColumn5,
            this.colunaOrcaNomeDescricao,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewButtonColumn1});
            this.dataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dataGridView1.Location = new System.Drawing.Point(12, 447);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1180, 170);
            this.dataGridView1.TabIndex = 64;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BackColor = System.Drawing.SystemColors.Control;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(12, 415);
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
            this.metroButton1.Location = new System.Drawing.Point(1157, 199);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(35, 33);
            this.metroButton1.TabIndex = 65;
            this.metroButton1.UseSelectable = true;
            // 
            // BtnAdicionarProduto
            // 
            this.BtnAdicionarProduto.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.add;
            this.BtnAdicionarProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnAdicionarProduto.Location = new System.Drawing.Point(1157, 414);
            this.BtnAdicionarProduto.Name = "BtnAdicionarProduto";
            this.BtnAdicionarProduto.Size = new System.Drawing.Size(35, 30);
            this.BtnAdicionarProduto.TabIndex = 66;
            this.BtnAdicionarProduto.UseSelectable = true;
            this.BtnAdicionarProduto.Click += new System.EventHandler(this.BtnAdicionarProduto_Click);
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
            this.dataGridViewTextBoxColumn4.HeaderText = "Valor Unitário";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
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
            // FrmOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.BtnAdicionarProduto);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.gbDadosCliente);
            this.Controls.Add(this.dgvItensOrcados);
            this.Controls.Add(this.lblItensOrcados);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtPesquisa);
            this.Name = "FrmOrcamento";
            this.Text = "FrmOrcamento";
            this.Controls.SetChildIndex(this.txtPesquisa, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.lblItensOrcados, 0);
            this.Controls.SetChildIndex(this.dgvItensOrcados, 0);
            this.Controls.SetChildIndex(this.gbDadosCliente, 0);
            this.Controls.SetChildIndex(this.panelTitulo, 0);
            this.Controls.SetChildIndex(this.metroLabel5, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.metroButton1, 0);
            this.Controls.SetChildIndex(this.BtnAdicionarProduto, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensOrcados)).EndInit();
            this.gbDadosCliente.ResumeLayout(false);
            this.gbDadosCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.TextBox txtPesquisa;
        private MetroFramework.Controls.MetroLabel lblItensOrcados;
        public System.Windows.Forms.DataGridView dgvItensOrcados;
        private System.Windows.Forms.GroupBox gbDadosCliente;
        private MetroFramework.Controls.MetroLabel lblNomeCliente;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaCodigoFabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaValorUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaValorTotal;
        private System.Windows.Forms.DataGridViewButtonColumn colunaOrcaRemover;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroLabel lblVigencia;
        public System.Windows.Forms.DataGridView dataGridView1;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton BtnAdicionarProduto;
        public MetroFramework.Controls.MetroTextBox txtNomeCliente;
        public MetroFramework.Controls.MetroTextBox metroTextBox4;
        public MetroFramework.Controls.MetroTextBox metroTextBox3;
        public MetroFramework.Controls.MetroTextBox metroTextBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcadosCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaSequencial;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaOrcaNomeDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
    }
}