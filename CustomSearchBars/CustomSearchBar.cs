using Commons;
using RestClient;

namespace CustomSearchBars
{
    public partial class CustomSearchBar : UserControl
    {
        public CustomSearchBar()
        {
            InitializeComponent();

            style = new();
            request = new();
        }

        private Style style;
        private Request request;

        public Style Style
        {
            get { return this.style; }
            set
            {
                this.style = value;

                StyleAppliers.PrimaryBg(this, style);
                StyleAppliers.TextBox(this.textBoxQuery, style);
                StyleAppliers.Button(this.buttonSearch, style);
            }
        }

        public Request Request
        {
            get { return this.request; }
            set { this.request = value; }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            noFocusObj.Focus();

            // TODO
        }

        private void textBoxQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                noFocusObj.Focus();

                // TODO
            }
        }
    }
}