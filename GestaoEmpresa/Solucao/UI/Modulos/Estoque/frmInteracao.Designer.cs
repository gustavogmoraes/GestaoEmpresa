using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;

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
            this.btnCancelarExcluir = new System.Windows.Forms.PictureBox();
            this.lblInteracoes = new System.Windows.Forms.Label();
            this.btnEditarSalvar = new System.Windows.Forms.PictureBox();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.lblQuantidadeEstoque = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtLineHorario = new System.Windows.Forms.Label();
            this.txtLineTipo = new System.Windows.Forms.Label();
            this.txtLineQuantidadeEstoque = new System.Windows.Forms.Label();
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
            this.GSMultiTextBox = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMultiTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtNumeroDaNotaFiscal = new System.Windows.Forms.TextBox();
            this.lblNS = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkInformarNumeroDeSerie = new System.Windows.Forms.CheckBox();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.lblObservacoes = new System.Windows.Forms.Label();
            this.txtLineObservacoes = new System.Windows.Forms.Label();
            this.lblQuantidadeAux = new System.Windows.Forms.Label();
            this.txtLineQuantidadeAux = new System.Windows.Forms.Label();
            this.txtQuantidadeAux = new System.Windows.Forms.TextBox();
            this.dateData = new System.Windows.Forms.DateTimePicker();
            this.dateHorario = new System.Windows.Forms.DateTimePicker();
            this.GStxtValor = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSTextBoxMonetaria();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).BeginInit();
            this.flpNumerosDeSerie.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVigencia
            // 
            this.lblVigencia.AutoSize = true;
            this.lblVigencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVigencia.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblVigencia.Location = new System.Drawing.Point(237, 44);
            this.lblVigencia.Name = "lblVigencia";
            this.lblVigencia.Size = new System.Drawing.Size(72, 24);
            this.lblVigencia.TabIndex = 79;
            this.lblVigencia.Text = "Horário";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCancelarExcluir);
            this.panel1.Controls.Add(this.lblInteracoes);
            this.panel1.Controls.Add(this.btnEditarSalvar);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 40);
            this.panel1.TabIndex = 83;
            // 
            // btnCancelarExcluir
            // 
            this.btnCancelarExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarExcluir.Location = new System.Drawing.Point(563, 8);
            this.btnCancelarExcluir.Name = "btnCancelarExcluir";
            this.btnCancelarExcluir.Size = new System.Drawing.Size(33, 26);
            this.btnCancelarExcluir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCancelarExcluir.TabIndex = 37;
            this.btnCancelarExcluir.TabStop = false;
            this.btnCancelarExcluir.Click += new System.EventHandler(this.btnCancelarExcluir_Click);
            // 
            // lblInteracoes
            // 
            this.lblInteracoes.AutoSize = true;
            this.lblInteracoes.BackColor = System.Drawing.Color.SteelBlue;
            this.lblInteracoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblInteracoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInteracoes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInteracoes.Location = new System.Drawing.Point(-2, 4);
            this.lblInteracoes.Name = "lblInteracoes";
            this.lblInteracoes.Size = new System.Drawing.Size(465, 29);
            this.lblInteracoes.TabIndex = 0;
            this.lblInteracoes.Text = "Consulta e Cadastro de Entradas e Saídas";
            // 
            // btnEditarSalvar
            // 
            this.btnEditarSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarSalvar.InitialImage = null;
            this.btnEditarSalvar.Location = new System.Drawing.Point(525, 4);
            this.btnEditarSalvar.Name = "btnEditarSalvar";
            this.btnEditarSalvar.Size = new System.Drawing.Size(32, 30);
            this.btnEditarSalvar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnEditarSalvar.TabIndex = 36;
            this.btnEditarSalvar.TabStop = false;
            this.btnEditarSalvar.Click += new System.EventHandler(this.btnEditarSalvar_Click);
            // 
            // cbTipo
            // 
            this.cbTipo.BackColor = System.Drawing.Color.Silver;
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Entrada",
            "Saída",
            "Base de troca"});
            this.cbTipo.Location = new System.Drawing.Point(33, 67);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(144, 32);
            this.cbTipo.TabIndex = 81;
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblStatus.Location = new System.Drawing.Point(16, 44);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 24);
            this.lblStatus.TabIndex = 78;
            this.lblStatus.Text = "Tipo";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BackColor = System.Drawing.Color.Silver;
            this.txtQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.Location = new System.Drawing.Point(36, 477);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(64, 22);
            this.txtQuantidade.TabIndex = 70;
            this.txtQuantidade.TextChanged += new System.EventHandler(this.txtQuantidade_TextChanged);
            // 
            // lblQuantidadeEstoque
            // 
            this.lblQuantidadeEstoque.AutoSize = true;
            this.lblQuantidadeEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeEstoque.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblQuantidadeEstoque.Location = new System.Drawing.Point(15, 455);
            this.lblQuantidadeEstoque.Name = "lblQuantidadeEstoque";
            this.lblQuantidadeEstoque.Size = new System.Drawing.Size(108, 24);
            this.lblQuantidadeEstoque.TabIndex = 74;
            this.lblQuantidadeEstoque.Text = "Quantidade";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblValor.Location = new System.Drawing.Point(283, 454);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(54, 24);
            this.lblValor.TabIndex = 66;
            this.lblValor.Text = "Valor";
            // 
            // txtLineHorario
            // 
            this.txtLineHorario.AutoSize = true;
            this.txtLineHorario.Enabled = false;
            this.txtLineHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineHorario.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineHorario.Location = new System.Drawing.Point(235, 64);
            this.txtLineHorario.Name = "txtLineHorario";
            this.txtLineHorario.Size = new System.Drawing.Size(228, 42);
            this.txtLineHorario.TabIndex = 86;
            this.txtLineHorario.Text = "__________";
            // 
            // txtLineTipo
            // 
            this.txtLineTipo.AutoSize = true;
            this.txtLineTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineTipo.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineTipo.Location = new System.Drawing.Point(11, 64);
            this.txtLineTipo.Name = "txtLineTipo";
            this.txtLineTipo.Size = new System.Drawing.Size(186, 42);
            this.txtLineTipo.TabIndex = 87;
            this.txtLineTipo.Text = "________";
            // 
            // txtLineQuantidadeEstoque
            // 
            this.txtLineQuantidadeEstoque.AutoSize = true;
            this.txtLineQuantidadeEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineQuantidadeEstoque.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineQuantidadeEstoque.Location = new System.Drawing.Point(14, 463);
            this.txtLineQuantidadeEstoque.Name = "txtLineQuantidadeEstoque";
            this.txtLineQuantidadeEstoque.Size = new System.Drawing.Size(123, 42);
            this.txtLineQuantidadeEstoque.TabIndex = 99;
            this.txtLineQuantidadeEstoque.Text = "_____";
            // 
            // txtOrigem
            // 
            this.txtOrigem.BackColor = System.Drawing.Color.Silver;
            this.txtOrigem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrigem.ForeColor = System.Drawing.Color.Black;
            this.txtOrigem.Location = new System.Drawing.Point(24, 549);
            this.txtOrigem.MaxLength = 100;
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Size = new System.Drawing.Size(462, 22);
            this.txtOrigem.TabIndex = 104;
            this.txtOrigem.TextChanged += new System.EventHandler(this.txtOrigem_TextChanged);
            // 
            // lblOrigem
            // 
            this.lblOrigem.AutoSize = true;
            this.lblOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigem.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblOrigem.Location = new System.Drawing.Point(19, 516);
            this.lblOrigem.Name = "lblOrigem";
            this.lblOrigem.Size = new System.Drawing.Size(73, 24);
            this.lblOrigem.TabIndex = 102;
            this.lblOrigem.Text = "Origem";
            // 
            // txtLineOrigem
            // 
            this.txtLineOrigem.AutoSize = true;
            this.txtLineOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineOrigem.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineOrigem.Location = new System.Drawing.Point(16, 536);
            this.txtLineOrigem.Name = "txtLineOrigem";
            this.txtLineOrigem.Size = new System.Drawing.Size(543, 42);
            this.txtLineOrigem.TabIndex = 103;
            this.txtLineOrigem.Text = "_________________________";
            this.txtLineOrigem.Click += new System.EventHandler(this.txtLineOrigem_Click);
            // 
            // txtDestino
            // 
            this.txtDestino.BackColor = System.Drawing.Color.Silver;
            this.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestino.ForeColor = System.Drawing.Color.Black;
            this.txtDestino.Location = new System.Drawing.Point(25, 627);
            this.txtDestino.MaxLength = 100;
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(461, 22);
            this.txtDestino.TabIndex = 107;
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestino.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDestino.Location = new System.Drawing.Point(20, 594);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(73, 24);
            this.lblDestino.TabIndex = 105;
            this.lblDestino.Text = "Destino";
            // 
            // txtLineDestino
            // 
            this.txtLineDestino.AutoSize = true;
            this.txtLineDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineDestino.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineDestino.Location = new System.Drawing.Point(17, 614);
            this.txtLineDestino.Name = "txtLineDestino";
            this.txtLineDestino.Size = new System.Drawing.Size(543, 42);
            this.txtLineDestino.TabIndex = 106;
            this.txtLineDestino.Text = "_________________________";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblProduto.Location = new System.Drawing.Point(20, 116);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(76, 24);
            this.lblProduto.TabIndex = 109;
            this.lblProduto.Text = "Produto";
            // 
            // txtLineProduto
            // 
            this.txtLineProduto.AutoSize = true;
            this.txtLineProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineProduto.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineProduto.Location = new System.Drawing.Point(18, 137);
            this.txtLineProduto.Name = "txtLineProduto";
            this.txtLineProduto.Size = new System.Drawing.Size(564, 42);
            this.txtLineProduto.TabIndex = 110;
            this.txtLineProduto.Text = "__________________________";
            // 
            // cbProduto
            // 
            this.cbProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProduto.BackColor = System.Drawing.Color.Silver;
            this.cbProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProduto.FormattingEnabled = true;
            this.cbProduto.Location = new System.Drawing.Point(37, 140);
            this.cbProduto.Name = "cbProduto";
            this.cbProduto.Size = new System.Drawing.Size(467, 32);
            this.cbProduto.TabIndex = 111;
            this.cbProduto.SelectedIndexChanged += new System.EventHandler(this.cbProduto_SelectedIndexChanged);
            // 
            // chkAtualizar
            // 
            this.chkAtualizar.AutoSize = true;
            this.chkAtualizar.Checked = true;
            this.chkAtualizar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtualizar.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkAtualizar.Location = new System.Drawing.Point(432, 455);
            this.chkAtualizar.Name = "chkAtualizar";
            this.chkAtualizar.Size = new System.Drawing.Size(181, 76);
            this.chkAtualizar.TabIndex = 113;
            this.chkAtualizar.Text = "Atualizar catálogo \r\nde produtos com \r\nnovo preço.\r\n";
            this.chkAtualizar.UseVisualStyleBackColor = true;
            // 
            // flpNumerosDeSerie
            // 
            this.flpNumerosDeSerie.AutoScroll = true;
            this.flpNumerosDeSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpNumerosDeSerie.Controls.Add(this.GSMultiTextBox);
            this.flpNumerosDeSerie.Enabled = false;
            this.flpNumerosDeSerie.Location = new System.Drawing.Point(20, 237);
            this.flpNumerosDeSerie.Name = "flpNumerosDeSerie";
            this.flpNumerosDeSerie.Size = new System.Drawing.Size(484, 125);
            this.flpNumerosDeSerie.TabIndex = 115;
            // 
            // GSMultiTextBox
            // 
            this.GSMultiTextBox.BackColor = System.Drawing.Color.Silver;
            this.GSMultiTextBox.Location = new System.Drawing.Point(3, 3);
            this.GSMultiTextBox.Name = "GSMultiTextBox";
            this.GSMultiTextBox.Size = new System.Drawing.Size(451, 32);
            this.GSMultiTextBox.TabIndex = 0;
            this.GSMultiTextBox.Texto = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(11, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(564, 42);
            this.label1.TabIndex = 116;
            this.label1.Text = "__________________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(21, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 24);
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
            // txtNumeroDaNotaFiscal
            // 
            this.txtNumeroDaNotaFiscal.BackColor = System.Drawing.Color.Silver;
            this.txtNumeroDaNotaFiscal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeroDaNotaFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroDaNotaFiscal.ForeColor = System.Drawing.Color.Black;
            this.txtNumeroDaNotaFiscal.Location = new System.Drawing.Point(27, 415);
            this.txtNumeroDaNotaFiscal.MaxLength = 100;
            this.txtNumeroDaNotaFiscal.Name = "txtNumeroDaNotaFiscal";
            this.txtNumeroDaNotaFiscal.Size = new System.Drawing.Size(462, 22);
            this.txtNumeroDaNotaFiscal.TabIndex = 120;
            this.txtNumeroDaNotaFiscal.TextChanged += new System.EventHandler(this.txtNumeroDaNotaFiscal_TextChanged);
            // 
            // lblNS
            // 
            this.lblNS.AutoSize = true;
            this.lblNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNS.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNS.Location = new System.Drawing.Point(22, 384);
            this.lblNS.Name = "lblNS";
            this.lblNS.Size = new System.Drawing.Size(203, 24);
            this.lblNS.TabIndex = 118;
            this.lblNS.Text = "Número da Nota Fiscal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(19, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(543, 42);
            this.label4.TabIndex = 119;
            this.label4.Text = "_________________________";
            // 
            // chkInformarNumeroDeSerie
            // 
            this.chkInformarNumeroDeSerie.AutoSize = true;
            this.chkInformarNumeroDeSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInformarNumeroDeSerie.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkInformarNumeroDeSerie.Location = new System.Drawing.Point(23, 186);
            this.chkInformarNumeroDeSerie.Name = "chkInformarNumeroDeSerie";
            this.chkInformarNumeroDeSerie.Size = new System.Drawing.Size(247, 28);
            this.chkInformarNumeroDeSerie.TabIndex = 122;
            this.chkInformarNumeroDeSerie.Text = "Informar Número de Série";
            this.chkInformarNumeroDeSerie.UseVisualStyleBackColor = true;
            this.chkInformarNumeroDeSerie.CheckedChanged += new System.EventHandler(this.chkInformarNumeroDeSerie_CheckedChanged);
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.BackColor = System.Drawing.Color.Silver;
            this.txtObservacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacoes.Location = new System.Drawing.Point(30, 693);
            this.txtObservacoes.MaxLength = 3000;
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacoes.Size = new System.Drawing.Size(483, 101);
            this.txtObservacoes.TabIndex = 123;
            // 
            // lblObservacoes
            // 
            this.lblObservacoes.AutoSize = true;
            this.lblObservacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacoes.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblObservacoes.Location = new System.Drawing.Point(21, 668);
            this.lblObservacoes.Name = "lblObservacoes";
            this.lblObservacoes.Size = new System.Drawing.Size(127, 24);
            this.lblObservacoes.TabIndex = 124;
            this.lblObservacoes.Text = "Observações ";
            // 
            // txtLineObservacoes
            // 
            this.txtLineObservacoes.AutoSize = true;
            this.txtLineObservacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineObservacoes.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineObservacoes.Location = new System.Drawing.Point(20, 765);
            this.txtLineObservacoes.Name = "txtLineObservacoes";
            this.txtLineObservacoes.Size = new System.Drawing.Size(564, 42);
            this.txtLineObservacoes.TabIndex = 125;
            this.txtLineObservacoes.Text = "__________________________";
            // 
            // lblQuantidadeAux
            // 
            this.lblQuantidadeAux.AutoSize = true;
            this.lblQuantidadeAux.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeAux.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblQuantidadeAux.Location = new System.Drawing.Point(143, 455);
            this.lblQuantidadeAux.Name = "lblQuantidadeAux";
            this.lblQuantidadeAux.Size = new System.Drawing.Size(97, 24);
            this.lblQuantidadeAux.TabIndex = 127;
            this.lblQuantidadeAux.Text = "Qtd. Saída";
            this.lblQuantidadeAux.Visible = false;
            // 
            // txtLineQuantidadeAux
            // 
            this.txtLineQuantidadeAux.AutoSize = true;
            this.txtLineQuantidadeAux.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineQuantidadeAux.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineQuantidadeAux.Location = new System.Drawing.Point(142, 463);
            this.txtLineQuantidadeAux.Name = "txtLineQuantidadeAux";
            this.txtLineQuantidadeAux.Size = new System.Drawing.Size(123, 42);
            this.txtLineQuantidadeAux.TabIndex = 128;
            this.txtLineQuantidadeAux.Text = "_____";
            this.txtLineQuantidadeAux.Visible = false;
            // 
            // txtQuantidadeAux
            // 
            this.txtQuantidadeAux.BackColor = System.Drawing.Color.Silver;
            this.txtQuantidadeAux.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantidadeAux.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidadeAux.Location = new System.Drawing.Point(161, 477);
            this.txtQuantidadeAux.Name = "txtQuantidadeAux";
            this.txtQuantidadeAux.Size = new System.Drawing.Size(64, 22);
            this.txtQuantidadeAux.TabIndex = 129;
            this.txtQuantidadeAux.TextChanged += new System.EventHandler(this.txtQuantidadeAux_TextChanged);
            // 
            // dateData
            // 
            this.dateData.CustomFormat = "";
            this.dateData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateData.Location = new System.Drawing.Point(248, 70);
            this.dateData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateData.Name = "dateData";
            this.dateData.Size = new System.Drawing.Size(123, 29);
            this.dateData.TabIndex = 130;
            // 
            // dateHorario
            // 
            this.dateHorario.CustomFormat = "HH:mm";
            this.dateHorario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateHorario.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateHorario.Location = new System.Drawing.Point(381, 70);
            this.dateHorario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateHorario.Name = "dateHorario";
            this.dateHorario.ShowUpDown = true;
            this.dateHorario.Size = new System.Drawing.Size(66, 29);
            this.dateHorario.TabIndex = 131;
            this.dateHorario.Value = new System.DateTime(2018, 8, 24, 0, 0, 0, 0);
            // 
            // GStxtValor
            // 
            this.GStxtValor.BackColor = System.Drawing.Color.Silver;
            this.GStxtValor.Location = new System.Drawing.Point(279, 473);
            this.GStxtValor.Name = "GStxtValor";
            this.GStxtValor.Size = new System.Drawing.Size(153, 36);
            this.GStxtValor.TabIndex = 121;
            this.GStxtValor.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // frmInteracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(602, 815);
            this.Controls.Add(this.dateData);
            this.Controls.Add(this.dateHorario);
            this.Controls.Add(this.lblQuantidadeAux);
            this.Controls.Add(this.txtQuantidadeAux);
            this.Controls.Add(this.txtLineQuantidadeAux);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.lblObservacoes);
            this.Controls.Add(this.txtLineObservacoes);
            this.Controls.Add(this.chkInformarNumeroDeSerie);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.GStxtValor);
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
            this.Controls.Add(this.lblVigencia);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.lblQuantidadeEstoque);
            this.Controls.Add(this.txtLineHorario);
            this.Controls.Add(this.txtLineTipo);
            this.Controls.Add(this.txtLineQuantidadeEstoque);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmInteracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrada / Saída";
            this.Load += new System.EventHandler(this.frmInteracao_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).EndInit();
            this.flpNumerosDeSerie.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblQuantidadeEstoque;
        private System.Windows.Forms.Label txtLineHorario;
        private System.Windows.Forms.Label txtLineTipo;
        private System.Windows.Forms.Label txtLineQuantidadeEstoque;
        private System.Windows.Forms.TextBox txtOrigem;
        private System.Windows.Forms.Label lblOrigem;
        private System.Windows.Forms.Label txtLineOrigem;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Label txtLineDestino;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label txtLineProduto;
        private System.Windows.Forms.ComboBox cbProduto;
        private FlowLayoutPanel flpNumerosDeSerie;
        private Label label1;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox txtNumeroDaNotaFiscal;
        private Label lblNS;
        private Label label4;
        private ControlesGenericos.GSMultiTextBox GSMultiTextBox;
        private CheckBox chkInformarNumeroDeSerie;
        private TextBox txtObservacoes;
        private Label lblObservacoes;
        private Label txtLineObservacoes;
        public Label lblValor;
        public CheckBox chkAtualizar;
        public ControlesGenericos.GSTextBoxMonetaria GStxtValor;
        private Label lblQuantidadeAux;
        private Label txtLineQuantidadeAux;
        private TextBox txtQuantidadeAux;
        private DateTimePicker dateData;
        private DateTimePicker dateHorario;
    }
}