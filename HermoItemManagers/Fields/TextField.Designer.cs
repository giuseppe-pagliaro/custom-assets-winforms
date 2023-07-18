namespace HermoItemManagers.Fields
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
            txtValue = new Label();
            SuspendLayout();
            // 
            // txtValue
            // 
            txtValue.AutoSize = true;
            txtValue.BackColor = Color.Transparent;
            txtValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtValue.Location = new Point(109, 15);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(54, 25);
            txtValue.TabIndex = 4;
            txtValue.Text = "Value";
            // 
            // TextField
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtValue);
            Name = "TextField";
            Size = new Size(175, 52);
            Controls.SetChildIndex(txtName, 0);
            Controls.SetChildIndex(txtSeparator, 0);
            Controls.SetChildIndex(txtValue, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtValue;
    }
}
