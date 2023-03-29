using System.Text.RegularExpressions;

namespace CustomLists
{
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();

            originalHeight = this.Height;
        }

        private ItemDatas? itemDatas;
        private int originalHeight;

        public ItemDatas ItemDatas
        {
            get
            {
                if (itemDatas is null)
                {
                    ItemDatas emptyitemData = new();
                    emptyitemData.Id = 0;
                    return emptyitemData;
                }

                return ((ListItem)this.MemberwiseClone()).itemDatas;
            }

            set
            {
                itemDatas = value;
                this.Populate();
            }
        }

        public int OriginalHeight
        {
            get { return originalHeight; }
        }

        private String classNameToString()
        {
            if (itemDatas is null)
            {
                return "Null Class";
            }

            String rawName = itemDatas.GetType().Name;
            return Regex.Replace(rawName, @"(\p{Lu})", " $1").TrimStart();
        }

        public virtual void Populate()
        {
            if (itemDatas is null)
            {
                txtID.Text = "(Item ID is Null)";
            }
            else
            {
                txtID.Text = this.classNameToString() + " #" + itemDatas.Id.ToString();
            }
        }
    }
}