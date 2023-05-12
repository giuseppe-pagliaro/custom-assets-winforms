using Commons;

namespace CustomItemManagers
{
    public partial class PathFieldEditor : Field
    {
        public PathFieldEditor()
        {
            InitializeComponent();

            togglable = true;
            active = false;

            Togglable = false;
            FileDialogMessage = "Select Folder";
            OpenDialogType = OpenDialogType.Folder;
            OpenDialogFilters = Array.Empty<OpenDialogFilter>();
        }

        private static readonly OpenDialogFilter ALL_FILES_FILTER = new("All files", "*.*");

        private bool active;
        private bool togglable;

        #region Properties

        public String BrowseButtonText
        {
            get { return buttonBrowse.Text; }
            set { buttonBrowse.Text = value; }
        }

        public String ActiveButtonText
        {
            get { return buttonActive.Text; }
            set { buttonActive.Text = value; }
        }

        public String FileDialogMessage { get; set; }

        public OpenDialogType OpenDialogType { get; set; }

        public OpenDialogFilter[] OpenDialogFilters { get; set; }

        public bool Togglable
        {
            get { return togglable; }
            set
            {
                if (togglable != value)
                {
                    togglable = value;

                    if (togglable)
                    {
                        buttonActive.Enabled = true;
                        buttonActive.Visible = true;
                        buttonBrowse.Enabled = true;
                        buttonBrowse.Visible = true;
                        txtBoxValue.Width -= buttonActive.Width - buttonBrowse.Width;

                        active = false;
                        buttonActive.BackColor = Style.SecondaryInteractableColor;
                        txtBoxValue.Enabled = false;
                    }
                    else
                    {
                        buttonActive.Enabled = false;
                        buttonActive.Visible = false;
                        buttonBrowse.Enabled = false;
                        buttonBrowse.Visible = false;
                        txtBoxValue.Width += buttonActive.Width - buttonBrowse.Width;
                    }
                }
            }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public String Value
        {
            get { return txtBoxValue.Text; }
        }

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
            txtBoxValue.Width -= WidthDiff;
            txtBoxValue.Location = new Point(txtBoxValue.Location.X + WidthDiff, txtBoxValue.Location.Y);
            buttonBrowse.Location = new Point(buttonBrowse.Location.X + WidthDiff, buttonBrowse.Location.Y);
            buttonActive.Location = new Point(buttonActive.Location.X + WidthDiff, buttonActive.Location.Y);
        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();

            Style.Apply(txtBoxValue, Style);
            Style.Apply(buttonActive, Style);
            Style.Apply(buttonBrowse, Style);

            if (!active)
            {
                buttonActive.BackColor = Style.SecondaryInteractableColor;
                buttonBrowse.BackColor = Style.SecondaryInteractableColor;
            }
        }

        #region Event Consumers

        private void buttonActive_Click(object sender, EventArgs e)
        {
            if (active)
            {
                active = false;
                buttonActive.BackColor = Style.SecondaryInteractableColor;
                buttonBrowse.BackColor = Style.SecondaryInteractableColor;
                txtBoxValue.Enabled = false;
            }
            else
            {
                active = true;
                buttonActive.BackColor = Style.PrimaryInteractableColor;
                buttonBrowse.BackColor = Style.SecondaryInteractableColor;
                txtBoxValue.Enabled = true;
            }
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
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

        #endregion
    }

    public enum OpenDialogType
    {
        Folder,
        File
    }
}