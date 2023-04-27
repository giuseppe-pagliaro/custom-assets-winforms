namespace CustomLists
{
    partial class ListItem
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
            txtID = new Label();
            SuspendLayout();
            // 
            // txtID
            // 
            txtID.AutoSize = true;
            txtID.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtID.Location = new Point(31, 30);
            txtID.Name = "txtID";
            txtID.Size = new Size(169, 31);
            txtID.TabIndex = 0;
            txtID.Text = "Object #99999";
            // 
            // ListItem
            // 
            AutoScaleMode = AutoScaleMode.None;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(txtID);
            Name = "ListItem";
            Size = new Size(571, 171);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label txtID;
    }
}
