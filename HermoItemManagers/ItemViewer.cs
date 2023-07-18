using HermoCommons;
using HermoItemManagers.Fields;
using System.Reflection;

namespace HermoItemManagers
{
    public partial class ItemViewer : Form
    {
        public ItemViewer(Style? style = null, String propIsNullMsg = "(Null Value)", String deleteBtnMsg = "Delete")
        {
            InitializeComponent();

            initialFormSize = Size;
            initialDelBtnLocation = buttonDelete.Location;

            Text = "No Item Provided";
            item = new();
            fields = new();
            this.style = style ?? Style.DEFAULT_STYLE;
            ApplyStyle();

            this.propIsNullMsg = propIsNullMsg;
            buttonDelete.Text = deleteBtnMsg;

            noFocusObj.Focus();
        }

        public ItemViewer(ItemDatas item, Style? style = null, String propIsNullMsg = "(Null Value)", String deleteBtnMsg = "Delete") : this(style, propIsNullMsg, deleteBtnMsg)
        {
            this.item = item;
            Populate();
        }

        protected ItemDatas item;
        protected List<Field> fields;
        private Style style;

        protected readonly String propIsNullMsg;
        private readonly Size initialFormSize;
        private readonly Point initialDelBtnLocation;

        public ItemDatas Item
        {
            get
            {
                return item.Clone();
            }

            set
            {
                item = value;
                ClearForm();
                Populate();
            }
        }

        public Style Style
        {
            get { return this.style; }

            set
            {
                this.style = value;
                ApplyStyle();
            }
        }

        private void ClearForm()
        {
            fields.Clear();
            Controls.Clear();

            buttonDelete.Location = initialDelBtnLocation;
            Controls.Add(buttonDelete);
            Size = initialFormSize;
        }

        protected virtual void Populate()
        {
            Text = $"{item.ClassNameToString()} #{item.Id}";

            foreach (PropertyInfo property in item.GetType().GetProperties().Where(p => p.Name != "Id").ToArray())
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
            Style.Apply(this, Style, BgType.Primary);

            foreach (Field field in fields)
            {
                field.Style = Style;
            }

            Style.Apply(buttonDelete, Style);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // TODO
        }
    }
}