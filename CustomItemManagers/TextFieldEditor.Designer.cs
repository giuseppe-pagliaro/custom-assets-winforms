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
            checkBoxActive = new CheckBox();
            SuspendLayout();
            // 
            // txtBoxValue
            // 
            txtBoxValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBoxValue.Enabled = false;
            txtBoxValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxValue.Location = new Point(109, 12);
            txtBoxValue.Name = "txtBoxValue";
            txtBoxValue.Size = new Size(219, 31);
            txtBoxValue.TabIndex = 4;
            txtBoxValue.KeyPress += txtBoxValue_KeyPress;
            // 
            // checkBoxActive
            // 
            checkBoxActive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxActive.AutoSize = true;
            checkBoxActive.BackColor = Color.Transparent;
            checkBoxActive.Location = new Point(312, 12);
            checkBoxActive.Name = "checkBoxActive";
            checkBoxActive.Size = new Size(18, 17);
            checkBoxActive.TabIndex = 6;
            checkBoxActive.UseVisualStyleBackColor = false;
            checkBoxActive.CheckedChanged += checkBoxActive_CheckedChanged;
            // 
            // TextFieldEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(checkBoxActive);
            Controls.Add(txtBoxValue);
            Name = "TextFieldEditor";
            Size = new Size(341, 52);
            Controls.SetChildIndex(txtName, 0);
            Controls.SetChildIndex(txtSeparator, 0);
            Controls.SetChildIndex(txtBoxValue, 0);
            Controls.SetChildIndex(checkBoxActive, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxValue;
        private CheckBox checkBoxActive;
    }
}
