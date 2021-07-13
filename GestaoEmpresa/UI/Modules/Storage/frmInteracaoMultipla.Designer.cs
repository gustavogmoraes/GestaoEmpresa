namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    partial class frmInteracaoMultipla
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInteracoes = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtLineTipo = new System.Windows.Forms.Label();
            this.btnEditarSalvar = new System.Windows.Forms.PictureBox();
            this.btnCancelarExcluir = new System.Windows.Forms.PictureBox();
            this.dateData = new System.Windows.Forms.DateTimePicker();
            this.dateHorario = new System.Windows.Forms.DateTimePicker();
            this.lblVigencia = new System.Windows.Forms.Label();
            this.txtLineHorario = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.lblDestino = new System.Windows.Forms.Label();
            this.txtLineDestino = new System.Windows.Forms.Label();
            this.txtOrigem = new System.Windows.Forms.TextBox();
            this.lblOrigem = new System.Windows.Forms.Label();
            this.txtNumeroDaNotaFiscal = new System.Windows.Forms.TextBox();
            this.lblNS = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColaborador = new System.Windows.Forms.TextBox();
            this.lblColaborador = new System.Windows.Forms.Label();
            this.txtLineColaborador = new System.Windows.Forms.Label();
            this.txtLineOrigem = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.lblObservacoes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblItens = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnEditarSalvar);
            this.panel1.Controls.Add(this.btnCancelarExcluir);
            this.panel1.Controls.Add(this.lblInteracoes);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1157, 40);
            this.panel1.TabIndex = 84;
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
            this.cbTipo.Location = new System.Drawing.Point(29, 66);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(144, 32);
            this.cbTipo.TabIndex = 89;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblStatus.Location = new System.Drawing.Point(12, 43);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 24);
            this.lblStatus.TabIndex = 88;
            this.lblStatus.Text = "Tipo";
            // 
            // txtLineTipo
            // 
            this.txtLineTipo.AutoSize = true;
            this.txtLineTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineTipo.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineTipo.Location = new System.Drawing.Point(7, 63);
            this.txtLineTipo.Name = "txtLineTipo";
            this.txtLineTipo.Size = new System.Drawing.Size(186, 42);
            this.txtLineTipo.TabIndex = 90;
            this.txtLineTipo.Text = "________";
            // 
            // btnEditarSalvar
            // 
            this.btnEditarSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarSalvar.InitialImage = null;
            this.btnEditarSalvar.Location = new System.Drawing.Point(763, 3);
            this.btnEditarSalvar.Name = "btnEditarSalvar";
            this.btnEditarSalvar.Size = new System.Drawing.Size(32, 30);
            this.btnEditarSalvar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnEditarSalvar.TabIndex = 36;
            this.btnEditarSalvar.TabStop = false;
            // 
            // btnCancelarExcluir
            // 
            this.btnCancelarExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarExcluir.Location = new System.Drawing.Point(801, 7);
            this.btnCancelarExcluir.Name = "btnCancelarExcluir";
            this.btnCancelarExcluir.Size = new System.Drawing.Size(33, 26);
            this.btnCancelarExcluir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCancelarExcluir.TabIndex = 37;
            this.btnCancelarExcluir.TabStop = false;
            // 
            // dateData
            // 
            this.dateData.CustomFormat = "";
            this.dateData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateData.Location = new System.Drawing.Point(219, 69);
            this.dateData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateData.Name = "dateData";
            this.dateData.Size = new System.Drawing.Size(123, 29);
            this.dateData.TabIndex = 134;
            // 
            // dateHorario
            // 
            this.dateHorario.CustomFormat = "HH:mm";
            this.dateHorario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateHorario.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateHorario.Location = new System.Drawing.Point(352, 69);
            this.dateHorario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateHorario.Name = "dateHorario";
            this.dateHorario.ShowUpDown = true;
            this.dateHorario.Size = new System.Drawing.Size(66, 29);
            this.dateHorario.TabIndex = 135;
            this.dateHorario.Value = new System.DateTime(2018, 8, 24, 0, 0, 0, 0);
            // 
            // lblVigencia
            // 
            this.lblVigencia.AutoSize = true;
            this.lblVigencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVigencia.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblVigencia.Location = new System.Drawing.Point(208, 43);
            this.lblVigencia.Name = "lblVigencia";
            this.lblVigencia.Size = new System.Drawing.Size(72, 24);
            this.lblVigencia.TabIndex = 132;
            this.lblVigencia.Text = "Horário";
            // 
            // txtLineHorario
            // 
            this.txtLineHorario.AutoSize = true;
            this.txtLineHorario.Enabled = false;
            this.txtLineHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineHorario.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineHorario.Location = new System.Drawing.Point(206, 63);
            this.txtLineHorario.Name = "txtLineHorario";
            this.txtLineHorario.Size = new System.Drawing.Size(228, 42);
            this.txtLineHorario.TabIndex = 133;
            this.txtLineHorario.Text = "__________";
            // 
            // txtDestino
            // 
            this.txtDestino.BackColor = System.Drawing.Color.Silver;
            this.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestino.ForeColor = System.Drawing.Color.Black;
            this.txtDestino.Location = new System.Drawing.Point(563, 150);
            this.txtDestino.MaxLength = 100;
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(461, 22);
            this.txtDestino.TabIndex = 141;
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestino.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDestino.Location = new System.Drawing.Point(558, 117);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(73, 24);
            this.lblDestino.TabIndex = 139;
            this.lblDestino.Text = "Destino";
            // 
            // txtLineDestino
            // 
            this.txtLineDestino.AutoSize = true;
            this.txtLineDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineDestino.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineDestino.Location = new System.Drawing.Point(552, 137);
            this.txtLineDestino.Name = "txtLineDestino";
            this.txtLineDestino.Size = new System.Drawing.Size(543, 42);
            this.txtLineDestino.TabIndex = 140;
            this.txtLineDestino.Text = "_________________________";
            // 
            // txtOrigem
            // 
            this.txtOrigem.BackColor = System.Drawing.Color.Silver;
            this.txtOrigem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrigem.ForeColor = System.Drawing.Color.Black;
            this.txtOrigem.Location = new System.Drawing.Point(17, 150);
            this.txtOrigem.MaxLength = 100;
            this.txtOrigem.Name = "txtOrigem";
            this.txtOrigem.Size = new System.Drawing.Size(462, 22);
            this.txtOrigem.TabIndex = 138;
            // 
            // lblOrigem
            // 
            this.lblOrigem.AutoSize = true;
            this.lblOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigem.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblOrigem.Location = new System.Drawing.Point(12, 117);
            this.lblOrigem.Name = "lblOrigem";
            this.lblOrigem.Size = new System.Drawing.Size(73, 24);
            this.lblOrigem.TabIndex = 136;
            this.lblOrigem.Text = "Origem";
            // 
            // txtNumeroDaNotaFiscal
            // 
            this.txtNumeroDaNotaFiscal.BackColor = System.Drawing.Color.Silver;
            this.txtNumeroDaNotaFiscal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeroDaNotaFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroDaNotaFiscal.ForeColor = System.Drawing.Color.Black;
            this.txtNumeroDaNotaFiscal.Location = new System.Drawing.Point(17, 269);
            this.txtNumeroDaNotaFiscal.MaxLength = 100;
            this.txtNumeroDaNotaFiscal.Name = "txtNumeroDaNotaFiscal";
            this.txtNumeroDaNotaFiscal.Size = new System.Drawing.Size(462, 22);
            this.txtNumeroDaNotaFiscal.TabIndex = 144;
            // 
            // lblNS
            // 
            this.lblNS.AutoSize = true;
            this.lblNS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNS.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblNS.Location = new System.Drawing.Point(12, 238);
            this.lblNS.Name = "lblNS";
            this.lblNS.Size = new System.Drawing.Size(203, 24);
            this.lblNS.TabIndex = 142;
            this.lblNS.Text = "Número da Nota Fiscal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(9, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(543, 42);
            this.label4.TabIndex = 143;
            this.label4.Text = "_________________________";
            // 
            // txtColaborador
            // 
            this.txtColaborador.BackColor = System.Drawing.Color.Silver;
            this.txtColaborador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtColaborador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColaborador.ForeColor = System.Drawing.Color.Black;
            this.txtColaborador.Location = new System.Drawing.Point(464, 76);
            this.txtColaborador.MaxLength = 100;
            this.txtColaborador.Name = "txtColaborador";
            this.txtColaborador.Size = new System.Drawing.Size(461, 22);
            this.txtColaborador.TabIndex = 147;
            // 
            // lblColaborador
            // 
            this.lblColaborador.AutoSize = true;
            this.lblColaborador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColaborador.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblColaborador.Location = new System.Drawing.Point(459, 43);
            this.lblColaborador.Name = "lblColaborador";
            this.lblColaborador.Size = new System.Drawing.Size(114, 24);
            this.lblColaborador.TabIndex = 145;
            this.lblColaborador.Text = "Colaborador";
            // 
            // txtLineColaborador
            // 
            this.txtLineColaborador.AutoSize = true;
            this.txtLineColaborador.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineColaborador.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineColaborador.Location = new System.Drawing.Point(456, 63);
            this.txtLineColaborador.Name = "txtLineColaborador";
            this.txtLineColaborador.Size = new System.Drawing.Size(543, 42);
            this.txtLineColaborador.TabIndex = 146;
            this.txtLineColaborador.Text = "_________________________";
            // 
            // txtLineOrigem
            // 
            this.txtLineOrigem.AutoSize = true;
            this.txtLineOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineOrigem.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineOrigem.Location = new System.Drawing.Point(6, 137);
            this.txtLineOrigem.Name = "txtLineOrigem";
            this.txtLineOrigem.Size = new System.Drawing.Size(543, 42);
            this.txtLineOrigem.TabIndex = 148;
            this.txtLineOrigem.Text = "_________________________";
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.BackColor = System.Drawing.Color.Silver;
            this.txtObservacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacoes.Location = new System.Drawing.Point(567, 215);
            this.txtObservacoes.MaxLength = 3000;
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacoes.Size = new System.Drawing.Size(483, 67);
            this.txtObservacoes.TabIndex = 149;
            // 
            // lblObservacoes
            // 
            this.lblObservacoes.AutoSize = true;
            this.lblObservacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacoes.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblObservacoes.Location = new System.Drawing.Point(558, 190);
            this.lblObservacoes.Name = "lblObservacoes";
            this.lblObservacoes.Size = new System.Drawing.Size(127, 24);
            this.lblObservacoes.TabIndex = 150;
            this.lblObservacoes.Text = "Observações ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(553, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(543, 42);
            this.label1.TabIndex = 151;
            this.label1.Text = "_________________________";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(17, 353);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1065, 308);
            this.flowLayoutPanel1.TabIndex = 152;
            // 
            // lblItens
            // 
            this.lblItens.AutoSize = true;
            this.lblItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItens.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblItens.Location = new System.Drawing.Point(14, 316);
            this.lblItens.Name = "lblItens";
            this.lblItens.Size = new System.Drawing.Size(49, 24);
            this.lblItens.TabIndex = 153;
            this.lblItens.Text = "Itens";
            // 
            // frmInteracaoMultipla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1094, 701);
            this.Controls.Add(this.lblItens);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblObservacoes);
            this.Controls.Add(this.txtLineOrigem);
            this.Controls.Add(this.txtColaborador);
            this.Controls.Add(this.lblColaborador);
            this.Controls.Add(this.txtLineColaborador);
            this.Controls.Add(this.txtNumeroDaNotaFiscal);
            this.Controls.Add(this.lblNS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.txtLineDestino);
            this.Controls.Add(this.txtOrigem);
            this.Controls.Add(this.lblOrigem);
            this.Controls.Add(this.dateData);
            this.Controls.Add(this.dateHorario);
            this.Controls.Add(this.lblVigencia);
            this.Controls.Add(this.txtLineHorario);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtLineTipo);
            this.Controls.Add(this.panel1);
            this.Name = "frmInteracaoMultipla";
            this.Text = "Entrada / Saída Multipla";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnEditarSalvar;
        private System.Windows.Forms.PictureBox btnCancelarExcluir;
        private System.Windows.Forms.Label lblInteracoes;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label txtLineTipo;
        private System.Windows.Forms.DateTimePicker dateData;
        private System.Windows.Forms.DateTimePicker dateHorario;
        private System.Windows.Forms.Label lblVigencia;
        private System.Windows.Forms.Label txtLineHorario;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Label txtLineDestino;
        private System.Windows.Forms.TextBox txtOrigem;
        private System.Windows.Forms.Label lblOrigem;
        private System.Windows.Forms.TextBox txtNumeroDaNotaFiscal;
        private System.Windows.Forms.Label lblNS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtColaborador;
        private System.Windows.Forms.Label lblColaborador;
        private System.Windows.Forms.Label txtLineColaborador;
        private System.Windows.Forms.Label txtLineOrigem;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Label lblObservacoes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblItens;
    }
}