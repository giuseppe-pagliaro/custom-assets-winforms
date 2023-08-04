using HermoCommons;
using HermoItemManagers.Fields;
using HermoItemManagers.Managers;

namespace HermoItemManagers
{
    public partial class FieldsForm : Form
    {
        protected FieldsForm()
        {
            InitializeComponent();

            item = ItemDatas.DEFAULT_ITEM;
            fields = new();
            style = Style.DEFAULT_STYLE;

            buttonAction.Text = "Action";
            propIsNullMsg = "(Null Value)";

            initialFormSize = Size;
            initialActionBtnLocation = buttonAction.Location;

            ApplyStyle();
        }

        public FieldsForm(ItemDatas? item = null, Style? style = null, String propIsNullMsg = "(Null Value)", String actionBtnMsg = "Action")
        {
            InitializeComponent();

            this.item = item ?? ItemDatas.DEFAULT_ITEM;
            fields = new();
            this.style = style ?? Style.DEFAULT_STYLE;

            buttonAction.Text = actionBtnMsg;
            this.propIsNullMsg = propIsNullMsg;

            initialFormSize = Size;
            initialActionBtnLocation = buttonAction.Location;

            if (item is not null) Populate();
            ApplyStyle();
        }

        protected ItemDatas item;
        protected List<Field> fields;
        protected Style style;

        protected readonly String propIsNullMsg;
        private readonly Size initialFormSize;
        private readonly Point initialActionBtnLocation;

        public ItemDatas Item
        {
            get { return item.Clone(); }

            internal set
            {
                item = value;
                ClearForm();
                Populate();
                ApplyStyle();
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

        private void ClearForm()
        {
            fields.Clear();
            Controls.Clear();

            buttonAction.Location = initialActionBtnLocation;
            Controls.Add(buttonAction);
            Size = initialFormSize;
        }

        protected virtual void Populate()
        {
            Text = $"{item.ClassNameToString()} #{item.Id}";
        }

        protected virtual void ApplyStyle()
        {
            Style.Apply(this, style, BgType.Primary);

            foreach (Field field in fields)
            {
                field.Style = style;
            }

            Style.Apply(buttonAction, style);
        }

        protected virtual void buttonAction_Click(object sender, EventArgs e)
        {
            noFocusObj.Focus();
        }

        internal void ItemWasEdited(object? sender, ItemEditedEventArgs e)
        {
            Item = e.NewItem;
        }

        internal void ItemWasDeleted(object? sender, EventArgs e)
        {
            Close();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!obj.GetType().Equals(GetType())) return false;

            FieldsForm fieldsForm = (FieldsForm)obj;

            return fieldsForm.Item.Equals(Item);
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 31 * hash + GetType().GetHashCode();
            hash = 31 * hash + (item == null ? 0 : item.GetHashCode());

            return hash;
        }
    }
}