using HermoCommons;
using HermoItemManagers.Fields;
using System.Reflection;

namespace HermoItemManagers
{
    public class ItemViewer<T> : ItemViewer where T : ItemDatas
    {
        public ItemViewer(T item, String propIsNullMsg = "(Null Value)", String deleteBtnMsg = "Delete") : base()
        {
            this.item = item;
            fields = new();
            style = new Style();
            this.propIsNullMsg = propIsNullMsg;
            buttonDelete.Text = deleteBtnMsg;

            Populate();
        }

        public ItemViewer(T item, Style style, String propIsNullMsg = "(Null Value)", String deleteBtnMsg = "Delete") : base()
        {
            this.item = item;
            fields = new();
            this.style = style;
            this.propIsNullMsg = propIsNullMsg;
            buttonDelete.Text = deleteBtnMsg;

            Populate();
            ApplyStyle();
        }

        private T item;
        private List<Field> fields;
        private Style style;
        private String propIsNullMsg;

        public Style Style
        {
            get { return this.style; }

            set
            {
                this.style = value;
                ApplyStyle();
            }
        }

        protected virtual void Populate()
        {
            Text = $"{item.ClassNameToString()} #{item.Id}";

            foreach (PropertyInfo property in typeof(T).GetProperties().Where(p => p.Name != "Id").ToArray())
            {
                if (Attribute.IsDefined(property, typeof(IsCopyable)))
                {
                    fields.Add(new CopyableTextField(property.Name, property.GetValue(item)?.ToString() ?? propIsNullMsg));
                }
                else
                {
                    fields.Add(new TextField(property.Name, property.GetValue(item)?.ToString() ?? propIsNullMsg));
                }

                fields[fields.Count - 1].Width = buttonDelete.Width;

                Height += buttonDelete.Location.Y * (fields.Count) + fields[fields.Count - 1].Height * (fields.Count);
            }

            for (int i = 0; i < fields.Count; i++)
            {
                fields[i].Location = new(buttonDelete.Location.X, buttonDelete.Location.Y * (i + 1) + fields[i].Height * i);
                Controls.Add(fields[i]);
            }

            buttonDelete.Location = new(buttonDelete.Location.X, fields[fields.Count - 1].Location.Y + fields[fields.Count - 1].Height + buttonDelete.Location.Y);
        }

        protected virtual void ApplyStyle()
        {
            Style.Apply(this, style, BgType.Primary);

            foreach (Field field in fields)
            {
                field.Style = style;
            }

            Style.Apply(buttonDelete, style);
        }
    }
}