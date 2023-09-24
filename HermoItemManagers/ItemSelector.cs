using HermoCommons;
using HermoRestClient;
using HermoSearchBars;
using System.Collections.ObjectModel;

namespace HermoItemManagers
{
    public partial class ItemSelector : Form
    {
        public ItemSelector(Style? style = null)
        {
            InitializeComponent();

            this.style = style ?? Style.DEFAULT_STYLE;
            isInit = false;

            if (style is not null) ApplyStyle();
        }

        private Style style;
        private bool isInit;

        #region Language Customization Properties

        public string ListItemsNullMsg
        {
            get => customList.ItemsNullMsg;
            set => customList.ItemsNullMsg = value;
        }

        public string ListItemsEmptyMsg
        {
            get => customList.ItemsEmptyMsg;
            set => customList.ItemsEmptyMsg = value;
        }

        public string ListTotPagesMsg
        {
            get => customList.TotPagesMsg;
            set => customList.TotPagesMsg = value;
        }

        public string SearchBarButtonText
        {
            get => hermoSearchBar.ButtonText;
            set => hermoSearchBar.ButtonText = value;
        }

        public string SearchBarQueryPlaceholderText
        {
            get => hermoSearchBar.QueryPlaceholderText;
            set => hermoSearchBar.QueryPlaceholderText = value;
        }

        public string SearchBarSearchingMsg
        {
            get => hermoSearchBar.SearchingMsg;
            set => hermoSearchBar.SearchingMsg = value;
        }

        #endregion

        #region Properties

        public Style Style
        {
            get => style;

            set
            {
                style = value;
                ApplyStyle();
            }
        }

        public int ListCurrentPage
        {
            get => customList.CurrentPage;
            set => customList.CurrentPage = value;
        }

        public int ListTotPages
        {
            get => customList.TotPages;
        }

        public ReadOnlyCollection<ItemDatas> ListItems
        {
            get => customList.Items;
        }

        public Color? ListBackgroundColor
        {
            get => customList.BackgroundColor;
            set => customList.BackgroundColor = value;
        }

        #endregion

        private void ApplyStyle()
        {
            Style.Apply(this, style, BgType.Primary);
            customList.Style = style;
            hermoSearchBar.Style = style;
        }

        public void InitSelectorEndpointMethods<T>(HermoEndpoint<T> hermoEndpoint) where T : ItemDatas
        {
            customList.SetItems(hermoEndpoint.GetNewItemsMethod(20).Invoke().Cast<ItemDatas>().ToList());
            hermoSearchBar.SearchMethod = hermoEndpoint.GetSearchMethod();

            isInit = true;
        }

        private void hermoSearchBar_SearchMade(object sender, SearchMadeEventArgs e)
        {
            if (!isInit) return;

            customList.SetItems(e.Result.ToList());
        }
    }
}