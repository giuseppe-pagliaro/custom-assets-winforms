using Commons;

namespace CustomItemManagers
{
    public partial class TextFieldEditor : Field
    {
        public TextFieldEditor()
        {
            InitializeComponent();
        }

        #region Properties

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

        public bool Mandatory { get; set; }

        #endregion

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
            Style.Apply(checkBoxActive, Style, BgType.Transparent);
        }

        private void checkBoxActive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxActive.Checked)
            {
                txtBoxValue.Enabled = true;
            }
            else
            {
                txtBoxValue.Enabled = false;
            }
        }
    }
}