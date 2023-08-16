using HermoCommons;

namespace HermoItemManagers
{
    public sealed partial class ListItem : UserControl
    {
        internal ListItem(Style? style = null)
        {
            InitializeComponent();

            this.style = style ?? Style.DEFAULT_STYLE;
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
                if (Populate is null) return;

                SuspendLayout();
                item = value;
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
    }
}