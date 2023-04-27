using Commons;

namespace CustomSearchBars
{
    public partial class CustomSearchBar : UserControl
    {
        public CustomSearchBar()
        {
            InitializeComponent();

            style = new();
        }

        // public delegate void SearchRequest(String query);
        private Style style;

        public Style Style
        {
            get { return style; }
            set
            {
                style = value;

                StyleAppliers.PrimaryBg(this, style);
                StyleAppliers.TextBox(this.textBoxQuery, style);
                StyleAppliers.Button(this.buttonSearch, style);
            }
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