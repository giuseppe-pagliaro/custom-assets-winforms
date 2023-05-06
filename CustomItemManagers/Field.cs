using Commons;

namespace CustomItemManagers
{
    public partial class Field : UserControl
    {
        public Field()
        {
            InitializeComponent();

            style = new();
            Name = "Field";
        }

        public Field(string name)
        {
            InitializeComponent();

            style = new();
            Name = name;
        }

        public Field(string name, Style style)
        {
            InitializeComponent();

            this.style = style;
            Name = name;
        }

        protected Style style;

        public Style Style
        {
            get { return this.style; }
            set
            {
                style = value;
                this.ApplyStyle();
            }
        }

        public String FieldName
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
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
        }
    }
}