using System.Collections.ObjectModel;

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

        private int currentPage = 1;
        private int totPages = 1000;

        private int startPageInd = 0;
        private int endPageInd = -1;

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
                if (this.totPages != 0)
                {
                    if (value < FIRST_PAGE || value > this.TotPages)
                    {
                        return;
                    }
                }

                if (this.items is null || this.items.Count == 0)
                {
                    return;
                }

                if (this.renderedItems != null)
                {
                    this.renderedItems.Clear();
                }

                if (this.endPageInd >= this.startPageInd)
                {
                    int itemsPerPage = this.endPageInd - this.startPageInd + 1;

                    if (value > this.currentPage)
                    {
                        this.startPageInd += itemsPerPage * (value - this.currentPage);

                        if (this.startPageInd >= this.items.Count)
                        {
                            this.startPageInd = this.items.Count - 1;
                        }
                    }
                    else if (value < this.currentPage)
                    {
                        this.startPageInd -= itemsPerPage * (this.currentPage - value);

                        if (this.startPageInd < 0)
                        {
                            this.startPageInd = 0;
                        }
                    }

                    this.endPageInd = this.startPageInd - 1;
                }

                this.currentPage = value;
                this.txtBoxCurrentPage.Text = value.ToString();

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

        #region Helper Methods

        private void AddListItems(int count)
        {
            if (this.items is null || this.renderedItems is null)
            {
                return;
            }

            for (int i = 0; i < count; i++)
            {
                if (this.endPageInd + 1 < this.items.Count)
                {
                    this.endPageInd++;

                    this.renderedItems.Add((ListItem)Activator.CreateInstance(this.itemsType));
                    this.renderedItems[this.renderedItems.Count - 1].ItemDatas = this.items[endPageInd];
                    this.renderedItems[this.renderedItems.Count - 1].Dock = DockStyle.Top;
                }
                else if (this.startPageInd - 1 >= 0)
                {
                    this.startPageInd--;

                    this.renderedItems.Insert(0, (ListItem)Activator.CreateInstance(this.itemsType));
                    this.renderedItems[0].ItemDatas = this.items[startPageInd];
                    this.renderedItems[0].Dock = DockStyle.Top;
                }
            }
        }

        private void RemoveListItems(int count)
        {
            if (this.renderedItems is null)
            {
                return;
            }

            this.renderedItems.RemoveRange(this.renderedItems.Count - count, count);
            this.endPageInd -= count;
        }

        private void RefreshItemPanel()
        {
            if (this.renderedItems is null)
            {
                return;
            }

            this.itemsPanel.Controls.Clear();

            for (int i = this.renderedItems.Count - 1; i >= 0; i--)
            {
                this.itemsPanel.Controls.Add(this.renderedItems[i]);
            }
        }

        private void ResizeListItems()
        {
            if (this.renderedItems is null)
            {
                return;
            }

            int originalHeight = ((ListItem)Activator.CreateInstance(this.itemsType)).OriginalHeight;

            if (this.renderedItems.Count > 0)
            {
                int totalEccessHeight = this.itemsPanel.Height - this.renderedItems.Count * originalHeight;
                int eccessHeight = totalEccessHeight / this.renderedItems.Count;
                foreach (ListItem listItem in this.renderedItems)
                {
                    listItem.Height = originalHeight + eccessHeight;
                }
            }
        }

        #endregion

        private void UpdateRenderedItems()
        {
            if (this.items is null || this.items.Count == 0 || this.itemsType is null)
            {
                return;
            }

            if (this.renderedItems is null)
            {
                this.renderedItems = new List<ListItem>();
            }

            int originalHeight = ((ListItem)Activator.CreateInstance(this.itemsType)).OriginalHeight;
            int itemsPerPage = this.itemsPanel.Height / originalHeight;
            int oldTotPages = this.TotPages;

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

            // TODO aumenta e basta durante il ricalcolo.
            if (oldTotPages != 0 && oldTotPages != this.totPages && this.currentPage != FIRST_PAGE)
            {
                this.currentPage = (this.currentPage * this.TotPages) / oldTotPages;
                this.txtBoxCurrentPage.Text = this.currentPage.ToString();
            }

            if (this.renderedItems.Count != itemsPerPage)
            {
                if (this.renderedItems.Count > itemsPerPage)
                {
                    RemoveListItems(this.renderedItems.Count - itemsPerPage);
                }
                else if (this.renderedItems.Count < itemsPerPage)
                {
                    AddListItems(itemsPerPage - this.renderedItems.Count);
                }

                RefreshItemPanel();
            }

            ResizeListItems();
        }

        private void CustomList_Load(object sender, EventArgs e)
        {
            this.itemsPanel.Controls.Clear();
            this.itemsPanel.Controls.Add(this.txtPlaceHolder);
            this.txtPlaceHolder.Text = this.itemsNullMsg;
            this.TotPages = 0;
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