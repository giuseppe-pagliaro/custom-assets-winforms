using HermoCommons;

namespace HermoItemManagers.Managers
{
    public sealed class FieldsFormManager
    {
        private FieldsFormManager()
        {
            entities = new();
        }

        private static readonly Lazy<FieldsFormManager> lazy = new(() => new FieldsFormManager());
        private readonly List<FieldsForm> entities;

        public static FieldsFormManager Instance { get { return lazy.Value; } }

        public void RequestEntity(ItemDatas itemDatas, Type type, Style style)
        {
            object? obj = Activator.CreateInstance(type);

            if (obj is null)
            {
                return;
            }

            FieldsForm fieldsForm = (FieldsForm)obj;
            fieldsForm.Item = itemDatas;

            FieldsForm? existentFieldsForm = entities.Find(exFieldsForm => exFieldsForm.Equals(fieldsForm));

            if (existentFieldsForm is not null)
            {
                existentFieldsForm.BringToFront();
                fieldsForm.Dispose();
                return;
            }

            fieldsForm.Style = style;
            fieldsForm.FormClosing += FieldsForm_FormClosing;
            fieldsForm.Show();
            entities.Add(fieldsForm);
        }

        public void ApplyStyle(Style style)
        {
            foreach (FieldsForm fieldsForm in entities)
            {
                fieldsForm.Style = style;
            }
        }

        private void FieldsForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (sender is not null)
            {
                entities.Remove((FieldsForm)sender);
            }
        }
    }
}