using HermoCommons;
using HermoItemManagers.Managers;

namespace HermoItemManagers
{
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();

            originalHeight = Height;
            style = Style.DEFAULT_STYLE;
            buttonEdit.Visible = false;
        }

        private ItemDatas? item;
        private readonly int originalHeight;

        private Type? viewerType;
        private Type? editorType;

        private Style style;

        #region Properties

        public ItemDatas Item
        {
            get
            {
                if (item is null)
                {
                    return ItemDatas.DEFAULT_ITEM;
                }

                return item.Clone();
            }
            set
            {
                item = value;
                Populate();
            }
        }

        internal int OriginalHeight
        {
            get { return originalHeight; }
        }

        internal Type Viewer
        {
            get
            {
                if (viewerType is null)
                {
                    return typeof(FieldsForm);
                }

                return viewerType;
            }
            set { viewerType = value; }
        }

        internal Type Editor
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
                editorType = value;

                if (!buttonEdit.Visible && editorType is not null)
                {
                    buttonEdit.Visible = true;
                }

                if (buttonEdit.Visible && editorType is null)
                {
                    buttonEdit.Visible = false;
                }
            }
        }

        public Style Style
        {
            get { return style; }
            set
            {
                style = value;
                ApplyStyle();
            }
        }

        #endregion

        protected virtual void Populate()
        {
            if (item is null)
            {
                txtID.Text = "(Item ID is Null)";
            }
            else
            {
                txtID.Text = item.ClassNameToString() + " #" + item.Id.ToString();
            }
        }

        protected virtual void ApplyStyle()
        {
            Style.Apply(this, style, BgType.Secondary);
            Style.Apply(txtID, style, FontStyle.Bold);
            Style.Apply(buttonEdit, style);
        }

        #region Event Consumers

        protected void ListItem_Click(object? sender, EventArgs e)
        {
            noFocusObj.Focus();

            if (viewerType is null) return;

            typeof(FieldsFormManager).GetMethod("RequestEntity")?.MakeGenericMethod(viewerType).Invoke(FieldsFormManager.Instance, new object[] { Item, style });
        }

        protected void buttonEdit_Click(object sender, EventArgs e)
        {
            noFocusObj.Focus();

            if (editorType is null) return;

            typeof(FieldsFormManager).GetMethod("RequestEntity")?.MakeGenericMethod(editorType).Invoke(FieldsFormManager.Instance, new object[] { Item, style });
        }

        #endregion
    }
}
