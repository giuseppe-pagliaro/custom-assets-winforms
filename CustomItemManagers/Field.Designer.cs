namespace CustomItemManagers
{
    partial class Field
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            txtSeparator = new Label();
            txtName = new Label();
            SuspendLayout();
            // 
            // txtSeparator
            // 
            txtSeparator.AutoSize = true;
            txtSeparator.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtSeparator.Location = new Point(86, 12);
            txtSeparator.Name = "txtSeparator";
            txtSeparator.Size = new Size(17, 28);
            txtSeparator.TabIndex = 3;
            txtSeparator.Text = ":";
            // 
            // txtName
            // 
            txtName.AutoSize = true;
            txtName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtName.Location = new Point(12, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(68, 28);
            txtName.TabIndex = 2;
            txtName.Text = "Name";
            // 
            // Field
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            Controls.Add(txtSeparator);
            Controls.Add(txtName);
            Name = "Field";
            Size = new Size(180, 52);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Label txtSeparator;
        protected Label txtName;
    }
}
