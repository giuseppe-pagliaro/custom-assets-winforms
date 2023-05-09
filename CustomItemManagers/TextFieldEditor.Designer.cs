namespace CustomItemManagers
{
    partial class TextFieldEditor
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
            txtBoxValue = new TextBox();
            buttonActive = new Button();
            SuspendLayout();
            // 
            // txtBoxValue
            // 
            txtBoxValue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtBoxValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxValue.Location = new Point(109, 12);
            txtBoxValue.Name = "txtBoxValue";
            txtBoxValue.Size = new Size(155, 31);
            txtBoxValue.TabIndex = 4;
            // 
            // buttonActive
            // 
            buttonActive.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            buttonActive.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonActive.Location = new Point(270, 12);
            buttonActive.Name = "buttonActive";
            buttonActive.Size = new Size(59, 31);
            buttonActive.TabIndex = 5;
            buttonActive.Text = "Edit";
            buttonActive.UseVisualStyleBackColor = true;
            buttonActive.Click += buttonActive_Click;
            // 
            // TextFieldEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonActive);
            Controls.Add(txtBoxValue);
            Name = "TextFieldEditor";
            Size = new Size(341, 52);
            Controls.SetChildIndex(txtName, 0);
            Controls.SetChildIndex(txtSeparator, 0);
            Controls.SetChildIndex(txtBoxValue, 0);
            Controls.SetChildIndex(buttonActive, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxValue;
        private Button buttonActive;
    }
}
