using HermoCommons;
using HermoRestClient;

namespace HermoSearchBars
{
    public partial class HermoSearchBar : UserControl
    {
        public HermoSearchBar()
        {
            InitializeComponent();

            style = Style.DEFAULT_STYLE;
            searchingMsg = "Searching";
        }

        private Style style;
        private Func<string, ItemDatas[]>? searchMethod;
        private string searchingMsg;

        #region Properties

        public string QueryPlaceholderText
        {
            get { return textBoxQuery.PlaceholderText; }
            set { textBoxQuery.PlaceholderText = value; }
        }

        public string ButtonText
        {
            get { return buttonSearch.Text; }
            set { buttonSearch.Text = value; }
        }

        public string SearchingMsg
        {
            get { return searchingMsg; }
            set { searchingMsg = value; }
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

        public Func<string, ItemDatas[]> SearchMethod
        {
            get
            {
                if (searchMethod is null) return query => { return Array.Empty<ItemDatas>(); };

                return new(searchMethod);
            }

            set { searchMethod = value; }
        }

        #endregion

        private void ThrowSearchMadeEvent()
        {
            if (searchMethod is null) return;

            ItemDatas[] result = Array.Empty<ItemDatas>();

            using (WaitForm waitForm = new(() => result = searchMethod(textBoxQuery.Text), style, searchingMsg))
            {
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

        private void HermoSearchBar_Resize(object sender, EventArgs e)
        {
            int x = this.Width - buttonSearch.Width - textBoxQuery.Location.X;
            buttonSearch.Location = new Point(x, buttonSearch.Location.Y);

            int offset = (int)Math.Round(textBoxQuery.Location.X * 2.5, 0);
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