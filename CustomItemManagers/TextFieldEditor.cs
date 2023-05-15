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

        #endregion

        protected override void ResizeControls(int WidthDiff)
        {
            txtBoxValue.Width -= WidthDiff;
            txtBoxValue.Location = new Point(txtBoxValue.Location.X + WidthDiff, txtBoxValue.Location.Y);
        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();

            Style.Apply(txtBoxValue, Style);

            if (!checkBoxActive.Checked)
            {
                buttonActive.BackColor = Style.SecondaryInteractableColor;
            }
        }

        private void buttonActive_Click(object sender, EventArgs e)
        {
            if (checkBoxActive.Checked)
            {
                txtBoxValue.Enabled = false;
            }
            else
            {
                txtBoxValue.Enabled = true;
            }
        }
    }
}