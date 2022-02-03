using MetroFramework.Controls;

namespace GS.GestaoEmpresa.UI.Modules.MainWindow
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.gbConfiguracoesBasicas = new System.Windows.Forms.GroupBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.txtConfigDatabaseName = new MetroFramework.Controls.MetroTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSalvarConfiguracaoBasica = new MetroFramework.Controls.MetroButton();
            this.txtConfigServer = new MetroFramework.Controls.MetroTextBox();
            this.panelConexao = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblIpApp = new System.Windows.Forms.Label();
            this.lblIpBanco = new System.Windows.Forms.Label();
            this.lblConfiguracoesBasicas = new System.Windows.Forms.Label();
            this.txtSenha = new MetroFramework.Controls.MetroTextBox();
            this.txtUsuario = new MetroFramework.Controls.MetroTextBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnEntrar = new MetroFramework.Controls.MetroButton();
            this.tabChamador = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPermissaoGrupo = new System.Windows.Forms.TextBox();
            this.txtPermissaoFuncao = new System.Windows.Forms.TextBox();
            this.txtPermissaoUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAtendimento = new MetroFramework.Controls.MetroButton();
            this.btnTecnico = new MetroFramework.Controls.MetroButton();
            this.btnAuditoria = new MetroFramework.Controls.MetroButton();
            this.btnCorporativo = new MetroFramework.Controls.MetroButton();
            this.btnConfiguracoes = new MetroFramework.Controls.MetroButton();
            this.btnEstoque = new MetroFramework.Controls.MetroButton();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.gsTopBorder1 = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSTopBorder();
            this.tabControl1.SuspendLayout();
            this.tabLogin.SuspendLayout();
            this.gbConfiguracoesBasicas.SuspendLayout();
            this.panelConexao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabChamador.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.CausesValidation = false;
            this.tabControl1.Controls.Add(this.tabLogin);
            this.tabControl1.Controls.Add(this.tabChamador);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(-4, 21);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1064, 610);
            this.tabControl1.TabIndex = 47;
            this.tabControl1.Visible = false;
            // 
            // tabLogin
            // 
            this.tabLogin.BackColor = System.Drawing.Color.Gainsboro;
            this.tabLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabLogin.Controls.Add(this.gbConfiguracoesBasicas);
            this.tabLogin.Controls.Add(this.panelConexao);
            this.tabLogin.Controls.Add(this.lblConfiguracoesBasicas);
            this.tabLogin.Controls.Add(this.txtSenha);
            this.tabLogin.Controls.Add(this.txtUsuario);
            this.tabLogin.Controls.Add(this.pictureBoxLogo);
            this.tabLogin.Controls.Add(this.pictureBox3);
            this.tabLogin.Controls.Add(this.pictureBox2);
            this.tabLogin.Controls.Add(this.label2);
            this.tabLogin.Controls.Add(this.label1);
            this.tabLogin.Controls.Add(this.lblTitle);
            this.tabLogin.Controls.Add(this.btnEntrar);
            this.tabLogin.Location = new System.Drawing.Point(4, 27);
            this.tabLogin.Margin = new System.Windows.Forms.Padding(4);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Padding = new System.Windows.Forms.Padding(4);
            this.tabLogin.Size = new System.Drawing.Size(1056, 579);
            this.tabLogin.TabIndex = 0;
            this.tabLogin.Text = "Login";
            this.tabLogin.Click += new System.EventHandler(this.tabLogin_Click);
            // 
            // gbConfiguracoesBasicas
            // 
            this.gbConfiguracoesBasicas.BackColor = System.Drawing.Color.Transparent;
            this.gbConfiguracoesBasicas.Controls.Add(this.lblServer);
            this.gbConfiguracoesBasicas.Controls.Add(this.lblDatabaseName);
            this.gbConfiguracoesBasicas.Controls.Add(this.txtConfigDatabaseName);
            this.gbConfiguracoesBasicas.Controls.Add(this.label13);
            this.gbConfiguracoesBasicas.Controls.Add(this.btnSalvarConfiguracaoBasica);
            this.gbConfiguracoesBasicas.Controls.Add(this.txtConfigServer);
            this.gbConfiguracoesBasicas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConfiguracoesBasicas.Location = new System.Drawing.Point(743, 176);
            this.gbConfiguracoesBasicas.Margin = new System.Windows.Forms.Padding(4);
            this.gbConfiguracoesBasicas.Name = "gbConfiguracoesBasicas";
            this.gbConfiguracoesBasicas.Padding = new System.Windows.Forms.Padding(4);
            this.gbConfiguracoesBasicas.Size = new System.Drawing.Size(300, 204);
            this.gbConfiguracoesBasicas.TabIndex = 47;
            this.gbConfiguracoesBasicas.TabStop = false;
            this.gbConfiguracoesBasicas.Text = "Configurações básicas";
            this.gbConfiguracoesBasicas.Visible = false;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.Location = new System.Drawing.Point(8, 27);
            this.lblServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(57, 23);
            this.lblServer.TabIndex = 49;
            this.lblServer.Text = "Server";
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseName.Location = new System.Drawing.Point(8, 86);
            this.lblDatabaseName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(134, 23);
            this.lblDatabaseName.TabIndex = 48;
            this.lblDatabaseName.Text = "Nome do Banco";
            // 
            // txtConfigDatabaseName
            // 
            // 
            // 
            // 
            this.txtConfigDatabaseName.CustomButton.Image = null;
            this.txtConfigDatabaseName.CustomButton.Location = new System.Drawing.Point(250, 2);
            this.txtConfigDatabaseName.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfigDatabaseName.CustomButton.Name = "";
            this.txtConfigDatabaseName.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtConfigDatabaseName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtConfigDatabaseName.CustomButton.TabIndex = 1;
            this.txtConfigDatabaseName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtConfigDatabaseName.CustomButton.UseSelectable = true;
            this.txtConfigDatabaseName.CustomButton.Visible = false;
            this.txtConfigDatabaseName.Lines = new string[0];
            this.txtConfigDatabaseName.Location = new System.Drawing.Point(8, 111);
            this.txtConfigDatabaseName.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfigDatabaseName.MaxLength = 32767;
            this.txtConfigDatabaseName.Name = "txtConfigDatabaseName";
            this.txtConfigDatabaseName.PasswordChar = '\0';
            this.txtConfigDatabaseName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtConfigDatabaseName.SelectedText = "";
            this.txtConfigDatabaseName.SelectionLength = 0;
            this.txtConfigDatabaseName.SelectionStart = 0;
            this.txtConfigDatabaseName.ShortcutsEnabled = true;
            this.txtConfigDatabaseName.Size = new System.Drawing.Size(280, 32);
            this.txtConfigDatabaseName.TabIndex = 47;
            this.txtConfigDatabaseName.UseSelectable = true;
            this.txtConfigDatabaseName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtConfigDatabaseName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(275, 12);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 28);
            this.label13.TabIndex = 46;
            this.label13.Text = "x";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // btnSalvarConfiguracaoBasica
            // 
            this.btnSalvarConfiguracaoBasica.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnSalvarConfiguracaoBasica.Location = new System.Drawing.Point(76, 151);
            this.btnSalvarConfiguracaoBasica.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvarConfiguracaoBasica.Name = "btnSalvarConfiguracaoBasica";
            this.btnSalvarConfiguracaoBasica.Size = new System.Drawing.Size(143, 42);
            this.btnSalvarConfiguracaoBasica.TabIndex = 42;
            this.btnSalvarConfiguracaoBasica.Text = "Salvar";
            this.btnSalvarConfiguracaoBasica.UseSelectable = true;
            this.btnSalvarConfiguracaoBasica.Click += new System.EventHandler(this.btnSalvarConfiguracaoBasica_Click);
            // 
            // txtConfigServer
            // 
            // 
            // 
            // 
            this.txtConfigServer.CustomButton.Image = null;
            this.txtConfigServer.CustomButton.Location = new System.Drawing.Point(250, 2);
            this.txtConfigServer.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfigServer.CustomButton.Name = "";
            this.txtConfigServer.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtConfigServer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtConfigServer.CustomButton.TabIndex = 1;
            this.txtConfigServer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtConfigServer.CustomButton.UseSelectable = true;
            this.txtConfigServer.CustomButton.Visible = false;
            this.txtConfigServer.Lines = new string[0];
            this.txtConfigServer.Location = new System.Drawing.Point(8, 53);
            this.txtConfigServer.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfigServer.MaxLength = 32767;
            this.txtConfigServer.Name = "txtConfigServer";
            this.txtConfigServer.PasswordChar = '\0';
            this.txtConfigServer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtConfigServer.SelectedText = "";
            this.txtConfigServer.SelectionLength = 0;
            this.txtConfigServer.SelectionStart = 0;
            this.txtConfigServer.ShortcutsEnabled = true;
            this.txtConfigServer.Size = new System.Drawing.Size(280, 32);
            this.txtConfigServer.TabIndex = 0;
            this.txtConfigServer.UseSelectable = true;
            this.txtConfigServer.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtConfigServer.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panelConexao
            // 
            this.panelConexao.BackColor = System.Drawing.Color.Transparent;
            this.panelConexao.Controls.Add(this.pictureBox5);
            this.panelConexao.Controls.Add(this.lblIpApp);
            this.panelConexao.Controls.Add(this.lblIpBanco);
            this.panelConexao.Location = new System.Drawing.Point(696, 28);
            this.panelConexao.Margin = new System.Windows.Forms.Padding(4);
            this.panelConexao.Name = "panelConexao";
            this.panelConexao.Size = new System.Drawing.Size(347, 123);
            this.panelConexao.TabIndex = 56;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.SemConexao;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Location = new System.Drawing.Point(17, 11);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(280, 62);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 53;
            this.pictureBox5.TabStop = false;
            // 
            // lblIpApp
            // 
            this.lblIpApp.AutoSize = true;
            this.lblIpApp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpApp.Location = new System.Drawing.Point(16, 75);
            this.lblIpApp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIpApp.Name = "lblIpApp";
            this.lblIpApp.Size = new System.Drawing.Size(0, 23);
            this.lblIpApp.TabIndex = 54;
            // 
            // lblIpBanco
            // 
            this.lblIpBanco.AutoSize = true;
            this.lblIpBanco.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpBanco.Location = new System.Drawing.Point(179, 75);
            this.lblIpBanco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIpBanco.Name = "lblIpBanco";
            this.lblIpBanco.Size = new System.Drawing.Size(0, 23);
            this.lblIpBanco.TabIndex = 55;
            // 
            // lblConfiguracoesBasicas
            // 
            this.lblConfiguracoesBasicas.AutoSize = true;
            this.lblConfiguracoesBasicas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfiguracoesBasicas.Location = new System.Drawing.Point(877, 4);
            this.lblConfiguracoesBasicas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfiguracoesBasicas.Name = "lblConfiguracoesBasicas";
            this.lblConfiguracoesBasicas.Size = new System.Drawing.Size(119, 23);
            this.lblConfiguracoesBasicas.TabIndex = 48;
            this.lblConfiguracoesBasicas.Text = "Configurações";
            this.lblConfiguracoesBasicas.Visible = false;
            this.lblConfiguracoesBasicas.Click += new System.EventHandler(this.lblConfiguracoesBasicas_Click_1);
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.SteelBlue;
            // 
            // 
            // 
            this.txtSenha.CustomButton.Image = null;
            this.txtSenha.CustomButton.Location = new System.Drawing.Point(175, 2);
            this.txtSenha.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtSenha.CustomButton.Name = "";
            this.txtSenha.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtSenha.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSenha.CustomButton.TabIndex = 1;
            this.txtSenha.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSenha.CustomButton.UseSelectable = true;
            this.txtSenha.CustomButton.Visible = false;
            this.txtSenha.Lines = new string[0];
            this.txtSenha.Location = new System.Drawing.Point(433, 389);
            this.txtSenha.Margin = new System.Windows.Forms.Padding(4);
            this.txtSenha.MaxLength = 32767;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSenha.SelectedText = "";
            this.txtSenha.SelectionLength = 0;
            this.txtSenha.SelectionStart = 0;
            this.txtSenha.ShortcutsEnabled = true;
            this.txtSenha.Size = new System.Drawing.Size(203, 30);
            this.txtSenha.TabIndex = 44;
            this.txtSenha.UseCustomBackColor = true;
            this.txtSenha.UseSelectable = true;
            this.txtSenha.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSenha.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha_KeyPress);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.SteelBlue;
            // 
            // 
            // 
            this.txtUsuario.CustomButton.Image = null;
            this.txtUsuario.CustomButton.Location = new System.Drawing.Point(175, 2);
            this.txtUsuario.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.CustomButton.Name = "";
            this.txtUsuario.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtUsuario.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUsuario.CustomButton.TabIndex = 1;
            this.txtUsuario.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUsuario.CustomButton.UseSelectable = true;
            this.txtUsuario.CustomButton.Visible = false;
            this.txtUsuario.Lines = new string[0];
            this.txtUsuario.Location = new System.Drawing.Point(432, 337);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuario.MaxLength = 32767;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PasswordChar = '\0';
            this.txtUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsuario.SelectedText = "";
            this.txtUsuario.SelectionLength = 0;
            this.txtUsuario.SelectionStart = 0;
            this.txtUsuario.ShortcutsEnabled = true;
            this.txtUsuario.Size = new System.Drawing.Size(203, 30);
            this.txtUsuario.TabIndex = 43;
            this.txtUsuario.UseCustomBackColor = true;
            this.txtUsuario.UseSelectable = true;
            this.txtUsuario.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUsuario.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(401, 39);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(263, 192);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLogo.TabIndex = 42;
            this.pictureBoxLogo.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(384, 375);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 44);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 40;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(381, 330);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(377, 400);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 25);
            this.label2.TabIndex = 38;
            this.label2.Text = "________________________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(377, 348);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 25);
            this.label1.TabIndex = 37;
            this.label1.Text = "________________________";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(384, 240);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(272, 50);
            this.lblTitle.TabIndex = 36;
            this.lblTitle.Text = "Gestão Empresa";
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrar.Enabled = false;
            this.btnEntrar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnEntrar.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnEntrar.Location = new System.Drawing.Point(436, 433);
            this.btnEntrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(159, 43);
            this.btnEntrar.TabIndex = 45;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseSelectable = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click_1);
            // 
            // tabChamador
            // 
            this.tabChamador.BackColor = System.Drawing.Color.Gainsboro;
            this.tabChamador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabChamador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabChamador.Controls.Add(this.label5);
            this.tabChamador.Controls.Add(this.groupBox1);
            this.tabChamador.Controls.Add(this.label9);
            this.tabChamador.Controls.Add(this.groupBox2);
            this.tabChamador.Controls.Add(this.pictureBox4);
            this.tabChamador.Location = new System.Drawing.Point(4, 27);
            this.tabChamador.Margin = new System.Windows.Forms.Padding(4);
            this.tabChamador.Name = "tabChamador";
            this.tabChamador.Padding = new System.Windows.Forms.Padding(4);
            this.tabChamador.Size = new System.Drawing.Size(1056, 579);
            this.tabChamador.TabIndex = 1;
            this.tabChamador.Text = "Chamador";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(611, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 31);
            this.label5.TabIndex = 25;
            this.label5.Text = "v 1.?";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtPermissaoGrupo);
            this.groupBox1.Controls.Add(this.txtPermissaoFuncao);
            this.groupBox1.Controls.Add(this.txtPermissaoUsuario);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(55, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(295, 116);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permissões";
            // 
            // txtPermissaoGrupo
            // 
            this.txtPermissaoGrupo.BackColor = System.Drawing.Color.SteelBlue;
            this.txtPermissaoGrupo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPermissaoGrupo.Location = new System.Drawing.Point(97, 91);
            this.txtPermissaoGrupo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPermissaoGrupo.Name = "txtPermissaoGrupo";
            this.txtPermissaoGrupo.Size = new System.Drawing.Size(133, 23);
            this.txtPermissaoGrupo.TabIndex = 24;
            // 
            // txtPermissaoFuncao
            // 
            this.txtPermissaoFuncao.BackColor = System.Drawing.Color.SteelBlue;
            this.txtPermissaoFuncao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPermissaoFuncao.Location = new System.Drawing.Point(97, 59);
            this.txtPermissaoFuncao.Margin = new System.Windows.Forms.Padding(4);
            this.txtPermissaoFuncao.Name = "txtPermissaoFuncao";
            this.txtPermissaoFuncao.Size = new System.Drawing.Size(133, 23);
            this.txtPermissaoFuncao.TabIndex = 23;
            // 
            // txtPermissaoUsuario
            // 
            this.txtPermissaoUsuario.BackColor = System.Drawing.Color.SteelBlue;
            this.txtPermissaoUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPermissaoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPermissaoUsuario.Location = new System.Drawing.Point(97, 26);
            this.txtPermissaoUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.txtPermissaoUsuario.Name = "txtPermissaoUsuario";
            this.txtPermissaoUsuario.Size = new System.Drawing.Size(133, 23);
            this.txtPermissaoUsuario.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 87);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 25);
            this.label6.TabIndex = 21;
            this.label6.Text = "Grupo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 55);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Função:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 25);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "Usuário:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(357, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(333, 46);
            this.label9.TabIndex = 22;
            this.label9.Text = "Gestão Empresa";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnAtendimento);
            this.groupBox2.Controls.Add(this.btnTecnico);
            this.groupBox2.Controls.Add(this.btnAuditoria);
            this.groupBox2.Controls.Add(this.btnCorporativo);
            this.groupBox2.Controls.Add(this.btnConfiguracoes);
            this.groupBox2.Controls.Add(this.btnEstoque);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(55, 122);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(956, 411);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Módulos";
            // 
            // btnAtendimento
            // 
            this.btnAtendimento.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAtendimento.BackgroundImage")));
            this.btnAtendimento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAtendimento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtendimento.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnAtendimento.Location = new System.Drawing.Point(481, 26);
            this.btnAtendimento.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtendimento.Name = "btnAtendimento";
            this.btnAtendimento.Size = new System.Drawing.Size(227, 185);
            this.btnAtendimento.TabIndex = 7;
            this.btnAtendimento.Text = "Atendimento";
            this.btnAtendimento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAtendimento.UseSelectable = true;
            this.btnAtendimento.Click += new System.EventHandler(this.btnAtendimento_Click);
            // 
            // btnTecnico
            // 
            this.btnTecnico.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.TenicoBlueCerto2;
            this.btnTecnico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTecnico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTecnico.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnTecnico.Location = new System.Drawing.Point(716, 26);
            this.btnTecnico.Margin = new System.Windows.Forms.Padding(4);
            this.btnTecnico.Name = "btnTecnico";
            this.btnTecnico.Size = new System.Drawing.Size(227, 185);
            this.btnTecnico.TabIndex = 13;
            this.btnTecnico.Text = "Técnico";
            this.btnTecnico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTecnico.UseSelectable = true;
            this.btnTecnico.Click += new System.EventHandler(this.btnTecnico_Click);
            // 
            // btnAuditoria
            // 
            this.btnAuditoria.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAuditoria.BackgroundImage")));
            this.btnAuditoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAuditoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAuditoria.Enabled = false;
            this.btnAuditoria.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnAuditoria.Location = new System.Drawing.Point(247, 218);
            this.btnAuditoria.Margin = new System.Windows.Forms.Padding(4);
            this.btnAuditoria.Name = "btnAuditoria";
            this.btnAuditoria.Size = new System.Drawing.Size(227, 185);
            this.btnAuditoria.TabIndex = 15;
            this.btnAuditoria.Text = "Auditoria";
            this.btnAuditoria.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAuditoria.UseSelectable = true;
            // 
            // btnCorporativo
            // 
            this.btnCorporativo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCorporativo.BackgroundImage")));
            this.btnCorporativo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCorporativo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCorporativo.Enabled = false;
            this.btnCorporativo.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnCorporativo.Location = new System.Drawing.Point(12, 218);
            this.btnCorporativo.Margin = new System.Windows.Forms.Padding(4);
            this.btnCorporativo.Name = "btnCorporativo";
            this.btnCorporativo.Size = new System.Drawing.Size(227, 185);
            this.btnCorporativo.TabIndex = 14;
            this.btnCorporativo.Text = "Corporativo";
            this.btnCorporativo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCorporativo.UseSelectable = true;
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.BackColor = System.Drawing.Color.Transparent;
            this.btnConfiguracoes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfiguracoes.BackgroundImage")));
            this.btnConfiguracoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConfiguracoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfiguracoes.Enabled = false;
            this.btnConfiguracoes.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnConfiguracoes.Location = new System.Drawing.Point(12, 26);
            this.btnConfiguracoes.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Size = new System.Drawing.Size(227, 185);
            this.btnConfiguracoes.TabIndex = 12;
            this.btnConfiguracoes.Text = "Configurações";
            this.btnConfiguracoes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfiguracoes.UseSelectable = true;
            this.btnConfiguracoes.Click += new System.EventHandler(this.btnConfiguracoes_Click_1);
            // 
            // btnEstoque
            // 
            this.btnEstoque.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEstoque.BackgroundImage")));
            this.btnEstoque.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEstoque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstoque.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnEstoque.Location = new System.Drawing.Point(247, 26);
            this.btnEstoque.Margin = new System.Windows.Forms.Padding(4);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(227, 185);
            this.btnEstoque.TabIndex = 8;
            this.btnEstoque.Text = "Estoque";
            this.btnEstoque.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEstoque.UseMnemonic = false;
            this.btnEstoque.UseSelectable = true;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click_1);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(728, -28);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(284, 181);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 23;
            this.pictureBox4.TabStop = false;
            // 
            // gsTopBorder1
            // 
            this.gsTopBorder1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gsTopBorder1.DisplayMaximize = false;
            this.gsTopBorder1.Location = new System.Drawing.Point(0, 0);
            this.gsTopBorder1.Margin = new System.Windows.Forms.Padding(5);
            this.gsTopBorder1.Name = "gsTopBorder1";
            this.gsTopBorder1.Size = new System.Drawing.Size(1051, 32);
            this.gsTopBorder1.TabIndex = 48;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 588);
            this.Controls.Add(this.gsTopBorder1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Load += new System.EventHandler(this.GestaoEmpresa_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.tabLogin.PerformLayout();
            this.gbConfiguracoesBasicas.ResumeLayout(false);
            this.gbConfiguracoesBasicas.PerformLayout();
            this.panelConexao.ResumeLayout(false);
            this.panelConexao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabChamador.ResumeLayout(false);
            this.tabChamador.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.GroupBox gbConfiguracoesBasicas;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblDatabaseName;
        private MetroTextBox txtConfigDatabaseName;
        private System.Windows.Forms.Label label13;
        private MetroButton btnSalvarConfiguracaoBasica;
        private MetroTextBox txtConfigServer;
        private System.Windows.Forms.Label lblConfiguracoesBasicas;
        private MetroTextBox txtSenha;
        private MetroTextBox txtUsuario;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private MetroButton btnEntrar;
        private System.Windows.Forms.TabPage tabChamador;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPermissaoGrupo;
        private System.Windows.Forms.TextBox txtPermissaoFuncao;
        private System.Windows.Forms.TextBox txtPermissaoUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroButton btnAuditoria;
        private MetroButton btnCorporativo;
        private MetroButton btnTecnico;
        private MetroButton btnConfiguracoes;
        private MetroButton btnEstoque;
        private MetroButton btnAtendimento;
        private System.Windows.Forms.Label lblIpBanco;
        private System.Windows.Forms.Label lblIpApp;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panelConexao;
        private Solucao.UI.ControlesGenericos.GSTopBorder gsTopBorder1;
    }
}