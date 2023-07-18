using HermoCommons;

namespace HermoItemManagers.Fields
{
    public partial class PhoneFieldEditor : Field
    {
        public PhoneFieldEditor(String name = "Field", String placeholderText = "", Style? style = null) : base(name, style)
        {
            InitializeComponent();

            PlaceholderText = placeholderText;
            defaultIntPrefixIndex = 0;
        }

        private ushort defaultIntPrefixIndex;

        #region Properties

        public bool Togglable
        {
            get { return checkBoxActive.Enabled; }
            set
            {
                if (checkBoxActive.Enabled != value)
                {
                    checkBoxActive.Enabled = value;
                    checkBoxActive.Visible = value;
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
            get { return comboIntPrefix.SelectedText + " " + txtBoxValue.Text; }
        }

        public String PlaceholderText
        {
            get { return txtBoxValue.PlaceholderText; }
            set { txtBoxValue.PlaceholderText = value; }
        }

        public ushort DefaultIntPrefixIndex
        {
            get { return defaultIntPrefixIndex; }
            set
            {
                if (value >= comboIntPrefix.Items.Count)
                {
                    defaultIntPrefixIndex = 0;
                    comboIntPrefix.SelectedIndex = defaultIntPrefixIndex;
                }
                else
                {
                    defaultIntPrefixIndex = value;
                    comboIntPrefix.SelectedIndex = defaultIntPrefixIndex;
                }
            }
        }

        public bool Mandatory { get; set; }

        #endregion

        protected override void ResizeControls(int WidthDiff)
        {
            comboIntPrefix.Anchor = AnchorStyles.None;
            comboIntPrefix.Location = new Point(comboIntPrefix.Location.X + WidthDiff, comboIntPrefix.Location.Y);
            comboIntPrefix.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            txtBoxValue.Anchor = AnchorStyles.None;
            txtBoxValue.Location = new Point(txtBoxValue.Location.X + WidthDiff, txtBoxValue.Location.Y);
            txtBoxValue.Width -= WidthDiff;
            txtBoxValue.Anchor = AnchorStyles.Top | AnchorStyles.Left;

        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();

            Style.Apply(comboIntPrefix, Style);
            Style.Apply(txtBoxValue, Style);
            Style.Apply(checkBoxActive, Style, BgType.Transparent);
        }

        #region Event Consumers

        private void checkBoxActive_CheckedChanged(object sender, EventArgs e)
        {
            noFocusObj.Focus();

            if (checkBoxActive.Checked)
            {
                comboIntPrefix.Enabled = true;
                txtBoxValue.Enabled = true;
            }
            else
            {
                comboIntPrefix.Enabled = false;
                txtBoxValue.Enabled = false;
            }
        }

        private void txtBoxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            else if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (txtBoxValue.Text.Length >= 11)
            {
                e.Handled = true;
            }
            else if (txtBoxValue.Text.Length == 3)
            {
                txtBoxValue.Text += " ";
                txtBoxValue.Select(txtBoxValue.Text.Length, 0);
            }
        }

        private void PhoneFieldEditor_Resize(object sender, EventArgs e)
        {
            txtBoxValue.Width = this.Width - txtName.Location.X - txtBoxValue.Location.X;
            txtBoxValue.Height = comboIntPrefix.Height;

            int x = this.Width - txtName.Location.X - checkBoxActive.Width + 2;
            checkBoxActive.Location = new Point(x, checkBoxActive.Location.Y);
        }

        #endregion
    }
}