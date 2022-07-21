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
            this.chkPorcentagemDeLucroCompraParaVenda.Location = new System.Drawing.Point(64, 130);
            this.chkPorcentagemDeLucroCompraParaVenda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.chkPorcentagemDeLucroDistribuidorParaConsumidor.Location = new System.Drawing.Point(64, 206);
            this.chkPorcentagemDeLucroDistribuidorParaConsumidor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.metroLabel1.Location = new System.Drawing.Point(64, 70);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(243, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Selecione os valores que deseja alterar: ";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // btnAplicar
            // 
            this.btnAplicar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnAplicar.Location = new System.Drawing.Point(145, 274);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.lblPercent1.Location = new System.Drawing.Point(461, 120);
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
            this.txtPctLucroVenda.Location = new System.Drawing.Point(406, 117);
            this.txtPctLucroVenda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.txtPctLucroConsFinal.Location = new System.Drawing.Point(406, 189);
            this.txtPctLucroConsFinal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.metroLabel2.Location = new System.Drawing.Point(461, 193);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(26, 25);
            this.metroLabel2.TabIndex = 109;
            this.metroLabel2.Text = "%";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // BulkUpdateProductsModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::GS.GestaoEmpresa.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(607, 327);
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
            this.Name = "BulkUpdateProductsModal";
            this.Padding = new System.Windows.Forms.Padding(27, 102, 27, 34);
            this.Controls.SetChildIndex(this.lblLabel, 0);
            this.Controls.SetChildIndex(this.chkPorcentagemDeLucroCompraParaVenda, 0);
            this.Controls.SetChildIndex(this.chkPorcentagemDeLucroDistribuidorParaConsumidor, 0);
            this.Controls.SetChildIndex(this.metroLabel1, 0);
            this.Controls.SetChildIndex(this.btnAplicar, 0);
            this.Controls.SetChildIndex(this.lblPercent1, 0);
            this.Controls.SetChildIndex(this.txtPctLucroVenda, 0);
            this.Controls.SetChildIndex(this.txtPctLucroConsFinal, 0);
            this.Controls.SetChildIndex(this.metroLabel2, 0);
            this.Controls.SetChildIndex(this.panelTitulo, 0);
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
    }
}
