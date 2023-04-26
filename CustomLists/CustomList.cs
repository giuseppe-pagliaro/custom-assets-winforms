using Commons;
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

        private int currentPage;
        private int totPages;
        private int startPageInd;
        private int endPageInd;

        private List<ItemDatas>? items;
        private List<ListItem>? renderedItems;
        private Type? itemsType;

        private Style style = new Style();

        #region Properties

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
                SetRenderedItemsNull();
                return;
            }

            if (itemDatas.Count == 0)
            {
                SetRenderedItemsEmpty();
                return;
            }

            this.items = itemDatas.Cast<ItemDatas>().ToList();
            this.itemsType = typeof(TListItem);
            this.TotPages = 0;
            this.CurrentPage = FIRST_PAGE;
        }

        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                if (this.totPages == 0)
                {
                    this.currentPage = FIRST_PAGE;
                    this.startPageInd = 0;
                    this.endPageInd = -1;
                }
                else
                {
                    if (value == this.currentPage)
                    {
                        return;
                    }

                    if (value < FIRST_PAGE || value > this.totPages)
                    {
                        this.txtBoxCurrentPage.Text = this.currentPage.ToString();
                        return;
                    }

                    if (this.items is null || this.items.Count == 0)
                    {
                        this.currentPage = FIRST_PAGE;
                        this.startPageInd = 0;
                        this.endPageInd = -1;
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
                }

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

        public Style Style
        {
            get { return style; }
            set
            {
                style = value;

                StyleAppliers.PrimaryBg(this, style);
                StyleAppliers.SecondaryBg(this.itemsPanel, style);

                StyleAppliers.Label(this.txtPlaceHolder, style, FontStyle.Bold);
                StyleAppliers.Label(this.txtPageCount, style, FontStyle.Regular);

                StyleAppliers.TextBox(this.txtBoxCurrentPage, style);

                StyleAppliers.Button(this.buttonStart, style);
                StyleAppliers.Button(this.buttonBack, style);
                StyleAppliers.Button(this.buttonNext, style);
                StyleAppliers.Button(this.buttonEnd, style);
            }
        }

        #endregion

        #region Helper Methods

        private int GetOriginalHeight()
        {
            if (this.itemsType is null)
            {
                return 1;
            }

            object? helperInstance = Activator.CreateInstance(this.itemsType);

            if (helperInstance is null)
            {
                return 1;
            }

            return ((ListItem)helperInstance).OriginalHeight;
        }

        private void RecalculateTotPages()
        {
            if (this.items is null || this.items.Count == 0)
            {
                this.TotPages = 0;
                return;
            }

            int newTotPages = 1;

            int itemsPerPage = this.endPageInd - this.startPageInd + 1;
            int itemsRemAfter = this.items.Count - this.endPageInd - 1;
            int itemsRemBefore = this.startPageInd;

            if (itemsPerPage < 1)
            {
                this.TotPages = 0;
                return;
            }

            if (itemsRemAfter > 0)
            {
                newTotPages += itemsRemAfter / itemsPerPage;

                if (itemsRemAfter % itemsPerPage != 0)
                {
                    newTotPages++;
                }
            }

            if (itemsRemBefore > 0)
            {
                newTotPages += itemsRemBefore / itemsPerPage;

                if (itemsRemBefore % itemsPerPage != 0)
                {
                    newTotPages++;
                }
            }

            if (newTotPages != this.totPages)
            {
                this.TotPages = newTotPages;
            }
        }

        private void RecalculateCurrentPage()
        {
            int itemsPerPage = this.endPageInd - this.startPageInd + 1;

            if (itemsPerPage < 1)
            {
                this.currentPage = 1;
                this.txtBoxCurrentPage.Text = this.currentPage.ToString();
                return;
            }

            int newCurrentPage = (this.endPageInd + 1) / itemsPerPage;
            if ((this.endPageInd + 1) % itemsPerPage != 0)
            {
                newCurrentPage += 1;
            }

            if (newCurrentPage != this.currentPage)
            {
                this.currentPage = newCurrentPage;
                this.txtBoxCurrentPage.Text = this.currentPage.ToString();
            }
        }

        private ListItem CreateInstance()
        {
            if (this.itemsType is null)
            {
                return new ListItem();
            }

            object? newInstance = Activator.CreateInstance(this.itemsType);

            if (newInstance is null)
            {
                return new ListItem();
            }

            return (ListItem)newInstance;
        }

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

                    this.renderedItems.Add(CreateInstance());
                    this.renderedItems[this.renderedItems.Count - 1].ItemDatas = this.items[endPageInd];
                    this.renderedItems[this.renderedItems.Count - 1].Dock = DockStyle.Top;
                }
                else if (this.startPageInd - 1 >= 0)
                {
                    this.startPageInd--;

                    this.renderedItems.Insert(0, CreateInstance());
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
                this.renderedItems = new List<ListItem>();
            }

            this.itemsPanel.Controls.Clear();

            for (int i = this.renderedItems.Count - 1; i >= 0; i--)
            {
                this.itemsPanel.Controls.Add(this.renderedItems[i]);
            }
        }

        private void ResizeListItems()
        {
            if (this.renderedItems is null || this.renderedItems.Count < 1)
            {
                return;
            }

            int originalHeight = GetOriginalHeight();
            int totalEccessHeight = this.itemsPanel.Height - this.renderedItems.Count * originalHeight;
            int eccessHeight = totalEccessHeight / this.renderedItems.Count;

            foreach (ListItem listItem in this.renderedItems)
            {
                listItem.Height = originalHeight + eccessHeight;
            }
        }

        #endregion

        private void SetRenderedItemsNull()
        {
            this.itemsPanel.Controls.Clear();
            this.itemsPanel.Controls.Add(this.txtPlaceHolder);
            this.txtPlaceHolder.Text = this.itemsNullMsg;
            this.TotPages = 0;
            this.CurrentPage = FIRST_PAGE;
        }

        private void SetRenderedItemsEmpty()
        {
            this.itemsPanel.Controls.Clear();
            this.itemsPanel.Controls.Add(this.txtPlaceHolder);
            this.txtPlaceHolder.Text = this.itemsEmptyMsg;
            this.TotPages = 0;
            this.CurrentPage = FIRST_PAGE;
        }

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

            int originalHeight = GetOriginalHeight();
            int itemsPerPage = this.itemsPanel.Height / originalHeight;

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

            RecalculateTotPages();
            RecalculateCurrentPage();
            ResizeListItems();
        }

        #region Default Events

        private void CustomList_Load(object sender, EventArgs e)
        {
            SetRenderedItemsNull();
        }

        private void itemsPanel_SizeChanged(object sender, EventArgs e)
        {
            UpdateRenderedItems();
        }

        private void CustomList_Click(object sender, EventArgs e)
        {
            noFocusObj.Focus();
        }

        private void txtBoxCurrentPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                noFocusObj.Focus();
                e.Handled = true;
            }
        }

        private void txtBoxCurrentPage_Enter(object sender, EventArgs e)
        {
            clickProtector.Size = new Size(clickProtector.Size.Width, this.itemsPanel.Height);
        }

        private void txtBoxCurrentPage_Leave(object sender, EventArgs e)
        {
            clickProtector.Size = new Size(clickProtector.Size.Width, 0);

            int newPage = Int32.Parse(txtBoxCurrentPage.Text);
            this.CurrentPage = newPage;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.CurrentPage--;
            noFocusObj.Focus();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.CurrentPage++;
            noFocusObj.Focus();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.CurrentPage = FIRST_PAGE;
            noFocusObj.Focus();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            this.CurrentPage = this.totPages;
            noFocusObj.Focus();
        }

        #endregion
    }
}