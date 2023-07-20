using HermoCommons;
using HermoItemManagers.Fields;
using System.Reflection;

namespace HermoItemManagers
{
    public partial class ItemViewer : FieldsForm
    {
        public ItemViewer(ItemDatas? item = null, Action<int>? deleteMethod = null, Style? style = null, String propIsNullMsg = "(Null Value)", String actionBtnMsg = "Delete")
            : base(item, style, propIsNullMsg, actionBtnMsg)
        {
            InitializeComponent();

            this.deleteMethod = deleteMethod;
        }

        private Action<int>? deleteMethod;

        public Action<int>? DeleteMethod
        {
            get { return deleteMethod; }
            set { deleteMethod = value; }
        }

        protected override void Populate()
        {
            base.Populate();

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

            if (deleteMethod is null) return;

            deleteMethod(item.Id);
            // TODO remove from memory. (chacher)
        }
    }
}