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
            get { return this.txtValue.Text; }
            set { this.txtValue.Text = value; }
        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();
            StyleAppliers.LinkLabel(this.txtValue, this.style);
        }

        private void txtValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(txtValue.Text);
            // TODO add prompt.
        }
    }
}