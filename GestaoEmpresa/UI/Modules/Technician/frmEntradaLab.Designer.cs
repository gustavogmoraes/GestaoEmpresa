namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Tecnico
{
    partial class frmEntradaLab
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
            this.btnEditarSalvar = new System.Windows.Forms.PictureBox();
            this.btnCancelarExcluir = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRastreioCaso = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbStatusLab = new System.Windows.Forms.ComboBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtLineProduto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEquipLab = new System.Windows.Forms.Button();
            this.txtLineCodigoFabricante = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblVigencia = new System.Windows.Forms.Label();
            this.txtLineHorario = new System.Windows.Forms.Label();
            this.dateData = new System.Windows.Forms.DateTimePicker();
            this.dateHorario = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.lblOsLab = new System.Windows.Forms.Label();
            this.txtQuantidadeAux = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colunaProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDefeitoRelatado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnEditarSalvar);
            this.panel1.Controls.Add(this.btnCancelarExcluir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1203, 40);
            this.panel1.TabIndex = 39;
            // 
            // btnEditarSalvar
            // 
            this.btnEditarSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarSalvar.InitialImage = null;
            this.btnEditarSalvar.Location = new System.Drawing.Point(900, 3);
            this.btnEditarSalvar.Name = "btnEditarSalvar";
            this.btnEditarSalvar.Size = new System.Drawing.Size(32, 30);
            this.btnEditarSalvar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnEditarSalvar.TabIndex = 36;
            this.btnEditarSalvar.TabStop = false;
            // 
            // btnCancelarExcluir
            // 
            this.btnCancelarExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarExcluir.Location = new System.Drawing.Point(955, 5);
            this.btnCancelarExcluir.Name = "btnCancelarExcluir";
            this.btnCancelarExcluir.Size = new System.Drawing.Size(33, 26);
            this.btnCancelarExcluir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCancelarExcluir.TabIndex = 37;
            this.btnCancelarExcluir.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(282, -5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consulta e Cadastro de Produtos";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCliente.Location = new System.Drawing.Point(36, 51);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(74, 22);
            this.lblCliente.TabIndex = 40;
            this.lblCliente.Text = "Client";
            this.lblCliente.Click += new System.EventHandler(this.lblCliente_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Silver;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 641);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1180, 182);
            this.flowLayoutPanel1.TabIndex = 44;
            // 
            // lblRastreioCaso
            // 
            this.lblRastreioCaso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRastreioCaso.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRastreioCaso.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblRastreioCaso.Location = new System.Drawing.Point(484, 556);
            this.lblRastreioCaso.Name = "lblRastreioCaso";
            this.lblRastreioCaso.Size = new System.Drawing.Size(304, 22);
            this.lblRastreioCaso.TabIndex = 45;
            this.lblRastreioCaso.Text = "Rastreio da Ocorrencia\r\n";
            this.lblRastreioCaso.Click += new System.EventHandler(this.lblRastreioCaso_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblStatus.Location = new System.Drawing.Point(26, 560);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(70, 22);
            this.lblStatus.TabIndex = 46;
            this.lblStatus.Text = "Status ";
            // 
            // cbStatusLab
            // 
            this.cbStatusLab.BackColor = System.Drawing.Color.Silver;
            this.cbStatusLab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatusLab.FormattingEnabled = true;
            this.cbStatusLab.Items.AddRange(new object[] {
            "Aguardando Analise",
            "Analisado Aguardando Valor",
            "Orçamento Digitado Aguardando Valor e Revisão",
            "Orçamento Digitado Aguardando Revisão",
            "Aguardando Aprovaçao",
            "Aprovado Aguardando Reparo",
            "Realizando Reparo",
            "Consertado Aguardando devolução",
            "Em transporte para Devoluçao",
            "Equipamento Devolvido",
            "",
            ""});
            this.cbStatusLab.Location = new System.Drawing.Point(90, 556);
            this.cbStatusLab.Name = "cbStatusLab";
            this.cbStatusLab.Size = new System.Drawing.Size(257, 32);
            this.cbStatusLab.TabIndex = 82;
            this.cbStatusLab.SelectedIndexChanged += new System.EventHandler(this.cbStatusLab_SelectedIndexChanged);
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.Silver;
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNome.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(116, 51);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(446, 24);
            this.txtNome.TabIndex = 83;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // txtLineProduto
            // 
            this.txtLineProduto.AutoSize = true;
            this.txtLineProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineProduto.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineProduto.Location = new System.Drawing.Point(12, 44);
            this.txtLineProduto.Name = "txtLineProduto";
            this.txtLineProduto.Size = new System.Drawing.Size(564, 42);
            this.txtLineProduto.TabIndex = 111;
            this.txtLineProduto.Text = "__________________________";
            this.txtLineProduto.Click += new System.EventHandler(this.txtLineProduto_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(16, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 22);
            this.label3.TabIndex = 112;
            this.label3.Text = "Equipamentos :";
            // 
            // btnEquipLab
            // 
            this.btnEquipLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEquipLab.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.add;
            this.btnEquipLab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEquipLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEquipLab.Location = new System.Drawing.Point(189, 88);
            this.btnEquipLab.Name = "btnEquipLab";
            this.btnEquipLab.Size = new System.Drawing.Size(32, 32);
            this.btnEquipLab.TabIndex = 114;
            this.btnEquipLab.UseVisualStyleBackColor = true;
            this.btnEquipLab.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLineCodigoFabricante
            // 
            this.txtLineCodigoFabricante.AutoSize = true;
            this.txtLineCodigoFabricante.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineCodigoFabricante.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineCodigoFabricante.Location = new System.Drawing.Point(8, 78);
            this.txtLineCodigoFabricante.Name = "txtLineCodigoFabricante";
            this.txtLineCodigoFabricante.Size = new System.Drawing.Size(210, 44);
            this.txtLineCodigoFabricante.TabIndex = 117;
            this.txtLineCodigoFabricante.Text = "__________";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(480, 586);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(229, 44);
            this.label7.TabIndex = 121;
            this.label7.Text = "___________";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // lblVigencia
            // 
            this.lblVigencia.AutoSize = true;
            this.lblVigencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVigencia.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblVigencia.Location = new System.Drawing.Point(236, 89);
            this.lblVigencia.Name = "lblVigencia";
            this.lblVigencia.Size = new System.Drawing.Size(72, 24);
            this.lblVigencia.TabIndex = 122;
            this.lblVigencia.Text = "Horário";
            // 
            // txtLineHorario
            // 
            this.txtLineHorario.AutoSize = true;
            this.txtLineHorario.Enabled = false;
            this.txtLineHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineHorario.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtLineHorario.Location = new System.Drawing.Point(303, 79);
            this.txtLineHorario.Name = "txtLineHorario";
            this.txtLineHorario.Size = new System.Drawing.Size(228, 42);
            this.txtLineHorario.TabIndex = 123;
            this.txtLineHorario.Text = "__________";
            // 
            // dateData
            // 
            this.dateData.CustomFormat = "";
            this.dateData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateData.Location = new System.Drawing.Point(315, 88);
            this.dateData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateData.Name = "dateData";
            this.dateData.Size = new System.Drawing.Size(123, 29);
            this.dateData.TabIndex = 131;
            // 
            // dateHorario
            // 
            this.dateHorario.CustomFormat = "HH:mm";
            this.dateHorario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateHorario.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateHorario.Location = new System.Drawing.Point(446, 88);
            this.dateHorario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateHorario.Name = "dateHorario";
            this.dateHorario.ShowUpDown = true;
            this.dateHorario.Size = new System.Drawing.Size(66, 29);
            this.dateHorario.TabIndex = 132;
            this.dateHorario.Value = new System.DateTime(2018, 8, 24, 0, 0, 0, 0);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.add;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(582, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 133;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblOsLab
            // 
            this.lblOsLab.AutoSize = true;
            this.lblOsLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOsLab.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblOsLab.Location = new System.Drawing.Point(537, 92);
            this.lblOsLab.Name = "lblOsLab";
            this.lblOsLab.Size = new System.Drawing.Size(47, 24);
            this.lblOsLab.TabIndex = 134;
            this.lblOsLab.Text = "OS :";
            // 
            // txtQuantidadeAux
            // 
            this.txtQuantidadeAux.BackColor = System.Drawing.Color.Silver;
            this.txtQuantidadeAux.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuantidadeAux.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidadeAux.Location = new System.Drawing.Point(958, 272);
            this.txtQuantidadeAux.Name = "txtQuantidadeAux";
            this.txtQuantidadeAux.Size = new System.Drawing.Size(126, 22);
            this.txtQuantidadeAux.TabIndex = 136;
            this.txtQuantidadeAux.TextChanged += new System.EventHandler(this.txtQuantidadeAux_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SteelBlue;
            this.label8.Location = new System.Drawing.Point(519, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(210, 44);
            this.label8.TabIndex = 137;
            this.label8.Text = "__________";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.add;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(363, 556);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 32);
            this.button2.TabIndex = 138;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.Enabled = false;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.SteelBlue;
            this.label9.Location = new System.Drawing.Point(13, 560);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(430, 42);
            this.label9.TabIndex = 139;
            this.label9.Text = "__________________________";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaProduto,
            this.colunaDefeitoRelatado,
            this.colunaStatus,
            this.colunaData});
            this.dataGridView1.Location = new System.Drawing.Point(16, 119);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1175, 424);
            this.dataGridView1.TabIndex = 140;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colunaProduto
            // 
            this.colunaProduto.HeaderText = "Produto";
            this.colunaProduto.Name = "colunaProduto";
            this.colunaProduto.Width = 400;
            // 
            // colunaDefeitoRelatado
            // 
            this.colunaDefeitoRelatado.HeaderText = "DefeitoRelatado";
            this.colunaDefeitoRelatado.Name = "colunaDefeitoRelatado";
            this.colunaDefeitoRelatado.Width = 330;
            // 
            // colunaStatus
            // 
            this.colunaStatus.HeaderText = "Status";
            this.colunaStatus.Name = "colunaStatus";
            this.colunaStatus.Width = 300;
            // 
            // colunaData
            // 
            this.colunaData.HeaderText = "Data Atualização";
            this.colunaData.Name = "colunaData";
            // 
            // frmEntradaLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1204, 749);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtQuantidadeAux);
            this.Controls.Add(this.lblOsLab);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateHorario);
            this.Controls.Add(this.dateData);
            this.Controls.Add(this.lblVigencia);
            this.Controls.Add(this.btnEquipLab);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbStatusLab);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblRastreioCaso);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtLineProduto);
            this.Controls.Add(this.txtLineCodigoFabricante);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLineHorario);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Name = "frmEntradaLab";
            this.Text = "frmEntradaLab";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnEditarSalvar;
        private System.Windows.Forms.PictureBox btnCancelarExcluir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblRastreioCaso;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbStatusLab;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label txtLineProduto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEquipLab;
        private System.Windows.Forms.Label txtLineCodigoFabricante;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblVigencia;
        private System.Windows.Forms.Label txtLineHorario;
        private System.Windows.Forms.DateTimePicker dateData;
        private System.Windows.Forms.DateTimePicker dateHorario;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblOsLab;
        private System.Windows.Forms.TextBox txtQuantidadeAux;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaDefeitoRelatado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaData;
    }
}