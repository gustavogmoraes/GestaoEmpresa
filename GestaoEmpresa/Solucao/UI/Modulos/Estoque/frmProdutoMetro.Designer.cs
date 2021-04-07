namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    partial class FrmProdutoMetro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProdutoMetro));
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.toggleStatus = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMetroToggle();
            this.chkAvisarQuantidade = new MetroFramework.Controls.MetroCheckBox();
            this.txtQuantidadeEmEstoque = new MetroFramework.Controls.MetroTextBox();
            this.lblQuantidadeEmEstoque = new MetroFramework.Controls.MetroLabel();
            this.txtQuantidadeMinima = new MetroFramework.Controls.MetroTextBox();
            this.lblQuantidadeMinima = new MetroFramework.Controls.MetroLabel();
            this.lblPrecoVenda = new MetroFramework.Controls.MetroLabel();
            this.lblPorcentagemLucro = new MetroFramework.Controls.MetroLabel();
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
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.txtMPrecoDeCompra = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMetroMonetary();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtMLucro = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMetroMonetary();
            this.txtMPrecoDeVenda = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMetroMonetary();
            this.txtMPorcentagemIpi = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMetroMonetary();
            this.txtMPrecoNaIntelbras = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMetroMonetary();
            this.txtMPrecoSugeridoRevenda = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMetroMonetary();
            this.txtMPorcentagemDeLucroConsumidorFinal = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMetroMonetary();
            this.txtMPscf = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMetroMonetary();
            this.gsImageAttacher1 = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSImageAttacher();
            this.txtTambemConhecidoComo = new MetroFramework.Controls.MetroTextBox();
            this.lblTambemConhecidoComo = new MetroFramework.Controls.MetroLabel();
            this.txtLocalizacao = new MetroFramework.Controls.MetroTextBox();
            this.lblLocalizacao = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).BeginInit();
            this.panelTitulo.SuspendLayout();
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
            this.chkAvisarQuantidade.Location = new System.Drawing.Point(20, 686);
            this.chkAvisarQuantidade.Name = "chkAvisarQuantidade";
            this.chkAvisarQuantidade.Size = new System.Drawing.Size(308, 19);
            this.chkAvisarQuantidade.TabIndex = 76;
            this.chkAvisarQuantidade.Text = "Avisar quando produto chegar na qtd. mínima";
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
            this.txtQuantidadeEmEstoque.CustomButton.Location = new System.Drawing.Point(71, 1);
            this.txtQuantidadeEmEstoque.CustomButton.Name = "";
            this.txtQuantidadeEmEstoque.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtQuantidadeEmEstoque.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtQuantidadeEmEstoque.CustomButton.TabIndex = 1;
            this.txtQuantidadeEmEstoque.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtQuantidadeEmEstoque.CustomButton.UseSelectable = true;
            this.txtQuantidadeEmEstoque.CustomButton.Visible = false;
            this.txtQuantidadeEmEstoque.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtQuantidadeEmEstoque.Lines = new string[0];
            this.txtQuantidadeEmEstoque.Location = new System.Drawing.Point(162, 635);
            this.txtQuantidadeEmEstoque.MaxLength = 32767;
            this.txtQuantidadeEmEstoque.Name = "txtQuantidadeEmEstoque";
            this.txtQuantidadeEmEstoque.PasswordChar = '\0';
            this.txtQuantidadeEmEstoque.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtQuantidadeEmEstoque.SelectedText = "";
            this.txtQuantidadeEmEstoque.SelectionLength = 0;
            this.txtQuantidadeEmEstoque.SelectionStart = 0;
            this.txtQuantidadeEmEstoque.ShortcutsEnabled = true;
            this.txtQuantidadeEmEstoque.Size = new System.Drawing.Size(93, 23);
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
            this.lblQuantidadeEmEstoque.Location = new System.Drawing.Point(149, 607);
            this.lblQuantidadeEmEstoque.Name = "lblQuantidadeEmEstoque";
            this.lblQuantidadeEmEstoque.Size = new System.Drawing.Size(135, 25);
            this.lblQuantidadeEmEstoque.TabIndex = 74;
            this.lblQuantidadeEmEstoque.Text = "Qtd em estoque";
            this.lblQuantidadeEmEstoque.UseCustomBackColor = true;
            // 
            // txtQuantidadeMinima
            // 
            this.txtQuantidadeMinima.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtQuantidadeMinima.CustomButton.Image = null;
            this.txtQuantidadeMinima.CustomButton.Location = new System.Drawing.Point(71, 1);
            this.txtQuantidadeMinima.CustomButton.Name = "";
            this.txtQuantidadeMinima.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtQuantidadeMinima.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtQuantidadeMinima.CustomButton.TabIndex = 1;
            this.txtQuantidadeMinima.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtQuantidadeMinima.CustomButton.UseSelectable = true;
            this.txtQuantidadeMinima.CustomButton.Visible = false;
            this.txtQuantidadeMinima.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtQuantidadeMinima.Lines = new string[0];
            this.txtQuantidadeMinima.Location = new System.Drawing.Point(41, 635);
            this.txtQuantidadeMinima.MaxLength = 32767;
            this.txtQuantidadeMinima.Name = "txtQuantidadeMinima";
            this.txtQuantidadeMinima.PasswordChar = '\0';
            this.txtQuantidadeMinima.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtQuantidadeMinima.SelectedText = "";
            this.txtQuantidadeMinima.SelectionLength = 0;
            this.txtQuantidadeMinima.SelectionStart = 0;
            this.txtQuantidadeMinima.ShortcutsEnabled = true;
            this.txtQuantidadeMinima.Size = new System.Drawing.Size(93, 23);
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
            this.lblQuantidadeMinima.Location = new System.Drawing.Point(38, 607);
            this.lblQuantidadeMinima.Name = "lblQuantidadeMinima";
            this.lblQuantidadeMinima.Size = new System.Drawing.Size(107, 25);
            this.lblQuantidadeMinima.TabIndex = 72;
            this.lblQuantidadeMinima.Text = "Qtd. mínima";
            this.lblQuantidadeMinima.UseCustomBackColor = true;
            // 
            // lblPrecoVenda
            // 
            this.lblPrecoVenda.AutoSize = true;
            this.lblPrecoVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblPrecoVenda.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPrecoVenda.Location = new System.Drawing.Point(453, 483);
            this.lblPrecoVenda.Name = "lblPrecoVenda";
            this.lblPrecoVenda.Size = new System.Drawing.Size(130, 25);
            this.lblPrecoVenda.TabIndex = 70;
            this.lblPrecoVenda.Text = "Preço de venda";
            this.lblPrecoVenda.UseCustomBackColor = true;
            // 
            // lblPorcentagemLucro
            // 
            this.lblPorcentagemLucro.AutoSize = true;
            this.lblPorcentagemLucro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblPorcentagemLucro.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPorcentagemLucro.Location = new System.Drawing.Point(371, 483);
            this.lblPorcentagemLucro.Name = "lblPorcentagemLucro";
            this.lblPorcentagemLucro.Size = new System.Drawing.Size(73, 25);
            this.lblPorcentagemLucro.TabIndex = 68;
            this.lblPorcentagemLucro.Text = "% Lucro";
            this.lblPorcentagemLucro.UseCustomBackColor = true;
            // 
            // lblPrecoCompra
            // 
            this.lblPrecoCompra.AutoSize = true;
            this.lblPrecoCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblPrecoCompra.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPrecoCompra.Location = new System.Drawing.Point(228, 483);
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
            this.txtObservacoes.CustomButton.Location = new System.Drawing.Point(474, 2);
            this.txtObservacoes.CustomButton.Name = "";
            this.txtObservacoes.CustomButton.Size = new System.Drawing.Size(65, 65);
            this.txtObservacoes.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtObservacoes.CustomButton.TabIndex = 1;
            this.txtObservacoes.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtObservacoes.CustomButton.UseSelectable = true;
            this.txtObservacoes.CustomButton.Visible = false;
            this.txtObservacoes.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtObservacoes.Lines = new string[0];
            this.txtObservacoes.Location = new System.Drawing.Point(25, 356);
            this.txtObservacoes.MaxLength = 32767;
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.PasswordChar = '\0';
            this.txtObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtObservacoes.SelectedText = "";
            this.txtObservacoes.SelectionLength = 0;
            this.txtObservacoes.SelectionStart = 0;
            this.txtObservacoes.ShortcutsEnabled = true;
            this.txtObservacoes.Size = new System.Drawing.Size(542, 70);
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
            this.lblObservacoes.Location = new System.Drawing.Point(21, 328);
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
            this.txtNome.Location = new System.Drawing.Point(25, 248);
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
            this.lblNome.Location = new System.Drawing.Point(21, 220);
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
            this.txtCodigoFabricante.Location = new System.Drawing.Point(229, 137);
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
            this.lblCodigoFabricante.Location = new System.Drawing.Point(225, 109);
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
            this.txtMarca.CustomButton.Location = new System.Drawing.Point(150, 1);
            this.txtMarca.CustomButton.Name = "";
            this.txtMarca.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtMarca.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMarca.CustomButton.TabIndex = 1;
            this.txtMarca.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMarca.CustomButton.UseSelectable = true;
            this.txtMarca.CustomButton.Visible = false;
            this.txtMarca.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtMarca.Lines = new string[0];
            this.txtMarca.Location = new System.Drawing.Point(21, 137);
            this.txtMarca.MaxLength = 32767;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.PasswordChar = '\0';
            this.txtMarca.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMarca.SelectedText = "";
            this.txtMarca.SelectionLength = 0;
            this.txtMarca.SelectionStart = 0;
            this.txtMarca.ShortcutsEnabled = true;
            this.txtMarca.Size = new System.Drawing.Size(172, 23);
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
            this.lblMarca.Location = new System.Drawing.Point(21, 110);
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
            this.txtCodigoDeBarras.Location = new System.Drawing.Point(25, 191);
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
            this.lblCodigoDeBarras.Location = new System.Drawing.Point(20, 163);
            this.lblCodigoDeBarras.Name = "lblCodigoDeBarras";
            this.lblCodigoDeBarras.Size = new System.Drawing.Size(143, 25);
            this.lblCodigoDeBarras.TabIndex = 78;
            this.lblCodigoDeBarras.Text = "Código de barras";
            this.lblCodigoDeBarras.UseCustomBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(137, 483);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(49, 25);
            this.metroLabel3.TabIndex = 81;
            this.metroLabel3.Text = "% IPI";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.Location = new System.Drawing.Point(69, 483);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(33, 25);
            this.metroLabel5.TabIndex = 86;
            this.metroLabel5.Text = "PV";
            this.metroLabel5.UseCustomBackColor = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.Location = new System.Drawing.Point(69, 542);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(43, 25);
            this.metroLabel6.TabIndex = 88;
            this.metroLabel6.Text = "PSD";
            this.metroLabel6.UseCustomBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(124, 542);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(73, 25);
            this.metroLabel1.TabIndex = 90;
            this.metroLabel1.Text = "% Lucro";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(268, 542);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(50, 25);
            this.metroLabel4.TabIndex = 92;
            this.metroLabel4.Text = "PSCF";
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel8.Location = new System.Drawing.Point(13, 569);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(31, 25);
            this.metroLabel8.TabIndex = 96;
            this.metroLabel8.Text = "R$";
            this.metroLabel8.UseCustomBackColor = true;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel9.Location = new System.Drawing.Point(14, 510);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(31, 25);
            this.metroLabel9.TabIndex = 97;
            this.metroLabel9.Text = "R$";
            this.metroLabel9.UseCustomBackColor = true;
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel12.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel12.Location = new System.Drawing.Point(436, 509);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(31, 25);
            this.metroLabel12.TabIndex = 100;
            this.metroLabel12.Text = "R$";
            this.metroLabel12.UseCustomBackColor = true;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel13.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel13.Location = new System.Drawing.Point(209, 569);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(31, 25);
            this.metroLabel13.TabIndex = 101;
            this.metroLabel13.Text = "R$";
            this.metroLabel13.UseCustomBackColor = true;
            // 
            // txtMPrecoDeCompra
            // 
            this.txtMPrecoDeCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtMPrecoDeCompra.BoxWidth = 128;
            this.txtMPrecoDeCompra.Location = new System.Drawing.Point(233, 507);
            this.txtMPrecoDeCompra.Name = "txtMPrecoDeCompra";
            this.txtMPrecoDeCompra.Size = new System.Drawing.Size(135, 30);
            this.txtMPrecoDeCompra.TabIndex = 102;
            this.txtMPrecoDeCompra.UseCustomBackColor = true;
            this.txtMPrecoDeCompra.UseCustomForeColor = true;
            this.txtMPrecoDeCompra.UseSelectable = true;
            this.txtMPrecoDeCompra.Value = null;
            this.txtMPrecoDeCompra.Load += new System.EventHandler(this.txtMPrecoDeCompra_Load);
            this.txtMPrecoDeCompra.Leave += new System.EventHandler(this.txtPrecoDeCompra_Leave);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.Location = new System.Drawing.Point(209, 510);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(31, 25);
            this.metroLabel7.TabIndex = 103;
            this.metroLabel7.Text = "R$";
            this.metroLabel7.UseCustomBackColor = true;
            // 
            // txtMLucro
            // 
            this.txtMLucro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtMLucro.BoxWidth = 50;
            this.txtMLucro.Location = new System.Drawing.Point(380, 507);
            this.txtMLucro.Name = "txtMLucro";
            this.txtMLucro.Size = new System.Drawing.Size(57, 30);
            this.txtMLucro.TabIndex = 104;
            this.txtMLucro.UseCustomBackColor = true;
            this.txtMLucro.UseCustomForeColor = true;
            this.txtMLucro.UseSelectable = true;
            this.txtMLucro.Value = null;
            this.txtMLucro.Leave += new System.EventHandler(this.txtMLucro_Leave);
            // 
            // txtMPrecoDeVenda
            // 
            this.txtMPrecoDeVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtMPrecoDeVenda.BoxWidth = 110;
            this.txtMPrecoDeVenda.Location = new System.Drawing.Point(460, 506);
            this.txtMPrecoDeVenda.Name = "txtMPrecoDeVenda";
            this.txtMPrecoDeVenda.Size = new System.Drawing.Size(117, 30);
            this.txtMPrecoDeVenda.TabIndex = 105;
            this.txtMPrecoDeVenda.UseCustomBackColor = true;
            this.txtMPrecoDeVenda.UseCustomForeColor = true;
            this.txtMPrecoDeVenda.UseSelectable = true;
            this.txtMPrecoDeVenda.Value = null;
            // 
            // txtMPorcentagemIpi
            // 
            this.txtMPorcentagemIpi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtMPorcentagemIpi.BoxWidth = 45;
            this.txtMPorcentagemIpi.Location = new System.Drawing.Point(137, 507);
            this.txtMPorcentagemIpi.Name = "txtMPorcentagemIpi";
            this.txtMPorcentagemIpi.Size = new System.Drawing.Size(52, 30);
            this.txtMPorcentagemIpi.TabIndex = 106;
            this.txtMPorcentagemIpi.UseCustomBackColor = true;
            this.txtMPorcentagemIpi.UseCustomForeColor = true;
            this.txtMPorcentagemIpi.UseSelectable = true;
            this.txtMPorcentagemIpi.Value = null;
            // 
            // txtMPrecoNaIntelbras
            // 
            this.txtMPrecoNaIntelbras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtMPrecoNaIntelbras.BoxWidth = 90;
            this.txtMPrecoNaIntelbras.Location = new System.Drawing.Point(38, 507);
            this.txtMPrecoNaIntelbras.Name = "txtMPrecoNaIntelbras";
            this.txtMPrecoNaIntelbras.Size = new System.Drawing.Size(97, 30);
            this.txtMPrecoNaIntelbras.TabIndex = 107;
            this.txtMPrecoNaIntelbras.UseCustomBackColor = true;
            this.txtMPrecoNaIntelbras.UseCustomForeColor = true;
            this.txtMPrecoNaIntelbras.UseSelectable = true;
            this.txtMPrecoNaIntelbras.Value = null;
            // 
            // txtMPrecoSugeridoRevenda
            // 
            this.txtMPrecoSugeridoRevenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtMPrecoSugeridoRevenda.BoxWidth = 90;
            this.txtMPrecoSugeridoRevenda.Location = new System.Drawing.Point(37, 566);
            this.txtMPrecoSugeridoRevenda.Name = "txtMPrecoSugeridoRevenda";
            this.txtMPrecoSugeridoRevenda.Size = new System.Drawing.Size(97, 30);
            this.txtMPrecoSugeridoRevenda.TabIndex = 108;
            this.txtMPrecoSugeridoRevenda.UseCustomBackColor = true;
            this.txtMPrecoSugeridoRevenda.UseCustomForeColor = true;
            this.txtMPrecoSugeridoRevenda.UseSelectable = true;
            this.txtMPrecoSugeridoRevenda.Value = null;
            // 
            // txtMPorcentagemDeLucroConsumidorFinal
            // 
            this.txtMPorcentagemDeLucroConsumidorFinal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtMPorcentagemDeLucroConsumidorFinal.BoxWidth = 45;
            this.txtMPorcentagemDeLucroConsumidorFinal.Location = new System.Drawing.Point(137, 566);
            this.txtMPorcentagemDeLucroConsumidorFinal.Name = "txtMPorcentagemDeLucroConsumidorFinal";
            this.txtMPorcentagemDeLucroConsumidorFinal.Size = new System.Drawing.Size(52, 30);
            this.txtMPorcentagemDeLucroConsumidorFinal.TabIndex = 109;
            this.txtMPorcentagemDeLucroConsumidorFinal.UseCustomBackColor = true;
            this.txtMPorcentagemDeLucroConsumidorFinal.UseCustomForeColor = true;
            this.txtMPorcentagemDeLucroConsumidorFinal.UseSelectable = true;
            this.txtMPorcentagemDeLucroConsumidorFinal.Value = null;
            // 
            // txtMPscf
            // 
            this.txtMPscf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtMPscf.BoxWidth = 128;
            this.txtMPscf.Location = new System.Drawing.Point(233, 564);
            this.txtMPscf.Name = "txtMPscf";
            this.txtMPscf.Size = new System.Drawing.Size(135, 30);
            this.txtMPscf.TabIndex = 110;
            this.txtMPscf.UseCustomBackColor = true;
            this.txtMPscf.UseCustomForeColor = true;
            this.txtMPscf.UseSelectable = true;
            this.txtMPscf.Value = null;
            // 
            // gsImageAttacher1
            // 
            this.gsImageAttacher1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gsImageAttacher1.BackgroundImage")));
            this.gsImageAttacher1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gsImageAttacher1.ForeColor = System.Drawing.Color.LightGray;
            this.gsImageAttacher1.Location = new System.Drawing.Point(380, 542);
            this.gsImageAttacher1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gsImageAttacher1.Name = "gsImageAttacher1";
            this.gsImageAttacher1.Size = new System.Drawing.Size(200, 163);
            this.gsImageAttacher1.TabIndex = 111;
            // 
            // txtTambemConhecidoComo
            // 
            this.txtTambemConhecidoComo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtTambemConhecidoComo.CustomButton.Image = null;
            this.txtTambemConhecidoComo.CustomButton.Location = new System.Drawing.Point(520, 1);
            this.txtTambemConhecidoComo.CustomButton.Name = "";
            this.txtTambemConhecidoComo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTambemConhecidoComo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTambemConhecidoComo.CustomButton.TabIndex = 1;
            this.txtTambemConhecidoComo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTambemConhecidoComo.CustomButton.UseSelectable = true;
            this.txtTambemConhecidoComo.CustomButton.Visible = false;
            this.txtTambemConhecidoComo.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtTambemConhecidoComo.Lines = new string[0];
            this.txtTambemConhecidoComo.Location = new System.Drawing.Point(25, 306);
            this.txtTambemConhecidoComo.MaxLength = 32767;
            this.txtTambemConhecidoComo.Name = "txtTambemConhecidoComo";
            this.txtTambemConhecidoComo.PasswordChar = '\0';
            this.txtTambemConhecidoComo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTambemConhecidoComo.SelectedText = "";
            this.txtTambemConhecidoComo.SelectionLength = 0;
            this.txtTambemConhecidoComo.SelectionStart = 0;
            this.txtTambemConhecidoComo.ShortcutsEnabled = true;
            this.txtTambemConhecidoComo.Size = new System.Drawing.Size(542, 23);
            this.txtTambemConhecidoComo.TabIndex = 113;
            this.txtTambemConhecidoComo.UseCustomBackColor = true;
            this.txtTambemConhecidoComo.UseSelectable = true;
            this.txtTambemConhecidoComo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTambemConhecidoComo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblTambemConhecidoComo
            // 
            this.lblTambemConhecidoComo.AutoSize = true;
            this.lblTambemConhecidoComo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblTambemConhecidoComo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTambemConhecidoComo.Location = new System.Drawing.Point(20, 277);
            this.lblTambemConhecidoComo.Name = "lblTambemConhecidoComo";
            this.lblTambemConhecidoComo.Size = new System.Drawing.Size(208, 25);
            this.lblTambemConhecidoComo.TabIndex = 112;
            this.lblTambemConhecidoComo.Text = "Também conhecido como";
            this.lblTambemConhecidoComo.UseCustomBackColor = true;
            // 
            // txtLocalizacao
            // 
            this.txtLocalizacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            // 
            // 
            // 
            this.txtLocalizacao.CustomButton.Image = null;
            this.txtLocalizacao.CustomButton.Location = new System.Drawing.Point(520, 1);
            this.txtLocalizacao.CustomButton.Name = "";
            this.txtLocalizacao.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtLocalizacao.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLocalizacao.CustomButton.TabIndex = 1;
            this.txtLocalizacao.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLocalizacao.CustomButton.UseSelectable = true;
            this.txtLocalizacao.CustomButton.Visible = false;
            this.txtLocalizacao.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtLocalizacao.Lines = new string[0];
            this.txtLocalizacao.Location = new System.Drawing.Point(25, 457);
            this.txtLocalizacao.MaxLength = 32767;
            this.txtLocalizacao.Name = "txtLocalizacao";
            this.txtLocalizacao.PasswordChar = '\0';
            this.txtLocalizacao.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLocalizacao.SelectedText = "";
            this.txtLocalizacao.SelectionLength = 0;
            this.txtLocalizacao.SelectionStart = 0;
            this.txtLocalizacao.ShortcutsEnabled = true;
            this.txtLocalizacao.Size = new System.Drawing.Size(542, 23);
            this.txtLocalizacao.TabIndex = 115;
            this.txtLocalizacao.UseCustomBackColor = true;
            this.txtLocalizacao.UseSelectable = true;
            this.txtLocalizacao.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLocalizacao.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblLocalizacao
            // 
            this.lblLocalizacao.AutoSize = true;
            this.lblLocalizacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblLocalizacao.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblLocalizacao.Location = new System.Drawing.Point(22, 429);
            this.lblLocalizacao.Name = "lblLocalizacao";
            this.lblLocalizacao.Size = new System.Drawing.Size(189, 25);
            this.lblLocalizacao.TabIndex = 114;
            this.lblLocalizacao.Text = "Localização no estoque";
            this.lblLocalizacao.UseCustomBackColor = true;
            // 
            // FrmProdutoMetro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = ((System.Drawing.Image)(resources.GetObject("$this.BackImage")));
            this.ClientSize = new System.Drawing.Size(599, 710);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtLocalizacao);
            this.Controls.Add(this.lblLocalizacao);
            this.Controls.Add(this.txtTambemConhecidoComo);
            this.Controls.Add(this.lblTambemConhecidoComo);
            this.Controls.Add(this.gsImageAttacher1);
            this.Controls.Add(this.txtMPscf);
            this.Controls.Add(this.txtMPorcentagemDeLucroConsumidorFinal);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtMPrecoSugeridoRevenda);
            this.Controls.Add(this.txtMPrecoNaIntelbras);
            this.Controls.Add(this.txtMPorcentagemIpi);
            this.Controls.Add(this.txtMPrecoDeVenda);
            this.Controls.Add(this.txtMLucro);
            this.Controls.Add(this.txtMPrecoDeCompra);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.lblPrecoCompra);
            this.Controls.Add(this.metroLabel13);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtCodigoDeBarras);
            this.Controls.Add(this.lblCodigoDeBarras);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.toggleStatus);
            this.Controls.Add(this.chkAvisarQuantidade);
            this.Controls.Add(this.txtQuantidadeEmEstoque);
            this.Controls.Add(this.lblQuantidadeEmEstoque);
            this.Controls.Add(this.txtQuantidadeMinima);
            this.Controls.Add(this.lblQuantidadeMinima);
            this.Controls.Add(this.lblPrecoVenda);
            this.Controls.Add(this.lblPorcentagemLucro);
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
            this.Controls.Add(this.lblCodigo);
            this.Name = "FrmProdutoMetro";
            this.Text = "frmProdutoMetroT";
            this.Controls.SetChildIndex(this.lblCodigo, 0);
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
            this.Controls.SetChildIndex(this.lblPorcentagemLucro, 0);
            this.Controls.SetChildIndex(this.lblPrecoVenda, 0);
            this.Controls.SetChildIndex(this.lblQuantidadeMinima, 0);
            this.Controls.SetChildIndex(this.txtQuantidadeMinima, 0);
            this.Controls.SetChildIndex(this.lblQuantidadeEmEstoque, 0);
            this.Controls.SetChildIndex(this.txtQuantidadeEmEstoque, 0);
            this.Controls.SetChildIndex(this.chkAvisarQuantidade, 0);
            this.Controls.SetChildIndex(this.toggleStatus, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.lblCodigoDeBarras, 0);
            this.Controls.SetChildIndex(this.txtCodigoDeBarras, 0);
            this.Controls.SetChildIndex(this.metroLabel3, 0);
            this.Controls.SetChildIndex(this.metroLabel5, 0);
            this.Controls.SetChildIndex(this.metroLabel1, 0);
            this.Controls.SetChildIndex(this.metroLabel4, 0);
            this.Controls.SetChildIndex(this.metroLabel8, 0);
            this.Controls.SetChildIndex(this.metroLabel9, 0);
            this.Controls.SetChildIndex(this.metroLabel12, 0);
            this.Controls.SetChildIndex(this.metroLabel13, 0);
            this.Controls.SetChildIndex(this.panelTitulo, 0);
            this.Controls.SetChildIndex(this.lblPrecoCompra, 0);
            this.Controls.SetChildIndex(this.metroLabel7, 0);
            this.Controls.SetChildIndex(this.txtMPrecoDeCompra, 0);
            this.Controls.SetChildIndex(this.txtMLucro, 0);
            this.Controls.SetChildIndex(this.txtMPrecoDeVenda, 0);
            this.Controls.SetChildIndex(this.txtMPorcentagemIpi, 0);
            this.Controls.SetChildIndex(this.txtMPrecoNaIntelbras, 0);
            this.Controls.SetChildIndex(this.txtMPrecoSugeridoRevenda, 0);
            this.Controls.SetChildIndex(this.metroLabel6, 0);
            this.Controls.SetChildIndex(this.txtMPorcentagemDeLucroConsumidorFinal, 0);
            this.Controls.SetChildIndex(this.txtMPscf, 0);
            this.Controls.SetChildIndex(this.gsImageAttacher1, 0);
            this.Controls.SetChildIndex(this.lblTambemConhecidoComo, 0);
            this.Controls.SetChildIndex(this.txtTambemConhecidoComo, 0);
            this.Controls.SetChildIndex(this.lblLocalizacao, 0);
            this.Controls.SetChildIndex(this.txtLocalizacao, 0);
            this.Controls.SetChildIndex(this.txtCodigo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
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
        public MetroFramework.Controls.MetroLabel lblPrecoVenda;
        public MetroFramework.Controls.MetroLabel lblPorcentagemLucro;
        public MetroFramework.Controls.MetroLabel lblPrecoCompra;
        public MetroFramework.Controls.MetroTextBox txtObservacoes;
        public MetroFramework.Controls.MetroLabel lblObservacoes;
        public MetroFramework.Controls.MetroTextBox txtCodigoDeBarras;
        public MetroFramework.Controls.MetroLabel lblCodigoDeBarras;
        public MetroFramework.Controls.MetroLabel metroLabel3;
        public MetroFramework.Controls.MetroLabel metroLabel5;
        public MetroFramework.Controls.MetroLabel metroLabel6;
        public MetroFramework.Controls.MetroLabel metroLabel1;
        public MetroFramework.Controls.MetroLabel metroLabel4;
        public MetroFramework.Controls.MetroLabel metroLabel8;
        public MetroFramework.Controls.MetroLabel metroLabel9;
        public MetroFramework.Controls.MetroLabel metroLabel12;
        public MetroFramework.Controls.MetroLabel metroLabel13;
        public ControlesGenericos.GSMetroMonetary txtMPrecoDeCompra;
        public MetroFramework.Controls.MetroLabel metroLabel7;
        public ControlesGenericos.GSMetroMonetary txtMLucro;
        public ControlesGenericos.GSMetroMonetary txtMPrecoDeVenda;
        public ControlesGenericos.GSMetroMonetary txtMPorcentagemIpi;
        public ControlesGenericos.GSMetroMonetary txtMPrecoNaIntelbras;
        public ControlesGenericos.GSMetroMonetary txtMPrecoSugeridoRevenda;
        public ControlesGenericos.GSMetroMonetary txtMPorcentagemDeLucroConsumidorFinal;
        public ControlesGenericos.GSMetroMonetary txtMPscf;
        public ControlesGenericos.GSImageAttacher gsImageAttacher1;
        public MetroFramework.Controls.MetroTextBox txtTambemConhecidoComo;
        public MetroFramework.Controls.MetroLabel lblTambemConhecidoComo;
        public MetroFramework.Controls.MetroTextBox txtLocalizacao;
        public MetroFramework.Controls.MetroLabel lblLocalizacao;
    }
}