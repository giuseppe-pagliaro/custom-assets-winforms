using HermoCommons;

namespace HermoItemManagers.Fields
{
    public partial class Field : UserControl
    {
        public Field(String name = "Field", Style? style = null)
        {
            InitializeComponent();

            Name = name;
            this.style = style ?? Style.DEFAULT_STYLE;
        }

        private Style style;

        #region Properties

        public Style Style
        {
            get { return style; }
            set
            {
                style = value;
                ApplyStyle();
            }
        }

        public String FieldName
        {
            get { return txtName.Text; }
            set
            {
                int oldTxtNameWidth = txtName.Width;
                txtName.Text = value;

                int newX = txtSeparator.Location.X + (txtName.Width - oldTxtNameWidth);
                txtSeparator.Location = new Point(newX, txtSeparator.Location.Y);

                ResizeControls(txtName.Width - oldTxtNameWidth);
            }
        }

        public String Separator
        {
            get { return txtSeparator.Text; }
            set
            {
                int oldTxtSeparatorWidth = txtSeparator.Width;
                txtSeparator.Text = value;

                ResizeControls(txtSeparator.Width - oldTxtSeparatorWidth);
            }
        }

        #endregion

        protected virtual void ResizeControls(int WidthDiff) { }

        protected virtual void ApplyStyle()
        {
            Style.Apply(this, style, BgType.Secondary);
            Style.Apply(txtName, style, FontStyle.Bold);
            Style.Apply(txtSeparator, style, FontStyle.Regular);
        }
    }
}