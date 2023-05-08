namespace CustomItemManagers
{
    partial class CopyableTextField
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
            components = new System.ComponentModel.Container();
            txtValue = new LinkLabel();
            toolTipValue = new ToolTip(components);
            SuspendLayout();
            // 
            // txtValue
            // 
            txtValue.AutoSize = true;
            txtValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtValue.Location = new Point(109, 15);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(54, 25);
            txtValue.TabIndex = 4;
            txtValue.TabStop = true;
            txtValue.Text = "Value";
            txtValue.LinkClicked += txtValue_LinkClicked;
            txtValue.MouseLeave += txtValue_MouseLeave;
            // 
            // CopyableTextField
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtValue);
            Name = "CopyableTextField";
            Size = new Size(175, 52);
            Controls.SetChildIndex(txtName, 0);
            Controls.SetChildIndex(txtSeparator, 0);
            Controls.SetChildIndex(txtValue, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel txtValue;
        protected ToolTip toolTipValue;
    }
}
