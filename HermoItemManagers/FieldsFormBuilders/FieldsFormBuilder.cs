namespace HermoItemManagers.FieldsFormBuilders
{
    public abstract class FieldsFormBuilder<T> where T : FieldsFormBuilder<T>
    {
        private static T InstantiateBuilder()
        {
            object? obj = Activator.CreateInstance(typeof(T), true);

            return obj is null ? throw new MissingMethodException() : (T)obj;
        }

        private static readonly Lazy<T> lazy = new(() => InstantiateBuilder());

        private string propIsNullMsg = "(Null Property)";
        private string actionBtnText = "Action";

        public static T Instance { get { return lazy.Value; } }

        public string PropIsNullMsg
        {
            get { return propIsNullMsg; }
            set { propIsNullMsg = value; }
        }

        public string ActionBtnText
        {
            get { return actionBtnText; }
            set { actionBtnText = value; }
        }

        public abstract void Populate(FieldsForm fieldsForm);

        public abstract void ApplyStyle(FieldsForm fieldsForm);

        public abstract void BtnClickedAction(FieldsForm fieldsForm);
    }
}