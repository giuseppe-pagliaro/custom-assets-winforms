namespace CustomItemManagers
{
    partial class TextField
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
            txtName = new Label();
            txtSeparator = new Label();
            txtValue = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtName.AutoSize = true;
            txtName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtName.Location = new Point(12, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(68, 28);
            txtName.TabIndex = 0;
            txtName.Text = "Name";
            // 
            // txtSeparator
            // 
            txtSeparator.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtSeparator.AutoSize = true;
            txtSeparator.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txtSeparator.Location = new Point(86, 12);
            txtSeparator.Name = "txtSeparator";
            txtSeparator.Size = new Size(17, 28);
            txtSeparator.TabIndex = 1;
            txtSeparator.Text = ":";
            // 
            // txtValue
            // 
            txtValue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtValue.AutoSize = true;
            txtValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtValue.Location = new Point(109, 15);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(54, 25);
            txtValue.TabIndex = 2;
            txtValue.Text = "Value";
            // 
            // TextField
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            Controls.Add(txtValue);
            Controls.Add(txtSeparator);
            Controls.Add(txtName);
            Name = "TextField";
            Size = new Size(175, 52);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Label txtName;
        protected Label txtSeparator;
        protected Label txtValue;
    }
}
