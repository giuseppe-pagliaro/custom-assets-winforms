using Commons;
using CustomItemManagers;
using System.Collections.ObjectModel;

namespace CustomLists
{
    public partial class CustomList : UserControl
    {
        public CustomList()
        {
            InitializeComponent();

            style = new();
            itemsNullMsg = "Null Items";
            itemsEmptyMsg = "No Items";
            totPagesMsg = " Pages";
        }

        private static readonly int FIRST_PAGE = 1;

        private String itemsNullMsg;
        private String itemsEmptyMsg;
        private String totPagesMsg;

        private int currentPage;
        private int totPages;
        private int startPageInd;
        private int endPageInd;

        private List<ItemDatas>? items;
        private List<ListItem>? renderedItems;
        private Type? itemsType;

        private Type? viewerType;
        private Type? editorType;

        private Style style;

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
                txtPageCount.Text = totPages.ToString() + totPagesMsg;
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
        public void SetItems<TItemDatas, TListItem>(List<TItemDatas> itemDatas)
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

            items = itemDatas.Cast<ItemDatas>().ToList();
            itemsType = typeof(TListItem);
            TotPages = 0;
            CurrentPage = FIRST_PAGE;
        }

        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                if (totPages == 0)
                {
                    currentPage = FIRST_PAGE;
                    startPageInd = 0;
                    endPageInd = -1;
                }
                else
                {
                    if (value == currentPage)
                    {
                        return;
                    }

                    if (value < FIRST_PAGE || value > totPages)
                    {
                        txtBoxCurrentPage.Text = currentPage.ToString();
                        return;
                    }

                    if (items is null || items.Count == 0)
                    {
                        currentPage = FIRST_PAGE;
                        startPageInd = 0;
                        endPageInd = -1;
                        return;
                    }

                    if (renderedItems != null)
                    {
                        renderedItems.Clear();
                    }

                    if (endPageInd >= startPageInd)
                    {
                        int itemsPerPage = endPageInd - startPageInd + 1;

                        if (value > currentPage)
                        {
                            startPageInd += itemsPerPage * (value - currentPage);

                            if (startPageInd >= items.Count)
                            {
                                startPageInd = items.Count - 1;
                            }
                        }
                        else if (value < currentPage)
                        {
                            startPageInd -= itemsPerPage * (currentPage - value);

                            if (startPageInd < 0)
                            {
                                startPageInd = 0;
                            }
                        }

                        endPageInd = startPageInd - 1;
                    }

                    currentPage = value;
                }

