using GS.GestaoEmpresa.UI.GenericControls;

namespace GS.GestaoEmpresa.UI.Modules.Storage.Interaction
{
    partial class InteractionView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InteractionView));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbTipo = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cbSituacao = new MetroFramework.Controls.MetroComboBox();
            this.gsFileAttacher1 = new GSFileAttacher();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.lblNotaFiscal = new MetroFramework.Controls.MetroLabel();
            this.txtNF = new MetroFramework.Controls.MetroTextBox();
            this.txtOS = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.cbFinalidade = new MetroFramework.Controls.MetroComboBox();
            this.lblFinalidade = new MetroFramework.Controls.MetroLabel();
            this.txtColaborador = new MetroFramework.Controls.MetroTextBox();
            this.lblResponsavel = new MetroFramework.Controls.MetroLabel();
            this.txtDestino = new MetroFramework.Controls.MetroTextBox();
            this.lblDestino = new MetroFramework.Controls.MetroLabel();
            this.txtOrigem = new MetroFramework.Controls.MetroTextBox();
            this.lblOrigem = new MetroFramework.Controls.MetroLabel();
            this.txtObservacao = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.panelProdutos = new MetroFramework.Controls.MetroPanel();
            this.flpNS = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDoSearch = new System.Windows.Forms.PictureBox();
            this.gridPesquisaProduto = new MetroFramework.Controls.MetroGrid();
            this.colunaPesquisaCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPesquisaFabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPesquisaCodigoDistribuidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPesquisaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPesquisaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPesquisaDistribuidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPesquisaPSCF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPesquisaLucro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPesquisaVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPesquisaQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaPesquisaSelecionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtPesquisa = new MetroFramework.Controls.MetroTextBox();
            this.gridProdutos = new MetroFramework.Controls.MetroGrid();
            this.colunaCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaFabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaCodigoFabricante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaNS = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colunaRemover = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtCodigo = new MetroFramework.Controls.MetroTextBox();
            this.lblCodigo = new MetroFramework.Controls.MetroLabel();
            this.dtpHorario = new GSDateTimePicker();
            this.dtpHorarioDevolucao = new GSDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).BeginInit();
            this.panelTitulo.SuspendLayout();
            this.panelProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDoSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPesquisaProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelarExcluir
            // 
            this.btnCancelarExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarExcluir.Location = new System.Drawing.Point(1160, 31);
            // 
            // btnEditarSalvar
            // 
            this.btnEditarSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarSalvar.Location = new System.Drawing.Point(1118, 29);
            // 
            // panelTitulo
            // 
            this.panelTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTitulo.Controls.Add(this.metroLabel1);
            this.panelTitulo.Size = new System.Drawing.Size(1210, 62);
            this.panelTitulo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitulo_Paint);
            this.panelTitulo.Controls.SetChildIndex(this.metroLabel1, 0);
            this.panelTitulo.Controls.SetChildIndex(this.btnCancelarExcluir, 0);
            this.panelTitulo.Controls.SetChildIndex(this.btnEditarSalvar, 0);
            this.panelTitulo.Controls.SetChildIndex(this.gsTopBorder1, 0);
            this.panelTitulo.Controls.SetChildIndex(this.lblTitulo, 0);
            // 
            // gsTopBorder1
            // 
            this.gsTopBorder1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gsTopBorder1.DisplayMaximize = true;
            this.gsTopBorder1.Location = new System.Drawing.Point(1, -1);
            this.gsTopBorder1.Size = new System.Drawing.Size(1209, 26);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(16, 31);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(150, 25);
            this.metroLabel1.TabIndex = 55;
            this.metroLabel1.Text = "Entradas e Saídas";
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.Click += new System.EventHandler(this.metroLabel1_Click);
            // 
            // cbTipo
            // 
            this.cbTipo.BackColor = System.Drawing.Color.White;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.ItemHeight = 23;
            this.cbTipo.Items.AddRange(new object[] {
            "Entrada",
            "Saída",
            "Base de troca"});
            this.cbTipo.Location = new System.Drawing.Point(22, 169);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(158, 29);
            this.cbTipo.TabIndex = 1;
            this.cbTipo.UseCustomBackColor = true;
            this.cbTipo.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(23, 141);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(45, 25);
            this.metroLabel2.TabIndex = 157;
            this.metroLabel2.Text = "Tipo";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(201, 73);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(69, 25);
            this.metroLabel3.TabIndex = 159;
            this.metroLabel3.Text = "Horário";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(605, 75);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(152, 25);
            this.metroLabel4.TabIndex = 162;
            this.metroLabel4.Text = "Horário devolução";
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.Location = new System.Drawing.Point(419, 75);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(76, 25);
            this.metroLabel5.TabIndex = 166;
            this.metroLabel5.Text = "Situação";
            this.metroLabel5.UseCustomBackColor = true;
            // 
            // cbSituacao
            // 
            this.cbSituacao.BackColor = System.Drawing.Color.White;
            this.cbSituacao.FormattingEnabled = true;
            this.cbSituacao.ItemHeight = 23;
            this.cbSituacao.Items.AddRange(new object[] {
            "Devolvido",
            "Vendido",
            "Trocado",
            "Emprestado",
            "Em uso",
            "Em estoque",
            "Outros"});
            this.cbSituacao.Location = new System.Drawing.Point(418, 103);
            this.cbSituacao.Name = "cbSituacao";
            this.cbSituacao.Size = new System.Drawing.Size(158, 29);
            this.cbSituacao.TabIndex = 4;
            this.cbSituacao.UseCustomBackColor = true;
            this.cbSituacao.UseSelectable = true;
            // 
            // gsFileAttacher1
            // 
            this.gsFileAttacher1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gsFileAttacher1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gsFileAttacher1.Location = new System.Drawing.Point(820, 103);
            this.gsFileAttacher1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gsFileAttacher1.Name = "gsFileAttacher1";
            this.gsFileAttacher1.Size = new System.Drawing.Size(385, 141);
            this.gsFileAttacher1.TabIndex = 15;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.Location = new System.Drawing.Point(823, 78);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(67, 25);
            this.metroLabel6.TabIndex = 168;
            this.metroLabel6.Text = "Anexos";
            this.metroLabel6.UseCustomBackColor = true;
            // 
            // lblNotaFiscal
            // 
            this.lblNotaFiscal.AutoSize = true;
            this.lblNotaFiscal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblNotaFiscal.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblNotaFiscal.Location = new System.Drawing.Point(22, 213);
            this.lblNotaFiscal.Name = "lblNotaFiscal";
            this.lblNotaFiscal.Size = new System.Drawing.Size(180, 25);
            this.lblNotaFiscal.TabIndex = 169;
            this.lblNotaFiscal.Text = "Número da nota fiscal";
            this.lblNotaFiscal.UseCustomBackColor = true;
            // 
            // txtNF
            // 
            // 
            // 
            // 
            this.txtNF.CustomButton.Image = null;
            this.txtNF.CustomButton.Location = new System.Drawing.Point(159, 1);
            this.txtNF.CustomButton.Name = "";
            this.txtNF.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNF.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNF.CustomButton.TabIndex = 1;
            this.txtNF.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNF.CustomButton.UseSelectable = true;
            this.txtNF.CustomButton.Visible = false;
            this.txtNF.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNF.Lines = new string[0];
            this.txtNF.Location = new System.Drawing.Point(22, 241);
            this.txtNF.MaxLength = 32767;
            this.txtNF.Name = "txtNF";
            this.txtNF.PasswordChar = '\0';
            this.txtNF.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNF.SelectedText = "";
            this.txtNF.SelectionLength = 0;
            this.txtNF.SelectionStart = 0;
            this.txtNF.ShortcutsEnabled = true;
            this.txtNF.Size = new System.Drawing.Size(181, 23);
            this.txtNF.TabIndex = 7;
            this.txtNF.UseSelectable = true;
            this.txtNF.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNF.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtOS
            // 
            // 
            // 
            // 
            this.txtOS.CustomButton.Image = null;
            this.txtOS.CustomButton.Location = new System.Drawing.Point(159, 1);
            this.txtOS.CustomButton.Name = "";
            this.txtOS.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtOS.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOS.CustomButton.TabIndex = 1;
            this.txtOS.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOS.CustomButton.UseSelectable = true;
            this.txtOS.CustomButton.Visible = false;
            this.txtOS.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtOS.Lines = new string[0];
            this.txtOS.Location = new System.Drawing.Point(228, 175);
            this.txtOS.MaxLength = 32767;
            this.txtOS.Name = "txtOS";
            this.txtOS.PasswordChar = '\0';
            this.txtOS.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOS.SelectedText = "";
            this.txtOS.SelectionLength = 0;
            this.txtOS.SelectionStart = 0;
            this.txtOS.ShortcutsEnabled = true;
            this.txtOS.Size = new System.Drawing.Size(181, 23);
            this.txtOS.TabIndex = 8;
            this.txtOS.UseSelectable = true;
            this.txtOS.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOS.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.Location = new System.Drawing.Point(228, 147);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(127, 25);
            this.metroLabel7.TabIndex = 171;
            this.metroLabel7.Text = "Número da OS";
            this.metroLabel7.UseCustomBackColor = true;
            // 
            // cbFinalidade
            // 
            this.cbFinalidade.FormattingEnabled = true;
            this.cbFinalidade.ItemHeight = 23;
            this.cbFinalidade.Items.AddRange(new object[] {
            "Reposição de estoque",
            "Venda",
            "Troca",
            "Empréstimo",
            "Uso (Mega)",
            "Outros"});
            this.cbFinalidade.Location = new System.Drawing.Point(639, 175);
            this.cbFinalidade.Name = "cbFinalidade";
            this.cbFinalidade.Size = new System.Drawing.Size(169, 29);
            this.cbFinalidade.TabIndex = 10;
            this.cbFinalidade.UseSelectable = true;
            // 
            // lblFinalidade
            // 
            this.lblFinalidade.AutoSize = true;
            this.lblFinalidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblFinalidade.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblFinalidade.Location = new System.Drawing.Point(639, 147);
            this.lblFinalidade.Name = "lblFinalidade";
            this.lblFinalidade.Size = new System.Drawing.Size(89, 25);
            this.lblFinalidade.TabIndex = 174;
            this.lblFinalidade.Text = "Finalidade";
            this.lblFinalidade.UseCustomBackColor = true;
            // 
            // txtColaborador
            // 
            // 
            // 
            // 
            this.txtColaborador.CustomButton.Image = null;
            this.txtColaborador.CustomButton.Location = new System.Drawing.Point(159, 1);
            this.txtColaborador.CustomButton.Name = "";
            this.txtColaborador.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtColaborador.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtColaborador.CustomButton.TabIndex = 1;
            this.txtColaborador.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtColaborador.CustomButton.UseSelectable = true;
            this.txtColaborador.CustomButton.Visible = false;
            this.txtColaborador.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtColaborador.Lines = new string[0];
            this.txtColaborador.Location = new System.Drawing.Point(434, 175);
            this.txtColaborador.MaxLength = 32767;
            this.txtColaborador.Name = "txtColaborador";
            this.txtColaborador.PasswordChar = '\0';
            this.txtColaborador.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtColaborador.SelectedText = "";
            this.txtColaborador.SelectionLength = 0;
            this.txtColaborador.SelectionStart = 0;
            this.txtColaborador.ShortcutsEnabled = true;
            this.txtColaborador.Size = new System.Drawing.Size(181, 23);
            this.txtColaborador.TabIndex = 9;
            this.txtColaborador.UseSelectable = true;
            this.txtColaborador.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtColaborador.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblResponsavel
            // 
            this.lblResponsavel.AutoSize = true;
            this.lblResponsavel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblResponsavel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblResponsavel.Location = new System.Drawing.Point(434, 147);
            this.lblResponsavel.Name = "lblResponsavel";
            this.lblResponsavel.Size = new System.Drawing.Size(105, 25);
            this.lblResponsavel.TabIndex = 175;
            this.lblResponsavel.Text = "Responsável";
            this.lblResponsavel.UseCustomBackColor = true;
            // 
            // txtDestino
            // 
            // 
            // 
            // 
            this.txtDestino.CustomButton.Image = null;
            this.txtDestino.CustomButton.Location = new System.Drawing.Point(159, 1);
            this.txtDestino.CustomButton.Name = "";
            this.txtDestino.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtDestino.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDestino.CustomButton.TabIndex = 1;
            this.txtDestino.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDestino.CustomButton.UseSelectable = true;
            this.txtDestino.CustomButton.Visible = false;
            this.txtDestino.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtDestino.Lines = new string[0];
            this.txtDestino.Location = new System.Drawing.Point(228, 247);
            this.txtDestino.MaxLength = 32767;
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.PasswordChar = '\0';
            this.txtDestino.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDestino.SelectedText = "";
            this.txtDestino.SelectionLength = 0;
            this.txtDestino.SelectionStart = 0;
            this.txtDestino.ShortcutsEnabled = true;
            this.txtDestino.Size = new System.Drawing.Size(181, 23);
            this.txtDestino.TabIndex = 12;
            this.txtDestino.UseSelectable = true;
            this.txtDestino.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDestino.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblDestino.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblDestino.Location = new System.Drawing.Point(228, 219);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(69, 25);
            this.lblDestino.TabIndex = 179;
            this.lblDestino.Text = "Destino";
            this.lblDestino.UseCustomBackColor = true;
            // 
            // txtOrigem
            // 
            // 
            // 
            // 
            this.txtOrigem.CustomButton.Image = null;
            this.txtOrigem.CustomButton.Location = new System.Drawing.Point(159, 1);
            this.txtOrigem.CustomButton.Name = "";
            this.txtOrigem.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtOrigem.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOrigem.CustomButton.TabIndex = 1;
            this.txtOrigem.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOrigem.CustomButton.UseSelectable = true;
            this.txtOrigem.CustomButton.Visible = false;
            this.txtOrigem.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtOrigem.Lines = new string[0];
            this.txtOrigem.Location = new System.Drawing.Point(22, 313);
            this.txtOrigem.MaxLength = 32767;
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.PasswordChar = '\0';
            this.txtOrigem.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOrigem.SelectedText = "";
            this.txtOrigem.SelectionLength = 0;
            this.txtOrigem.SelectionStart = 0;
            this.txtOrigem.ShortcutsEnabled = true;
            this.txtOrigem.Size = new System.Drawing.Size(181, 23);
            this.txtOrigem.TabIndex = 11;
            this.txtOrigem.UseSelectable = true;
            this.txtOrigem.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOrigem.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblOrigem
            // 
            this.lblOrigem.AutoSize = true;
            this.lblOrigem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblOrigem.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblOrigem.Location = new System.Drawing.Point(22, 285);
            this.lblOrigem.Name = "lblOrigem";
            this.lblOrigem.Size = new System.Drawing.Size(70, 25);
            this.lblOrigem.TabIndex = 177;
            this.lblOrigem.Text = "Origem";
            this.lblOrigem.UseCustomBackColor = true;
            // 
            // txtObservacao
            // 
            // 
            // 
            // 
            this.txtObservacao.CustomButton.Image = null;
            this.txtObservacao.CustomButton.Location = new System.Drawing.Point(285, 1);
            this.txtObservacao.CustomButton.Name = "";
            this.txtObservacao.CustomButton.Size = new System.Drawing.Size(75, 75);
            this.txtObservacao.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtObservacao.CustomButton.TabIndex = 1;
            this.txtObservacao.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtObservacao.CustomButton.UseSelectable = true;
            this.txtObservacao.CustomButton.Visible = false;
            this.txtObservacao.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtObservacao.Lines = new string[0];
            this.txtObservacao.Location = new System.Drawing.Point(443, 247);
            this.txtObservacao.MaxLength = 32767;
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.PasswordChar = '\0';
            this.txtObservacao.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtObservacao.SelectedText = "";
            this.txtObservacao.SelectionLength = 0;
            this.txtObservacao.SelectionStart = 0;
            this.txtObservacao.ShortcutsEnabled = true;
            this.txtObservacao.Size = new System.Drawing.Size(361, 77);
            this.txtObservacao.TabIndex = 13;
            this.txtObservacao.UseSelectable = true;
            this.txtObservacao.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtObservacao.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel9.Location = new System.Drawing.Point(443, 219);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(110, 25);
            this.metroLabel9.TabIndex = 182;
            this.metroLabel9.Text = "Observações";
            this.metroLabel9.UseCustomBackColor = true;
            // 
            // panelProdutos
            // 
            this.panelProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelProdutos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelProdutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProdutos.Controls.Add(this.flpNS);
            this.panelProdutos.Controls.Add(this.btnDoSearch);
            this.panelProdutos.Controls.Add(this.gridPesquisaProduto);
            this.panelProdutos.Controls.Add(this.txtPesquisa);
            this.panelProdutos.Controls.Add(this.gridProdutos);
            this.panelProdutos.HorizontalScrollbarBarColor = true;
            this.panelProdutos.HorizontalScrollbarHighlightOnWheel = false;
            this.panelProdutos.HorizontalScrollbarSize = 10;
            this.panelProdutos.Location = new System.Drawing.Point(22, 360);
            this.panelProdutos.Name = "panelProdutos";
            this.panelProdutos.Size = new System.Drawing.Size(1169, 372);
            this.panelProdutos.TabIndex = 183;
            this.panelProdutos.UseCustomBackColor = true;
            this.panelProdutos.VerticalScrollbarBarColor = true;
            this.panelProdutos.VerticalScrollbarHighlightOnWheel = false;
            this.panelProdutos.VerticalScrollbarSize = 10;
            // 
            // flpNS
            // 
            this.flpNS.AutoScroll = true;
            this.flpNS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.flpNS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpNS.Location = new System.Drawing.Point(7, 171);
            this.flpNS.Name = "flpNS";
            this.flpNS.Size = new System.Drawing.Size(1151, 129);
            this.flpNS.TabIndex = 184;
            this.flpNS.Visible = false;
            // 
            // btnDoSearch
            // 
            this.btnDoSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoSearch.BackColor = System.Drawing.Color.White;
            this.btnDoSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoSearch.Image = global::GS.GestaoEmpresa.Properties.Resources.AuditoriaBlue;
            this.btnDoSearch.Location = new System.Drawing.Point(1121, 17);
            this.btnDoSearch.Name = "btnDoSearch";
            this.btnDoSearch.Size = new System.Drawing.Size(25, 25);
            this.btnDoSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDoSearch.TabIndex = 8;
            this.btnDoSearch.TabStop = false;
            this.btnDoSearch.Click += new System.EventHandler(this.btnDoSearch_Click);
            // 
            // gridPesquisaProduto
            // 
            this.gridPesquisaProduto.AllowUserToAddRows = false;
            this.gridPesquisaProduto.AllowUserToDeleteRows = false;
            this.gridPesquisaProduto.AllowUserToResizeRows = false;
            this.gridPesquisaProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPesquisaProduto.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gridPesquisaProduto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPesquisaProduto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridPesquisaProduto.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPesquisaProduto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridPesquisaProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPesquisaProduto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaPesquisaCodigo,
            this.colunaPesquisaFabricante,
            this.colunaPesquisaCodigoDistribuidor,
            this.colunaPesquisaNome,
            this.colunaPesquisaCompra,
            this.colunaPesquisaDistribuidor,
            this.colunaPesquisaPSCF,
            this.colunaPesquisaLucro,
            this.colunaPesquisaVenda,
            this.colunaPesquisaQuantidade,
            this.colunaPesquisaSelecionar});
            this.gridPesquisaProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPesquisaProduto.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridPesquisaProduto.EnableHeadersVisualStyles = false;
            this.gridPesquisaProduto.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridPesquisaProduto.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridPesquisaProduto.Location = new System.Drawing.Point(7, 109);
            this.gridPesquisaProduto.Name = "gridPesquisaProduto";
            this.gridPesquisaProduto.ReadOnly = true;
            this.gridPesquisaProduto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPesquisaProduto.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridPesquisaProduto.RowHeadersVisible = false;
            this.gridPesquisaProduto.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridPesquisaProduto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridPesquisaProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPesquisaProduto.Size = new System.Drawing.Size(1151, 170);
            this.gridPesquisaProduto.TabIndex = 10;
            this.gridPesquisaProduto.Visible = false;
            this.gridPesquisaProduto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPesquisaProduto_CellContentClick);
            this.gridPesquisaProduto.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPesquisaProduto_CellContentDoubleClick);
            this.gridPesquisaProduto.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridPesquisaProduto_CellPainting);
            this.gridPesquisaProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridPesquisaProduto_KeyPress);
            // 
            // colunaPesquisaCodigo
            // 
            this.colunaPesquisaCodigo.HeaderText = "Cód. Mega";
            this.colunaPesquisaCodigo.Name = "colunaPesquisaCodigo";
            this.colunaPesquisaCodigo.ReadOnly = true;
            this.colunaPesquisaCodigo.Width = 60;
            // 
            // colunaPesquisaFabricante
            // 
            this.colunaPesquisaFabricante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colunaPesquisaFabricante.HeaderText = "Fabricante";
            this.colunaPesquisaFabricante.Name = "colunaPesquisaFabricante";
            this.colunaPesquisaFabricante.ReadOnly = true;
            this.colunaPesquisaFabricante.Width = 92;
            // 
            // colunaPesquisaCodigoDistribuidor
            // 
            this.colunaPesquisaCodigoDistribuidor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colunaPesquisaCodigoDistribuidor.HeaderText = "Cód. Fabricante";
            this.colunaPesquisaCodigoDistribuidor.Name = "colunaPesquisaCodigoDistribuidor";
            this.colunaPesquisaCodigoDistribuidor.ReadOnly = true;
            this.colunaPesquisaCodigoDistribuidor.Width = 113;
            // 
            // colunaPesquisaNome
            // 
            this.colunaPesquisaNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaPesquisaNome.HeaderText = "Nome";
            this.colunaPesquisaNome.Name = "colunaPesquisaNome";
            this.colunaPesquisaNome.ReadOnly = true;
            // 
            // colunaPesquisaCompra
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colunaPesquisaCompra.DefaultCellStyle = dataGridViewCellStyle2;
            this.colunaPesquisaCompra.HeaderText = "PC";
            this.colunaPesquisaCompra.Name = "colunaPesquisaCompra";
            this.colunaPesquisaCompra.ReadOnly = true;
            this.colunaPesquisaCompra.Width = 80;
            // 
            // colunaPesquisaDistribuidor
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colunaPesquisaDistribuidor.DefaultCellStyle = dataGridViewCellStyle3;
            this.colunaPesquisaDistribuidor.HeaderText = "PD";
            this.colunaPesquisaDistribuidor.Name = "colunaPesquisaDistribuidor";
            this.colunaPesquisaDistribuidor.ReadOnly = true;
            this.colunaPesquisaDistribuidor.Width = 80;
            // 
            // colunaPesquisaPSCF
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colunaPesquisaPSCF.DefaultCellStyle = dataGridViewCellStyle4;
            this.colunaPesquisaPSCF.HeaderText = "PSCF";
            this.colunaPesquisaPSCF.Name = "colunaPesquisaPSCF";
            this.colunaPesquisaPSCF.ReadOnly = true;
            this.colunaPesquisaPSCF.Width = 80;
            // 
            // colunaPesquisaLucro
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colunaPesquisaLucro.DefaultCellStyle = dataGridViewCellStyle5;
            this.colunaPesquisaLucro.HeaderText = "L";
            this.colunaPesquisaLucro.Name = "colunaPesquisaLucro";
            this.colunaPesquisaLucro.ReadOnly = true;
            this.colunaPesquisaLucro.Width = 55;
            // 
            // colunaPesquisaVenda
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colunaPesquisaVenda.DefaultCellStyle = dataGridViewCellStyle6;
            this.colunaPesquisaVenda.HeaderText = "PV";
            this.colunaPesquisaVenda.Name = "colunaPesquisaVenda";
            this.colunaPesquisaVenda.ReadOnly = true;
            this.colunaPesquisaVenda.Width = 80;
            // 
            // colunaPesquisaQuantidade
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colunaPesquisaQuantidade.DefaultCellStyle = dataGridViewCellStyle7;
            this.colunaPesquisaQuantidade.HeaderText = "Qtd.";
            this.colunaPesquisaQuantidade.Name = "colunaPesquisaQuantidade";
            this.colunaPesquisaQuantidade.ReadOnly = true;
            this.colunaPesquisaQuantidade.Width = 50;
            // 
            // colunaPesquisaSelecionar
            // 
            this.colunaPesquisaSelecionar.HeaderText = "";
            this.colunaPesquisaSelecionar.Name = "colunaPesquisaSelecionar";
            this.colunaPesquisaSelecionar.ReadOnly = true;
            this.colunaPesquisaSelecionar.Width = 30;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPesquisa.CustomButton.Image = null;
            this.txtPesquisa.CustomButton.Location = new System.Drawing.Point(1123, 2);
            this.txtPesquisa.CustomButton.Name = "";
            this.txtPesquisa.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtPesquisa.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPesquisa.CustomButton.TabIndex = 1;
            this.txtPesquisa.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPesquisa.CustomButton.UseSelectable = true;
            this.txtPesquisa.CustomButton.Visible = false;
            this.txtPesquisa.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.txtPesquisa.Lines = new string[0];
            this.txtPesquisa.Location = new System.Drawing.Point(7, 14);
            this.txtPesquisa.MaxLength = 32767;
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.PasswordChar = '\0';
            this.txtPesquisa.PromptText = "Pesquisar...";
            this.txtPesquisa.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPesquisa.SelectedText = "";
            this.txtPesquisa.SelectionLength = 0;
            this.txtPesquisa.SelectionStart = 0;
            this.txtPesquisa.ShortcutsEnabled = true;
            this.txtPesquisa.Size = new System.Drawing.Size(1151, 30);
            this.txtPesquisa.TabIndex = 14;
            this.txtPesquisa.UseSelectable = true;
            this.txtPesquisa.WaterMark = "Pesquisar...";
            this.txtPesquisa.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPesquisa.WaterMarkFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPesquisa_KeyPress);
            this.txtPesquisa.Leave += new System.EventHandler(this.txtPesquisa_Leave);
            // 
            // gridProdutos
            // 
            this.gridProdutos.AllowUserToAddRows = false;
            this.gridProdutos.AllowUserToResizeRows = false;
            this.gridProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridProdutos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gridProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridProdutos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProdutos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.gridProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaCodigo,
            this.colunaFabricante,
            this.colunaCodigoFabricante,
            this.colunaNome,
            this.colunaValor,
            this.colunaQuantidade,
            this.colunaTotal,
            this.colunaNS,
            this.colunaRemover});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridProdutos.DefaultCellStyle = dataGridViewCellStyle14;
            this.gridProdutos.EnableHeadersVisualStyles = false;
            this.gridProdutos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridProdutos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridProdutos.Location = new System.Drawing.Point(7, 53);
            this.gridProdutos.Name = "gridProdutos";
            this.gridProdutos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProdutos.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.gridProdutos.RowHeadersVisible = false;
            this.gridProdutos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridProdutos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridProdutos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProdutos.Size = new System.Drawing.Size(1151, 312);
            this.gridProdutos.TabIndex = 2;
            this.gridProdutos.UseCustomBackColor = true;
            this.gridProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProdutos_CellContentClick);
            this.gridProdutos.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProdutos_CellMouseEnter);
            this.gridProdutos.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridProdutos_CellPainting);
            this.gridProdutos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProdutos_CellValueChanged);
            // 
            // colunaCodigo
            // 
            this.colunaCodigo.HeaderText = "Cód. Mega";
            this.colunaCodigo.Name = "colunaCodigo";
            this.colunaCodigo.ReadOnly = true;
            this.colunaCodigo.Width = 80;
            // 
            // colunaFabricante
            // 
            this.colunaFabricante.HeaderText = "Fabricante";
            this.colunaFabricante.Name = "colunaFabricante";
            // 
            // colunaCodigoFabricante
            // 
            this.colunaCodigoFabricante.HeaderText = "Cód. Fabricante";
            this.colunaCodigoFabricante.Name = "colunaCodigoFabricante";
            // 
            // colunaNome
            // 
            this.colunaNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaNome.HeaderText = "Nome";
            this.colunaNome.Name = "colunaNome";
            this.colunaNome.ReadOnly = true;
            // 
            // colunaValor
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colunaValor.DefaultCellStyle = dataGridViewCellStyle11;
            this.colunaValor.HeaderText = "Valor";
            this.colunaValor.Name = "colunaValor";
            // 
            // colunaQuantidade
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colunaQuantidade.DefaultCellStyle = dataGridViewCellStyle12;
            this.colunaQuantidade.HeaderText = "Qtd.";
            this.colunaQuantidade.Name = "colunaQuantidade";
            this.colunaQuantidade.Width = 50;
            // 
            // colunaTotal
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colunaTotal.DefaultCellStyle = dataGridViewCellStyle13;
            this.colunaTotal.HeaderText = "Total";
            this.colunaTotal.Name = "colunaTotal";
            // 
            // colunaNS
            // 
            this.colunaNS.HeaderText = "  NS";
            this.colunaNS.Name = "colunaNS";
            this.colunaNS.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colunaNS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colunaNS.Width = 50;
            // 
            // colunaRemover
            // 
            this.colunaRemover.HeaderText = "";
            this.colunaRemover.Name = "colunaRemover";
            this.colunaRemover.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colunaRemover.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colunaRemover.Width = 30;
            // 
            // txtCodigo
            // 
            // 
            // 
            // 
            this.txtCodigo.CustomButton.Image = null;
            this.txtCodigo.CustomButton.Location = new System.Drawing.Point(85, 1);
            this.txtCodigo.CustomButton.Name = "";
            this.txtCodigo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCodigo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCodigo.CustomButton.TabIndex = 1;
            this.txtCodigo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCodigo.CustomButton.UseSelectable = true;
            this.txtCodigo.CustomButton.Visible = false;
            this.txtCodigo.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtCodigo.Lines = new string[0];
            this.txtCodigo.Location = new System.Drawing.Point(22, 106);
            this.txtCodigo.MaxLength = 32767;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.PasswordChar = '\0';
            this.txtCodigo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCodigo.SelectedText = "";
            this.txtCodigo.SelectionLength = 0;
            this.txtCodigo.SelectionStart = 0;
            this.txtCodigo.ShortcutsEnabled = true;
            this.txtCodigo.Size = new System.Drawing.Size(107, 23);
            this.txtCodigo.TabIndex = 184;
            this.txtCodigo.UseSelectable = true;
            this.txtCodigo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCodigo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblCodigo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblCodigo.Location = new System.Drawing.Point(14, 78);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(67, 25);
            this.lblCodigo.TabIndex = 185;
            this.lblCodigo.Text = "Código";
            this.lblCodigo.UseCustomBackColor = true;
            // 
            // dtpHorario
            // 
            this.dtpHorario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpHorario.Location = new System.Drawing.Point(168, 92);
            this.dtpHorario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpHorario.Name = "dtpHorario";
            this.dtpHorario.Size = new System.Drawing.Size(241, 40);
            this.dtpHorario.TabIndex = 186;
            // 
            // dtpHorarioDevolucao
            // 
            this.dtpHorarioDevolucao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpHorarioDevolucao.Location = new System.Drawing.Point(581, 96);
            this.dtpHorarioDevolucao.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtpHorarioDevolucao.Name = "dtpHorarioDevolucao";
            this.dtpHorarioDevolucao.Size = new System.Drawing.Size(281, 52);
            this.dtpHorarioDevolucao.TabIndex = 187;
            // 
            // FrmInteracaoMetro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackImage = ((System.Drawing.Image)(resources.GetObject("$this.BackImage")));
            this.ClientSize = new System.Drawing.Size(1207, 740);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.gsFileAttacher1);
            this.Controls.Add(this.dtpHorarioDevolucao);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.dtpHorario);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.panelProdutos);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.txtOrigem);
            this.Controls.Add(this.lblOrigem);
            this.Controls.Add(this.txtColaborador);
            this.Controls.Add(this.lblResponsavel);
            this.Controls.Add(this.lblFinalidade);
            this.Controls.Add(this.cbFinalidade);
            this.Controls.Add(this.txtOS);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.txtNF);
            this.Controls.Add(this.lblNotaFiscal);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.cbSituacao);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.cbTipo);
            this.KeyPreview = true;
            this.Name = "FrmInteracaoMetro";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.cbTipo, 0);
            this.Controls.SetChildIndex(this.metroLabel2, 0);
            this.Controls.SetChildIndex(this.metroLabel4, 0);
            this.Controls.SetChildIndex(this.cbSituacao, 0);
            this.Controls.SetChildIndex(this.metroLabel5, 0);
            this.Controls.SetChildIndex(this.lblNotaFiscal, 0);
            this.Controls.SetChildIndex(this.txtNF, 0);
            this.Controls.SetChildIndex(this.metroLabel7, 0);
            this.Controls.SetChildIndex(this.txtOS, 0);
            this.Controls.SetChildIndex(this.cbFinalidade, 0);
            this.Controls.SetChildIndex(this.lblFinalidade, 0);
            this.Controls.SetChildIndex(this.lblResponsavel, 0);
            this.Controls.SetChildIndex(this.txtColaborador, 0);
            this.Controls.SetChildIndex(this.lblOrigem, 0);
            this.Controls.SetChildIndex(this.txtOrigem, 0);
            this.Controls.SetChildIndex(this.lblDestino, 0);
            this.Controls.SetChildIndex(this.txtDestino, 0);
            this.Controls.SetChildIndex(this.txtObservacao, 0);
            this.Controls.SetChildIndex(this.metroLabel9, 0);
            this.Controls.SetChildIndex(this.panelProdutos, 0);
            this.Controls.SetChildIndex(this.panelTitulo, 0);
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.dtpHorario, 0);
            this.Controls.SetChildIndex(this.metroLabel3, 0);
            this.Controls.SetChildIndex(this.dtpHorarioDevolucao, 0);
            this.Controls.SetChildIndex(this.gsFileAttacher1, 0);
            this.Controls.SetChildIndex(this.metroLabel6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelProdutos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnDoSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPesquisaProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private GSFileAttacher gsFileAttacher1;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel lblNotaFiscal;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel lblFinalidade;
        private MetroFramework.Controls.MetroLabel lblResponsavel;
        private MetroFramework.Controls.MetroLabel lblDestino;
        private MetroFramework.Controls.MetroLabel lblOrigem;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroPanel panelProdutos;
        private System.Windows.Forms.PictureBox btnDoSearch;
        private MetroFramework.Controls.MetroGrid gridPesquisaProduto;
        private MetroFramework.Controls.MetroTextBox txtPesquisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPesquisaCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPesquisaFabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPesquisaCodigoDistribuidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPesquisaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPesquisaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPesquisaDistribuidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPesquisaPSCF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPesquisaLucro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPesquisaVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaPesquisaQuantidade;
        private System.Windows.Forms.DataGridViewButtonColumn colunaPesquisaSelecionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaFabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCodigoFabricante;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaTotal;
        private System.Windows.Forms.DataGridViewButtonColumn colunaNS;
        private System.Windows.Forms.DataGridViewButtonColumn colunaRemover;
        private System.Windows.Forms.FlowLayoutPanel flpNS;
        private MetroFramework.Controls.MetroLabel lblCodigo;
        public MetroFramework.Controls.MetroComboBox cbTipo;
        public MetroFramework.Controls.MetroComboBox cbSituacao;
        public MetroFramework.Controls.MetroTextBox txtNF;
        public MetroFramework.Controls.MetroComboBox cbFinalidade;
        public MetroFramework.Controls.MetroTextBox txtColaborador;
        public MetroFramework.Controls.MetroTextBox txtDestino;
        public MetroFramework.Controls.MetroTextBox txtOrigem;
        public MetroFramework.Controls.MetroTextBox txtObservacao;
        public MetroFramework.Controls.MetroTextBox txtCodigo;
        public GSDateTimePicker dtpHorario;
        public GSDateTimePicker dtpHorarioDevolucao;
        public MetroFramework.Controls.MetroTextBox txtOS;
        public MetroFramework.Controls.MetroGrid gridProdutos;
    }
}