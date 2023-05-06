using Commons;
using CustomItemManagers;

namespace CustomLists
{
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();

            originalHeight = Height;
            style = new();
            buttonEdit.Visible = false;
        }

        private ItemDatas? itemDatas;
        private int originalHeight;

        private Type? viewerType;
        private Type? editorType;
        private FieldsForm? viewer;
        private FieldsForm? editor;

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
                itemDatas = value;
                Populate();
            }
        }

        internal int OriginalHeight
        {
            get { return originalHeight; }
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
            set { viewerType = value; }
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

                if (viewer is not null)
                {
                    viewer.Style = style;
                }

                if (editor is not null)
                {
                    editor.Style = style;
                }
            }
        }

        protected virtual void Populate()
        {
            if (itemDatas is null)
            {
                txtID.Text = "(Item ID is Null)";
            }
            else
            {
                txtID.Text = itemDatas.ClassNameToString() + " #" + itemDatas.Id.ToString();
            }
        }

        protected virtual void ApplyStyle()
        {
            StyleAppliers.SecondaryBg(this, style);
            StyleAppliers.Label(txtID, style, FontStyle.Bold);
            StyleAppliers.Button(buttonEdit, style);
        }

        protected static FieldsForm CreateInstance(Type type)
        {
            object? obj = Activator.CreateInstance(type);

            if (obj is null)
            {
                return new FieldsForm();
            }

            return (FieldsForm)obj;
        }
        protected void ListItem_Click(object sender, EventArgs e)
        {
            if (viewerType is null)
            {
                return;
            }

            if (viewer is null)
            {
                viewer = CreateInstance(viewerType);
                viewer.FormClosed += viewer_FormClosed;
                viewer.Style = style;
                viewer.ItemDatas = ItemDatas;
                viewer.Show();
            }
            else
            {
                viewer.BringToFront();
            }
        }

        protected void buttonEdit_Click(object sender, EventArgs e)
        {
            noFocusObj.Focus();

            if (editorType is null)
            {
                return;
            }

            if (editor is null)
            {
                editor = CreateInstance(editorType);
                editor.FormClosed += editor_FormClosed;
                editor.Style = style;
                editor.ItemDatas = ItemDatas;
                editor.Show();
            }
            else
            {
                editor.BringToFront();
            }
        }

        protected void viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            viewer = null;
        }

        protected void editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            editor = null;
        }
    }
}