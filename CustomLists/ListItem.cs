using Commons;

namespace CustomLists
{
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();

            originalHeight = this.Height;
            style = new();
        }

        private ItemDatas? itemDatas;
        private int originalHeight;

        private Style style;

        public ItemDatas ItemDatas
        {
            get
            {
                if (itemDatas is null)
                {
                    return new ItemDatas();
                }

                return itemDatas.Clone();
            }
            set
            {
                this.itemDatas = value;
                this.Populate();
            }
        }

        internal int OriginalHeight
        {
            get { return originalHeight; }
        }

        public Style Style
        {
            get { return style; }
            set
            {
                style = value;
                this.ApplyStyle();
            }
        }

        public virtual void Populate()
        {
            if (itemDatas is null)
            {
                this.txtID.Text = "(Item ID is Null)";
            }
            else
            {
                this.txtID.Text = this.itemDatas.ClassNameToString() + " #" + this.itemDatas.Id.ToString();
            }
        }

        public virtual void ApplyStyle()
        {
            StyleAppliers.SecondaryBg(this, style);
            StyleAppliers.Label(this.txtID, style, FontStyle.Bold);
        }
    }
}