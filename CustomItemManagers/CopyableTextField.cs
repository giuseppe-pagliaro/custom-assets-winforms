using Commons;

namespace CustomItemManagers
{
    public partial class CopyableTextField : Field
    {
        public CopyableTextField() : base()
        {
            InitializeComponent();

            value = "(empty)";
            CopyMessage = "Click to copy.";
            CopiedMessage = "Copied.";
            toolTipValue.SetToolTip(txtValue, CopyMessage);
        }

        public CopyableTextField(String name, String value) : base(name)
        {
            InitializeComponent();

            clicked = false;
            this.value = value;
            CopyMessage = "Click to copy.";
            CopiedMessage = "Copied.";
            toolTipValue.SetToolTip(txtValue, CopyMessage);
        }

        public CopyableTextField(String name, String value, Style style) : base(name, style)
        {
            InitializeComponent();

            clicked = false;
            this.value = value;
            CopyMessage = "Click to copy.";
            CopiedMessage = "Copied.";
            toolTipValue.SetToolTip(txtValue, CopyMessage);
        }

        private bool clicked;
        private String value;

        #region Properties

        public String CopyMessage { get; set; }

        public String CopiedMessage { get; set; }

        public String Value
        {
            get { return value; }
            set
            {
                this.value = value;
                txtValue.Text = value;
            }
        }

        #endregion

        protected override void ResizeControls(int WidthDiff)
        {
            txtValue.Location = new Point(txtValue.Location.X + WidthDiff, txtValue.Location.Y);
        }

        protected override void ApplyStyle()
        {
            base.ApplyStyle();
            Style.Apply(txtValue, Style, LinkType.Normal);
        }

        #region Event Consumers

        private void txtValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtValue.Text = value + " ✓";
            txtValue.LinkColor = Style.InteractableFontColor;
            toolTipValue.SetToolTip(txtValue, CopiedMessage);
            clicked = true;

            Clipboard.SetText(value);
        }

        private void txtValue_MouseLeave(object sender, EventArgs e)
        {
            if (clicked)
            {
                clicked = false;
                txtValue.Text = value;
                txtValue.LinkColor = Style.LinkColor;
                toolTipValue.SetToolTip(txtValue, CopyMessage);
            }
        }

        #endregion
    }
}