namespace HermoSearchBars
{
    partial class HermoSearchBar
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
            textBoxQuery = new TextBox();
            buttonSearch = new Button();
            noFocusObj = new Label();
            SuspendLayout();
            // 
            // textBoxQuery
            // 
            textBoxQuery.BackColor = SystemColors.ControlDark;
            textBoxQuery.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxQuery.Location = new Point(18, 18);
            textBoxQuery.Margin = new Padding(4);
            textBoxQuery.Multiline = true;
            textBoxQuery.Name = "textBoxQuery";
            textBoxQuery.PlaceholderText = "Type Query Here";
            textBoxQuery.Size = new Size(674, 43);
            textBoxQuery.TabIndex = 1;
            textBoxQuery.KeyPress += textBoxQuery_KeyPress;
            // 
            // buttonSearch
            // 
            buttonSearch.Anchor = AnchorStyles.Top;
            buttonSearch.BackColor = SystemColors.ControlDark;
            buttonSearch.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSearch.Location = new Point(704, 18);
            buttonSearch.Margin = new Padding(4);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(141, 45);
            buttonSearch.TabIndex = 2;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = false;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // noFocusObj
            // 
            noFocusObj.AutoSize = true;
            noFocusObj.BackColor = Color.Transparent;
            noFocusObj.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            noFocusObj.Location = new Point(852, 23);
            noFocusObj.Margin = new Padding(4, 0, 4, 0);
            noFocusObj.Name = "noFocusObj";
            noFocusObj.Size = new Size(0, 25);
            noFocusObj.TabIndex = 0;
            // 
            // HermoSearchBar
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(noFocusObj);
            Controls.Add(buttonSearch);
            Controls.Add(textBoxQuery);
            Margin = new Padding(4);
            Name = "HermoSearchBar";
            Size = new Size(862, 81);
            Resize += HermoSearchBar_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxQuery;
        private Button buttonSearch;
        private Label noFocusObj;
    }
}
