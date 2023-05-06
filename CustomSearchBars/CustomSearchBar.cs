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

        public Style Style
        {
            get { return style; }
            set
            {
                style = value;

                StyleAppliers.PrimaryBg(this, style);
                StyleAppliers.TextBox(textBoxQuery, style);
                StyleAppliers.Button(buttonSearch, style);
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

        #region Default Events

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

        #endregion

        protected virtual void OnSearchMade(SearchMadeEventArgs e)
        {
            SearchMade?.Invoke(this, e);
        }

        public event EventHandler<SearchMadeEventArgs>? SearchMade;
    }

    public class SearchMadeEventArgs : EventArgs
    {
        public SearchMadeEventArgs() : base()
        {
            Result = "";
        }

        public String Result { get; set; }
    }
}