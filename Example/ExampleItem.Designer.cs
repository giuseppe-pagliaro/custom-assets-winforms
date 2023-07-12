namespace Example
{
    partial class ExampleItem
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
            CustomAssetsCommons.ItemDatas itemDatas1 = new();
            txtValue = new Label();
            SuspendLayout();
            // 
            // txtID
            // 
            txtID.Size = new Size(162, 31);
            txtID.Text = "Item Datas #0";
            // 
            // txtValue
            // 
            txtValue.AutoSize = true;
            txtValue.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtValue.Location = new Point(31, 104);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(97, 23);
            txtValue.TabIndex = 1;
            txtValue.Text = "Value: 1000";
            // 
            // ExampleItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtValue);
            itemDatas1.Id = 0;
            ItemDatas = itemDatas1;
            Name = "ExampleItem";
            Size = new Size(571, 173);
            Controls.SetChildIndex(txtID, 0);
            Controls.SetChildIndex(txtValue, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtValue;
    }
}