                txtBoxCurrentPage.Text = value.ToString();
                UpdateRenderedItems();
            }
        }

        public int TotPages
        {
            get { return totPages; }
            private set
            {
                totPages = value;
                txtPageCount.Text = value.ToString() + totPagesMsg;
            }
        }

        public Type Viewer
        {
            get
            {
                if (viewerType is null)
                {
                    return typeof(FieldsForm);
                }

                return viewerType;
            }
            set
            {
                if (!value.IsSubclassOf(typeof(FieldsForm)))
                {
                    if (!(value == typeof(FieldsForm)))
                    {
                        throw new IncompatibleClassException();
                    }
                }

                viewerType = value;
            }
        }

        public Type Editor
        {
            get
            {
                if (editorType is null)
                {
                    return typeof(FieldsForm);
                }

                return editorType;
            }
            set
            {
                if (!value.IsSubclassOf(typeof(FieldsForm)))
                {
                    if (!(value == typeof(FieldsForm)))
                    {
                        throw new IncompatibleClassException();
                    }
                }

                editorType = value;
            }
        }

        public Style Style
        {
            get { return style; }
            set
            {
                style = value;

                Style.Apply(this, style, BgType.Primary);
                Style.Apply(itemsPanel, style, BgType.Secondary);

                Style.Apply(txtPlaceHolder, style, FontStyle.Bold);
                Style.Apply(txtPageCount, style, FontStyle.Regular);

                Style.Apply(txtBoxCurrentPage, style);

                Style.Apply(buttonStart, style);
                Style.Apply(buttonBack, style);
                Style.Apply(buttonNext, style);
                Style.Apply(buttonEnd, style);

                if (renderedItems is not null)
                {
                    foreach (var renderedItem in renderedItems)
                    {
                        renderedItem.Style = style;
                    }
                }
            }
        }

        #endregion

        #region Helper Methods

        private int GetOriginalHeight()
        {
            if (itemsType is null)
            {
                return 1;
            }

            object? helperInstance = Activator.CreateInstance(itemsType);

            if (helperInstance is null)
            {
                return 1;
            }

            return ((ListItem)helperInstance).OriginalHeight;
        }

        private void RecalculateTotPages()
        {
            if (items is null || items.Count == 0)
            {
                TotPages = 0;
                return;
            }

            int newTotPages = 1;

            int itemsPerPage = endPageInd - startPageInd + 1;
            int itemsRemAfter = items.Count - endPageInd - 1;
            int itemsRemBefore = startPageInd;

            if (itemsPerPage < 1)
            {
                TotPages = 0;
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

            if (newTotPages != totPages)
            {
                TotPages = newTotPages;
            }
        }

        private void RecalculateCurrentPage()
        {
            int itemsPerPage = endPageInd - startPageInd + 1;

            if (itemsPerPage < 1)
            {
                currentPage = 1;
                txtBoxCurrentPage.Text = currentPage.ToString();
                return;
            }

            int newCurrentPage = (endPageInd + 1) / itemsPerPage;
            if ((endPageInd + 1) % itemsPerPage != 0)
            {
                newCurrentPage += 1;
            }

            if (newCurrentPage != currentPage)
            {
                currentPage = newCurrentPage;
                txtBoxCurrentPage.Text = currentPage.ToString();
            }
        }

        private ListItem CreateInstance()
        {
            if (itemsType is null)
            {
                return new ListItem();
            }

            object? newInstance = Activator.CreateInstance(itemsType);

            if (newInstance is null)
            {
                return new ListItem();
            }

            return (ListItem)newInstance;
        }

        private void SetItemViewers(int ind)
        {
            if (renderedItems is null)
            {
                return;
            }

            if (viewerType is not null)
            {
                renderedItems[ind].Viewer = viewerType;
            }

            if (editorType is not null)
            {
                renderedItems[ind].Editor = editorType;
            }
        }

        private void AddListItems(int count)
        {
            if (items is null || renderedItems is null)
            {
                return;
            }

            for (int i = 0; i < count; i++)
            {
                if (endPageInd + 1 < items.Count)
                {
                    endPageInd++;

                    renderedItems.Add(CreateInstance());
                    renderedItems[renderedItems.Count - 1].ItemDatas = items[endPageInd];
                    renderedItems[renderedItems.Count - 1].Style = style;
                    renderedItems[renderedItems.Count - 1].Dock = DockStyle.Top;
                    SetItemViewers(renderedItems.Count - 1);
                }
                else if (startPageInd - 1 >= 0)
                {
                    startPageInd--;

                    renderedItems.Insert(0, CreateInstance());
                    renderedItems[0].ItemDatas = items[startPageInd];
                    renderedItems[0].Style = style;
                    renderedItems[0].Dock = DockStyle.Top;
                    SetItemViewers(0);
                }
            }
        }

        private void RemoveListItems(int count)
        {
            if (renderedItems is null)
            {
                return;
            }

            renderedItems.RemoveRange(renderedItems.Count - count, count);
            endPageInd -= count;
        }

        private void RefreshItemPanel()
        {
            if (renderedItems is null)
            {
                renderedItems = new List<ListItem>();
            }

            itemsPanel.Controls.Clear();

            for (int i = renderedItems.Count - 1; i >= 0; i--)
            {
                itemsPanel.Controls.Add(renderedItems[i]);
            }
        }

        private void ResizeListItems()
        {
            if (renderedItems is null || renderedItems.Count < 1)
            {
                return;
            }

            int originalHeight = GetOriginalHeight();
            int totalEccessHeight = itemsPanel.Height - renderedItems.Count * originalHeight;
            int eccessHeight = totalEccessHeight / renderedItems.Count;

            foreach (ListItem listItem in renderedItems)
            {
                listItem.Height = originalHeight + eccessHeight;
            }
        }

        #endregion

        private void SetRenderedItemsNull()
        {
            itemsPanel.Controls.Clear();
            itemsPanel.Controls.Add(txtPlaceHolder);
            txtPlaceHolder.Text = itemsNullMsg;
            TotPages = 0;
            CurrentPage = FIRST_PAGE;
        }

        private void SetRenderedItemsEmpty()
        {
            itemsPanel.Controls.Clear();
            itemsPanel.Controls.Add(txtPlaceHolder);
            txtPlaceHolder.Text = itemsEmptyMsg;
            TotPages = 0;
            CurrentPage = FIRST_PAGE;
        }

        private void UpdateRenderedItems()
        {
            if (items is null || items.Count == 0 || itemsType is null)
            {
                return;
            }

            if (renderedItems is null)
            {
                renderedItems = new List<ListItem>();
            }

            int originalHeight = GetOriginalHeight();
            int itemsPerPage = itemsPanel.Height / originalHeight;

            if (renderedItems.Count != itemsPerPage)
            {
                if (renderedItems.Count > itemsPerPage)
                {
                    RemoveListItems(renderedItems.Count - itemsPerPage);
                }
                else if (renderedItems.Count < itemsPerPage)
                {
                    AddListItems(itemsPerPage - renderedItems.Count);
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
            clickProtector.Size = new Size(clickProtector.Size.Width, itemsPanel.Height);
        }

        private void txtBoxCurrentPage_Leave(object sender, EventArgs e)
        {
            clickProtector.Size = new Size(clickProtector.Size.Width, 0);

            int newPage = Int32.Parse(txtBoxCurrentPage.Text);
            CurrentPage = newPage;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            CurrentPage--;
            noFocusObj.Focus();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            noFocusObj.Focus();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            CurrentPage = FIRST_PAGE;
            noFocusObj.Focus();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            CurrentPage = totPages;
            noFocusObj.Focus();
        }

        #endregion
    }

    public class IncompatibleClassException : Exception
    {
        public IncompatibleClassException()
            : base("The class you provided isn't or doesn't extend \"CustomItemManagers.FieldsForm\".") { }
    }
}