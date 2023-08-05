using HermoCommons;
using HermoItemManagers.Managers;

namespace HermoItemManagers
{
    public sealed partial class FieldsForm : Form
    {
        internal FieldsForm()
        {
            item = ItemDatas.DEFAULT_ITEM;
            style = Style.DEFAULT_STYLE;
            initialFormSize = Size;
            initialActionBtnLocation = buttonAction.Location;
        }

        private ItemDatas item;
        internal Style style;

        internal Action<FieldsForm>? Populate;
        internal Action<FieldsForm>? ApplyStyle;
        internal Action<FieldsForm>? BtnClickedAction;

        private readonly Size initialFormSize;
        private readonly Point initialActionBtnLocation;

        public ItemDatas Item
        {
            get { return item.Clone(); }

            internal set
            {
                if (Populate is null || ApplyStyle is null) return;

                item = value;

                SuspendLayout();
                Clear();
                Populate(this);
                ApplyStyle(this);
                ResumeLayout(true);
            }
        }

        public Style Style
        {
            get { return style; }

            set
            {
                if (ApplyStyle is null) return;

                style = value;
                SuspendLayout();
                ApplyStyle(this);
                ResumeLayout(true);
            }
        }

        public Point ActionBtnLocation
        {
            get { return buttonAction.Location; }
            set { buttonAction.Location = value; }
        }

        public int ActionBtnWidth
        {
            get { return buttonAction.Width; }
            set { buttonAction.Width = value; }
        }

        public int ActionBtnHeight
        {
            get { return buttonAction.Height; }
            set { buttonAction.Height = value; }
        }

        public String ActionBtnText
        {
            get { return buttonAction.Text; }
            set { buttonAction.Text = value; }
        }

        public void ApplyActionBtnStyle()
        {
            Style.Apply(buttonAction, style);
        }

        private void Clear()
        {
            Controls.Clear();

            buttonAction.Location = initialActionBtnLocation;
            Controls.Add(buttonAction);
            Size = initialFormSize;
            buttonAction.Text = "Action";
        }

        private void buttonAction_Click(object sender, EventArgs e)
        {
            noFocusObj.Focus();

            if (BtnClickedAction is null) return;
            BtnClickedAction(this);
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
            if (!GetType().Equals(obj.GetType())) return false;

            FieldsForm fieldsForm = (FieldsForm)obj;

            if ((Populate?.GetType().Equals(fieldsForm.Populate?.GetType()) ?? false) &&
                (ApplyStyle?.GetType().Equals(fieldsForm.ApplyStyle?.GetType()) ?? false) &&
                (BtnClickedAction?.GetType().Equals(fieldsForm.BtnClickedAction?.GetType()) ?? false))
            {
                return fieldsForm.Item.Equals(Item);
            }
            else
            {
                return ApplyStyle is null && BtnClickedAction is null;
            }
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 31 * hash + (Populate is null ? 0 : Populate.GetType().GetHashCode());
            hash = 31 * hash + (ApplyStyle is null ? 0 : ApplyStyle.GetType().GetHashCode());
            hash = 31 * hash + (BtnClickedAction is null ? 0 : BtnClickedAction.GetType().GetHashCode());
            hash = 31 * hash + (item is null ? 0 : item.GetHashCode());

            return hash;
        }
    }
}