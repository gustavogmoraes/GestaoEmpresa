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
            this.cbSituacao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLineSituacao = new System.Windows.Forms.Label();
            this.txtTecnico = new System.Windows.Forms.TextBox();
            this.lblTecnico = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbFinalidade = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLineFinalidade = new System.Windows.Forms.Label();
            this.flpNumerosDeSerie = new System.Windows.Forms.FlowLayoutPanel();
            this.GSMultiTextBox = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMultiTextBox();
            this.txtOrdemDeServico = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLineOS = new System.Windows.Forms.Label();
            this.panelDevolucao = new System.Windows.Forms.Panel();
            this.dtpDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpTimeDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.gsFileAttacher1 = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSFileAttacher();
            this.GStxtValor = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSTextBoxMonetaria();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).BeginInit();
            this.flpNumerosDeSerie.SuspendLayout();
            this.panelDevolucao.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVigencia
            // 
            this.lblVigencia.AutoSize = true;
            this.lblVigencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVigencia.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblVigencia.Location = new System.Drawing.Point(281, 41);
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
            this.panel1.Size = new System.Drawing.Size(1414, 40);
            this.panel1.TabIndex = 83;
            // 
            // btnCancelarExcluir
            // 
            this.btnCancelarExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarExcluir.Location = new System.Drawing.Point(1324, 9);
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
            this.btnEditarSalvar.Location = new System.Drawing.Point(1286, 5);
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
            this.cbTipo.Location = new System.Drawing.Point(29, 72);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(209, 32);
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
            this.txtQuantidade.Location = new System.Drawing.Point(34, 224);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(64, 22);
            this.txtQuantidade.TabIndex = 5;
            this.txtQuantidade.TextChanged += new System.EventHandler(this.txtQuantidade_TextChanged);
            // 
            // lblQuantidadeEstoque
            // 
            this.lblQuantidadeEstoque.AutoSize = true;
            this.lblQuantidadeEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeEstoque.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblQuantidadeEstoque.Location = new System.Drawing.Point(13, 202);
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
            this.lblValor.Location = new System.Drawing.Point(281, 201);
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
            this.txtLineHorario.Location = new System.Drawing.Point(279, 70);
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
            this.txtLineTipo.Location = new System.Drawing.Point(11, 71);
            this.txtLineTipo.Name = "txtLineTipo";
            this.txtLineTipo.Size = new System.Drawing.Size(249, 42);
            this.txtLineTipo.TabIndex = 87;
            this.txtLineTipo.Text = "___________";
            // 
            // txtLineQuantidadeEstoque
            // 
            this.txtLineQuantidadeEstoque.AutoSize = true;
            this.txtLineQuantidadeEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineQuantidadeEstoque.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineQuantidadeEstoque.Location = new System.Drawing.Point(12, 210);
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
            this.txtOrigem.Location = new System.Drawing.Point(23, 650);
            this.txtOrigem.MaxLength = 100;
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Size = new System.Drawing.Size(452, 22);
            this.txtOrigem.TabIndex = 8;
            this.txtOrigem.TextChanged += new System.EventHandler(this.txtOrigem_TextChanged);
            // 
            // lblOrigem
            // 
            this.lblOrigem.AutoSize = true;
            this.lblOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigem.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblOrigem.Location = new System.Drawing.Point(17, 621);
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
            this.txtLineOrigem.Location = new System.Drawing.Point(16, 642);
            this.txtLineOrigem.Name = "txtLineOrigem";
            this.txtLineOrigem.Size = new System.Drawing.Size(480, 42);
            this.txtLineOrigem.TabIndex = 7;
            this.txtLineOrigem.Text = "______________________";
            this.txtLineOrigem.Click += new System.EventHandler(this.txtLineOrigem_Click);
            // 
            // txtDestino
            // 
            this.txtDestino.BackColor = System.Drawing.Color.Silver;
            this.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestino.ForeColor = System.Drawing.Color.Black;
            this.txtDestino.Location = new System.Drawing.Point(536, 654);
            this.txtDestino.MaxLength = 100;
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(461, 22);
            this.txtDestino.TabIndex = 9;
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestino.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDestino.Location = new System.Drawing.Point(531, 621);
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
            this.txtLineDestino.Location = new System.Drawing.Point(528, 641);
            this.txtLineDestino.Name = "txtLineDestino";
            this.txtLineDestino.Size = new System.Drawing.Size(480, 42);
            this.txtLineDestino.TabIndex = 106;
            this.txtLineDestino.Text = "______________________";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblProduto.Location = new System.Drawing.Point(14, 118);
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
            this.txtLineProduto.Location = new System.Drawing.Point(10, 142);
            this.txtLineProduto.Name = "txtLineProduto";
            this.txtLineProduto.Size = new System.Drawing.Size(984, 42);
            this.txtLineProduto.TabIndex = 110;
            this.txtLineProduto.Text = "______________________________________________";
            // 
            // cbProduto
            // 
            this.cbProduto.BackColor = System.Drawing.Color.Silver;
            this.cbProduto.DropDownHeight = 500;
            this.cbProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProduto.FormattingEnabled = true;
            this.cbProduto.IntegralHeight = false;
            this.cbProduto.Location = new System.Drawing.Point(23, 142);
            this.cbProduto.Name = "cbProduto";
            this.cbProduto.Size = new System.Drawing.Size(956, 32);
            this.cbProduto.TabIndex = 1;
            this.cbProduto.SelectedIndexChanged += new System.EventHandler(this.cbProduto_SelectedIndexChanged);
            this.cbProduto.TextChanged += new System.EventHandler(this.cbProduto_TextChanged);
            // 
            // chkAtualizar
            // 
            this.chkAtualizar.AutoSize = true;
            this.chkAtualizar.Checked = true;
            this.chkAtualizar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtualizar.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkAtualizar.Location = new System.Drawing.Point(353, 257);
            this.chkAtualizar.Name = "chkAtualizar";
            this.chkAtualizar.Size = new System.Drawing.Size(159, 64);
            this.chkAtualizar.TabIndex = 100;
            this.chkAtualizar.Text = "Atualizar catálogo \r\nde produtos com \r\nnovo preço.\r\n";
            this.chkAtualizar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(11, 488);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(501, 42);
            this.label1.TabIndex = 116;
            this.label1.Text = "_______________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(21, 300);
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
            this.txtNumeroDaNotaFiscal.Location = new System.Drawing.Point(536, 230);
            this.txtNumeroDaNotaFiscal.MaxLength = 100;
            this.txtNumeroDaNotaFiscal.Name = "txtNumeroDaNotaFiscal";
            this.txtNumeroDaNotaFiscal.Size = new System.Drawing.Size(395, 22);
            this.txtNumeroDaNotaFiscal.TabIndex = 4;
            this.txtNumeroDaNotaFiscal.TextChanged += new System.EventHandler(this.txtNumeroDaNotaFiscal_TextChanged);
            // 
            // lblNS
            // 
            this.lblNS.AutoSize = true;
            this.lblNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNS.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNS.Location = new System.Drawing.Point(531, 199);
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
            this.label4.Location = new System.Drawing.Point(528, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(480, 42);
            this.label4.TabIndex = 119;
            this.label4.Text = "______________________";
            // 
            // chkInformarNumeroDeSerie
            // 
            this.chkInformarNumeroDeSerie.AutoSize = true;
            this.chkInformarNumeroDeSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInformarNumeroDeSerie.ForeColor = System.Drawing.Color.SteelBlue;
            this.chkInformarNumeroDeSerie.Location = new System.Drawing.Point(23, 274);
            this.chkInformarNumeroDeSerie.Name = "chkInformarNumeroDeSerie";
            this.chkInformarNumeroDeSerie.Size = new System.Drawing.Size(247, 28);
            this.chkInformarNumeroDeSerie.TabIndex = 2;
            this.chkInformarNumeroDeSerie.Text = "Informar Número de Série";
            this.chkInformarNumeroDeSerie.UseVisualStyleBackColor = true;
            this.chkInformarNumeroDeSerie.CheckedChanged += new System.EventHandler(this.chkInformarNumeroDeSerie_CheckedChanged);
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.BackColor = System.Drawing.Color.Silver;
            this.txtObservacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacoes.Location = new System.Drawing.Point(538, 391);
            this.txtObservacoes.MaxLength = 3000;
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacoes.Size = new System.Drawing.Size(454, 122);
            this.txtObservacoes.TabIndex = 10;
            // 
            // lblObservacoes
            // 
            this.lblObservacoes.AutoSize = true;
            this.lblObservacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacoes.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblObservacoes.Location = new System.Drawing.Point(532, 364);
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
            this.txtLineObservacoes.Location = new System.Drawing.Point(530, 488);
            this.txtLineObservacoes.Name = "txtLineObservacoes";
            this.txtLineObservacoes.Size = new System.Drawing.Size(480, 42);
            this.txtLineObservacoes.TabIndex = 125;
            this.txtLineObservacoes.Text = "______________________";
            // 
            // lblQuantidadeAux
            // 
            this.lblQuantidadeAux.AutoSize = true;
            this.lblQuantidadeAux.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeAux.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblQuantidadeAux.Location = new System.Drawing.Point(141, 202);
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
            this.txtLineQuantidadeAux.Location = new System.Drawing.Point(140, 210);
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
            this.txtQuantidadeAux.Location = new System.Drawing.Point(159, 224);
            this.txtQuantidadeAux.Name = "txtQuantidadeAux";
            this.txtQuantidadeAux.Size = new System.Drawing.Size(64, 22);
            this.txtQuantidadeAux.TabIndex = 6;
            this.txtQuantidadeAux.TextChanged += new System.EventHandler(this.txtQuantidadeAux_TextChanged);
            // 
            // dateData
            // 
            this.dateData.CustomFormat = "dd/MM/yyyy";
            this.dateData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateData.Location = new System.Drawing.Point(289, 72);
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
            this.dateHorario.Location = new System.Drawing.Point(422, 72);
            this.dateHorario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateHorario.Name = "dateHorario";
            this.dateHorario.ShowUpDown = true;
            this.dateHorario.Size = new System.Drawing.Size(66, 29);
            this.dateHorario.TabIndex = 131;
            this.dateHorario.Value = new System.DateTime(2018, 8, 24, 0, 0, 0, 0);
            // 
            // cbSituacao
            // 
            this.cbSituacao.BackColor = System.Drawing.Color.Silver;
            this.cbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSituacao.FormattingEnabled = true;
            this.cbSituacao.Items.AddRange(new object[] {
            "Devolvido",
            "Vendido",
            "Trocado",
            "Emprestado",
            "Em uso",
            "Em estoque",
            "Outros"});
            this.cbSituacao.Location = new System.Drawing.Point(543, 69);
            this.cbSituacao.Name = "cbSituacao";
            this.cbSituacao.Size = new System.Drawing.Size(191, 32);
            this.cbSituacao.TabIndex = 133;
            this.cbSituacao.SelectedIndexChanged += new System.EventHandler(this.cbSituacao_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(531, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 132;
            this.label3.Text = "Situação";
            // 
            // txtLineSituacao
            // 
            this.txtLineSituacao.AutoSize = true;
            this.txtLineSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineSituacao.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineSituacao.Location = new System.Drawing.Point(528, 69);
            this.txtLineSituacao.Name = "txtLineSituacao";
            this.txtLineSituacao.Size = new System.Drawing.Size(228, 42);
            this.txtLineSituacao.TabIndex = 134;
            this.txtLineSituacao.Text = "__________";
            // 
            // txtTecnico
            // 
            this.txtTecnico.BackColor = System.Drawing.Color.Silver;
            this.txtTecnico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTecnico.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTecnico.ForeColor = System.Drawing.Color.Black;
            this.txtTecnico.Location = new System.Drawing.Point(20, 567);
            this.txtTecnico.MaxLength = 100;
            this.txtTecnico.Name = "txtTecnico";
            this.txtTecnico.Size = new System.Drawing.Size(410, 22);
            this.txtTecnico.TabIndex = 136;
            // 
            // lblTecnico
            // 
            this.lblTecnico.AutoSize = true;
            this.lblTecnico.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTecnico.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTecnico.Location = new System.Drawing.Point(14, 538);
            this.lblTecnico.Name = "lblTecnico";
            this.lblTecnico.Size = new System.Drawing.Size(79, 24);
            this.lblTecnico.TabIndex = 137;
            this.lblTecnico.Text = "Técnico";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(10, 566);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(480, 42);
            this.label7.TabIndex = 135;
            this.label7.Text = "______________________";
            // 
            // cbFinalidade
            // 
            this.cbFinalidade.BackColor = System.Drawing.Color.Silver;
            this.cbFinalidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFinalidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFinalidade.FormattingEnabled = true;
            this.cbFinalidade.Items.AddRange(new object[] {
            "Reposição de estoque",
            "Venda",
            "Troca",
            "Empréstimo",
            "Uso (Mega)",
            "Outros"});
            this.cbFinalidade.Location = new System.Drawing.Point(543, 566);
            this.cbFinalidade.Name = "cbFinalidade";
            this.cbFinalidade.Size = new System.Drawing.Size(449, 32);
            this.cbFinalidade.TabIndex = 139;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(531, 538);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 24);
            this.label6.TabIndex = 138;
            this.label6.Text = "Finalidade";
            // 
            // txtLineFinalidade
            // 
            this.txtLineFinalidade.AutoSize = true;
            this.txtLineFinalidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineFinalidade.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineFinalidade.Location = new System.Drawing.Point(528, 566);
            this.txtLineFinalidade.Name = "txtLineFinalidade";
            this.txtLineFinalidade.Size = new System.Drawing.Size(480, 42);
            this.txtLineFinalidade.TabIndex = 140;
            this.txtLineFinalidade.Text = "______________________";
            // 
            // flpNumerosDeSerie
            // 
            this.flpNumerosDeSerie.AutoScroll = true;
            this.flpNumerosDeSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpNumerosDeSerie.Controls.Add(this.GSMultiTextBox);
            this.flpNumerosDeSerie.Enabled = false;
            this.flpNumerosDeSerie.Location = new System.Drawing.Point(20, 325);
            this.flpNumerosDeSerie.Name = "flpNumerosDeSerie";
            this.flpNumerosDeSerie.Size = new System.Drawing.Size(478, 188);
            this.flpNumerosDeSerie.TabIndex = 115;
            // 
            // GSMultiTextBox
            // 
            this.GSMultiTextBox.BackColor = System.Drawing.Color.Silver;
            this.GSMultiTextBox.Location = new System.Drawing.Point(3, 3);
            this.GSMultiTextBox.Name = "GSMultiTextBox";
            this.GSMultiTextBox.Size = new System.Drawing.Size(451, 32);
            this.GSMultiTextBox.TabIndex = 3;
            this.GSMultiTextBox.Texto = "";
            // 
            // txtOrdemDeServico
            // 
            this.txtOrdemDeServico.BackColor = System.Drawing.Color.Silver;
            this.txtOrdemDeServico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrdemDeServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrdemDeServico.ForeColor = System.Drawing.Color.Black;
            this.txtOrdemDeServico.Location = new System.Drawing.Point(536, 324);
            this.txtOrdemDeServico.MaxLength = 100;
            this.txtOrdemDeServico.Name = "txtOrdemDeServico";
            this.txtOrdemDeServico.Size = new System.Drawing.Size(395, 22);
            this.txtOrdemDeServico.TabIndex = 141;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.SteelBlue;
            this.label9.Location = new System.Drawing.Point(531, 293);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(264, 24);
            this.label9.TabIndex = 142;
            this.label9.Text = "Número da Ordem de Serviço";
            // 
            // txtLineOS
            // 
            this.txtLineOS.AutoSize = true;
            this.txtLineOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineOS.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineOS.Location = new System.Drawing.Point(528, 311);
            this.txtLineOS.Name = "txtLineOS";
            this.txtLineOS.Size = new System.Drawing.Size(480, 42);
            this.txtLineOS.TabIndex = 143;
            this.txtLineOS.Text = "______________________";
            // 
            // panelDevolucao
            // 
            this.panelDevolucao.Controls.Add(this.dtpDevolucao);
            this.panelDevolucao.Controls.Add(this.label11);
            this.panelDevolucao.Controls.Add(this.dtpTimeDevolucao);
            this.panelDevolucao.Controls.Add(this.label12);
            this.panelDevolucao.Location = new System.Drawing.Point(755, 42);
            this.panelDevolucao.Name = "panelDevolucao";
            this.panelDevolucao.Size = new System.Drawing.Size(237, 94);
            this.panelDevolucao.TabIndex = 144;
            this.panelDevolucao.Visible = false;
            // 
            // dtpDevolucao
            // 
            this.dtpDevolucao.CustomFormat = "dd/MM/yyyy";
            this.dtpDevolucao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDevolucao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpDevolucao.Location = new System.Drawing.Point(18, 29);
            this.dtpDevolucao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDevolucao.Name = "dtpDevolucao";
            this.dtpDevolucao.Size = new System.Drawing.Size(123, 29);
            this.dtpDevolucao.TabIndex = 147;
            this.dtpDevolucao.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.SteelBlue;
            this.label11.Location = new System.Drawing.Point(10, -2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 24);
            this.label11.TabIndex = 145;
            this.label11.Text = "Horário devoluçao";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // dtpTimeDevolucao
            // 
            this.dtpTimeDevolucao.CustomFormat = "HH:mm";
            this.dtpTimeDevolucao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeDevolucao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeDevolucao.Location = new System.Drawing.Point(151, 29);
            this.dtpTimeDevolucao.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpTimeDevolucao.Name = "dtpTimeDevolucao";
            this.dtpTimeDevolucao.ShowUpDown = true;
            this.dtpTimeDevolucao.Size = new System.Drawing.Size(66, 29);
            this.dtpTimeDevolucao.TabIndex = 148;
            this.dtpTimeDevolucao.Value = new System.DateTime(2018, 8, 24, 0, 0, 0, 0);
            this.dtpTimeDevolucao.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.SteelBlue;
            this.label12.Location = new System.Drawing.Point(8, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(228, 42);
            this.label12.TabIndex = 146;
            this.label12.Text = "__________";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // gsFileAttacher1
            // 
            this.gsFileAttacher1.Location = new System.Drawing.Point(1013, 69);
            this.gsFileAttacher1.Name = "gsFileAttacher1";
            this.gsFileAttacher1.Size = new System.Drawing.Size(362, 108);
            this.gsFileAttacher1.TabIndex = 145;
            // 
            // GStxtValor
            // 
            this.GStxtValor.BackColor = System.Drawing.Color.Silver;
            this.GStxtValor.Location = new System.Drawing.Point(277, 220);
            this.GStxtValor.Name = "GStxtValor";
            this.GStxtValor.Size = new System.Drawing.Size(153, 36);
            this.GStxtValor.TabIndex = 7;
            this.GStxtValor.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(1009, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 24);
            this.label5.TabIndex = 146;
            this.label5.Text = "Anexos";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SteelBlue;
            this.label8.Location = new System.Drawing.Point(1006, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(375, 42);
            this.label8.TabIndex = 147;
            this.label8.Text = "_________________";
            // 
            // frmInteracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1377, 708);
            this.Controls.Add(this.gsFileAttacher1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panelDevolucao);
            this.Controls.Add(this.txtOrdemDeServico);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtLineOS);
            this.Controls.Add(this.cbFinalidade);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLineFinalidade);
            this.Controls.Add(this.txtTecnico);
            this.Controls.Add(this.lblTecnico);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbSituacao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLineSituacao);
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
            this.panelDevolucao.ResumeLayout(false);
            this.panelDevolucao.PerformLayout();
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
        private Label label1;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblNS;
        private Label label4;
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
        public TextBox txtNumeroDaNotaFiscal;
        private ComboBox cbSituacao;
        private Label label3;
        private Label txtLineSituacao;
        private TextBox txtTecnico;
        private Label lblTecnico;
        private Label label7;
        private ComboBox cbFinalidade;
        private Label label6;
        private Label txtLineFinalidade;
        private ControlesGenericos.GSMultiTextBox GSMultiTextBox;
        private FlowLayoutPanel flpNumerosDeSerie;
        public TextBox txtOrdemDeServico;
        private Label label9;
        private Label txtLineOS;
        private Panel panelDevolucao;
        private DateTimePicker dtpDevolucao;
        private Label label11;
        private DateTimePicker dtpTimeDevolucao;
        private Label label12;
        private ControlesGenericos.GSFileAttacher gsFileAttacher1;
        private Label label5;
        private Label label8;
    }
}