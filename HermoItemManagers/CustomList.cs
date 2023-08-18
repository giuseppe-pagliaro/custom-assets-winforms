using HermoCommons;
using HermoItemManagers.ListItemBuilders;
using HermoItemManagers.Managers;
using System.Collections.ObjectModel;

namespace HermoItemManagers
{
    public partial class CustomList : UserControl, IItemDatasUser
    {
        public CustomList()
        {
            InitializeComponent();

            style = Style.DEFAULT_STYLE;
            itemsNullMsg = "Null Items";
            itemsEmptyMsg = "No Items";
            totPagesMsg = " Pages";
        }

        private static readonly int FIRST_PAGE = 1;

        private string itemsNullMsg;
        private string itemsEmptyMsg;
        private string totPagesMsg;

        private int currentPage;
        private int totPages;
        private int startPageInd;
        private int endPageInd;

        private List<ItemDatas>? items;
        private List<ListItem>? renderedItems;

        private Action<ListItem>? Populate;
        private Action<ListItem>? ApplyStyle;
        private Action<ListItem>? ListItemClickedAction;
        private Action<ListItem>? ButtonEditClickedAction;

        private Style style;
        private Color? backgroundColor;

        #region Properties

        public string ItemsNullMsg
        {
            get => itemsNullMsg;
            set => itemsNullMsg = value;
        }

        public string ItemsEmptyMsg
        {
            get => itemsEmptyMsg;
            set => itemsEmptyMsg = value;
        }

        public string TotPagesMsg
        {
            get => totPagesMsg;

            set
            {
                totPagesMsg = value;
                txtPageCount.Text = totPages.ToString() + totPagesMsg;
            }
        }

        public ReadOnlyCollection<ItemDatas> Items
        {
            get => items?.AsReadOnly() ?? new ReadOnlyCollection<ItemDatas>(new[] { ItemDatas.DEFAULT_ITEM });
        }
        public void SetItems<TListItemBuilder>(List<ItemDatas> items) where TListItemBuilder : ListItemBuilder<TListItemBuilder>
        {
            RemoveItemsReference();

            if (items is null)
            {
                SetRenderedItemsNull();
                return;
            }

            if (items.Count == 0)
            {
                SetRenderedItemsEmpty();
                return;
            }

            this.items = ItemsManager.Instance.AddReference(items.ToArray()).ToList();
            this.items.ForEach(item => ItemsManager.Instance.AddItemDatasUserToEvents(item.GetHashCode(), this));

            TListItemBuilder Instance = (TListItemBuilder)(typeof(ListItemBuilder<TListItemBuilder>).GetProperty("Instance")?.GetValue(null) ?? throw new InstanceNotFoundException());
            Populate = Instance.Populate;
            ApplyStyle = Instance.ApplyStyle;
            ListItemClickedAction = Instance.ListItemClickedAction;
            ButtonEditClickedAction = Instance.ButtonEditClickedAction;

            TotPages = 0;
            CurrentPage = FIRST_PAGE;
        }
        public void SetItems(List<ItemDatas> items) => SetItems<DefaultListItemBuilder>(items);

        public int CurrentPage
        {
            get => currentPage;

            set
            {
                if (totPages == 0)
                {
                    SuspendLayout();

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

                    SuspendLayout();

                    renderedItems?.Clear();

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

                txtBoxCurrentPage.Text = currentPage.ToString();

                ResumeLayout();

                UpdateRenderedItems();
            }
        }

        public int TotPages
        {
            get => totPages;

            private set
            {
                totPages = value;
                txtPageCount.Text = value.ToString() + totPagesMsg;
            }
        }

        public Style Style
        {
            get => style;

            set
            {
                style = value;

                SuspendLayout();

                Style.Apply(this, style, BgType.Primary);
                Style.Apply(itemsPanel, style, BgType.Secondary);

                if (BackgroundColor is not null)
                {
                    BackColor = BackgroundColor.Value;
                }

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

                ResumeLayout();
            }
        }

        public Color? BackgroundColor
        {
            get => backgroundColor;
            set
            {
                backgroundColor = value;

                if (BackgroundColor is not null)
                {
                    BackColor = BackgroundColor.Value;
                }
            }
        }

        #endregion

        #region Helper Methods

        private static int GetOriginalHeight() => new ListItem().OriginalHeight;

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

        private void SetBuilderMethods(int ind)
        {
            if (renderedItems is null) return;

            renderedItems[ind].Populate = Populate;
            renderedItems[ind].ApplyStyle = ApplyStyle;
            renderedItems[ind].ListItemClickedAction = ListItemClickedAction;
            renderedItems[ind].ButtonEditClickedAction = ButtonEditClickedAction;
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

                    renderedItems.Add(new());
                    SetBuilderMethods(renderedItems.Count - 1);
                    renderedItems[renderedItems.Count - 1].Item = ItemsManager.Instance.AddReference(new[] { items[endPageInd] })[0];
                    renderedItems[renderedItems.Count - 1].Style = style;
                    renderedItems[renderedItems.Count - 1].Dock = DockStyle.Top;
                }
                else if (startPageInd - 1 >= 0)
                {
                    startPageInd--;

                    renderedItems.Insert(0, new());
                    SetBuilderMethods(0);
                    renderedItems[0].Item = ItemsManager.Instance.AddReference(new[] { items[startPageInd] })[0];
                    renderedItems[0].Style = style;
                    renderedItems[0].Dock = DockStyle.Top;
                }
            }
        }

