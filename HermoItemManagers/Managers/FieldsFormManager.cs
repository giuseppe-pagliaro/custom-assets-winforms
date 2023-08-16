using HermoCommons;
using HermoItemManagers.FieldsFormBuilders;

namespace HermoItemManagers.Managers
{
    public sealed class FieldsFormManager
    {
        private FieldsFormManager()
        {
            entities = new();
        }

        private static readonly Lazy<FieldsFormManager> lazy = new(() => new FieldsFormManager());
        private readonly Dictionary<int, FieldsForm> entities;

        public static FieldsFormManager Instance { get { return lazy.Value; } }

        public void RequestEntity<TBuilder>(ItemDatas itemDatas, Style style) where TBuilder : FieldsFormBuilder<TBuilder>
        {
            TBuilder Instance = (TBuilder)(typeof(FieldsFormBuilder<TBuilder>).GetProperty("Instance")?.GetValue(null) ?? throw new InstanceNotFoundException());

            FieldsForm fieldsForm = new(style)
            {
                Populate = Instance.Populate,
                ApplyStyle = Instance.ApplyStyle,
                BtnClickedAction = Instance.BtnClickedAction,
                Item = ItemsManager.Instance.AddReference(new ItemDatas[] { itemDatas })[0]
            };
            int fieldsFormHash = fieldsForm.GetHashCode();

            if (entities.ContainsKey(fieldsFormHash))
            {
                entities[fieldsFormHash].BringToFront();
                ItemsManager.Instance.RemoveReference(new ItemDatas[] { itemDatas });
                fieldsForm.Dispose();
            }
            else
            {
                fieldsForm.FormClosing += FieldsForm_FormClosing;
                ItemsManager.Instance.AddFieldsFormToEvents(itemDatas.GetHashCode(), fieldsForm);
                fieldsForm.Show();
                entities.Add(fieldsFormHash, fieldsForm);
            }
        }

        public void ApplyStyle(Style style)
        {
            foreach (KeyValuePair<int, FieldsForm> keyValuePair in entities)
            {
                keyValuePair.Value.Style = style;
            }
        }

        private void FieldsForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (sender is null) return;

            FieldsForm fieldsForm = (FieldsForm)sender;
            ItemsManager.Instance.RemoveReference(new ItemDatas[] { fieldsForm.Item });
            entities.Remove(fieldsForm.GetHashCode());
        }
    }
}