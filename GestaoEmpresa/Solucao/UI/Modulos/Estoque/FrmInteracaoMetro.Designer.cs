namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    partial class FrmInteracaoMetro
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.panelDevolucao = new System.Windows.Forms.Panel();
            this.dtpDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpTimeDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.cbSituacao = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLineSituacao = new System.Windows.Forms.Label();
            this.dateData = new System.Windows.Forms.DateTimePicker();
            this.dateHorario = new System.Windows.Forms.DateTimePicker();
            this.lblVigencia = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtLineHorario = new System.Windows.Forms.Label();
            this.txtLineTipo = new System.Windows.Forms.Label();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).BeginInit();
            this.panelTitulo.SuspendLayout();
            this.panelDevolucao.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelarExcluir
            // 
            this.btnCancelarExcluir.Location = new System.Drawing.Point(1160, 31);
            // 
            // btnEditarSalvar
            // 
            this.btnEditarSalvar.Location = new System.Drawing.Point(1118, 29);
            // 
            // panelTitulo
            // 
            this.panelTitulo.Controls.Add(this.metroLabel1);
            this.panelTitulo.Size = new System.Drawing.Size(1210, 62);
            this.panelTitulo.Controls.SetChildIndex(this.metroLabel1, 0);
            this.panelTitulo.Controls.SetChildIndex(this.btnCancelarExcluir, 0);
            this.panelTitulo.Controls.SetChildIndex(this.btnEditarSalvar, 0);
            this.panelTitulo.Controls.SetChildIndex(this.gsTopBorder1, 0);
            this.panelTitulo.Controls.SetChildIndex(this.lblTitulo, 0);
            // 
            // gsTopBorder1
            // 
            this.gsTopBorder1.Size = new System.Drawing.Size(1207, 26);
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
            // panelDevolucao
            // 
            this.panelDevolucao.Controls.Add(this.dtpDevolucao);
            this.panelDevolucao.Controls.Add(this.label11);
            this.panelDevolucao.Controls.Add(this.dtpTimeDevolucao);
            this.panelDevolucao.Controls.Add(this.label12);
            this.panelDevolucao.Location = new System.Drawing.Point(778, 224);
            this.panelDevolucao.Name = "panelDevolucao";
            this.panelDevolucao.Size = new System.Drawing.Size(237, 94);
            this.panelDevolucao.TabIndex = 155;
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
            this.cbSituacao.Location = new System.Drawing.Point(566, 251);
            this.cbSituacao.Name = "cbSituacao";
            this.cbSituacao.Size = new System.Drawing.Size(191, 32);
            this.cbSituacao.TabIndex = 153;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(554, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 152;
            this.label3.Text = "Situação";
            // 
            // txtLineSituacao
            // 
            this.txtLineSituacao.AutoSize = true;
            this.txtLineSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineSituacao.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineSituacao.Location = new System.Drawing.Point(551, 251);
            this.txtLineSituacao.Name = "txtLineSituacao";
            this.txtLineSituacao.Size = new System.Drawing.Size(228, 42);
            this.txtLineSituacao.TabIndex = 154;
            this.txtLineSituacao.Text = "__________";
            // 
            // dateData
            // 
            this.dateData.CustomFormat = "dd/MM/yyyy";
            this.dateData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateData.Location = new System.Drawing.Point(312, 254);
            this.dateData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateData.Name = "dateData";
            this.dateData.Size = new System.Drawing.Size(123, 29);
            this.dateData.TabIndex = 150;
            // 
            // dateHorario
            // 
            this.dateHorario.CustomFormat = "HH:mm";
            this.dateHorario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateHorario.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateHorario.Location = new System.Drawing.Point(445, 254);
            this.dateHorario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateHorario.Name = "dateHorario";
            this.dateHorario.ShowUpDown = true;
            this.dateHorario.Size = new System.Drawing.Size(66, 29);
            this.dateHorario.TabIndex = 151;
            this.dateHorario.Value = new System.DateTime(2018, 8, 24, 0, 0, 0, 0);
            // 
            // lblVigencia
            // 
            this.lblVigencia.AutoSize = true;
            this.lblVigencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVigencia.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblVigencia.Location = new System.Drawing.Point(304, 223);
            this.lblVigencia.Name = "lblVigencia";
            this.lblVigencia.Size = new System.Drawing.Size(72, 24);
            this.lblVigencia.TabIndex = 146;
            this.lblVigencia.Text = "Horário";
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
            this.cbTipo.Location = new System.Drawing.Point(52, 254);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(209, 32);
            this.cbTipo.TabIndex = 147;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblStatus.Location = new System.Drawing.Point(39, 226);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 24);
            this.lblStatus.TabIndex = 145;
            this.lblStatus.Text = "Tipo";
            // 
            // txtLineHorario
            // 
            this.txtLineHorario.AutoSize = true;
            this.txtLineHorario.Enabled = false;
            this.txtLineHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineHorario.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineHorario.Location = new System.Drawing.Point(302, 252);
            this.txtLineHorario.Name = "txtLineHorario";
            this.txtLineHorario.Size = new System.Drawing.Size(228, 42);
            this.txtLineHorario.TabIndex = 148;
            this.txtLineHorario.Text = "__________";
            // 
            // txtLineTipo
            // 
            this.txtLineTipo.AutoSize = true;
            this.txtLineTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineTipo.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineTipo.Location = new System.Drawing.Point(34, 253);
            this.txtLineTipo.Name = "txtLineTipo";
            this.txtLineTipo.Size = new System.Drawing.Size(249, 42);
            this.txtLineTipo.TabIndex = 149;
            this.txtLineTipo.Text = "___________";
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.BackColor = System.Drawing.Color.White;
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Items.AddRange(new object[] {
            "Entrada",
            "Saída",
            "Base de troca"});
            this.metroComboBox1.Location = new System.Drawing.Point(22, 103);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(158, 29);
            this.metroComboBox1.TabIndex = 156;
            this.metroComboBox1.UseCustomBackColor = true;
            this.metroComboBox1.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(22, 75);
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
            this.metroLabel3.Location = new System.Drawing.Point(238, 75);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(69, 25);
            this.metroLabel3.TabIndex = 159;
            this.metroLabel3.Text = "Horário";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimePicker1.Location = new System.Drawing.Point(238, 103);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(123, 29);
            this.dateTimePicker1.TabIndex = 160;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "HH:mm";
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(371, 103);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(66, 29);
            this.dateTimePicker2.TabIndex = 161;
            this.dateTimePicker2.Value = new System.DateTime(2018, 8, 24, 0, 0, 0, 0);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dateTimePicker3.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimePicker3.Location = new System.Drawing.Point(749, 106);
            this.dateTimePicker3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(123, 29);
            this.dateTimePicker3.TabIndex = 163;
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.CustomFormat = "HH:mm";
            this.dateTimePicker4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker4.Location = new System.Drawing.Point(882, 106);
            this.dateTimePicker4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.ShowUpDown = true;
            this.dateTimePicker4.Size = new System.Drawing.Size(66, 29);
            this.dateTimePicker4.TabIndex = 164;
            this.dateTimePicker4.Value = new System.DateTime(2018, 8, 24, 0, 0, 0, 0);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(749, 78);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(152, 25);
            this.metroLabel4.TabIndex = 162;
            this.metroLabel4.Text = "Horário devolução";
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // FrmInteracaoMetro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 747);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.dateTimePicker4);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.panelDevolucao);
            this.Controls.Add(this.cbSituacao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLineSituacao);
            this.Controls.Add(this.dateData);
            this.Controls.Add(this.dateHorario);
            this.Controls.Add(this.lblVigencia);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtLineHorario);
            this.Controls.Add(this.txtLineTipo);
            this.Name = "FrmInteracaoMetro";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.panelTitulo, 0);
            this.Controls.SetChildIndex(this.txtLineTipo, 0);
            this.Controls.SetChildIndex(this.txtLineHorario, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.cbTipo, 0);
            this.Controls.SetChildIndex(this.lblVigencia, 0);
            this.Controls.SetChildIndex(this.dateHorario, 0);
            this.Controls.SetChildIndex(this.dateData, 0);
            this.Controls.SetChildIndex(this.txtLineSituacao, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cbSituacao, 0);
            this.Controls.SetChildIndex(this.panelDevolucao, 0);
            this.Controls.SetChildIndex(this.metroComboBox1, 0);
            this.Controls.SetChildIndex(this.metroLabel2, 0);
            this.Controls.SetChildIndex(this.metroLabel3, 0);
            this.Controls.SetChildIndex(this.dateTimePicker2, 0);
            this.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.Controls.SetChildIndex(this.metroLabel4, 0);
            this.Controls.SetChildIndex(this.dateTimePicker4, 0);
            this.Controls.SetChildIndex(this.dateTimePicker3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelDevolucao.ResumeLayout(false);
            this.panelDevolucao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Panel panelDevolucao;
        private System.Windows.Forms.DateTimePicker dtpDevolucao;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpTimeDevolucao;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbSituacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtLineSituacao;
        private System.Windows.Forms.DateTimePicker dateData;
        private System.Windows.Forms.DateTimePicker dateHorario;
        private System.Windows.Forms.Label lblVigencia;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label txtLineHorario;
        private System.Windows.Forms.Label txtLineTipo;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private MetroFramework.Controls.MetroLabel metroLabel4;
    }
}