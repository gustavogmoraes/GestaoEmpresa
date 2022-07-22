namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    partial class BulkUpdateProductsModal
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLabel = new MetroFramework.Controls.MetroLabel();
            this.chkPorcentagemDeLucroCompraParaVenda = new MetroFramework.Controls.MetroCheckBox();
            this.chkPorcentagemDeLucroDistribuidorParaConsumidor = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnAplicar = new MetroFramework.Controls.MetroButton();
            this.lblPercent1 = new MetroFramework.Controls.MetroLabel();
            this.txtPctLucroVenda = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMetroMonetary();
            this.txtPctLucroConsFinal = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMetroMonetary();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtFilterSell = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMetroMonetary();
            this.chkFilterSell = new MetroFramework.Controls.MetroCheckBox();
            this.txtFilterFinalConsumer = new GS.GestaoEmpresa.Solucao.UI.ControlesGenericos.GSMetroMonetary();
            this.chkFilterConsumer = new MetroFramework.Controls.MetroCheckBox();
            this.lblFilters = new MetroFramework.Controls.MetroLabel();
            this.chkManufacturer = new MetroFramework.Controls.MetroCheckBox();
            this.comboManufacturer = new MetroFramework.Controls.MetroComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).BeginInit();
            this.panelTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelarExcluir
            // 
            this.btnCancelarExcluir.Visible = false;
            // 
            // btnEditarSalvar
            // 
            this.btnEditarSalvar.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(338, 30);
            this.lblTitulo.Text = "Atualização de produtos em massa";
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblLabel.Location = new System.Drawing.Point(64, 12);
            this.lblLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(277, 25);
            this.lblLabel.TabIndex = 0;
            this.lblLabel.Text = "Atualização de produtos em massa";
            this.lblLabel.UseCustomBackColor = true;
            // 
            // chkPorcentagemDeLucroCompraParaVenda
            // 
            this.chkPorcentagemDeLucroCompraParaVenda.AutoSize = true;
            this.chkPorcentagemDeLucroCompraParaVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.chkPorcentagemDeLucroCompraParaVenda.Location = new System.Drawing.Point(38, 317);
            this.chkPorcentagemDeLucroCompraParaVenda.Margin = new System.Windows.Forms.Padding(4);
            this.chkPorcentagemDeLucroCompraParaVenda.Name = "chkPorcentagemDeLucroCompraParaVenda";
            this.chkPorcentagemDeLucroCompraParaVenda.Size = new System.Drawing.Size(200, 15);
            this.chkPorcentagemDeLucroCompraParaVenda.TabIndex = 1;
            this.chkPorcentagemDeLucroCompraParaVenda.Text = "% de lucro da compra para venda";
            this.chkPorcentagemDeLucroCompraParaVenda.UseCustomBackColor = true;
            this.chkPorcentagemDeLucroCompraParaVenda.UseSelectable = true;
            // 
            // chkPorcentagemDeLucroDistribuidorParaConsumidor
            // 
            this.chkPorcentagemDeLucroDistribuidorParaConsumidor.AutoSize = true;
            this.chkPorcentagemDeLucroDistribuidorParaConsumidor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.chkPorcentagemDeLucroDistribuidorParaConsumidor.Location = new System.Drawing.Point(38, 355);
            this.chkPorcentagemDeLucroDistribuidorParaConsumidor.Margin = new System.Windows.Forms.Padding(4);
            this.chkPorcentagemDeLucroDistribuidorParaConsumidor.Name = "chkPorcentagemDeLucroDistribuidorParaConsumidor";
            this.chkPorcentagemDeLucroDistribuidorParaConsumidor.Size = new System.Drawing.Size(279, 15);
            this.chkPorcentagemDeLucroDistribuidorParaConsumidor.TabIndex = 2;
            this.chkPorcentagemDeLucroDistribuidorParaConsumidor.Text = "% de lucro do distribuídor para consumidor final";
            this.chkPorcentagemDeLucroDistribuidorParaConsumidor.UseCustomBackColor = true;
            this.chkPorcentagemDeLucroDistribuidorParaConsumidor.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(22, 274);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(314, 25);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Selecione os valores que deseja alterar: ";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // btnAplicar
            // 
            this.btnAplicar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnAplicar.Location = new System.Drawing.Point(192, 402);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(223, 39);
            this.btnAplicar.TabIndex = 7;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseSelectable = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // lblPercent1
            // 
            this.lblPercent1.AutoSize = true;
            this.lblPercent1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblPercent1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPercent1.Location = new System.Drawing.Point(435, 307);
            this.lblPercent1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercent1.Name = "lblPercent1";
            this.lblPercent1.Size = new System.Drawing.Size(26, 25);
            this.lblPercent1.TabIndex = 8;
            this.lblPercent1.Text = "%";
            this.lblPercent1.UseCustomBackColor = true;
            // 
            // txtPctLucroVenda
            // 
            this.txtPctLucroVenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtPctLucroVenda.BoxWidth = 45;
            this.txtPctLucroVenda.Location = new System.Drawing.Point(380, 304);
            this.txtPctLucroVenda.Margin = new System.Windows.Forms.Padding(4);
            this.txtPctLucroVenda.Name = "txtPctLucroVenda";
            this.txtPctLucroVenda.Size = new System.Drawing.Size(61, 39);
            this.txtPctLucroVenda.TabIndex = 107;
            this.txtPctLucroVenda.UseCustomBackColor = true;
            this.txtPctLucroVenda.UseCustomForeColor = true;
            this.txtPctLucroVenda.UseSelectable = true;
            this.txtPctLucroVenda.Value = null;
            // 
            // txtPctLucroConsFinal
            // 
            this.txtPctLucroConsFinal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtPctLucroConsFinal.BoxWidth = 45;
            this.txtPctLucroConsFinal.Location = new System.Drawing.Point(380, 344);
            this.txtPctLucroConsFinal.Margin = new System.Windows.Forms.Padding(4);
            this.txtPctLucroConsFinal.Name = "txtPctLucroConsFinal";
            this.txtPctLucroConsFinal.Size = new System.Drawing.Size(61, 39);
            this.txtPctLucroConsFinal.TabIndex = 108;
            this.txtPctLucroConsFinal.UseCustomBackColor = true;
            this.txtPctLucroConsFinal.UseCustomForeColor = true;
            this.txtPctLucroConsFinal.UseSelectable = true;
            this.txtPctLucroConsFinal.Value = null;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(435, 348);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(26, 25);
            this.metroLabel2.TabIndex = 109;
            this.metroLabel2.Text = "%";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.metroLabel3.Location = new System.Drawing.Point(-19, 240);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(651, 19);
            this.metroLabel3.TabIndex = 110;
            this.metroLabel3.Text = "_________________________________________________________________________________" +
    "__________________________";
            this.metroLabel3.UseCustomBackColor = true;
            // 
            // txtFilterSell
            // 
            this.txtFilterSell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtFilterSell.BoxWidth = 45;
            this.txtFilterSell.Location = new System.Drawing.Point(205, 90);
            this.txtFilterSell.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilterSell.Name = "txtFilterSell";
            this.txtFilterSell.Size = new System.Drawing.Size(50, 34);
            this.txtFilterSell.TabIndex = 113;
            this.txtFilterSell.UseCustomBackColor = true;
            this.txtFilterSell.UseCustomForeColor = true;
            this.txtFilterSell.UseSelectable = true;
            this.txtFilterSell.Value = null;
            // 
            // chkFilterSell
            // 
            this.chkFilterSell.AutoSize = true;
            this.chkFilterSell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.chkFilterSell.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkFilterSell.Location = new System.Drawing.Point(38, 100);
            this.chkFilterSell.Name = "chkFilterSell";
            this.chkFilterSell.Size = new System.Drawing.Size(430, 19);
            this.chkFilterSell.TabIndex = 114;
            this.chkFilterSell.Text = "Somente produtos com              % de lucro da compra para venda";
            this.chkFilterSell.UseCustomBackColor = true;
            this.chkFilterSell.UseSelectable = true;
            // 
            // txtFilterFinalConsumer
            // 
            this.txtFilterFinalConsumer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtFilterFinalConsumer.BoxWidth = 45;
            this.txtFilterFinalConsumer.Location = new System.Drawing.Point(205, 121);
            this.txtFilterFinalConsumer.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilterFinalConsumer.Name = "txtFilterFinalConsumer";
            this.txtFilterFinalConsumer.Size = new System.Drawing.Size(50, 34);
            this.txtFilterFinalConsumer.TabIndex = 115;
            this.txtFilterFinalConsumer.UseCustomBackColor = true;
            this.txtFilterFinalConsumer.UseCustomForeColor = true;
            this.txtFilterFinalConsumer.UseSelectable = true;
            this.txtFilterFinalConsumer.Value = null;
            // 
            // chkFilterConsumer
            // 
            this.chkFilterConsumer.AutoSize = true;
            this.chkFilterConsumer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.chkFilterConsumer.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkFilterConsumer.Location = new System.Drawing.Point(38, 131);
            this.chkFilterConsumer.Name = "chkFilterConsumer";
            this.chkFilterConsumer.Size = new System.Drawing.Size(519, 19);
            this.chkFilterConsumer.TabIndex = 116;
            this.chkFilterConsumer.Text = "Somente produtos com              % de lucro do distribuídor para consumidor fina" +
    "l";
            this.chkFilterConsumer.UseCustomBackColor = true;
            this.chkFilterConsumer.UseSelectable = true;
            // 
            // lblFilters
            // 
            this.lblFilters.AutoSize = true;
            this.lblFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblFilters.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblFilters.Location = new System.Drawing.Point(21, 65);
            this.lblFilters.Name = "lblFilters";
            this.lblFilters.Size = new System.Drawing.Size(56, 25);
            this.lblFilters.TabIndex = 117;
            this.lblFilters.Text = "Filtros";
            this.lblFilters.UseCustomBackColor = true;
            // 
            // chkManufacturer
            // 
            this.chkManufacturer.AutoSize = true;
            this.chkManufacturer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.chkManufacturer.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkManufacturer.Location = new System.Drawing.Point(38, 177);
            this.chkManufacturer.Name = "chkManufacturer";
            this.chkManufacturer.Size = new System.Drawing.Size(227, 19);
            this.chkManufacturer.TabIndex = 118;
            this.chkManufacturer.Text = "Somente produtos do fabricante ";
            this.chkManufacturer.UseCustomBackColor = true;
            this.chkManufacturer.UseSelectable = true;
            // 
            // comboManufacturer
            // 
            this.comboManufacturer.FormattingEnabled = true;
            this.comboManufacturer.ItemHeight = 23;
            this.comboManufacturer.Location = new System.Drawing.Point(272, 165);
            this.comboManufacturer.Name = "comboManufacturer";
            this.comboManufacturer.Size = new System.Drawing.Size(196, 29);
            this.comboManufacturer.TabIndex = 119;
            this.comboManufacturer.UseSelectable = true;
            // 
            // BulkUpdateProductsModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::GS.GestaoEmpresa.Properties.Resources.Background;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.None;
            this.ClientSize = new System.Drawing.Size(607, 476);
            this.Controls.Add(this.txtFilterFinalConsumer);
            this.Controls.Add(this.txtFilterSell);
            this.Controls.Add(this.comboManufacturer);
            this.Controls.Add(this.chkManufacturer);
            this.Controls.Add(this.lblFilters);
            this.Controls.Add(this.chkFilterConsumer);
            this.Controls.Add(this.chkFilterSell);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtPctLucroConsFinal);
            this.Controls.Add(this.txtPctLucroVenda);
            this.Controls.Add(this.lblPercent1);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.chkPorcentagemDeLucroDistribuidorParaConsumidor);
            this.Controls.Add(this.chkPorcentagemDeLucroCompraParaVenda);
            this.Controls.Add(this.lblLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BulkUpdateProductsModal";
            this.Padding = new System.Windows.Forms.Padding(27, 102, 27, 34);
            this.Load += new System.EventHandler(this.BulkUpdateProductsModal_Load);
            this.Controls.SetChildIndex(this.lblLabel, 0);
            this.Controls.SetChildIndex(this.chkPorcentagemDeLucroCompraParaVenda, 0);
            this.Controls.SetChildIndex(this.chkPorcentagemDeLucroDistribuidorParaConsumidor, 0);
            this.Controls.SetChildIndex(this.metroLabel1, 0);
            this.Controls.SetChildIndex(this.btnAplicar, 0);
            this.Controls.SetChildIndex(this.lblPercent1, 0);
            this.Controls.SetChildIndex(this.txtPctLucroVenda, 0);
            this.Controls.SetChildIndex(this.txtPctLucroConsFinal, 0);
            this.Controls.SetChildIndex(this.metroLabel2, 0);
            this.Controls.SetChildIndex(this.metroLabel3, 0);
            this.Controls.SetChildIndex(this.chkFilterSell, 0);
            this.Controls.SetChildIndex(this.chkFilterConsumer, 0);
            this.Controls.SetChildIndex(this.lblFilters, 0);
            this.Controls.SetChildIndex(this.chkManufacturer, 0);
            this.Controls.SetChildIndex(this.comboManufacturer, 0);
            this.Controls.SetChildIndex(this.panelTitulo, 0);
            this.Controls.SetChildIndex(this.txtFilterSell, 0);
            this.Controls.SetChildIndex(this.txtFilterFinalConsumer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarExcluir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditarSalvar)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblLabel;
        private MetroFramework.Controls.MetroCheckBox chkPorcentagemDeLucroCompraParaVenda;
        private MetroFramework.Controls.MetroCheckBox chkPorcentagemDeLucroDistribuidorParaConsumidor;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnAplicar;
        private MetroFramework.Controls.MetroLabel lblPercent1;
        public ControlesGenericos.GSMetroMonetary txtPctLucroVenda;
        public ControlesGenericos.GSMetroMonetary txtPctLucroConsFinal;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        public ControlesGenericos.GSMetroMonetary txtFilterSell;
        private MetroFramework.Controls.MetroCheckBox chkFilterSell;
        public ControlesGenericos.GSMetroMonetary txtFilterFinalConsumer;
        private MetroFramework.Controls.MetroCheckBox chkFilterConsumer;
        private MetroFramework.Controls.MetroLabel lblFilters;
        private MetroFramework.Controls.MetroCheckBox chkManufacturer;
        private MetroFramework.Controls.MetroComboBox comboManufacturer;
    }
}
