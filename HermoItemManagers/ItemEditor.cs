using HermoCommons;
using HermoItemManagers.Fields;
using System.Reflection;

namespace HermoItemManagers
{
    public partial class ItemEditor : FieldsForm
    {
        public ItemEditor(ItemDatas? currItem = null, Func<ItemDatas, ItemDatas, ItemDatas>? editMethod = null, Style? style = null, String propIsNullMsg = "(Null Value)", String actionBtnMsg = "Edit")
            : base(currItem, style, propIsNullMsg, actionBtnMsg)
        {
            InitializeComponent();

            this.editMethod = editMethod;
        }

        private Func<ItemDatas, ItemDatas, ItemDatas>? editMethod;

        protected override void Populate()
        {
            base.Populate();

            foreach (PropertyInfo property in item.GetType().GetProperties().Where(p => p.Name != "Id").ToArray())
            {
                switch (property.PropertyType)
                {
                    // TODO other cases

                    default:
                        fields.Add(new TextFieldEditor(property.Name, property.GetValue(item)?.ToString() ?? propIsNullMsg, style)
                            { Togglable = true, FilterType = FilterType.None, Mandatory = !Attribute.IsDefined(property, typeof(IsNotMandatory)) });
                        break;
                }

                fields[fields.Count - 1].Width = buttonAction.Width;
                Height += buttonAction.Location.Y * (fields.Count) + fields[fields.Count - 1].Height * (fields.Count);
            }

            for (int i = 0; i < fields.Count; i++)
            {
                fields[i].Location = new(buttonAction.Location.X, buttonAction.Location.Y * (i + 1) + fields[i].Height * i);
                Controls.Add(fields[i]);
            }

            buttonAction.Location = new(buttonAction.Location.X, fields[fields.Count - 1].Location.Y + fields[fields.Count - 1].Height + buttonAction.Location.Y);
        }

        protected override void buttonAction_Click(object sender, EventArgs e)
        {
            base.buttonAction_Click(sender, e);

            if (editMethod is null) return;

            ItemDatas newInstance = item.Clone();
            int i = 0;
            foreach (PropertyInfo property in item.GetType().GetProperties().Where(p => p.Name != "Id").ToArray())
            {
                switch (fields[i].GetType())
                {
                    // TODO other cases

                    default:
                        TextFieldEditor txtFieldEditor = (TextFieldEditor)fields[i];
                        if (!txtFieldEditor.Active || txtFieldEditor.Value != "")
                        {
                            property.SetValue(newInstance, txtFieldEditor.Value);
                        }
                        break;
                }

                i++;
            }

            editMethod(item, newInstance);

            // TODO edit in memory. (chacher)
        }
    }
}