using Commons;

namespace CustomItemManagers
{
    public partial class PathFieldEditor : Field
    {
        public PathFieldEditor()
        {
            InitializeComponent();

            FileDialogMessage = "Select Folder";
            OpenDialogType = OpenDialogType.Folder;
            OpenDialogFilters = Array.Empty<OpenDialogFilter>();
        }

        private static readonly OpenDialogFilter ALL_FILES_FILTER = new("All files", "*.*");

        #region Properties

        public String BrowseButtonText
        {
            get { return buttonBrowse.Text; }
            set { buttonBrowse.Text = value; }
        }

        public String FileDialogMessage { get; set; }

        public OpenDialogType OpenDialogType { get; set; }

        public OpenDialogFilter[] OpenDialogFilters { get; set; }

        public bool Togglable
        {
            get { return checkBoxActive.Enabled; }
            set
            {
                if (checkBoxActive.Enabled == value)
                {
                    return;
                }

                if (value)
                {
                    checkBoxActive.Enabled = true;
                    checkBoxActive.Visible = true;
                }
                else
                {
                    checkBoxActive.Enabled = false;
                    checkBoxActive.Visible = false;
                }
            }
        }

        public bool Active
        {
            get { return checkBoxActive.Checked; }
            set { checkBoxActive.Checked = value; }
        }

        public String Value
        {
            get { return txtBoxValue.Text; }
        }

        public String PlaceholderText
        {
            get { return txtBoxValue.PlaceholderText; }
            set { txtBoxValue.PlaceholderText = value; }
        }

        public bool Mandatory { get; set; }

        #endregion

        private String FormatDialogFilters()
        {
            String formattedDialogFilters = ALL_FILES_FILTER.ToString();
            for (int i = 1; i < OpenDialogFilters.Length - 1; i++)
            {
                formattedDialogFilters += "|" + OpenDialogFilters[i] + "|";
            }
            formattedDialogFilters += OpenDialogFilters[OpenDialogFilters.Length - 1];

            return formattedDialogFilters;
        }

        protected override void ResizeControls(int WidthDiff)
        {
            txtBoxValue.Anchor = AnchorStyles.None;
            txtBoxValue.Location = new Point(txtBoxValue.Location.X + WidthDiff, txtBoxValue.Location.Y);
            txtBoxValue.Width -= WidthDiff;
            txtBoxValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();

            Style.Apply(txtBoxValue, Style);
            Style.Apply(buttonBrowse, Style);

            if (!checkBoxActive.Checked)
            {
                buttonBrowse.BackColor = Style.SecondaryInteractableColor;
            }
        }

        #region Event Consumers

        private void checkBoxActive_CheckedChanged(object sender, EventArgs e)
        {
            noFocusObj.Focus();

            if (checkBoxActive.Checked)
            {
                buttonBrowse.BackColor = Style.PrimaryInteractableColor;
                buttonBrowse.Enabled = true;
                txtBoxValue.Enabled = true;
            }
            else
            {
                buttonBrowse.BackColor = Style.SecondaryInteractableColor;
                buttonBrowse.Enabled = false;
                txtBoxValue.Enabled = false;
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            noFocusObj.Focus();

            if (OpenDialogType == OpenDialogType.Folder)
            {
                FolderBrowserDialog folderBrowserDialog = new();

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtBoxValue.Text = folderBrowserDialog.SelectedPath;
                }
                else
                {
                    txtBoxValue.Text = "";
                }
            }
            else
            {
                OpenFileDialog openFileDialog = new();
                openFileDialog.Title = FileDialogMessage;
                openFileDialog.InitialDirectory = @"C:\";
                openFileDialog.Filter = FormatDialogFilters();

                if (OpenDialogFilters.Length == 0)
                {
                    openFileDialog.FilterIndex = 0;
                }
                else
                {
                    openFileDialog.FilterIndex = 1;
                }

                openFileDialog.ShowDialog();
                txtBoxValue.Text = openFileDialog.FileName;
            }
        }

        private void PathFieldEditor_Resize(object sender, EventArgs e)
        {
            int x = this.Width - txtName.Location.X - buttonBrowse.Width;
            buttonBrowse.Location = new Point(x, buttonBrowse.Location.Y);

            int offset = (int)Math.Round(txtName.Location.X * 1.5, 0);
            txtBoxValue.Width = this.Width - offset - buttonBrowse.Width - txtBoxValue.Location.X;

            offset = (int)Math.Round(txtName.Location.X * 1.5, 0) - 2;
            x = this.Width - offset - buttonBrowse.Width - checkBoxActive.Width;
            checkBoxActive.Location = new Point(x, checkBoxActive.Location.Y);
        }

        #endregion
    }

    public enum OpenDialogType
    {
        Folder,
        File
    }
}