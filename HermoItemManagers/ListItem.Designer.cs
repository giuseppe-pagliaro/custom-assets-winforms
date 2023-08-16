namespace HermoItemManagers
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
            buttonEdit = new Button();
            noFocusObj = new Label();
            SuspendLayout();
            // 
            // buttonEdit
            // 
            buttonEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEdit.AutoSize = true;
            buttonEdit.Location = new Point(498, 35);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(67, 40);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // noFocusObj
            // 
            noFocusObj.AutoSize = true;
            noFocusObj.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            noFocusObj.Location = new Point(551, 127);
            noFocusObj.Name = "noFocusObj";
            noFocusObj.Size = new Size(0, 25);
            noFocusObj.TabIndex = 2;
            // 
            // ListItem
            // 
            AutoScaleMode = AutoScaleMode.None;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(noFocusObj);
            Controls.Add(buttonEdit);
            Name = "ListItem";
            Size = new Size(600, 200);
            Click += ListItem_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label noFocusObj;
        private Button buttonEdit;
    }
}
