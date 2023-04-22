namespace Example
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            customList = new CustomLists.CustomList();
            customSearchBar = new CustomSearchBars.CustomSearchBar();
            SuspendLayout();
            // 
            // customList
            // 
            customList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            customList.BackColor = SystemColors.Control;
            customList.CurrentPage = 1;
            customList.ItemsEmptyMsg = "No Items";
            customList.ItemsNullMsg = "Items is Null";
            customList.Location = new Point(0, 60);
            customList.Name = "customList";
            customList.Size = new Size(742, 473);
            customList.TabIndex = 0;
            customList.TotPagesMsg = " Pages";
            // 
            // customSearchBar
            // 
            customSearchBar.Dock = DockStyle.Top;
            customSearchBar.Location = new Point(0, 0);
            customSearchBar.Name = "customSearchBar";
            customSearchBar.Size = new Size(742, 54);
            customSearchBar.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(742, 533);
            Controls.Add(customSearchBar);
            Controls.Add(customList);
            Name = "MainForm";
            Text = "Main Form";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private CustomLists.CustomList customList;
        private CustomSearchBars.CustomSearchBar customSearchBar;
    }
}