using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    partial class frmInteracao
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
            this.lblVigencia = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInteracoes = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.lblObservacoes = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.lblQuantidadeEstoque = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtLineHorario = new System.Windows.Forms.Label();
            this.txtLineTipo = new System.Windows.Forms.Label();
            this.txtLineQuantidadeEstoque = new System.Windows.Forms.Label();
            this.txtLineObservacoes = new System.Windows.Forms.Label();
            this.txtHorario = new System.Windows.Forms.TextBox();
            this.txtOrigem = new System.Windows.Forms.TextBox();
            this.lblOrigem = new System.Windows.Forms.Label();
            this.txtLineOrigem = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.lblDestino = new System.Windows.Forms.Label();
            this.txtLineDestino = new System.Windows.Forms.Label();
            this.lblProduto = new System.Windows.Forms.Label();
            this.txtLineProduto = new System.Windows.Forms.Label();
            this.cbProduto = new System.Windows.Forms.ComboBox();
            this.chkAtualizar = new System.Windows.Forms.CheckBox();
            this.flpNumerosDeSerie = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnEditarSalvar = new System.Windows.Forms.PictureBox();
            this.btnCancelarExcluir = new System.Windows.Forms.PictureBox();
            this.txtNumeroDaNotaFiscal = new System.Windows.Forms.TextBox();
            this.lblNS = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gsMultiTextBox1 = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMultiTextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtLineValor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flpNumerosDeSerie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVigencia
            // 
            this.lblVigencia.AutoSize = true;
            this.lblVigencia.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVigencia.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblVigencia.Location = new System.Drawing.Point(237, 44);
            this.lblVigencia.Name = "lblVigencia";
            this.lblVigencia.Size = new System.Drawing.Size(75, 22);
            this.lblVigencia.TabIndex = 79;
            this.lblVigencia.Text = "Horário";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnEditarSalvar);
            this.panel1.Controls.Add(this.btnCancelarExcluir);
            this.panel1.Controls.Add(this.lblInteracoes);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 40);
            this.panel1.TabIndex = 83;
            // 
            // lblInteracoes
            // 
            this.lblInteracoes.AutoSize = true;
            this.lblInteracoes.BackColor = System.Drawing.Color.SteelBlue;
            this.lblInteracoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblInteracoes.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInteracoes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInteracoes.Location = new System.Drawing.Point(-2, 4);
            this.lblInteracoes.Name = "lblInteracoes";
            this.lblInteracoes.Size = new System.Drawing.Size(511, 30);
            this.lblInteracoes.TabIndex = 0;
            this.lblInteracoes.Text = "Consulta e Cadastro de Entradas e Saídas";
            // 
            // cbTipo
            // 
            this.cbTipo.BackColor = System.Drawing.Color.Silver;
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Entrada",
            "Saída"});
            this.cbTipo.Location = new System.Drawing.Point(33, 67);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(105, 30);
            this.cbTipo.TabIndex = 81;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblStatus.Location = new System.Drawing.Point(16, 44);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 22);
            this.lblStatus.TabIndex = 78;
            this.lblStatus.Text = "Tipo";
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.BackColor = System.Drawing.Color.Silver;
            this.txtObservacoes.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacoes.Location = new System.Drawing.Point(21, 136);
            this.txtObservacoes.MaxLength = 3000;
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacoes.Size = new System.Drawing.Size(483, 101);
            this.txtObservacoes.TabIndex = 73;
            // 
            // lblObservacoes
            // 
            this.lblObservacoes.AutoSize = true;
            this.lblObservacoes.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacoes.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblObservacoes.Location = new System.Drawing.Point(12, 111);
            this.lblObservacoes.Name = "lblObservacoes";
            this.lblObservacoes.Size = new System.Drawing.Size(139, 22);
            this.lblObservacoes.TabIndex = 76;
            this.lblObservacoes.Text = "Observações ";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BackColor = System.Drawing.Color.Silver;
            this.txtQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantidade.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.Location = new System.Drawing.Point(36, 595);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(64, 24);
            this.txtQuantidade.TabIndex = 70;
            this.txtQuantidade.TextChanged += new System.EventHandler(this.txtQuantidade_TextChanged);
            // 
            // lblQuantidadeEstoque
            // 
            this.lblQuantidadeEstoque.AutoSize = true;
            this.lblQuantidadeEstoque.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeEstoque.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblQuantidadeEstoque.Location = new System.Drawing.Point(15, 573);
            this.lblQuantidadeEstoque.Name = "lblQuantidadeEstoque";
            this.lblQuantidadeEstoque.Size = new System.Drawing.Size(125, 22);
            this.lblQuantidadeEstoque.TabIndex = 74;
            this.lblQuantidadeEstoque.Text = "Quantidade";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblValor.Location = new System.Drawing.Point(166, 572);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(59, 22);
            this.lblValor.TabIndex = 66;
            this.lblValor.Text = "Valor";
            // 
            // txtLineHorario
            // 
            this.txtLineHorario.AutoSize = true;
            this.txtLineHorario.Enabled = false;
            this.txtLineHorario.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineHorario.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineHorario.Location = new System.Drawing.Point(234, 64);
            this.txtLineHorario.Name = "txtLineHorario";
            this.txtLineHorario.Size = new System.Drawing.Size(229, 44);
            this.txtLineHorario.TabIndex = 86;
            this.txtLineHorario.Text = "___________";
            // 
            // txtLineTipo
            // 
            this.txtLineTipo.AutoSize = true;
            this.txtLineTipo.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineTipo.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineTipo.Location = new System.Drawing.Point(12, 64);
            this.txtLineTipo.Name = "txtLineTipo";
            this.txtLineTipo.Size = new System.Drawing.Size(153, 44);
            this.txtLineTipo.TabIndex = 87;
            this.txtLineTipo.Text = "_______";
            // 
            // txtLineQuantidadeEstoque
            // 
            this.txtLineQuantidadeEstoque.AutoSize = true;
            this.txtLineQuantidadeEstoque.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineQuantidadeEstoque.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineQuantidadeEstoque.Location = new System.Drawing.Point(14, 581);
            this.txtLineQuantidadeEstoque.Name = "txtLineQuantidadeEstoque";
            this.txtLineQuantidadeEstoque.Size = new System.Drawing.Size(115, 44);
            this.txtLineQuantidadeEstoque.TabIndex = 99;
            this.txtLineQuantidadeEstoque.Text = "_____";
            // 
            // txtLineObservacoes
            // 
            this.txtLineObservacoes.AutoSize = true;
            this.txtLineObservacoes.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineObservacoes.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineObservacoes.Location = new System.Drawing.Point(11, 208);
            this.txtLineObservacoes.Name = "txtLineObservacoes";
            this.txtLineObservacoes.Size = new System.Drawing.Size(514, 44);
            this.txtLineObservacoes.TabIndex = 100;
            this.txtLineObservacoes.Text = "__________________________";
            // 
            // txtHorario
            // 
            this.txtHorario.BackColor = System.Drawing.Color.Silver;
            this.txtHorario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHorario.Enabled = false;
            this.txtHorario.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHorario.ForeColor = System.Drawing.Color.Black;
            this.txtHorario.Location = new System.Drawing.Point(242, 77);
            this.txtHorario.Name = "txtHorario";
            this.txtHorario.Size = new System.Drawing.Size(188, 24);
            this.txtHorario.TabIndex = 101;
            // 
            // txtOrigem
            // 
            this.txtOrigem.BackColor = System.Drawing.Color.Silver;
            this.txtOrigem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrigem.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrigem.ForeColor = System.Drawing.Color.Black;
            this.txtOrigem.Location = new System.Drawing.Point(24, 667);
            this.txtOrigem.MaxLength = 100;
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Size = new System.Drawing.Size(462, 24);
            this.txtOrigem.TabIndex = 104;
            this.txtOrigem.TextChanged += new System.EventHandler(this.txtOrigem_TextChanged);
            // 
            // lblOrigem
            // 
            this.lblOrigem.AutoSize = true;
            this.lblOrigem.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigem.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblOrigem.Location = new System.Drawing.Point(19, 634);
            this.lblOrigem.Name = "lblOrigem";
            this.lblOrigem.Size = new System.Drawing.Size(78, 22);
            this.lblOrigem.TabIndex = 102;
            this.lblOrigem.Text = "Origem";
            // 
            // txtLineOrigem
            // 
            this.txtLineOrigem.AutoSize = true;
            this.txtLineOrigem.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineOrigem.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineOrigem.Location = new System.Drawing.Point(16, 654);
            this.txtLineOrigem.Name = "txtLineOrigem";
            this.txtLineOrigem.Size = new System.Drawing.Size(495, 44);
            this.txtLineOrigem.TabIndex = 103;
            this.txtLineOrigem.Text = "_________________________";
            this.txtLineOrigem.Click += new System.EventHandler(this.txtLineOrigem_Click);
            // 
            // txtDestino
            // 
            this.txtDestino.BackColor = System.Drawing.Color.Silver;
            this.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDestino.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestino.ForeColor = System.Drawing.Color.Black;
            this.txtDestino.Location = new System.Drawing.Point(25, 745);
            this.txtDestino.MaxLength = 100;
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(461, 24);
            this.txtDestino.TabIndex = 107;
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestino.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDestino.Location = new System.Drawing.Point(20, 712);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(77, 22);
            this.lblDestino.TabIndex = 105;
            this.lblDestino.Text = "Destino";
            // 
            // txtLineDestino
            // 
            this.txtLineDestino.AutoSize = true;
            this.txtLineDestino.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineDestino.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineDestino.Location = new System.Drawing.Point(17, 732);
            this.txtLineDestino.Name = "txtLineDestino";
            this.txtLineDestino.Size = new System.Drawing.Size(495, 44);
            this.txtLineDestino.TabIndex = 106;
            this.txtLineDestino.Text = "_________________________";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblProduto.Location = new System.Drawing.Point(20, 257);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(83, 22);
            this.lblProduto.TabIndex = 109;
            this.lblProduto.Text = "Produto";
            // 
            // txtLineProduto
            // 
            this.txtLineProduto.AutoSize = true;
            this.txtLineProduto.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineProduto.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineProduto.Location = new System.Drawing.Point(18, 278);
            this.txtLineProduto.Name = "txtLineProduto";
            this.txtLineProduto.Size = new System.Drawing.Size(514, 44);
            this.txtLineProduto.TabIndex = 110;
            this.txtLineProduto.Text = "__________________________";
            // 
            // cbProduto
            // 
            this.cbProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProduto.BackColor = System.Drawing.Color.Silver;
            this.cbProduto.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProduto.FormattingEnabled = true;
            this.cbProduto.Location = new System.Drawing.Point(37, 281);
            this.cbProduto.Name = "cbProduto";
            this.cbProduto.Size = new System.Drawing.Size(467, 30);
            this.cbProduto.TabIndex = 111;
            // 
            // chkAtualizar
            // 
            this.chkAtualizar.AutoSize = true;
            this.chkAtualizar.Checked = true;
            this.chkAtualizar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtualizar.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtualizar.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkAtualizar.Location = new System.Drawing.Point(315, 573);
            this.chkAtualizar.Name = "chkAtualizar";
            this.chkAtualizar.Size = new System.Drawing.Size(204, 70);
            this.chkAtualizar.TabIndex = 113;
            this.chkAtualizar.Text = "Atualizar catálogo \r\nde produtos com \r\nnovo preço.\r\n";
            this.chkAtualizar.UseVisualStyleBackColor = true;
            // 
            // flpNumerosDeSerie
            // 
            this.flpNumerosDeSerie.AutoScroll = true;
            this.flpNumerosDeSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpNumerosDeSerie.Controls.Add(this.gsMultiTextBox1);
            this.flpNumerosDeSerie.Location = new System.Drawing.Point(20, 355);
            this.flpNumerosDeSerie.Name = "flpNumerosDeSerie";
            this.flpNumerosDeSerie.Size = new System.Drawing.Size(484, 125);
            this.flpNumerosDeSerie.TabIndex = 115;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(11, 451);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 44);
            this.label1.TabIndex = 116;
            this.label1.Text = "__________________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(21, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 22);
            this.label2.TabIndex = 117;
            this.label2.Text = "Números de Série";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 401);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(484, 125);
            this.flowLayoutPanel1.TabIndex = 115;
            // 
            // btnEditarSalvar
            // 
            this.btnEditarSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarSalvar.InitialImage = null;
            this.btnEditarSalvar.Location = new System.Drawing.Point(506, 4);
            this.btnEditarSalvar.Name = "btnEditarSalvar";
            this.btnEditarSalvar.Size = new System.Drawing.Size(32, 30);
            this.btnEditarSalvar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnEditarSalvar.TabIndex = 36;
            this.btnEditarSalvar.TabStop = false;
            this.btnEditarSalvar.Click += new System.EventHandler(this.btnEditarSalvar_Click);
            // 
            // btnCancelarExcluir
            // 
            this.btnCancelarExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarExcluir.Location = new System.Drawing.Point(545, 6);
            this.btnCancelarExcluir.Name = "btnCancelarExcluir";
            this.btnCancelarExcluir.Size = new System.Drawing.Size(33, 26);
            this.btnCancelarExcluir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCancelarExcluir.TabIndex = 37;
            this.btnCancelarExcluir.TabStop = false;
            this.btnCancelarExcluir.Click += new System.EventHandler(this.btnCancelarExcluir_Click);
            // 
            // txtNumeroDaNotaFiscal
            // 
            this.txtNumeroDaNotaFiscal.BackColor = System.Drawing.Color.Silver;
            this.txtNumeroDaNotaFiscal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeroDaNotaFiscal.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroDaNotaFiscal.ForeColor = System.Drawing.Color.Black;
            this.txtNumeroDaNotaFiscal.Location = new System.Drawing.Point(27, 533);
            this.txtNumeroDaNotaFiscal.MaxLength = 100;
            this.txtNumeroDaNotaFiscal.Name = "txtNumeroDaNotaFiscal";
            this.txtNumeroDaNotaFiscal.Size = new System.Drawing.Size(462, 24);
            this.txtNumeroDaNotaFiscal.TabIndex = 120;
            // 
            // lblNS
            // 
            this.lblNS.AutoSize = true;
            this.lblNS.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNS.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNS.Location = new System.Drawing.Point(22, 502);
            this.lblNS.Name = "lblNS";
            this.lblNS.Size = new System.Drawing.Size(217, 22);
            this.lblNS.TabIndex = 118;
            this.lblNS.Text = "Número da Nota Fiscal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(19, 520);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(495, 44);
            this.label4.TabIndex = 119;
            this.label4.Text = "_________________________";
            // 
            // gsMultiTextBox1
            // 
            this.gsMultiTextBox1.BackColor = System.Drawing.Color.Silver;
            this.gsMultiTextBox1.Location = new System.Drawing.Point(3, 3);
            this.gsMultiTextBox1.Name = "gsMultiTextBox1";
            this.gsMultiTextBox1.Size = new System.Drawing.Size(451, 32);
            this.gsMultiTextBox1.TabIndex = 0;
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.Color.Silver;
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtValor.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(192, 594);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(79, 24);
            this.txtValor.TabIndex = 121;
            // 
            // txtLineValor
            // 
            this.txtLineValor.AutoSize = true;
            this.txtLineValor.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineValor.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineValor.Location = new System.Drawing.Point(162, 581);
            this.txtLineValor.Name = "txtLineValor";
            this.txtLineValor.Size = new System.Drawing.Size(153, 44);
            this.txtLineValor.TabIndex = 122;
            this.txtLineValor.Text = "_______";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(158, 595);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 22);
            this.label5.TabIndex = 123;
            this.label5.Text = "R$";
            // 
            // frmInteracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(584, 784);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtLineValor);
            this.Controls.Add(this.txtNumeroDaNotaFiscal);
            this.Controls.Add(this.lblNS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flpNumerosDeSerie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkAtualizar);
            this.Controls.Add(this.cbProduto);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.txtLineProduto);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.txtLineDestino);
            this.Controls.Add(this.txtOrigem);
            this.Controls.Add(this.lblOrigem);
            this.Controls.Add(this.txtLineOrigem);
            this.Controls.Add(this.txtHorario);
            this.Controls.Add(this.lblVigencia);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.lblObservacoes);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.lblQuantidadeEstoque);
            this.Controls.Add(this.txtLineHorario);
            this.Controls.Add(this.txtLineTipo);
            this.Controls.Add(this.txtLineQuantidadeEstoque);
            this.Controls.Add(this.txtLineObservacoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmInteracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrada / Saída";
            this.Load += new System.EventHandler(this.frmInteracao_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flpNumerosDeSerie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblVigencia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnEditarSalvar;
        private System.Windows.Forms.PictureBox btnCancelarExcluir;
        private System.Windows.Forms.Label lblInteracoes;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Label lblObservacoes;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblQuantidadeEstoque;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label txtLineHorario;
        private System.Windows.Forms.Label txtLineTipo;
        private System.Windows.Forms.Label txtLineQuantidadeEstoque;
        private System.Windows.Forms.Label txtLineObservacoes;
        private System.Windows.Forms.TextBox txtHorario;
        private System.Windows.Forms.TextBox txtOrigem;
        private System.Windows.Forms.Label lblOrigem;
        private System.Windows.Forms.Label txtLineOrigem;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Label txtLineDestino;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label txtLineProduto;
        private System.Windows.Forms.ComboBox cbProduto;
        private CheckBox chkAtualizar;
        private FlowLayoutPanel flpNumerosDeSerie;
        private Label label1;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox txtNumeroDaNotaFiscal;
        private Label lblNS;
        private Label label4;
        private ControlesGenericos.GSMultiTextBox gsMultiTextBox1;
        private TextBox txtValor;
        private Label txtLineValor;
        private Label label5;
    }
}