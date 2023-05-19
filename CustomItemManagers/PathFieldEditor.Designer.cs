namespace CustomItemManagers
{
    partial class PathFieldEditor
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
            buttonBrowse = new Button();
            checkBoxActive = new CheckBox();
            noFocusObj = new Label();
            SuspendLayout();
            // 
            // txtBoxValue
            // 
            txtBoxValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBoxValue.Enabled = false;
            txtBoxValue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxValue.Location = new Point(109, 12);
            txtBoxValue.Name = "txtBoxValue";
            txtBoxValue.ReadOnly = true;
            txtBoxValue.Size = new Size(292, 31);
            txtBoxValue.TabIndex = 4;
            // 
            // buttonBrowse
            // 
            buttonBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonBrowse.Enabled = false;
            buttonBrowse.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonBrowse.Location = new Point(407, 12);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(86, 31);
            buttonBrowse.TabIndex = 5;
            buttonBrowse.Text = "Browse";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // checkBoxActive
            // 
            checkBoxActive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxActive.AutoSize = true;
            checkBoxActive.BackColor = Color.Transparent;
            checkBoxActive.Location = new Point(385, 12);
            checkBoxActive.Name = "checkBoxActive";
            checkBoxActive.Size = new Size(18, 17);
            checkBoxActive.TabIndex = 7;
            checkBoxActive.UseVisualStyleBackColor = false;
            checkBoxActive.CheckedChanged += checkBoxActive_CheckedChanged;
            // 
            // noFocusObj
            // 
            noFocusObj.AutoSize = true;
            noFocusObj.BackColor = Color.Transparent;
            noFocusObj.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            noFocusObj.Location = new Point(499, 21);
            noFocusObj.Name = "noFocusObj";
            noFocusObj.Size = new Size(0, 17);
            noFocusObj.TabIndex = 8;
            // 
            // PathFieldEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(noFocusObj);
            Controls.Add(checkBoxActive);
            Controls.Add(buttonBrowse);
            Controls.Add(txtBoxValue);
            Name = "PathFieldEditor";
            Size = new Size(505, 52);
            Controls.SetChildIndex(txtName, 0);
            Controls.SetChildIndex(txtSeparator, 0);
            Controls.SetChildIndex(txtBoxValue, 0);
            Controls.SetChildIndex(buttonBrowse, 0);
            Controls.SetChildIndex(checkBoxActive, 0);
            Controls.SetChildIndex(noFocusObj, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxValue;
        private Button buttonBrowse;
        private CheckBox checkBoxActive;
        private Label noFocusObj;
    }
}
