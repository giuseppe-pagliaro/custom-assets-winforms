using Commons;

namespace CustomItemManagers
{
    public partial class CopyableTextField : Field
    {
        public CopyableTextField() : base()
        {
            InitializeComponent();

            Value = "(empty)";
        }

        public CopyableTextField(String name, String value) : base(name)
        {
            InitializeComponent();

            Value = value;
        }

        public CopyableTextField(String name, String value, Style style) : base(name, style)
        {
            InitializeComponent();

            Value = value;
        }

        public String Value
        {
            get { return txtValue.Text; }
            set { txtValue.Text = value; }
        }

        protected override void ResizeControls(int WidthDiff)
        {
            txtValue.Location = new Point(txtValue.Location.X + WidthDiff, txtValue.Location.Y);
        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();
            Style.Apply(txtValue, style, LinkType.Normal);
        }

        private void txtValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(txtValue.Text);
            // TODO add prompt.
        }
    }
}