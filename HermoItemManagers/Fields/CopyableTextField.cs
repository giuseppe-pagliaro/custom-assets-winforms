using HermoCommons;

namespace HermoItemManagers.Fields
{
    public partial class CopyableTextField : Field
    {
        public CopyableTextField(String name = "Field", String value = "", Style? style = null) : base(name, style)
        {
            InitializeComponent();

            clicked = false;
            this.value = String.Empty;
            this.Value = value;
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