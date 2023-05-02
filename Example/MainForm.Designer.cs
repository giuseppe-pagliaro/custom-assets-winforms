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
            Commons.Style style5 = new Commons.Style();
            RestClient.Request request3 = new RestClient.Request();
            Commons.Style style6 = new Commons.Style();
            customList = new CustomLists.CustomList();
            customSearchBar = new CustomSearchBars.CustomSearchBar();
            groupBoxStyles = new GroupBox();
            noFocusObj = new Label();
            buttonDarkMode = new Button();
            buttonLightMode = new Button();
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
            customList.Style = style5;
            customList.TabIndex = 0;
            customList.TotPagesMsg = " Pages";
            // 
            // customSearchBar
            // 
            customSearchBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            customSearchBar.BackColor = SystemColors.Control;
            customSearchBar.Location = new Point(288, 42);
            customSearchBar.Name = "customSearchBar";
            customSearchBar.Request = request3;
            customSearchBar.Size = new Size(500, 43);
            customSearchBar.Style = style6;
            customSearchBar.TabIndex = 1;
            // 
            // groupBoxStyles
            // 
            groupBoxStyles.BackColor = SystemColors.Control;
            groupBoxStyles.Controls.Add(noFocusObj);
            groupBoxStyles.Controls.Add(buttonDarkMode);
            groupBoxStyles.Controls.Add(buttonLightMode);
            groupBoxStyles.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBoxStyles.Location = new Point(12, 0);
            groupBoxStyles.Name = "groupBoxStyles";
            groupBoxStyles.Size = new Size(270, 84);
            groupBoxStyles.TabIndex = 2;
            groupBoxStyles.TabStop = false;
            groupBoxStyles.Text = "Styles";
            // 
            // noFocusObj
            // 
            noFocusObj.AutoSize = true;
            noFocusObj.BackColor = Color.Transparent;
            noFocusObj.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            noFocusObj.Location = new Point(260, 46);
            noFocusObj.Name = "noFocusObj";
            noFocusObj.Size = new Size(0, 17);
            noFocusObj.TabIndex = 2;
            // 
            // buttonDarkMode
            // 
            buttonDarkMode.BackColor = SystemColors.ControlDark;
            buttonDarkMode.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDarkMode.Location = new Point(143, 38);
            buttonDarkMode.Name = "buttonDarkMode";
            buttonDarkMode.Size = new Size(111, 36);
            buttonDarkMode.TabIndex = 1;
            buttonDarkMode.Text = "Dark Mode";
            buttonDarkMode.UseVisualStyleBackColor = false;
            buttonDarkMode.Click += buttonDarkMode_Click;
            // 
            // buttonLightMode
            // 
            buttonLightMode.BackColor = SystemColors.ControlDark;
            buttonLightMode.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLightMode.Location = new Point(15, 38);
            buttonLightMode.Name = "buttonLightMode";
            buttonLightMode.Size = new Size(115, 36);
            buttonLightMode.TabIndex = 0;
            buttonLightMode.Text = "Light Mode";
            buttonLightMode.UseVisualStyleBackColor = false;
            buttonLightMode.Click += buttonLightMode_Click;
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
            txtSearchInfo.Size = new Size(473, 23);
            txtSearchInfo.TabIndex = 4;
            txtSearchInfo.Text = "Get a list of universities in a specified country. (hipolabs.com)";
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
        private TextBox textBoxResult;
        private Label txtSearchInfo;
        private Button buttonDarkMode;
        private Button buttonLightMode;
        private Label noFocusObj;
    }
}