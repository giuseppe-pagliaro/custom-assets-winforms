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
            Commons.Style style1 = new Commons.Style();
            Commons.Style style2 = new Commons.Style();
            customList = new CustomLists.CustomList();
            customSearchBar = new CustomSearchBars.CustomSearchBar();
            groupBoxStyles = new GroupBox();
            radioLightMode = new RadioButton();
            radioDarkMode = new RadioButton();
            textBoxResult = new TextBox();
            txtSearchInfo = new Label();
            groupBoxStyles.SuspendLayout();
            SuspendLayout();
            // 
            // customList
            // 
            customList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            customList.BackColor = SystemColors.Control;
            customList.BorderStyle = BorderStyle.FixedSingle;
            customList.CurrentPage = 1;
            customList.ItemsEmptyMsg = "No Items";
            customList.ItemsNullMsg = "Items is Null";
            customList.Location = new Point(12, 126);
            customList.Name = "customList";
            customList.Size = new Size(764, 519);
            customList.Style = style1;
            customList.TabIndex = 0;
            customList.TotPagesMsg = " Pages";
            // 
            // customSearchBar
            // 
            customSearchBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            customSearchBar.BackColor = SystemColors.Control;
            customSearchBar.Location = new Point(288, 42);
            customSearchBar.Name = "customSearchBar";
            customSearchBar.Size = new Size(500, 43);
            customSearchBar.Style = style2;
            customSearchBar.TabIndex = 1;
            // 
            // groupBoxStyles
            // 
            groupBoxStyles.BackColor = SystemColors.Control;
            groupBoxStyles.Controls.Add(radioLightMode);
            groupBoxStyles.Controls.Add(radioDarkMode);
            groupBoxStyles.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBoxStyles.Location = new Point(12, 0);
            groupBoxStyles.Name = "groupBoxStyles";
            groupBoxStyles.Size = new Size(270, 84);
            groupBoxStyles.TabIndex = 2;
            groupBoxStyles.TabStop = false;
            groupBoxStyles.Text = "Styles";
            // 
            // radioLightMode
            // 
            radioLightMode.AutoSize = true;
            radioLightMode.Checked = true;
            radioLightMode.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            radioLightMode.Location = new Point(12, 42);
            radioLightMode.Name = "radioLightMode";
            radioLightMode.Size = new Size(118, 27);
            radioLightMode.TabIndex = 1;
            radioLightMode.TabStop = true;
            radioLightMode.Text = "Light Mode";
            radioLightMode.UseVisualStyleBackColor = true;
            radioLightMode.CheckedChanged += radioLightMode_CheckedChanged;
            // 
            // radioDarkMode
            // 
            radioDarkMode.AutoSize = true;
            radioDarkMode.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            radioDarkMode.Location = new Point(145, 42);
            radioDarkMode.Name = "radioDarkMode";
            radioDarkMode.Size = new Size(115, 27);
            radioDarkMode.TabIndex = 0;
            radioDarkMode.Text = "Dark Mode";
            radioDarkMode.UseVisualStyleBackColor = true;
            radioDarkMode.CheckedChanged += radioDarkMode_CheckedChanged;
            // 
            // textBoxResult
            // 
            textBoxResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxResult.BorderStyle = BorderStyle.FixedSingle;
            textBoxResult.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxResult.Location = new Point(12, 90);
            textBoxResult.Name = "textBoxResult";
            textBoxResult.PlaceholderText = "Search Results Go Here";
            textBoxResult.ReadOnly = true;
            textBoxResult.Size = new Size(764, 30);
            textBoxResult.TabIndex = 3;
            // 
            // txtSearchInfo
            // 
            txtSearchInfo.AutoSize = true;
            txtSearchInfo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtSearchInfo.Location = new Point(297, 16);
            txtSearchInfo.Name = "txtSearchInfo";
            txtSearchInfo.Size = new Size(281, 23);
            txtSearchInfo.TabIndex = 4;
            txtSearchInfo.Text = "Looking for first result from Google.";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 657);
            Controls.Add(txtSearchInfo);
            Controls.Add(textBoxResult);
            Controls.Add(groupBoxStyles);
            Controls.Add(customSearchBar);
            Controls.Add(customList);
            Name = "MainForm";
            Text = "Example";
            Load += MainForm_Load;
            groupBoxStyles.ResumeLayout(false);
            groupBoxStyles.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomLists.CustomList customList;
        private CustomSearchBars.CustomSearchBar customSearchBar;
        private GroupBox groupBoxStyles;
        private RadioButton radioLightMode;
        private RadioButton radioDarkMode;
        private TextBox textBoxResult;
        private Label txtSearchInfo;
    }
}