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
            buttonEdit = new Button();
            noFocusObj = new Label();
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
            txtID.Click += ListItem_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonEdit.Location = new Point(474, 32);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(67, 29);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // noFocusObj
            // 
            noFocusObj.AutoSize = true;
            noFocusObj.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            noFocusObj.Location = new Point(343, 36);
            noFocusObj.Name = "noFocusObj";
            noFocusObj.Size = new Size(0, 17);
            noFocusObj.TabIndex = 2;
            // 
            // ListItem
            // 
            AutoScaleMode = AutoScaleMode.None;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(noFocusObj);
            Controls.Add(buttonEdit);
            Controls.Add(txtID);
            Name = "ListItem";
            Size = new Size(573, 173);
            Click += ListItem_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Label txtID;
        private Button buttonEdit;
        private Label noFocusObj;
    }
}
