namespace HermoItemManagers
{
    partial class ItemSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSelector));
            customList = new CustomList();
            hermoSearchBar = new HermoSearchBars.HermoSearchBar();
            SuspendLayout();
            // 
            // customList
            // 
            customList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            customList.BackColor = SystemColors.Control;
            customList.BackgroundColor = null;
            customList.BorderStyle = BorderStyle.FixedSingle;
            customList.CurrentPage = 1;
            customList.ItemsEmptyMsg = "No Items";
            customList.ItemsNullMsg = "Null Items";
            customList.Location = new Point(0, 89);
            customList.Margin = new Padding(4, 4, 4, 4);
            customList.Name = "customList";
            customList.Size = new Size(822, 798);
            customList.TabIndex = 0;
            customList.TotPagesMsg = " Pages";
            // 
            // hermoSearchBar
            // 
            hermoSearchBar.ButtonText = "Search";
            hermoSearchBar.Dock = DockStyle.Top;
            hermoSearchBar.Location = new Point(0, 0);
            hermoSearchBar.Margin = new Padding(4);
            hermoSearchBar.Name = "hermoSearchBar";
            hermoSearchBar.QueryPlaceholderText = "Type Query Here";
            hermoSearchBar.SearchingMsg = "Searching";
            hermoSearchBar.Size = new Size(822, 81);
            hermoSearchBar.TabIndex = 1;
            hermoSearchBar.SearchMade += hermoSearchBar_SearchMade;
            // 
            // ItemSelector
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 887);
            Controls.Add(hermoSearchBar);
            Controls.Add(customList);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ItemSelector";
            Text = "ItemSelector";
            ResumeLayout(false);
        }

        #endregion

        private CustomList customList;
        private HermoSearchBars.HermoSearchBar hermoSearchBar;
    }
}