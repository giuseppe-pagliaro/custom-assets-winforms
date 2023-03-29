using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace CustomLists
{
    public partial class CustomList : UserControl
    {
        public CustomList()
        {
            InitializeComponent();
        }

        private static readonly int FIRST_PAGE = 1;

        private String itemsNullMsg = "Null Items";
        private String itemsEmptyMsg = "No Items";
        private String totPagesMsg = " Pages";

        private int currentPage;
        private int totPages;

        private List<ItemDatas>? items;
        private List<ListItem>? renderedItems;
        private Type? itemsType;

        public String ItemsNullMsg
        {
            get { return itemsNullMsg; }
            set { itemsNullMsg = value; }
        }

        public String ItemsEmptyMsg
        {
            get { return itemsEmptyMsg; }
            set { itemsEmptyMsg = value; }
        }

        public String TotPagesMsg
        {
            get { return totPagesMsg; }
            set
            {
                totPagesMsg = value;
                this.txtPageCount.Text = this.totPages.ToString() + this.totPagesMsg;
            }
        }

        public ReadOnlyCollection<ItemDatas> Items
        {
            get
            {
                if (items == null)
                {
                    return new ReadOnlyCollection<ItemDatas>(new List<ItemDatas>());
                }
                return items.AsReadOnly();
            }
        }
        public void setItems<TItemDatas, TListItem>(List<TItemDatas> itemDatas)
        where TItemDatas : ItemDatas where TListItem : ListItem
        {
            if (itemDatas is null)
            {
                this.itemsPanel.Controls.Clear();
                this.itemsPanel.Controls.Add(this.txtPlaceHolder);
                this.txtPlaceHolder.Text = this.itemsNullMsg;
                this.TotPages = 0;
                return;
            }

            if (itemDatas.Count == 0)
            {
                this.itemsPanel.Controls.Clear();
                this.itemsPanel.Controls.Add(this.txtPlaceHolder);
                this.txtPlaceHolder.Text = this.itemsEmptyMsg;
                this.TotPages = 0;
                return;
            }

            this.items = itemDatas.Cast<ItemDatas>().ToList();
            this.itemsType = typeof(TListItem);
            this.CurrentPage = FIRST_PAGE;
        }

        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                if (this.items is null || this.items.Count == 0)
                {
                    return;
                }

                currentPage = value;
                this.txtBoxCurrentPage.Text = value.ToString();

                if (this.renderedItems != null)
                {
                    this.renderedItems.Clear();
                }
                
                UpdateRenderedItems();
            }
        }

        public int TotPages
        {
            get { return totPages; }
            private set
            {
                totPages = value;
                this.txtPageCount.Text = value.ToString() + this.totPagesMsg;
            }
        }

        private void UpdateRenderedItems()
        {
            // Integrity Checks

            if (this.items is null || this.items.Count == 0 || this.itemsType is null)
            {
                return;
            }

            if (this.renderedItems is null)
            {
                this.renderedItems = new List<ListItem>();
            }

            // Add or Remove ListItems (if needed)

            int originalHeight = ((ListItem)Activator.CreateInstance(this.itemsType)).OriginalHeight;
            int itemsPerPage = this.itemsPanel.Height / originalHeight;
            if (itemsPerPage > 0)
            {
                if (this.items.Count % itemsPerPage == 0)
                {
                    this.TotPages = this.items.Count / itemsPerPage;
                }
                else
                {
                    this.TotPages = this.items.Count / itemsPerPage + 1;
                }
            }
            else
            {
                this.TotPages = 0;
            }

            if (this.renderedItems.Count > itemsPerPage)
            {
                int itemsToRemove = this.renderedItems.Count - itemsPerPage;
                this.renderedItems.RemoveRange(this.renderedItems.Count - itemsToRemove, itemsToRemove);
            }
            else if (this.renderedItems.Count < itemsPerPage)
            {
                // TODO fix dataInd
                int itemsToAdd = itemsPerPage - this.renderedItems.Count;
                int baseInd = this.items.Count - itemsPerPage * (this.totPages - this.currentPage + 1);
                baseInd += this.renderedItems.Count;
                if (itemsPerPage > 0 && this.items.Count % itemsPerPage != 0)
                {
                    baseInd += this.items.Count % itemsPerPage + 1;
                }

                for (int i = 0; i < itemsToAdd; i++)
                {
                    int dataInd = baseInd + i;
                    this.renderedItems.Add((ListItem)Activator.CreateInstance(this.itemsType));
                    this.renderedItems[this.renderedItems.Count - 1].ItemDatas = this.items[dataInd];
                    this.renderedItems[this.renderedItems.Count - 1].Dock = DockStyle.Top;
                }
            }

            // Refresh ItemPanel Controls

            this.itemsPanel.Controls.Clear();
            for (int i = this.renderedItems.Count - 1; i >= 0; i--)
            {
                this.itemsPanel.Controls.Add(this.renderedItems[i]);
            }

            // Resize ListItems

            if (itemsPerPage > 0)
            {
                int totalEccessHeight = this.itemsPanel.Height - itemsPerPage * originalHeight;
                int eccessHeight = totalEccessHeight / itemsPerPage;
                foreach (ListItem listItem in this.renderedItems)
                {
                    listItem.Height = originalHeight + eccessHeight;
                }
            }
        }

        private void CustomList_Load(object sender, EventArgs e)
        {
            this.txtPlaceHolder.Visible = true;
            this.txtPlaceHolder.Text = itemsEmptyMsg;
        }

        private void txtBoxCurrentPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (this.txtBoxCurrentPage.Text != this.currentPage.ToString())
                {
                    int newPage = Int32.Parse(txtBoxCurrentPage.Text);

                    if (newPage >= FIRST_PAGE || newPage <= this.totPages)
                    {
                        this.CurrentPage = newPage;
                    }
                    else
                    {
                        this.txtBoxCurrentPage.Text = newPage.ToString();
                    }
                }

                noFocusObj.Focus();
                e.Handled = true;
            }
        }

        private void itemsPanel_SizeChanged(object sender, EventArgs e)
        {
            UpdateRenderedItems();
        }

        private void txtBoxCurrentPage_TextChanged(object sender, EventArgs e)
        {
            // Serve ???
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (this.currentPage != FIRST_PAGE)
            {
                this.CurrentPage--;
            }
            noFocusObj.Focus();
        }

        private void buttonAvanti_Click(object sender, EventArgs e)
        {
            if (this.currentPage != this.totPages)
            {
                this.CurrentPage++;
            }
            noFocusObj.Focus();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.CurrentPage = FIRST_PAGE;
            noFocusObj.Focus();
        }

        private void buttonFine_Click(object sender, EventArgs e)
        {
            this.CurrentPage = this.totPages;
            noFocusObj.Focus();
        }
    }
}