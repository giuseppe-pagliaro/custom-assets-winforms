namespace CustomSearchBars
{
    partial class CustomSearchBar
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
            buttonSearch = new Button();
            textBoxQuery = new TextBox();
            noFocusObj = new Label();
            SuspendLayout();
            // 
            // buttonSearch
            // 
            buttonSearch.Anchor = AnchorStyles.Top;
            buttonSearch.BackColor = SystemColors.ControlDark;
            buttonSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSearch.Location = new Point(469, 12);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(94, 30);
            buttonSearch.TabIndex = 0;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // textBoxQuery
            // 
            textBoxQuery.BackColor = SystemColors.ControlDark;
            textBoxQuery.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxQuery.Location = new Point(12, 12);
            textBoxQuery.Multiline = true;
            textBoxQuery.Name = "textBoxQuery";
            textBoxQuery.PlaceholderText = "Type Query Here";
            textBoxQuery.Size = new Size(451, 30);
            textBoxQuery.TabIndex = 1;
            textBoxQuery.KeyPress += textBoxQuery_KeyPress;
            // 
            // noFocusObj
            // 
            noFocusObj.AutoSize = true;
            noFocusObj.BackColor = Color.Transparent;
            noFocusObj.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            noFocusObj.Location = new Point(569, 12);
            noFocusObj.Name = "noFocusObj";
            noFocusObj.Size = new Size(0, 17);
            noFocusObj.TabIndex = 2;
            // 
            // CustomSearchBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(noFocusObj);
            Controls.Add(textBoxQuery);
            Controls.Add(buttonSearch);
            Name = "CustomSearchBar";
            Size = new Size(575, 54);
            Resize += CustomSearchBar_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSearch;
        private TextBox textBoxQuery;
        private Label noFocusObj;
    }
}
