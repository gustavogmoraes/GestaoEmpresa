namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    partial class GSDateTimePicker
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
            this.dateData = new System.Windows.Forms.DateTimePicker();
            this.dateHorario = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // dateData
            // 
            this.dateData.CustomFormat = "dd/MM/yyyy";
            this.dateData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateData.Location = new System.Drawing.Point(4, 5);
            this.dateData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateData.Name = "dateData";
            this.dateData.Size = new System.Drawing.Size(123, 29);
            this.dateData.TabIndex = 132;
            // 
            // dateHorario
            // 
            this.dateHorario.CustomFormat = "HH:mm";
            this.dateHorario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateHorario.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateHorario.Location = new System.Drawing.Point(137, 5);
            this.dateHorario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateHorario.Name = "dateHorario";
            this.dateHorario.ShowUpDown = true;
            this.dateHorario.Size = new System.Drawing.Size(66, 29);
            this.dateHorario.TabIndex = 133;
            this.dateHorario.Value = new System.DateTime(2018, 8, 24, 0, 0, 0, 0);
            // 
            // GSDateTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateData);
            this.Controls.Add(this.dateHorario);
            this.Name = "GSDateTimePicker";
            this.Size = new System.Drawing.Size(214, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateData;
        private System.Windows.Forms.DateTimePicker dateHorario;
    }
}
