using HermoCommons;

namespace HermoItemManagers.Fields
{
    public partial class TextFieldEditor : Field
    {
        public TextFieldEditor(String name = "Field", String placeholderText = "", Style? style = null) : base(name, style)
        {
            InitializeComponent();

            PlaceholderText = placeholderText;
            charLimit = 50;
        }

        private int charLimit;

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
            get { return txtBoxValue.Text; }
        }

        public int CharLimit
        {
            get { return charLimit; }
            set { charLimit = value; }
        }

        public String PlaceholderText
        {
            get { return txtBoxValue.PlaceholderText; }
            set { txtBoxValue.PlaceholderText = value; }
        }

        public FilterType FilterType { get; set; }

        public bool Mandatory { get; set; }

        #endregion

        protected override void ResizeControls(int WidthDiff)
        {
            txtBoxValue.Anchor = AnchorStyles.None;
            txtBoxValue.Location = new Point(txtBoxValue.Location.X + WidthDiff, txtBoxValue.Location.Y);
            txtBoxValue.Width -= WidthDiff;
            txtBoxValue.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();

            Style.Apply(txtBoxValue, Style);
            Style.Apply(checkBoxActive, Style, BgType.Transparent);
        }

        #region Event Consumers

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

        private void txtBoxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            switch (FilterType)
            {
                case FilterType.DecimalNumbersOnly:
                    if (txtBoxValue.Text.Length >= charLimit)
                    {
                        e.Handled = true;
                        break;
                    }

                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        if (e.KeyChar != ',' && e.KeyChar != '.')
                        {
                            e.Handled = true;
                            break;
                        }
                    }

                    if (e.KeyChar == '.' || e.KeyChar == ',')
                    {
                        if (txtBoxValue.Text.Contains('.') || txtBoxValue.Text.Contains(","))
                        {
                            e.Handled = true;
                        }
                        else if (txtBoxValue.Text.Length == 0)
                        {
                            txtBoxValue.Text = "0";
                            txtBoxValue.Select(txtBoxValue.Text.Length, 0);
                        }
                    }

                    break;

                case FilterType.NumbersOnly:
                    if (txtBoxValue.Text.Length >= charLimit)
                    {
                        e.Handled = true;
                    }
                    else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }

                    break;

                case FilterType.Date:
                    if (txtBoxValue.Text.Length >= 10)
                    {
                        e.Handled = true;
                        break;
                    }

                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
                    {
                        e.Handled = true;
                        break;
                    }

                    switch (txtBoxValue.Text.Length)
                    {
                        case 1:
                            if (e.KeyChar == '/')
                            {
                                txtBoxValue.Text = "0" + txtBoxValue.Text;
                                txtBoxValue.Select(txtBoxValue.Text.Length, 0);
                            }
                            else
                            {
                                txtBoxValue.Text += e.KeyChar;
                                e.KeyChar = '/';
                                txtBoxValue.Select(txtBoxValue.Text.Length, 0);
                            }

                            break;

                        case 4:
                            if (e.KeyChar == '/')
                            {
                                String subStr = txtBoxValue.Text.Substring(0, 3);
                                txtBoxValue.Text = subStr + "0" + txtBoxValue.Text[3];
                                txtBoxValue.Select(txtBoxValue.Text.Length, 0);
                            }
                            else
                            {
                                txtBoxValue.Text += e.KeyChar;
                                e.KeyChar = '/';
                                txtBoxValue.Select(txtBoxValue.Text.Length, 0);
                            }

                            break;
                    }

                    break;
            }
        }

        private void TextFieldEditor_Resize(object sender, EventArgs e)
        {
            txtBoxValue.Width = this.Width - txtName.Location.X - txtBoxValue.Location.X;

            int x = this.Width - txtName.Location.X - checkBoxActive.Width + 2;
            checkBoxActive.Location = new Point(x, checkBoxActive.Location.Y);
        }

        #endregion
    }

    public enum FilterType
    {
        None,
        NumbersOnly,
        DecimalNumbersOnly,
        Date
    }
}