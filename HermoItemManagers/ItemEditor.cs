using HermoCommons;
using HermoItemManagers.Fields;
using HermoItemManagers.Managers;
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

        //private static readonly HashSet<Type> TEXT_EDITOR_TYPES = new(new[] { typeof(string), typeof(int), typeof(bool) });

        private readonly Func<ItemDatas, ItemDatas, ItemDatas>? editMethod;

        protected override void Populate()
        {
            base.Populate();

            foreach (PropertyInfo property in item.GetType().GetProperties().Where(p => p.Name != "Id").ToArray())
            {
                if (property.PropertyType.Equals(typeof(HermoPhoneNumber)))
                {
                    // TODO
                }
                else if (property.PropertyType.Equals(typeof(HermoDate)))
                {
                    fields.Add(new TextFieldEditor(property.Name, property.GetValue(item)?.ToString() ?? propIsNullMsg, style)
                        { Togglable = true, FilterType = FilterType.Date, Mandatory = !Attribute.IsDefined(property, typeof(IsNotMandatory)) });
                }
                else if (property.PropertyType.Equals(typeof(int)))
                {
                    fields.Add(new TextFieldEditor(property.Name, property.GetValue(item)?.ToString() ?? propIsNullMsg, style)
                        { Togglable = true, FilterType = FilterType.NumbersOnly, Mandatory = !Attribute.IsDefined(property, typeof(IsNotMandatory)) });
                }
                else if (property.PropertyType.Equals(typeof(float)) || property.PropertyType.Equals(typeof(double)))
                {
                    fields.Add(new TextFieldEditor(property.Name, property.GetValue(item)?.ToString() ?? propIsNullMsg, style)
                        { Togglable = true, FilterType = FilterType.DecimalNumbersOnly, Mandatory = !Attribute.IsDefined(property, typeof(IsNotMandatory)) });
                }
                else if (property.PropertyType.Equals(typeof(string)))
                {
                    fields.Add(new TextFieldEditor(property.Name, property.GetValue(item)?.ToString() ?? propIsNullMsg, style)
                        { Togglable = true, FilterType = FilterType.None, Mandatory = !Attribute.IsDefined(property, typeof(IsNotMandatory)) });
                }
                else
                {
                    // TODO generate selector.
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
                if (property.PropertyType.Equals(typeof(HermoPhoneNumber)))
                {
                    // TODO
                }
                else if (property.PropertyType.Equals(typeof(HermoDate)))
                {
                    // TODO
                }
                else if (property.PropertyType.Equals(typeof(int)))
                {
                    // TODO
                }
                else if (property.PropertyType.Equals(typeof(float)) || property.PropertyType.Equals(typeof(double)))
                {
                    // TODO
                }
                else if (property.PropertyType.Equals(typeof(string)))
                {
                    TextFieldEditor txtFieldEditor = (TextFieldEditor)fields[i];

                    if (!txtFieldEditor.Active || txtFieldEditor.Value != "")
                    {
                        property.SetValue(newInstance, txtFieldEditor.Value);
                    }
                }
                else
                {
                    // TODO get value from selector.
                }

                i++;
            }

            editMethod(item, newInstance);
            ItemsManager.Instance.Edit(newInstance);
            Close();
        }
    }
}