        private void RemoveListItems(int count)
        {
            if (renderedItems is null) return;

            ItemsManager.Instance.RemoveReference((from listItem in renderedItems.GetRange(renderedItems.Count - count, count) select listItem.Item).ToArray());
            renderedItems.RemoveRange(renderedItems.Count - count, count);
            endPageInd -= count;
        }

        private void RefreshItemPanel()
        {
            renderedItems ??= new List<ListItem>();

            itemsPanel.Controls.Clear();

            for (int i = renderedItems.Count - 1; i >= 0; i--)
            {
                itemsPanel.Controls.Add(renderedItems[i]);
            }
        }

        private void ResizeListItems(int originalHeight)
        {
            if (renderedItems is null || renderedItems.Count < 1) return;

            int totalEccessHeight = itemsPanel.Height - renderedItems.Count * originalHeight;
            int eccessHeight = totalEccessHeight / renderedItems.Count;

            foreach (ListItem listItem in renderedItems)
            {
                listItem.Height = originalHeight + eccessHeight;
            }
        }

        private void RemoveItemsReference()
        {
            if (this.items is not null && this.items.Count > 0)
            {
                ItemsManager.Instance.RemoveReference(this.items.ToArray());
            }
        }

        #endregion

        private void SetRenderedItemsNull()
        {
            SuspendLayout();

            itemsPanel.Controls.Clear();
            itemsPanel.Controls.Add(txtPlaceHolder);
            txtPlaceHolder.Text = itemsNullMsg;
            TotPages = 0;
            CurrentPage = FIRST_PAGE;

            ResumeLayout();
        }

        private void SetRenderedItemsEmpty()
        {
            SuspendLayout();

            itemsPanel.Controls.Clear();
            itemsPanel.Controls.Add(txtPlaceHolder);
            txtPlaceHolder.Text = itemsEmptyMsg;
            TotPages = 0;
            CurrentPage = FIRST_PAGE;

            ResumeLayout();
        }

        private void UpdateRenderedItems()
        {
            if (items is null || items.Count == 0)
            {
                return;
            }

            SuspendLayout();

            renderedItems ??= new List<ListItem>();

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
                RecalculateTotPages();
                RecalculateCurrentPage();
            }

            ResizeListItems(originalHeight);

            ResumeLayout();
        }

        #region Event Consumers

        private void CustomList_Load(object sender, EventArgs e) => SetRenderedItemsNull();

        private void itemsPanel_SizeChanged(object sender, EventArgs e) => UpdateRenderedItems();

        private void CustomList_Click(object sender, EventArgs e) => noFocusObj.Focus();

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

            int newPage = int.Parse(txtBoxCurrentPage.Text);
            CurrentPage = newPage;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            noFocusObj.Focus();
            CurrentPage--;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            noFocusObj.Focus();
            CurrentPage++;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            noFocusObj.Focus();
            CurrentPage = FIRST_PAGE;
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            noFocusObj.Focus();
            CurrentPage = totPages;
        }

        private void CustomList_Resize(object sender, EventArgs e)
        {
            SuspendLayout();

            itemsPanel.Width = this.Width - 2;
            controlPanel.Width = this.Width - 2;

            double spacing = this.Height * 1.2295 / 100;
            itemsPanel.Height = this.Height - controlPanel.Height - (int)Math.Round(spacing, 0);

            int y = this.Height - controlPanel.Height - 2;
            controlPanel.Location = new Point(controlPanel.Location.X, y);

            ResumeLayout();
        }

        void IItemDatasUser.ItemWasEdited(object? sender, ItemEditedEventArgs e)
        {
            if (items is null) return;

            int itemInd = items.IndexOf(e.NewItem);

            if (itemInd == -1) return;

            items[itemInd] = e.NewItem;

            if (itemInd < startPageInd || itemInd > endPageInd || renderedItems is null) return;

            // If Item is set before the Builder Methods, the item will be set without calling them (saves time).
            ListItem listItemToEdit = new()
            {
                Item = e.NewItem,
                Populate = Populate,
                ApplyStyle = ApplyStyle,
                ListItemClickedAction = ListItemClickedAction,
                ButtonEditClickedAction = ButtonEditClickedAction
            };
            int listItemInd = renderedItems.IndexOf(listItemToEdit);

            if (listItemInd == -1) return;
            renderedItems[listItemInd].Item = e.NewItem;

            SuspendLayout();
            RefreshItemPanel();
            ResumeLayout();
        }

        void IItemDatasUser.ItemWasDeleted(object? sender, ItemDeletedEventArgs e)
        {
            if (items is null) return;

            int itemInd = items.IndexOf(e.ItemDeleted);

            if (itemInd == -1) return;

            items.RemoveAt(itemInd);

            if (itemInd < startPageInd || itemInd > endPageInd || renderedItems is null) return;

            // If Item is set before the Builder Methods, the item will be set without calling them (saves time).
            ListItem listItemToDelete = new()
            {
                Item = e.ItemDeleted,
                Populate = Populate,
                ApplyStyle = ApplyStyle,
                ListItemClickedAction = ListItemClickedAction,
                ButtonEditClickedAction = ButtonEditClickedAction
            };

            if (!renderedItems.Remove(listItemToDelete)) return;

            SuspendLayout();
            RefreshItemPanel();
            ResumeLayout();
        }

        #endregion
    }
}