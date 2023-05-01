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
            jsonResult = "";
        }

        private Style style;
        private Request request;
        private String jsonResult;

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

        private void MakeSearch()
        {
            this.jsonResult = RestClient.HttpClient.MakeRequest(this.request,
                new String[] { this.textBoxQuery.Text }).Result;
        }

        private void ThrowSearchMadeEvent()
        {
            using (WaitForm waitForm = new(MakeSearch))
            {
                waitForm.Style = this.style;
                waitForm.ShowDialog();
            }

            SearchMadeEventArgs args = new()
            {
                JsonResult = this.jsonResult
            };

            OnSearchMade(args);
        }

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
            JsonResult = "";
        }

        public String JsonResult { get; set; }
    }
}