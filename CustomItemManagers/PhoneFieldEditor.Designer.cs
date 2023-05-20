namespace CustomItemManagers
{
    partial class PhoneFieldEditor
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
            comboIntPrefix = new ComboBox();
            txtBoxValue = new TextBox();
            checkBoxActive = new CheckBox();
            noFocusObj = new Label();
            SuspendLayout();
            // 
            // comboIntPrefix
            // 
            comboIntPrefix.Enabled = false;
            comboIntPrefix.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboIntPrefix.FormattingEnabled = true;
            comboIntPrefix.Location = new Point(161, 18);
            comboIntPrefix.Name = "comboIntPrefix";
            comboIntPrefix.Size = new Size(121, 43);
            comboIntPrefix.TabIndex = 4;
            // 
            // txtBoxValue
            // 
            txtBoxValue.Enabled = false;
            txtBoxValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxValue.Location = new Point(288, 18);
            txtBoxValue.Multiline = true;
            txtBoxValue.Name = "txtBoxValue";
            txtBoxValue.Size = new Size(452, 43);
            txtBoxValue.TabIndex = 5;
            txtBoxValue.KeyPress += txtBoxValue_KeyPress;
            // 
            // checkBoxActive
            // 
            checkBoxActive.Anchor = AnchorStyles.Top;
            checkBoxActive.AutoSize = true;
            checkBoxActive.BackColor = Color.Transparent;
            checkBoxActive.Location = new Point(720, 18);
            checkBoxActive.Margin = new Padding(4);
            checkBoxActive.Name = "checkBoxActive";
            checkBoxActive.Size = new Size(22, 21);
            checkBoxActive.TabIndex = 8;
            checkBoxActive.UseVisualStyleBackColor = false;
            checkBoxActive.CheckedChanged += checkBoxActive_CheckedChanged;
            // 
            // noFocusObj
            // 
            noFocusObj.AutoSize = true;
            noFocusObj.Font = new Font("Segoe UI", 8.142858F, FontStyle.Regular, GraphicsUnit.Point);
            noFocusObj.Location = new Point(746, 31);
            noFocusObj.Name = "noFocusObj";
            noFocusObj.Size = new Size(0, 28);
            noFocusObj.TabIndex = 9;
            // 
            // PhoneFieldEditor
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(noFocusObj);
            Controls.Add(checkBoxActive);
            Controls.Add(txtBoxValue);
            Controls.Add(comboIntPrefix);
            Name = "PhoneFieldEditor";
            Size = new Size(758, 78);
            Resize += PhoneFieldEditor_Resize;
            Controls.SetChildIndex(txtName, 0);
            Controls.SetChildIndex(txtSeparator, 0);
            Controls.SetChildIndex(comboIntPrefix, 0);
            Controls.SetChildIndex(txtBoxValue, 0);
            Controls.SetChildIndex(checkBoxActive, 0);
            Controls.SetChildIndex(noFocusObj, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboIntPrefix;
        private TextBox txtBoxValue;
        private CheckBox checkBoxActive;
        private Label noFocusObj;
    }
}
