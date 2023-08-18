using HermoCommons;

namespace HermoItemManagers
{
    public sealed partial class ListItem : UserControl
    {
        internal ListItem()
        {
            InitializeComponent();

            this.style = Style.DEFAULT_STYLE;
            buttonEdit.Visible = false;

            originalHeight = Size.Height;
        }

        private ItemDatas? item;
        private Style style;

        internal Action<ListItem>? Populate;
        internal Action<ListItem>? ApplyStyle;
        internal Action<ListItem>? ListItemClickedAction;
        private Action<ListItem>? buttonEditClickedAction;

        private readonly int originalHeight;

        #region Properties

        public ItemDatas Item
        {
            get => item?.Clone() ?? ItemDatas.DEFAULT_ITEM;

            internal set
            {
                item = value;

                if (Populate is null) return;

                SuspendLayout();
                Clear();
                Populate(this);
                ResumeLayout(true);
            }
        }

        public Style Style
        {
            get => style;

            set
            {
                if (ApplyStyle is null) return;

                style = value;
                SuspendLayout();
                ApplyStyle(this);
                ResumeLayout(true);
            }
        }

        public int EditButtonWidth
        {
            get => buttonEdit.Width;
        }

        public int EditButtonHeight
        {
            get => buttonEdit.Height;
        }

        public Point EditButtonLocation
        {
            get => buttonEdit.Location;
        }

        internal Action<ListItem>? ButtonEditClickedAction
        {
            get => buttonEditClickedAction;

            set
            {
                if (value is null && buttonEdit.Visible)
                {
                    buttonEdit.Visible = false;
                    buttonEditClickedAction = null;
                }
                else if (value is not null && !buttonEdit.Visible)
                {
                    buttonEdit.Visible = true;
                    buttonEditClickedAction = value;
                }
                else
                {
                    buttonEditClickedAction = value;
                }
            }
        }

        internal int OriginalHeight
        {
            get => originalHeight;
        }

        #endregion

        private void Clear()
        {
            Controls.Clear();
            Controls.Add(buttonEdit);
            Controls.Add(noFocusObj);
        }

        public void ApplyEditButtonStyle() => Style.Apply(buttonEdit, style);

        #region Event Consumers

        private void ListItem_Click(object? sender, EventArgs e)
        {
            noFocusObj.Focus();

            if (ListItemClickedAction is null) return;
            ListItemClickedAction(this);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            noFocusObj.Focus();

            if (ButtonEditClickedAction is null) return;
            ButtonEditClickedAction(this);
        }

        #endregion

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!GetType().Equals(obj.GetType())) return false;

            ListItem listItem = (ListItem)obj;

            if ((Populate?.Equals(listItem.Populate) ?? false) &&
                (ApplyStyle?.Equals(listItem.ApplyStyle) ?? false) &&
                (ListItemClickedAction?.Equals(listItem.ListItemClickedAction) ?? false) &&
                (buttonEditClickedAction?.Equals(listItem.buttonEditClickedAction) ?? false))
            {
                return listItem.Item.Equals(Item);
            }
            else
            {
                return Populate is null && ApplyStyle is null && ListItemClickedAction is null && buttonEditClickedAction is null;
            }
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 31 * hash + (Populate is null ? 0 : Populate.GetHashCode());
            hash = 31 * hash + (ApplyStyle is null ? 0 : ApplyStyle.GetHashCode());
            hash = 31 * hash + (ListItemClickedAction is null ? 0 : ListItemClickedAction.GetHashCode());
            hash = 31 * hash + (buttonEditClickedAction is null ? 0 : buttonEditClickedAction.GetHashCode());
            hash = 31 * hash + (item is null ? 0 : item.GetHashCode());

            return hash;
        }
    }
}