using HermoCommons;
using HermoItemManagers.Fields;
using HermoItemManagers.Managers;
using System.Collections.ObjectModel;

namespace HermoItemManagers
{
    public sealed partial class FieldsForm : Form
    {
        internal FieldsForm(Style? style = null)
        {
            InitializeComponent();

            this.item = ItemDatas.DEFAULT_ITEM;
            this.style = style ?? Style.DEFAULT_STYLE;
            fields = new();

            initialFormSize = Size;
            initialActionBtnLocation = buttonAction.Location;
        }

        private ItemDatas item;
        private Style style;
        private readonly List<Field> fields;

        internal Action<FieldsForm>? Populate;
        internal Action<FieldsForm>? ApplyStyle;
        internal Action<FieldsForm>? BtnClickedAction;

        private Size initialFormSize;
        private Point initialActionBtnLocation;

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

        #region Button Action

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

        public string ActionBtnText
        {
            get { return buttonAction.Text; }
            set { buttonAction.Text = value; }
        }

        public void ApplyActionBtnStyle()
        {
            Style.Apply(buttonAction, style);
        }

        #endregion

        #region Fields

        public ReadOnlyCollection<Field> Fields
        {
            get { return fields.AsReadOnly(); }
        }

        public void AddField(Field field)
        {
            fields.Add(field);
        }

        public void AddFields(Field[] newFields)
        {
            fields.AddRange(newFields);
        }

        public void RemoveField(Field field)
        {
            fields.Remove(field);
        }

        public void RemoveField(int fieldInd)
        {
            fields.RemoveAt(fieldInd);
        }

        public void ClearFields()
        {
            fields.Clear();
        }

        public void ApplyFieldStyle()
        {
            foreach (Field field in fields)
            {
                field.Style = style;
            }
        }

        #endregion

        private void Clear()
        {
            Controls.Clear();
            fields.Clear();

            buttonAction.Location = initialActionBtnLocation;
            Controls.Add(buttonAction);
            Controls.Add(noFocusObj);
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