using HermoCommons;

namespace HermoItemManagers.Fields
{
    public partial class TextField : Field
    {
        public TextField(string name = "Field", string value = "", Style? style = null) : base(name, style)
        {
            InitializeComponent();

            Value = value;
        }

        public string Value
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