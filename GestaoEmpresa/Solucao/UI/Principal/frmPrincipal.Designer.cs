namespace GestaoEmpresa.GS.GestaoEmpresa.GS.GestaoEmpresa.UI.Principal
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.gbConfiguracoesBasicas = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNomeBancoConfiguracoes = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSenhaConfiguracao = new System.Windows.Forms.TextBox();
            this.txtUsuarioConfiguracao = new System.Windows.Forms.TextBox();
            this.btnSalvarConfiguracaoBasica = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtServidorConfiguracao = new System.Windows.Forms.TextBox();
            this.lblConfiguracoesBasicas = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEntrar = new System.Windows.Forms.Button();
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
            this.btnAtendimento = new System.Windows.Forms.Button();
            this.btnTecnico = new System.Windows.Forms.Button();
            this.btnAuditoria = new System.Windows.Forms.Button();
            this.btnCorporativo = new System.Windows.Forms.Button();
            this.btnConfiguracoes = new System.Windows.Forms.Button();
            this.btnEstoque = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabLogin.SuspendLayout();
            this.gbConfiguracoesBasicas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.tabControl1.Location = new System.Drawing.Point(-3, -13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(798, 496);
            this.tabControl1.TabIndex = 47;
            this.tabControl1.Visible = false;
            // 
            // tabLogin
            // 
            this.tabLogin.BackColor = System.Drawing.Color.Gainsboro;
            this.tabLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabLogin.BackgroundImage")));
            this.tabLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabLogin.Controls.Add(this.gbConfiguracoesBasicas);
            this.tabLogin.Controls.Add(this.lblConfiguracoesBasicas);
            this.tabLogin.Controls.Add(this.txtSenha);
            this.tabLogin.Controls.Add(this.txtUsuario);
            this.tabLogin.Controls.Add(this.pictureBox1);
            this.tabLogin.Controls.Add(this.label4);
            this.tabLogin.Controls.Add(this.pictureBox3);
            this.tabLogin.Controls.Add(this.pictureBox2);
            this.tabLogin.Controls.Add(this.label2);
            this.tabLogin.Controls.Add(this.label1);
            this.tabLogin.Controls.Add(this.label3);
            this.tabLogin.Controls.Add(this.btnEntrar);
            this.tabLogin.Location = new System.Drawing.Point(4, 23);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogin.Size = new System.Drawing.Size(790, 469);
            this.tabLogin.TabIndex = 0;
            this.tabLogin.Text = "Login";
            this.tabLogin.Click += new System.EventHandler(this.tabLogin_Click);
            // 
            // gbConfiguracoesBasicas
            // 
            this.gbConfiguracoesBasicas.Controls.Add(this.label10);
            this.gbConfiguracoesBasicas.Controls.Add(this.label14);
            this.gbConfiguracoesBasicas.Controls.Add(this.txtNomeBancoConfiguracoes);
            this.gbConfiguracoesBasicas.Controls.Add(this.label13);
            this.gbConfiguracoesBasicas.Controls.Add(this.txtSenhaConfiguracao);
            this.gbConfiguracoesBasicas.Controls.Add(this.txtUsuarioConfiguracao);
            this.gbConfiguracoesBasicas.Controls.Add(this.btnSalvarConfiguracaoBasica);
            this.gbConfiguracoesBasicas.Controls.Add(this.label12);
            this.gbConfiguracoesBasicas.Controls.Add(this.label11);
            this.gbConfiguracoesBasicas.Controls.Add(this.txtServidorConfiguracao);
            this.gbConfiguracoesBasicas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConfiguracoesBasicas.Location = new System.Drawing.Point(557, 30);
            this.gbConfiguracoesBasicas.Name = "gbConfiguracoesBasicas";
            this.gbConfiguracoesBasicas.Size = new System.Drawing.Size(225, 273);
            this.gbConfiguracoesBasicas.TabIndex = 47;
            this.gbConfiguracoesBasicas.TabStop = false;
            this.gbConfiguracoesBasicas.Text = "Configurações básicas";
            this.gbConfiguracoesBasicas.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 17);
            this.label10.TabIndex = 49;
            this.label10.Text = "Servidor";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 17);
            this.label14.TabIndex = 48;
            this.label14.Text = "Nome do Banco";
            // 
            // txtNomeBancoConfiguracoes
            // 
            this.txtNomeBancoConfiguracoes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeBancoConfiguracoes.Location = new System.Drawing.Point(6, 89);
            this.txtNomeBancoConfiguracoes.Name = "txtNomeBancoConfiguracoes";
            this.txtNomeBancoConfiguracoes.Size = new System.Drawing.Size(210, 27);
            this.txtNomeBancoConfiguracoes.TabIndex = 47;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(206, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 19);
            this.label13.TabIndex = 46;
            this.label13.Text = "x";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // txtSenhaConfiguracao
            // 
            this.txtSenhaConfiguracao.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenhaConfiguracao.Location = new System.Drawing.Point(6, 188);
            this.txtSenhaConfiguracao.Name = "txtSenhaConfiguracao";
            this.txtSenhaConfiguracao.PasswordChar = '*';
            this.txtSenhaConfiguracao.Size = new System.Drawing.Size(210, 27);
            this.txtSenhaConfiguracao.TabIndex = 45;
            // 
            // txtUsuarioConfiguracao
            // 
            this.txtUsuarioConfiguracao.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioConfiguracao.Location = new System.Drawing.Point(6, 138);
            this.txtUsuarioConfiguracao.Name = "txtUsuarioConfiguracao";
            this.txtUsuarioConfiguracao.Size = new System.Drawing.Size(210, 27);
            this.txtUsuarioConfiguracao.TabIndex = 44;
            // 
            // btnSalvarConfiguracaoBasica
            // 
            this.btnSalvarConfiguracaoBasica.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarConfiguracaoBasica.Location = new System.Drawing.Point(56, 225);
            this.btnSalvarConfiguracaoBasica.Name = "btnSalvarConfiguracaoBasica";
            this.btnSalvarConfiguracaoBasica.Size = new System.Drawing.Size(107, 34);
            this.btnSalvarConfiguracaoBasica.TabIndex = 42;
            this.btnSalvarConfiguracaoBasica.Text = "Salvar";
            this.btnSalvarConfiguracaoBasica.UseVisualStyleBackColor = true;
            this.btnSalvarConfiguracaoBasica.Click += new System.EventHandler(this.btnSalvarConfiguracaoBasica_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 17);
            this.label12.TabIndex = 41;
            this.label12.Text = "Senha";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 17);
            this.label11.TabIndex = 39;
            this.label11.Text = "Usuário";
            // 
            // txtServidorConfiguracao
            // 
            this.txtServidorConfiguracao.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServidorConfiguracao.Location = new System.Drawing.Point(6, 43);
            this.txtServidorConfiguracao.Name = "txtServidorConfiguracao";
            this.txtServidorConfiguracao.Size = new System.Drawing.Size(210, 27);
            this.txtServidorConfiguracao.TabIndex = 0;
            // 
            // lblConfiguracoesBasicas
            // 
            this.lblConfiguracoesBasicas.AutoSize = true;
            this.lblConfiguracoesBasicas.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfiguracoesBasicas.Location = new System.Drawing.Point(657, 3);
            this.lblConfiguracoesBasicas.Name = "lblConfiguracoesBasicas";
            this.lblConfiguracoesBasicas.Size = new System.Drawing.Size(86, 16);
            this.lblConfiguracoesBasicas.TabIndex = 48;
            this.lblConfiguracoesBasicas.Text = "Configurações";
            this.lblConfiguracoesBasicas.Visible = false;
            this.lblConfiguracoesBasicas.Click += new System.EventHandler(this.lblConfiguracoesBasicas_Click_1);
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.SteelBlue;
            this.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSenha.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(325, 316);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(152, 26);
            this.txtSenha.TabIndex = 44;
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha_KeyPress);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.SteelBlue;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(324, 274);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(152, 26);
            this.txtUsuario.TabIndex = 43;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(301, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 42;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(310, 394);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "Esqueceu sua senha?";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(288, 305);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(26, 36);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 40;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(286, 268);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(283, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "________________________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(283, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "________________________";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(277, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 36);
            this.label3.TabIndex = 36;
            this.label3.Text = "Gestão Empresa";
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEntrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEntrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnEntrar.Location = new System.Drawing.Point(327, 352);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(119, 35);
            this.btnEntrar.TabIndex = 45;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click_1);
            // 
            // tabChamador
            // 
            this.tabChamador.BackColor = System.Drawing.Color.Gainsboro;
            this.tabChamador.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabChamador.BackgroundImage")));
            this.tabChamador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabChamador.Controls.Add(this.label5);
            this.tabChamador.Controls.Add(this.groupBox1);
            this.tabChamador.Controls.Add(this.label9);
            this.tabChamador.Controls.Add(this.groupBox2);
            this.tabChamador.Controls.Add(this.pictureBox4);
            this.tabChamador.Location = new System.Drawing.Point(4, 23);
            this.tabChamador.Name = "tabChamador";
            this.tabChamador.Padding = new System.Windows.Forms.Padding(3);
            this.tabChamador.Size = new System.Drawing.Size(790, 469);
            this.tabChamador.TabIndex = 1;
            this.tabChamador.Text = "Chamador";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(458, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 24);
            this.label5.TabIndex = 25;
            this.label5.Text = "v 1.0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPermissaoGrupo);
            this.groupBox1.Controls.Add(this.txtPermissaoFuncao);
            this.groupBox1.Controls.Add(this.txtPermissaoUsuario);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(41, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 94);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Permissões";
            // 
            // txtPermissaoGrupo
            // 
            this.txtPermissaoGrupo.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPermissaoGrupo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPermissaoGrupo.Location = new System.Drawing.Point(73, 74);
            this.txtPermissaoGrupo.Name = "txtPermissaoGrupo";
            this.txtPermissaoGrupo.Size = new System.Drawing.Size(100, 20);
            this.txtPermissaoGrupo.TabIndex = 24;
            // 
            // txtPermissaoFuncao
            // 
            this.txtPermissaoFuncao.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPermissaoFuncao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPermissaoFuncao.Location = new System.Drawing.Point(73, 48);
            this.txtPermissaoFuncao.Name = "txtPermissaoFuncao";
            this.txtPermissaoFuncao.Size = new System.Drawing.Size(100, 20);
            this.txtPermissaoFuncao.TabIndex = 23;
            // 
            // txtPermissaoUsuario
            // 
            this.txtPermissaoUsuario.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPermissaoUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPermissaoUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPermissaoUsuario.Location = new System.Drawing.Point(73, 21);
            this.txtPermissaoUsuario.Name = "txtPermissaoUsuario";
            this.txtPermissaoUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtPermissaoUsuario.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 21);
            this.label6.TabIndex = 21;
            this.label6.Text = "Grupo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 21);
            this.label7.TabIndex = 20;
            this.label7.Text = "Função:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 21);
            this.label8.TabIndex = 19;
            this.label8.Text = "Usuário:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(268, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(271, 38);
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
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(41, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(717, 334);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Módulos";
            // 
            // btnAtendimento
            // 
            this.btnAtendimento.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAtendimento.BackgroundImage")));
            this.btnAtendimento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAtendimento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtendimento.Enabled = false;
            this.btnAtendimento.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtendimento.Location = new System.Drawing.Point(361, 21);
            this.btnAtendimento.Name = "btnAtendimento";
            this.btnAtendimento.Size = new System.Drawing.Size(170, 150);
            this.btnAtendimento.TabIndex = 7;
            this.btnAtendimento.Text = "Atendimento";
            this.btnAtendimento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAtendimento.UseVisualStyleBackColor = true;
            // 
            // btnTecnico
            // 
            this.btnTecnico.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTecnico.BackgroundImage")));
            this.btnTecnico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTecnico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTecnico.Enabled = false;
            this.btnTecnico.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTecnico.Location = new System.Drawing.Point(537, 21);
            this.btnTecnico.Name = "btnTecnico";
            this.btnTecnico.Size = new System.Drawing.Size(170, 150);
            this.btnTecnico.TabIndex = 13;
            this.btnTecnico.Text = "Técnico";
            this.btnTecnico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTecnico.UseVisualStyleBackColor = true;
            // 
            // btnAuditoria
            // 
            this.btnAuditoria.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAuditoria.BackgroundImage")));
            this.btnAuditoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAuditoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAuditoria.Enabled = false;
            this.btnAuditoria.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuditoria.Location = new System.Drawing.Point(185, 177);
            this.btnAuditoria.Name = "btnAuditoria";
            this.btnAuditoria.Size = new System.Drawing.Size(170, 150);
            this.btnAuditoria.TabIndex = 15;
            this.btnAuditoria.Text = "Auditoria";
            this.btnAuditoria.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAuditoria.UseVisualStyleBackColor = true;
            // 
            // btnCorporativo
            // 
            this.btnCorporativo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCorporativo.BackgroundImage")));
            this.btnCorporativo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCorporativo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCorporativo.Enabled = false;
            this.btnCorporativo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorporativo.Location = new System.Drawing.Point(9, 177);
            this.btnCorporativo.Name = "btnCorporativo";
            this.btnCorporativo.Size = new System.Drawing.Size(170, 150);
            this.btnCorporativo.TabIndex = 14;
            this.btnCorporativo.Text = "Corporativo";
            this.btnCorporativo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCorporativo.UseVisualStyleBackColor = true;
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConfiguracoes.BackgroundImage")));
            this.btnConfiguracoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConfiguracoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfiguracoes.Enabled = false;
            this.btnConfiguracoes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracoes.Location = new System.Drawing.Point(9, 21);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Size = new System.Drawing.Size(170, 150);
            this.btnConfiguracoes.TabIndex = 12;
            this.btnConfiguracoes.Text = "Configurações";
            this.btnConfiguracoes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfiguracoes.UseVisualStyleBackColor = true;
            this.btnConfiguracoes.Click += new System.EventHandler(this.btnConfiguracoes_Click_1);
            // 
            // btnEstoque
            // 
            this.btnEstoque.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEstoque.BackgroundImage")));
            this.btnEstoque.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEstoque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstoque.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstoque.Location = new System.Drawing.Point(185, 21);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(170, 150);
            this.btnEstoque.TabIndex = 8;
            this.btnEstoque.Text = "Estoque";
            this.btnEstoque.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEstoque.UseMnemonic = false;
            this.btnEstoque.UseVisualStyleBackColor = true;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click_1);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.BackgroundImage")));
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(539, -23);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(252, 176);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 23;
            this.pictureBox4.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(788, 478);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GestaoEmpresa";
            this.Load += new System.EventHandler(this.GestaoEmpresa_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.tabLogin.PerformLayout();
            this.gbConfiguracoesBasicas.ResumeLayout(false);
            this.gbConfiguracoesBasicas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNomeBancoConfiguracoes;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSenhaConfiguracao;
        private System.Windows.Forms.TextBox txtUsuarioConfiguracao;
        private System.Windows.Forms.Button btnSalvarConfiguracaoBasica;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtServidorConfiguracao;
        private System.Windows.Forms.Label lblConfiguracoesBasicas;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEntrar;
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
        private System.Windows.Forms.Button btnAuditoria;
        private System.Windows.Forms.Button btnCorporativo;
        private System.Windows.Forms.Button btnTecnico;
        private System.Windows.Forms.Button btnConfiguracoes;
        private System.Windows.Forms.Button btnEstoque;
        private System.Windows.Forms.Button btnAtendimento;
    }
}