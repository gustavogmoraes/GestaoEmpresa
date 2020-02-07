namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    partial class frmProdutoMetro
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
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.toggleStatus = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMetroToggle();
            this.chkAvisarQuantidade = new MetroFramework.Controls.MetroCheckBox();
            this.txtQuantidadeEmEstoque = new MetroFramework.Controls.MetroTextBox();
            this.lblQuantidadeEmEstoque = new MetroFramework.Controls.MetroLabel();
            this.txtQuantidadeMinima = new MetroFramework.Controls.MetroTextBox();
            this.lblQuantidadeMinima = new MetroFramework.Controls.MetroLabel();
            this.txtPrecoDeVenda = new MetroFramework.Controls.MetroTextBox();
            this.lblPrecoVenda = new MetroFramework.Controls.MetroLabel();
            this.txtPorcentagemLucro = new MetroFramework.Controls.MetroTextBox();
            this.lblPorcentagemLucro = new MetroFramework.Controls.MetroLabel();
            this.txtPrecoDeCompra = new MetroFramework.Controls.MetroTextBox();
            this.lblPrecoCompra = new MetroFramework.Controls.MetroLabel();
            this.txtObservacoes = new MetroFramework.Controls.MetroTextBox();
            this.lblObservacoes = new MetroFramework.Controls.MetroLabel();
            this.txtNome = new MetroFramework.Controls.MetroTextBox();
            this.lblNome = new MetroFramework.Controls.MetroLabel();
            this.txtCodigoFabricante = new MetroFramework.Controls.MetroTextBox();
            this.lblCodigoFabricante = new MetroFramework.Controls.MetroLabel();
            this.txtMarca = new MetroFramework.Controls.MetroTextBox();
            this.lblMarca = new MetroFramework.Controls.MetroLabel();
            this.cbVigencia = new MetroFramework.Controls.MetroComboBox();
            this.lblVigencia = new MetroFramework.Controls.MetroLabel();
            this.txtCodigo = new MetroFramework.Controls.MetroTextBox();
            this.lblCodigo = new MetroFramework.Controls.MetroLabel();
            this.txtCodigoDeBarras = new MetroFramework.Controls.MetroTextBox();
            this.lblCodigoDeBarras = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtPorcentagemIpi = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtPrecoNaIntelbras = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtPrecoSugeridoRevenda = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditarSalvar
            // 
            this.btnEditarSalvar.Location = new System.Drawing.Point(520, 26);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(314, 30);
            this.lblTitulo.Text = "Cadastro e consulta de produtos";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblStatus.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblStatus.Location = new System.Drawing.Point(225, 59);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(57, 25);
            this.lblStatus.TabIndex = 55;
            this.lblStatus.Text = "Status";
            this.lblStatus.UseCustomBackColor = true;
            // 
            // toggleStatus
            // 
            this.toggleStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.toggleStatus.Checked = true;
            this.toggleStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleStatus.Location = new System.Drawing.Point(197, 73);
            this.toggleStatus.Name = "toggleStatus";
            this.toggleStatus.Size = new System.Drawing.Size(121, 40);
            this.toggleStatus.TabIndex = 77;
            this.toggleStatus.TextoOff = null;
            this.toggleStatus.TextoOn = null;
            this.toggleStatus.UseCustomBackColor = true;
            this.toggleStatus.UseSelectable = true;
            // 
            // chkAvisarQuantidade
            // 
            this.chkAvisarQuantidade.AutoSize = true;
            this.chkAvisarQuantidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.chkAvisarQuantidade.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkAvisarQuantidade.Location = new System.Drawing.Point(21, 661);
            this.chkAvisarQuantidade.Name = "chkAvisarQuantidade";
            this.chkAvisarQuantidade.Size = new System.Drawing.Size(353, 19);
            this.chkAvisarQuantidade.TabIndex = 76;
            this.chkAvisarQuantidade.Text = "Avisar quando produto chegar na quantidade mínima";
            this.chkAvisarQuantidade.UseCustomBackColor = true;
            this.chkAvisarQuantidade.UseSelectable = true;
            // 
            // txtQuantidadeEmEstoque
            // 
            this.txtQuantidadeEmEstoque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtQuantidadeEmEstoque.CustomButton.Image = null;
            this.txtQuantidadeEmEstoque.CustomButton.Location = new System.Drawing.Point(106, 1);
            this.txtQuantidadeEmEstoque.CustomButton.Name = "";
            this.txtQuantidadeEmEstoque.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtQuantidadeEmEstoque.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtQuantidadeEmEstoque.CustomButton.TabIndex = 1;
            this.txtQuantidadeEmEstoque.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtQuantidadeEmEstoque.CustomButton.UseSelectable = true;
            this.txtQuantidadeEmEstoque.CustomButton.Visible = false;
            this.txtQuantidadeEmEstoque.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtQuantidadeEmEstoque.Lines = new string[0];
            this.txtQuantidadeEmEstoque.Location = new System.Drawing.Point(390, 633);
            this.txtQuantidadeEmEstoque.MaxLength = 32767;
            this.txtQuantidadeEmEstoque.Name = "txtQuantidadeEmEstoque";
            this.txtQuantidadeEmEstoque.PasswordChar = '\0';
            this.txtQuantidadeEmEstoque.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtQuantidadeEmEstoque.SelectedText = "";
            this.txtQuantidadeEmEstoque.SelectionLength = 0;
            this.txtQuantidadeEmEstoque.SelectionStart = 0;
            this.txtQuantidadeEmEstoque.ShortcutsEnabled = true;
            this.txtQuantidadeEmEstoque.Size = new System.Drawing.Size(128, 23);
            this.txtQuantidadeEmEstoque.TabIndex = 75;
            this.txtQuantidadeEmEstoque.UseCustomBackColor = true;
            this.txtQuantidadeEmEstoque.UseSelectable = true;
            this.txtQuantidadeEmEstoque.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtQuantidadeEmEstoque.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblQuantidadeEmEstoque
            // 
            this.lblQuantidadeEmEstoque.AutoSize = true;
            this.lblQuantidadeEmEstoque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblQuantidadeEmEstoque.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblQuantidadeEmEstoque.Location = new System.Drawing.Point(374, 605);
            this.lblQuantidadeEmEstoque.Name = "lblQuantidadeEmEstoque";
            this.lblQuantidadeEmEstoque.Size = new System.Drawing.Size(196, 25);
            this.lblQuantidadeEmEstoque.TabIndex = 74;
            this.lblQuantidadeEmEstoque.Text = "Quantidade em estoque";
            this.lblQuantidadeEmEstoque.UseCustomBackColor = true;
            // 
            // txtQuantidadeMinima
            // 
            this.txtQuantidadeMinima.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtQuantidadeMinima.CustomButton.Image = null;
            this.txtQuantidadeMinima.CustomButton.Location = new System.Drawing.Point(106, 1);
            this.txtQuantidadeMinima.CustomButton.Name = "";
            this.txtQuantidadeMinima.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtQuantidadeMinima.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtQuantidadeMinima.CustomButton.TabIndex = 1;
            this.txtQuantidadeMinima.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtQuantidadeMinima.CustomButton.UseSelectable = true;
            this.txtQuantidadeMinima.CustomButton.Visible = false;
            this.txtQuantidadeMinima.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtQuantidadeMinima.Lines = new string[0];
            this.txtQuantidadeMinima.Location = new System.Drawing.Point(35, 624);
            this.txtQuantidadeMinima.MaxLength = 32767;
            this.txtQuantidadeMinima.Name = "txtQuantidadeMinima";
            this.txtQuantidadeMinima.PasswordChar = '\0';
            this.txtQuantidadeMinima.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtQuantidadeMinima.SelectedText = "";
            this.txtQuantidadeMinima.SelectionLength = 0;
            this.txtQuantidadeMinima.SelectionStart = 0;
            this.txtQuantidadeMinima.ShortcutsEnabled = true;
            this.txtQuantidadeMinima.Size = new System.Drawing.Size(128, 23);
            this.txtQuantidadeMinima.TabIndex = 73;
            this.txtQuantidadeMinima.UseCustomBackColor = true;
            this.txtQuantidadeMinima.UseSelectable = true;
            this.txtQuantidadeMinima.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtQuantidadeMinima.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblQuantidadeMinima
            // 
            this.lblQuantidadeMinima.AutoSize = true;
            this.lblQuantidadeMinima.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblQuantidadeMinima.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblQuantidadeMinima.Location = new System.Drawing.Point(19, 596);
            this.lblQuantidadeMinima.Name = "lblQuantidadeMinima";
            this.lblQuantidadeMinima.Size = new System.Drawing.Size(164, 25);
            this.lblQuantidadeMinima.TabIndex = 72;
            this.lblQuantidadeMinima.Text = "Quantidade mínima";
            this.lblQuantidadeMinima.UseCustomBackColor = true;
            // 
            // txtPrecoDeVenda
            // 
            this.txtPrecoDeVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtPrecoDeVenda.CustomButton.Image = null;
            this.txtPrecoDeVenda.CustomButton.Location = new System.Drawing.Point(106, 1);
            this.txtPrecoDeVenda.CustomButton.Name = "";
            this.txtPrecoDeVenda.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPrecoDeVenda.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPrecoDeVenda.CustomButton.TabIndex = 1;
            this.txtPrecoDeVenda.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPrecoDeVenda.CustomButton.UseSelectable = true;
            this.txtPrecoDeVenda.CustomButton.Visible = false;
            this.txtPrecoDeVenda.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPrecoDeVenda.Lines = new string[0];
            this.txtPrecoDeVenda.Location = new System.Drawing.Point(439, 477);
            this.txtPrecoDeVenda.MaxLength = 32767;
            this.txtPrecoDeVenda.Name = "txtPrecoDeVenda";
            this.txtPrecoDeVenda.PasswordChar = '\0';
            this.txtPrecoDeVenda.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrecoDeVenda.SelectedText = "";
            this.txtPrecoDeVenda.SelectionLength = 0;
            this.txtPrecoDeVenda.SelectionStart = 0;
            this.txtPrecoDeVenda.ShortcutsEnabled = true;
            this.txtPrecoDeVenda.Size = new System.Drawing.Size(128, 23);
            this.txtPrecoDeVenda.TabIndex = 71;
            this.txtPrecoDeVenda.UseCustomBackColor = true;
            this.txtPrecoDeVenda.UseSelectable = true;
            this.txtPrecoDeVenda.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPrecoDeVenda.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblPrecoVenda
            // 
            this.lblPrecoVenda.AutoSize = true;
            this.lblPrecoVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblPrecoVenda.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPrecoVenda.Location = new System.Drawing.Point(433, 449);
            this.lblPrecoVenda.Name = "lblPrecoVenda";
            this.lblPrecoVenda.Size = new System.Drawing.Size(130, 25);
            this.lblPrecoVenda.TabIndex = 70;
            this.lblPrecoVenda.Text = "Preço de venda";
            this.lblPrecoVenda.UseCustomBackColor = true;
            // 
            // txtPorcentagemLucro
            // 
            this.txtPorcentagemLucro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtPorcentagemLucro.CustomButton.Image = null;
            this.txtPorcentagemLucro.CustomButton.Location = new System.Drawing.Point(106, 1);
            this.txtPorcentagemLucro.CustomButton.Name = "";
            this.txtPorcentagemLucro.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPorcentagemLucro.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPorcentagemLucro.CustomButton.TabIndex = 1;
            this.txtPorcentagemLucro.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPorcentagemLucro.CustomButton.UseSelectable = true;
            this.txtPorcentagemLucro.CustomButton.Visible = false;
            this.txtPorcentagemLucro.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPorcentagemLucro.Lines = new string[0];
            this.txtPorcentagemLucro.Location = new System.Drawing.Point(360, 544);
            this.txtPorcentagemLucro.MaxLength = 32767;
            this.txtPorcentagemLucro.Name = "txtPorcentagemLucro";
            this.txtPorcentagemLucro.PasswordChar = '\0';
            this.txtPorcentagemLucro.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPorcentagemLucro.SelectedText = "";
            this.txtPorcentagemLucro.SelectionLength = 0;
            this.txtPorcentagemLucro.SelectionStart = 0;
            this.txtPorcentagemLucro.ShortcutsEnabled = true;
            this.txtPorcentagemLucro.Size = new System.Drawing.Size(128, 23);
            this.txtPorcentagemLucro.TabIndex = 69;
            this.txtPorcentagemLucro.UseCustomBackColor = true;
            this.txtPorcentagemLucro.UseSelectable = true;
            this.txtPorcentagemLucro.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPorcentagemLucro.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPorcentagemLucro.Leave += new System.EventHandler(this.txtPorcentagemLucro_Leave);
            // 
            // lblPorcentagemLucro
            // 
            this.lblPorcentagemLucro.AutoSize = true;
            this.lblPorcentagemLucro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblPorcentagemLucro.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPorcentagemLucro.Location = new System.Drawing.Point(336, 516);
            this.lblPorcentagemLucro.Name = "lblPorcentagemLucro";
            this.lblPorcentagemLucro.Size = new System.Drawing.Size(179, 25);
            this.lblPorcentagemLucro.TabIndex = 68;
            this.lblPorcentagemLucro.Text = "Porcentagem de lucro";
            this.lblPorcentagemLucro.UseCustomBackColor = true;
            // 
            // txtPrecoDeCompra
            // 
            this.txtPrecoDeCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtPrecoDeCompra.CustomButton.Image = null;
            this.txtPrecoDeCompra.CustomButton.Location = new System.Drawing.Point(106, 1);
            this.txtPrecoDeCompra.CustomButton.Name = "";
            this.txtPrecoDeCompra.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPrecoDeCompra.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPrecoDeCompra.CustomButton.TabIndex = 1;
            this.txtPrecoDeCompra.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPrecoDeCompra.CustomButton.UseSelectable = true;
            this.txtPrecoDeCompra.CustomButton.Visible = false;
            this.txtPrecoDeCompra.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPrecoDeCompra.Lines = new string[0];
            this.txtPrecoDeCompra.Location = new System.Drawing.Point(277, 477);
            this.txtPrecoDeCompra.MaxLength = 32767;
            this.txtPrecoDeCompra.Name = "txtPrecoDeCompra";
            this.txtPrecoDeCompra.PasswordChar = '\0';
            this.txtPrecoDeCompra.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrecoDeCompra.SelectedText = "";
            this.txtPrecoDeCompra.SelectionLength = 0;
            this.txtPrecoDeCompra.SelectionStart = 0;
            this.txtPrecoDeCompra.ShortcutsEnabled = true;
            this.txtPrecoDeCompra.Size = new System.Drawing.Size(128, 23);
            this.txtPrecoDeCompra.TabIndex = 67;
            this.txtPrecoDeCompra.UseCustomBackColor = true;
            this.txtPrecoDeCompra.UseSelectable = true;
            this.txtPrecoDeCompra.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPrecoDeCompra.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblPrecoCompra
            // 
            this.lblPrecoCompra.AutoSize = true;
            this.lblPrecoCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblPrecoCompra.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPrecoCompra.Location = new System.Drawing.Point(268, 449);
            this.lblPrecoCompra.Name = "lblPrecoCompra";
            this.lblPrecoCompra.Size = new System.Drawing.Size(142, 25);
            this.lblPrecoCompra.TabIndex = 66;
            this.lblPrecoCompra.Text = "Preço de compra";
            this.lblPrecoCompra.UseCustomBackColor = true;
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtObservacoes.CustomButton.Image = null;
            this.txtObservacoes.CustomButton.Location = new System.Drawing.Point(426, 2);
            this.txtObservacoes.CustomButton.Name = "";
            this.txtObservacoes.CustomButton.Size = new System.Drawing.Size(113, 113);
            this.txtObservacoes.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtObservacoes.CustomButton.TabIndex = 1;
            this.txtObservacoes.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtObservacoes.CustomButton.UseSelectable = true;
            this.txtObservacoes.CustomButton.Visible = false;
            this.txtObservacoes.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtObservacoes.Lines = new string[0];
            this.txtObservacoes.Location = new System.Drawing.Point(25, 313);
            this.txtObservacoes.MaxLength = 32767;
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.PasswordChar = '\0';
            this.txtObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtObservacoes.SelectedText = "";
            this.txtObservacoes.SelectionLength = 0;
            this.txtObservacoes.SelectionStart = 0;
            this.txtObservacoes.ShortcutsEnabled = true;
            this.txtObservacoes.Size = new System.Drawing.Size(542, 118);
            this.txtObservacoes.TabIndex = 65;
            this.txtObservacoes.UseCustomBackColor = true;
            this.txtObservacoes.UseSelectable = true;
            this.txtObservacoes.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtObservacoes.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblObservacoes
            // 
            this.lblObservacoes.AutoSize = true;
            this.lblObservacoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblObservacoes.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblObservacoes.Location = new System.Drawing.Point(21, 285);
            this.lblObservacoes.Name = "lblObservacoes";
            this.lblObservacoes.Size = new System.Drawing.Size(110, 25);
            this.lblObservacoes.TabIndex = 64;
            this.lblObservacoes.Text = "Observações";
            this.lblObservacoes.UseCustomBackColor = true;
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtNome.CustomButton.Image = null;
            this.txtNome.CustomButton.Location = new System.Drawing.Point(520, 1);
            this.txtNome.CustomButton.Name = "";
            this.txtNome.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNome.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNome.CustomButton.TabIndex = 1;
            this.txtNome.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNome.CustomButton.UseSelectable = true;
            this.txtNome.CustomButton.Visible = false;
            this.txtNome.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNome.Lines = new string[0];
            this.txtNome.Location = new System.Drawing.Point(25, 260);
            this.txtNome.MaxLength = 32767;
            this.txtNome.Name = "txtNome";
            this.txtNome.PasswordChar = '\0';
            this.txtNome.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNome.SelectedText = "";
            this.txtNome.SelectionLength = 0;
            this.txtNome.SelectionStart = 0;
            this.txtNome.ShortcutsEnabled = true;
            this.txtNome.Size = new System.Drawing.Size(542, 23);
            this.txtNome.TabIndex = 63;
            this.txtNome.UseCustomBackColor = true;
            this.txtNome.UseSelectable = true;
            this.txtNome.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNome.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblNome.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblNome.Location = new System.Drawing.Point(21, 232);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(59, 25);
            this.lblNome.TabIndex = 62;
            this.lblNome.Text = "Nome";
            this.lblNome.UseCustomBackColor = true;
            // 
            // txtCodigoFabricante
            // 
            this.txtCodigoFabricante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtCodigoFabricante.CustomButton.Image = null;
            this.txtCodigoFabricante.CustomButton.Location = new System.Drawing.Point(159, 1);
            this.txtCodigoFabricante.CustomButton.Name = "";
            this.txtCodigoFabricante.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCodigoFabricante.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCodigoFabricante.CustomButton.TabIndex = 1;
            this.txtCodigoFabricante.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCodigoFabricante.CustomButton.UseSelectable = true;
            this.txtCodigoFabricante.CustomButton.Visible = false;
            this.txtCodigoFabricante.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtCodigoFabricante.Lines = new string[0];
            this.txtCodigoFabricante.Location = new System.Drawing.Point(229, 149);
            this.txtCodigoFabricante.MaxLength = 32767;
            this.txtCodigoFabricante.Name = "txtCodigoFabricante";
            this.txtCodigoFabricante.PasswordChar = '\0';
            this.txtCodigoFabricante.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCodigoFabricante.SelectedText = "";
            this.txtCodigoFabricante.SelectionLength = 0;
            this.txtCodigoFabricante.SelectionStart = 0;
            this.txtCodigoFabricante.ShortcutsEnabled = true;
            this.txtCodigoFabricante.Size = new System.Drawing.Size(181, 23);
            this.txtCodigoFabricante.TabIndex = 61;
            this.txtCodigoFabricante.UseCustomBackColor = true;
            this.txtCodigoFabricante.UseSelectable = true;
            this.txtCodigoFabricante.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCodigoFabricante.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblCodigoFabricante
            // 
            this.lblCodigoFabricante.AutoSize = true;
            this.lblCodigoFabricante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblCodigoFabricante.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblCodigoFabricante.Location = new System.Drawing.Point(225, 121);
            this.lblCodigoFabricante.Name = "lblCodigoFabricante";
            this.lblCodigoFabricante.Size = new System.Drawing.Size(172, 25);
            this.lblCodigoFabricante.TabIndex = 60;
            this.lblCodigoFabricante.Text = "Código do fabricante";
            this.lblCodigoFabricante.UseCustomBackColor = true;
            // 
            // txtMarca
            // 
            this.txtMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtMarca.CustomButton.Image = null;
            this.txtMarca.CustomButton.Location = new System.Drawing.Point(159, 1);
            this.txtMarca.CustomButton.Name = "";
            this.txtMarca.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtMarca.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMarca.CustomButton.TabIndex = 1;
            this.txtMarca.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMarca.CustomButton.UseSelectable = true;
            this.txtMarca.CustomButton.Visible = false;
            this.txtMarca.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtMarca.Lines = new string[0];
            this.txtMarca.Location = new System.Drawing.Point(25, 149);
            this.txtMarca.MaxLength = 32767;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.PasswordChar = '\0';
            this.txtMarca.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMarca.SelectedText = "";
            this.txtMarca.SelectionLength = 0;
            this.txtMarca.SelectionStart = 0;
            this.txtMarca.ShortcutsEnabled = true;
            this.txtMarca.Size = new System.Drawing.Size(181, 23);
            this.txtMarca.TabIndex = 59;
            this.txtMarca.UseCustomBackColor = true;
            this.txtMarca.UseSelectable = true;
            this.txtMarca.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMarca.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblMarca.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblMarca.Location = new System.Drawing.Point(21, 121);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(59, 25);
            this.lblMarca.TabIndex = 58;
            this.lblMarca.Text = "Marca";
            this.lblMarca.UseCustomBackColor = true;
            // 
            // cbVigencia
            // 
            this.cbVigencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cbVigencia.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbVigencia.FormattingEnabled = true;
            this.cbVigencia.ItemHeight = 19;
            this.cbVigencia.Location = new System.Drawing.Point(424, 87);
            this.cbVigencia.Name = "cbVigencia";
            this.cbVigencia.Size = new System.Drawing.Size(155, 25);
            this.cbVigencia.TabIndex = 57;
            this.cbVigencia.UseCustomBackColor = true;
            this.cbVigencia.UseSelectable = true;
            this.cbVigencia.SelectedIndexChanged += new System.EventHandler(this.cbVigencia_SelectedIndexChanged);
            // 
            // lblVigencia
            // 
            this.lblVigencia.AutoSize = true;
            this.lblVigencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblVigencia.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblVigencia.Location = new System.Drawing.Point(424, 62);
            this.lblVigencia.Name = "lblVigencia";
            this.lblVigencia.Size = new System.Drawing.Size(77, 25);
            this.lblVigencia.TabIndex = 56;
            this.lblVigencia.Text = "Vigência";
            this.lblVigencia.UseCustomBackColor = true;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtCodigo.CustomButton.Image = null;
            this.txtCodigo.CustomButton.Location = new System.Drawing.Point(94, 1);
            this.txtCodigo.CustomButton.Name = "";
            this.txtCodigo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCodigo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCodigo.CustomButton.TabIndex = 1;
            this.txtCodigo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCodigo.CustomButton.UseSelectable = true;
            this.txtCodigo.CustomButton.Visible = false;
            this.txtCodigo.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtCodigo.Lines = new string[0];
            this.txtCodigo.Location = new System.Drawing.Point(25, 87);
            this.txtCodigo.MaxLength = 32767;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.PasswordChar = '\0';
            this.txtCodigo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCodigo.SelectedText = "";
            this.txtCodigo.SelectionLength = 0;
            this.txtCodigo.SelectionStart = 0;
            this.txtCodigo.ShortcutsEnabled = true;
            this.txtCodigo.Size = new System.Drawing.Size(116, 23);
            this.txtCodigo.TabIndex = 54;
            this.txtCodigo.UseCustomBackColor = true;
            this.txtCodigo.UseSelectable = true;
            this.txtCodigo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCodigo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblCodigo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblCodigo.Location = new System.Drawing.Point(21, 59);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(67, 25);
            this.lblCodigo.TabIndex = 53;
            this.lblCodigo.Text = "Código";
            this.lblCodigo.UseCustomBackColor = true;
            // 
            // txtCodigoDeBarras
            // 
            this.txtCodigoDeBarras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtCodigoDeBarras.CustomButton.Image = null;
            this.txtCodigoDeBarras.CustomButton.Location = new System.Drawing.Point(520, 1);
            this.txtCodigoDeBarras.CustomButton.Name = "";
            this.txtCodigoDeBarras.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCodigoDeBarras.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCodigoDeBarras.CustomButton.TabIndex = 1;
            this.txtCodigoDeBarras.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCodigoDeBarras.CustomButton.UseSelectable = true;
            this.txtCodigoDeBarras.CustomButton.Visible = false;
            this.txtCodigoDeBarras.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtCodigoDeBarras.Lines = new string[0];
            this.txtCodigoDeBarras.Location = new System.Drawing.Point(25, 203);
            this.txtCodigoDeBarras.MaxLength = 32767;
            this.txtCodigoDeBarras.Name = "txtCodigoDeBarras";
            this.txtCodigoDeBarras.PasswordChar = '\0';
            this.txtCodigoDeBarras.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCodigoDeBarras.SelectedText = "";
            this.txtCodigoDeBarras.SelectionLength = 0;
            this.txtCodigoDeBarras.SelectionStart = 0;
            this.txtCodigoDeBarras.ShortcutsEnabled = true;
            this.txtCodigoDeBarras.Size = new System.Drawing.Size(542, 23);
            this.txtCodigoDeBarras.TabIndex = 62;
            this.txtCodigoDeBarras.UseCustomBackColor = true;
            this.txtCodigoDeBarras.UseSelectable = true;
            this.txtCodigoDeBarras.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCodigoDeBarras.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtCodigoDeBarras.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCodigoDeBarras_KeyDown);
            // 
            // lblCodigoDeBarras
            // 
            this.lblCodigoDeBarras.AutoSize = true;
            this.lblCodigoDeBarras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblCodigoDeBarras.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblCodigoDeBarras.Location = new System.Drawing.Point(20, 175);
            this.lblCodigoDeBarras.Name = "lblCodigoDeBarras";
            this.lblCodigoDeBarras.Size = new System.Drawing.Size(143, 25);
            this.lblCodigoDeBarras.TabIndex = 78;
            this.lblCodigoDeBarras.Text = "Código de barras";
            this.lblCodigoDeBarras.UseCustomBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(487, 541);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(26, 25);
            this.metroLabel1.TabIndex = 80;
            this.metroLabel1.Text = "%";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(148, 532);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(26, 25);
            this.metroLabel2.TabIndex = 83;
            this.metroLabel2.Text = "%";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // txtPorcentagemIpi
            // 
            this.txtPorcentagemIpi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtPorcentagemIpi.CustomButton.Image = null;
            this.txtPorcentagemIpi.CustomButton.Location = new System.Drawing.Point(106, 1);
            this.txtPorcentagemIpi.CustomButton.Name = "";
            this.txtPorcentagemIpi.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPorcentagemIpi.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPorcentagemIpi.CustomButton.TabIndex = 1;
            this.txtPorcentagemIpi.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPorcentagemIpi.CustomButton.UseSelectable = true;
            this.txtPorcentagemIpi.CustomButton.Visible = false;
            this.txtPorcentagemIpi.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPorcentagemIpi.Lines = new string[0];
            this.txtPorcentagemIpi.Location = new System.Drawing.Point(21, 534);
            this.txtPorcentagemIpi.MaxLength = 32767;
            this.txtPorcentagemIpi.Name = "txtPorcentagemIpi";
            this.txtPorcentagemIpi.PasswordChar = '\0';
            this.txtPorcentagemIpi.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPorcentagemIpi.SelectedText = "";
            this.txtPorcentagemIpi.SelectionLength = 0;
            this.txtPorcentagemIpi.SelectionStart = 0;
            this.txtPorcentagemIpi.ShortcutsEnabled = true;
            this.txtPorcentagemIpi.Size = new System.Drawing.Size(128, 23);
            this.txtPorcentagemIpi.TabIndex = 82;
            this.txtPorcentagemIpi.UseCustomBackColor = true;
            this.txtPorcentagemIpi.UseSelectable = true;
            this.txtPorcentagemIpi.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPorcentagemIpi.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(58, 506);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(30, 25);
            this.metroLabel3.TabIndex = 81;
            this.metroLabel3.Text = "IPI";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // txtPrecoNaIntelbras
            // 
            this.txtPrecoNaIntelbras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtPrecoNaIntelbras.CustomButton.Image = null;
            this.txtPrecoNaIntelbras.CustomButton.Location = new System.Drawing.Point(106, 1);
            this.txtPrecoNaIntelbras.CustomButton.Name = "";
            this.txtPrecoNaIntelbras.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPrecoNaIntelbras.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPrecoNaIntelbras.CustomButton.TabIndex = 1;
            this.txtPrecoNaIntelbras.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPrecoNaIntelbras.CustomButton.UseSelectable = true;
            this.txtPrecoNaIntelbras.CustomButton.Visible = false;
            this.txtPrecoNaIntelbras.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPrecoNaIntelbras.Lines = new string[0];
            this.txtPrecoNaIntelbras.Location = new System.Drawing.Point(28, 471);
            this.txtPrecoNaIntelbras.MaxLength = 32767;
            this.txtPrecoNaIntelbras.Name = "txtPrecoNaIntelbras";
            this.txtPrecoNaIntelbras.PasswordChar = '\0';
            this.txtPrecoNaIntelbras.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrecoNaIntelbras.SelectedText = "";
            this.txtPrecoNaIntelbras.SelectionLength = 0;
            this.txtPrecoNaIntelbras.SelectionStart = 0;
            this.txtPrecoNaIntelbras.ShortcutsEnabled = true;
            this.txtPrecoNaIntelbras.Size = new System.Drawing.Size(128, 23);
            this.txtPrecoNaIntelbras.TabIndex = 87;
            this.txtPrecoNaIntelbras.UseCustomBackColor = true;
            this.txtPrecoNaIntelbras.UseSelectable = true;
            this.txtPrecoNaIntelbras.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPrecoNaIntelbras.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.Location = new System.Drawing.Point(19, 443);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(148, 25);
            this.metroLabel5.TabIndex = 86;
            this.metroLabel5.Text = "Preço na Intelbras";
            this.metroLabel5.UseCustomBackColor = true;
            // 
            // txtPrecoSugeridoRevenda
            // 
            this.txtPrecoSugeridoRevenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtPrecoSugeridoRevenda.CustomButton.Image = null;
            this.txtPrecoSugeridoRevenda.CustomButton.Location = new System.Drawing.Point(106, 1);
            this.txtPrecoSugeridoRevenda.CustomButton.Name = "";
            this.txtPrecoSugeridoRevenda.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPrecoSugeridoRevenda.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPrecoSugeridoRevenda.CustomButton.TabIndex = 1;
            this.txtPrecoSugeridoRevenda.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPrecoSugeridoRevenda.CustomButton.UseSelectable = true;
            this.txtPrecoSugeridoRevenda.CustomButton.Visible = false;
            this.txtPrecoSugeridoRevenda.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPrecoSugeridoRevenda.Lines = new string[0];
            this.txtPrecoSugeridoRevenda.Location = new System.Drawing.Point(199, 544);
            this.txtPrecoSugeridoRevenda.MaxLength = 32767;
            this.txtPrecoSugeridoRevenda.Name = "txtPrecoSugeridoRevenda";
            this.txtPrecoSugeridoRevenda.PasswordChar = '\0';
            this.txtPrecoSugeridoRevenda.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrecoSugeridoRevenda.SelectedText = "";
            this.txtPrecoSugeridoRevenda.SelectionLength = 0;
            this.txtPrecoSugeridoRevenda.SelectionStart = 0;
            this.txtPrecoSugeridoRevenda.ShortcutsEnabled = true;
            this.txtPrecoSugeridoRevenda.Size = new System.Drawing.Size(128, 23);
            this.txtPrecoSugeridoRevenda.TabIndex = 89;
            this.txtPrecoSugeridoRevenda.UseCustomBackColor = true;
            this.txtPrecoSugeridoRevenda.UseSelectable = true;
            this.txtPrecoSugeridoRevenda.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPrecoSugeridoRevenda.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.Location = new System.Drawing.Point(190, 516);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(121, 25);
            this.metroLabel6.TabIndex = 88;
            this.metroLabel6.Text = "Preço revenda";
            this.metroLabel6.UseCustomBackColor = true;
            // 
            // frmProdutoMetro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 710);
            this.Controls.Add(this.txtPrecoSugeridoRevenda);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtPrecoNaIntelbras);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtPorcentagemIpi);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtCodigoDeBarras);
            this.Controls.Add(this.lblCodigoDeBarras);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.toggleStatus);
            this.Controls.Add(this.chkAvisarQuantidade);
            this.Controls.Add(this.txtQuantidadeEmEstoque);
            this.Controls.Add(this.lblQuantidadeEmEstoque);
            this.Controls.Add(this.txtQuantidadeMinima);
            this.Controls.Add(this.lblQuantidadeMinima);
            this.Controls.Add(this.txtPrecoDeVenda);
            this.Controls.Add(this.lblPrecoVenda);
            this.Controls.Add(this.txtPorcentagemLucro);
            this.Controls.Add(this.lblPorcentagemLucro);
            this.Controls.Add(this.txtPrecoDeCompra);
            this.Controls.Add(this.lblPrecoCompra);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.lblObservacoes);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtCodigoFabricante);
            this.Controls.Add(this.lblCodigoFabricante);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.cbVigencia);
            this.Controls.Add(this.lblVigencia);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Name = "frmProdutoMetro";
            this.Text = "frmProdutoMetroT";
            this.Controls.SetChildIndex(this.lblCodigo, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            this.Controls.SetChildIndex(this.lblVigencia, 0);
            this.Controls.SetChildIndex(this.cbVigencia, 0);
            this.Controls.SetChildIndex(this.lblMarca, 0);
            this.Controls.SetChildIndex(this.txtMarca, 0);
            this.Controls.SetChildIndex(this.lblCodigoFabricante, 0);
            this.Controls.SetChildIndex(this.txtCodigoFabricante, 0);
            this.Controls.SetChildIndex(this.lblNome, 0);
            this.Controls.SetChildIndex(this.txtNome, 0);
            this.Controls.SetChildIndex(this.lblObservacoes, 0);
            this.Controls.SetChildIndex(this.txtObservacoes, 0);
            this.Controls.SetChildIndex(this.lblPrecoCompra, 0);
            this.Controls.SetChildIndex(this.txtPrecoDeCompra, 0);
            this.Controls.SetChildIndex(this.lblPorcentagemLucro, 0);
            this.Controls.SetChildIndex(this.txtPorcentagemLucro, 0);
            this.Controls.SetChildIndex(this.lblPrecoVenda, 0);
            this.Controls.SetChildIndex(this.txtPrecoDeVenda, 0);
            this.Controls.SetChildIndex(this.lblQuantidadeMinima, 0);
            this.Controls.SetChildIndex(this.txtQuantidadeMinima, 0);
            this.Controls.SetChildIndex(this.lblQuantidadeEmEstoque, 0);
            this.Controls.SetChildIndex(this.txtQuantidadeEmEstoque, 0);
            this.Controls.SetChildIndex(this.chkAvisarQuantidade, 0);
            this.Controls.SetChildIndex(this.toggleStatus, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.lblCodigoDeBarras, 0);
            this.Controls.SetChildIndex(this.txtCodigoDeBarras, 0);
            this.Controls.SetChildIndex(this.metroLabel1, 0);
            this.Controls.SetChildIndex(this.metroLabel3, 0);
            this.Controls.SetChildIndex(this.txtPorcentagemIpi, 0);
            this.Controls.SetChildIndex(this.metroLabel2, 0);
            this.Controls.SetChildIndex(this.metroLabel5, 0);
            this.Controls.SetChildIndex(this.txtPrecoNaIntelbras, 0);
            this.Controls.SetChildIndex(this.metroLabel6, 0);
            this.Controls.SetChildIndex(this.txtPrecoSugeridoRevenda, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public MetroFramework.Controls.MetroTextBox txtCodigo;
        public MetroFramework.Controls.MetroTextBox txtNome;
        public MetroFramework.Controls.MetroLabel lblStatus;
        public ControlesGenericos.GSMetroToggle toggleStatus;
        public MetroFramework.Controls.MetroLabel lblNome;
        public MetroFramework.Controls.MetroTextBox txtCodigoFabricante;
        public MetroFramework.Controls.MetroLabel lblCodigoFabricante;
        public MetroFramework.Controls.MetroTextBox txtMarca;
        public MetroFramework.Controls.MetroLabel lblMarca;
        public MetroFramework.Controls.MetroComboBox cbVigencia;
        public MetroFramework.Controls.MetroLabel lblVigencia;
        public MetroFramework.Controls.MetroLabel lblCodigo;
        public MetroFramework.Controls.MetroCheckBox chkAvisarQuantidade;
        public MetroFramework.Controls.MetroTextBox txtQuantidadeEmEstoque;
        public MetroFramework.Controls.MetroLabel lblQuantidadeEmEstoque;
        public MetroFramework.Controls.MetroTextBox txtQuantidadeMinima;
        public MetroFramework.Controls.MetroLabel lblQuantidadeMinima;
        public MetroFramework.Controls.MetroTextBox txtPrecoDeVenda;
        public MetroFramework.Controls.MetroLabel lblPrecoVenda;
        public MetroFramework.Controls.MetroTextBox txtPorcentagemLucro;
        public MetroFramework.Controls.MetroLabel lblPorcentagemLucro;
        public MetroFramework.Controls.MetroTextBox txtPrecoDeCompra;
        public MetroFramework.Controls.MetroLabel lblPrecoCompra;
        public MetroFramework.Controls.MetroTextBox txtObservacoes;
        public MetroFramework.Controls.MetroLabel lblObservacoes;
        public MetroFramework.Controls.MetroTextBox txtCodigoDeBarras;
        public MetroFramework.Controls.MetroLabel lblCodigoDeBarras;
        public MetroFramework.Controls.MetroLabel metroLabel1;
        public MetroFramework.Controls.MetroLabel metroLabel2;
        public MetroFramework.Controls.MetroTextBox txtPorcentagemIpi;
        public MetroFramework.Controls.MetroLabel metroLabel3;
        public MetroFramework.Controls.MetroTextBox txtPrecoNaIntelbras;
        public MetroFramework.Controls.MetroLabel metroLabel5;
        public MetroFramework.Controls.MetroTextBox txtPrecoSugeridoRevenda;
        public MetroFramework.Controls.MetroLabel metroLabel6;
    }
}