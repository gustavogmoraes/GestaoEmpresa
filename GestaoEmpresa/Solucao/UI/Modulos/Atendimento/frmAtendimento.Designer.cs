﻿namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento
{
    partial class frmAtendimento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAtendimento));
            this.BtnOrcamento = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ScrollSelecao = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ucSessaoSistema2 = new GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados.UCSessaoSistema();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProdutos = new System.Windows.Forms.TabPage();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.dgvOrcamentos = new System.Windows.Forms.DataGridView();
            this.colunaDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colunaDetalhar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnNovoProduto = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnOrcamento
            // 
            this.BtnOrcamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOrcamento.BackColor = System.Drawing.Color.DimGray;
            this.BtnOrcamento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnOrcamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOrcamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOrcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOrcamento.ForeColor = System.Drawing.Color.White;
            this.BtnOrcamento.Location = new System.Drawing.Point(2340, 121);
            this.BtnOrcamento.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BtnOrcamento.Name = "BtnOrcamento";
            this.BtnOrcamento.Size = new System.Drawing.Size(236, 206);
            this.BtnOrcamento.TabIndex = 7;
            this.BtnOrcamento.Text = "Orçamentos";
            this.BtnOrcamento.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ScrollSelecao);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(2298, 88);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 1242);
            this.panel1.TabIndex = 9;
            // 
            // ScrollSelecao
            // 
            this.ScrollSelecao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScrollSelecao.BackColor = System.Drawing.Color.SteelBlue;
            this.ScrollSelecao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScrollSelecao.Location = new System.Drawing.Point(8, 35);
            this.ScrollSelecao.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ScrollSelecao.Name = "ScrollSelecao";
            this.ScrollSelecao.Size = new System.Drawing.Size(20, 202);
            this.ScrollSelecao.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 185);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(714, 79);
            this.label1.TabIndex = 2;
            this.label1.Text = "_________________";
            // 
            // ucSessaoSistema2
            // 
            this.ucSessaoSistema2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSessaoSistema2.BackColor = System.Drawing.Color.SteelBlue;
            this.ucSessaoSistema2.Location = new System.Drawing.Point(0, -23);
            this.ucSessaoSistema2.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.ucSessaoSistema2.Name = "ucSessaoSistema2";
            this.ucSessaoSistema2.Size = new System.Drawing.Size(2578, 127);
            this.ucSessaoSistema2.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabProdutos);
            this.tabControl1.Location = new System.Drawing.Point(-8, 88);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2366, 1227);
            this.tabControl1.TabIndex = 8;
            // 
            // tabProdutos
            // 
            this.tabProdutos.BackColor = System.Drawing.Color.Silver;
            this.tabProdutos.Controls.Add(this.btnRefresh);
            this.tabProdutos.Controls.Add(this.pictureBox3);
            this.tabProdutos.Controls.Add(this.txtPesquisa);
            this.tabProdutos.Controls.Add(this.btnNovoProduto);
            this.tabProdutos.Controls.Add(this.dgvOrcamentos);
            this.tabProdutos.Location = new System.Drawing.Point(8, 39);
            this.tabProdutos.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabProdutos.Name = "tabProdutos";
            this.tabProdutos.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabProdutos.Size = new System.Drawing.Size(2350, 1180);
            this.tabProdutos.TabIndex = 0;
            this.tabProdutos.Text = "tabOrcamentos";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.ForeColor = System.Drawing.Color.Silver;
            this.txtPesquisa.Location = new System.Drawing.Point(92, 17);
            this.txtPesquisa.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(1014, 44);
            this.txtPesquisa.TabIndex = 6;
            this.txtPesquisa.Text = "Pesquisar...";
            // 
            // dgvOrcamentos
            // 
            this.dgvOrcamentos.AllowUserToAddRows = false;
            this.dgvOrcamentos.AllowUserToDeleteRows = false;
            this.dgvOrcamentos.AllowUserToOrderColumns = true;
            this.dgvOrcamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrcamentos.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrcamentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrcamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrcamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colunaDescricao,
            this.colunaCliente,
            this.colunaStatus,
            this.colunaData,
            this.colunaDetalhar});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrcamentos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOrcamentos.GridColor = System.Drawing.Color.Silver;
            this.dgvOrcamentos.Location = new System.Drawing.Point(-72, 75);
            this.dgvOrcamentos.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvOrcamentos.Name = "dgvOrcamentos";
            this.dgvOrcamentos.ReadOnly = true;
            this.dgvOrcamentos.RowHeadersWidth = 82;
            this.dgvOrcamentos.Size = new System.Drawing.Size(2370, 1090);
            this.dgvOrcamentos.TabIndex = 0;
            // 
            // colunaDescricao
            // 
            this.colunaDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colunaDescricao.HeaderText = "Descrição";
            this.colunaDescricao.MinimumWidth = 10;
            this.colunaDescricao.Name = "colunaDescricao";
            this.colunaDescricao.ReadOnly = true;
            // 
            // colunaCliente
            // 
            this.colunaCliente.HeaderText = "Cliente";
            this.colunaCliente.MinimumWidth = 10;
            this.colunaCliente.Name = "colunaCliente";
            this.colunaCliente.ReadOnly = true;
            this.colunaCliente.Width = 700;
            // 
            // colunaStatus
            // 
            this.colunaStatus.HeaderText = "Status";
            this.colunaStatus.MinimumWidth = 10;
            this.colunaStatus.Name = "colunaStatus";
            this.colunaStatus.ReadOnly = true;
            this.colunaStatus.Width = 300;
            // 
            // colunaData
            // 
            this.colunaData.HeaderText = "Data / Hora";
            this.colunaData.MinimumWidth = 10;
            this.colunaData.Name = "colunaData";
            this.colunaData.ReadOnly = true;
            this.colunaData.Width = 300;
            // 
            // colunaDetalhar
            // 
            this.colunaDetalhar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colunaDetalhar.HeaderText = "";
            this.colunaDetalhar.MinimumWidth = 10;
            this.colunaDetalhar.Name = "colunaDetalhar";
            this.colunaDetalhar.ReadOnly = true;
            this.colunaDetalhar.Width = 30;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::GS.GestaoEmpresa.Properties.Resources.BoxBlueShort;
            this.pictureBox2.InitialImage = global::GS.GestaoEmpresa.Properties.Resources.BoxBlueShort;
            this.pictureBox2.Location = new System.Drawing.Point(16, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(136, 96);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(1144, 7);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(64, 62);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Silver;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(16, 21);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 46);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // btnNovoProduto
            // 
            this.btnNovoProduto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNovoProduto.BackgroundImage = global::GS.GestaoEmpresa.Properties.Resources.add;
            this.btnNovoProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNovoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoProduto.Location = new System.Drawing.Point(1220, 7);
            this.btnNovoProduto.Margin = new System.Windows.Forms.Padding(6);
            this.btnNovoProduto.Name = "btnNovoProduto";
            this.btnNovoProduto.Size = new System.Drawing.Size(64, 62);
            this.btnNovoProduto.TabIndex = 5;
            this.btnNovoProduto.UseVisualStyleBackColor = true;
            this.btnNovoProduto.Click += new System.EventHandler(this.btnNovoProduto_Click);
            // 
            // frmAtendimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2568, 1310);
            this.Controls.Add(this.BtnOrcamento);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ucSessaoSistema2);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmAtendimento";
            this.Text = "Atendimento";
            this.Load += new System.EventHandler(this.frmAtendimento_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabProdutos.ResumeLayout(false);
            this.tabProdutos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrcamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnOrcamento;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ScrollSelecao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Persistencia.BancoDeDados.UCSessaoSistema ucSessaoSistema2;
        private System.Windows.Forms.Button btnNovoProduto;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProdutos;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.DataGridView dgvOrcamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colunaData;
        private System.Windows.Forms.DataGridViewButtonColumn colunaDetalhar;
    }
}