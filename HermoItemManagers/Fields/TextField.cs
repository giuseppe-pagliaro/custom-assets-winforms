using HermoCommons;

namespace HermoItemManagers.Fields
{
    public partial class TextField : Field
    {
        public TextField() : base()
        {
            InitializeComponent();

            Value = "(empty)";
        }

        public TextField(String name, String value) : base(name)
        {
            InitializeComponent();

            Value = value;
        }

        public TextField(String name, String value, Style style) : base(name, style)
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
            Style.Apply(txtValue, Style, FontStyle.Regular);
        }
    }
}