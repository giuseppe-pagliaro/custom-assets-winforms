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
            result = "";
        }

        private Style style;
        private Request request;
        private String result;

        #region Properties

        public String QueryPlaceholderText
        {
            get { return textBoxQuery.PlaceholderText; }
            set { textBoxQuery.PlaceholderText = value; }
        }

        public String ButtonText
        {
            get { return buttonSearch.Text; }
            set { buttonSearch.Text = value; }
        }

        public Style Style
        {
            get { return style; }
            set
            {
                style = value;

                Style.Apply(this, style, BgType.Primary);
                Style.Apply(textBoxQuery, style);
                Style.Apply(buttonSearch, style);
            }
        }

        public Request Request
        {
            get { return request; }
            set { request = value; }
        }

        #endregion

        private void MakeSearch()
        {
            result = RestClient.HttpClient.MakeRequest(request,
                new String[] { textBoxQuery.Text.Replace(" ", "+") }).Result;
        }

        private void ThrowSearchMadeEvent()
        {
            using (WaitForm waitForm = new(MakeSearch))
            {
                waitForm.Style = style;
                waitForm.ShowDialog();
            }

            SearchMadeEventArgs args = new()
            {
                Result = result
            };

            OnSearchMade(args);
        }

        #region Event Consumers

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            noFocusObj.Focus();
            ThrowSearchMadeEvent();
        }

        private void textBoxQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                noFocusObj.Focus();
                ThrowSearchMadeEvent();
            }
        }

        private void CustomSearchBar_Resize(object sender, EventArgs e)
        {
            int x = this.Width - buttonSearch.Width - textBoxQuery.Location.X;
            buttonSearch.Location = new Point(x, buttonSearch.Location.Y);

            int offset = (int)Math.Round(textBoxQuery.Location.X * 2.5);
            textBoxQuery.Width = this.Width - offset - buttonSearch.Width;
        }

        #endregion

        protected virtual void OnSearchMade(SearchMadeEventArgs e)
        {
            SearchMade?.Invoke(this, e);
        }

        public event EventHandler<SearchMadeEventArgs>? SearchMade;
    }
}