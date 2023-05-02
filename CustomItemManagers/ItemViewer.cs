using Commons;
using CustomLists;

namespace CustomItemManagers
{
    public partial class ItemViewer : Form
    {
        public ItemViewer()
        {
            InitializeComponent();

            this.style = new();
        }

        private ItemDatas? itemDatas;
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
                this.Text = "(Item ID is Null)";
            }
            else
            {
                this.Text = this.itemDatas.ClassNameToString() + " #" + this.itemDatas.Id.ToString();
            }
        }

        public virtual void ApplyStyle()
        {
            StyleAppliers.PrimaryBg(this, style);
        }
    }
}