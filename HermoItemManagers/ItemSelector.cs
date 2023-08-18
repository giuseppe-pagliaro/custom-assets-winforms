using HermoCommons;
using System.Collections.ObjectModel;

namespace HermoItemManagers
{
    public partial class ItemSelector : Form
    {
        public ItemSelector(Style? style = null)
        {
            InitializeComponent();

            this.style = style ?? Style.DEFAULT_STYLE;
            if (style is not null) ApplyStyle();
        }

        private Style style;

        public Color? ListBackgroundColor
        {
            get => customList.BackgroundColor;
            set => customList.BackgroundColor = value;
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

        public Style Style
        {
            get => style;

            set
            {
                style = value;
                ApplyStyle();
            }
        }

        private void ApplyStyle()
        {
            // TODO
        }
    }
}