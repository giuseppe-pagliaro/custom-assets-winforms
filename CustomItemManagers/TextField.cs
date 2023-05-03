using Commons;

namespace CustomItemManagers
{
    public partial class TextField : UserControl
    {
        public TextField()
        {
            InitializeComponent();

            this.Name = "Field";
            this.Value = "(empty)";
            this.style = new();
        }

        public TextField(String name, String value)
        {
            InitializeComponent();

            this.Name = name;
            this.Value = value;
            this.style = new();
        }

        private Style style;

        public Style Style
        {
            get { return this.style; }
            set
            {
                this.style = value;
                this.ApplyStyle();
            }
        }

        public String FieldName
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }

        public String Value
        {
            get { return this.txtValue.Text; }
            set { this.txtValue.Text = value; }
        }

        public String Separator
        {
            get { return this.txtSeparator.Text; }
            set { this.txtSeparator.Text = value; }
        }

        protected virtual void ApplyStyle()
        {
            StyleAppliers.SecondaryBg(this, this.style);
            StyleAppliers.Label(this.txtName, this.style, FontStyle.Bold);
            StyleAppliers.Label(this.txtSeparator, this.style, FontStyle.Regular);
            StyleAppliers.Label(this.txtValue, this.style, FontStyle.Regular);
        }
    }
}