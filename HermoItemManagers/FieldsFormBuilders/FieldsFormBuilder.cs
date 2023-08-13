using System.Reflection;

namespace HermoItemManagers.FieldsFormBuilders
{
    public abstract class FieldsFormBuilder<T> where T : FieldsFormBuilder<T>
    {
        private static T InstantiateBuilder()
        {
            object? obj = Activator.CreateInstance(typeof(T), true);

            return obj is null ? throw new BuilderNotInstantiatedException() : (T)obj;
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

        public void SetProps(params object[] newProps)
        {
            PropertyInfo[] properties = typeof(FieldsFormBuilder<T>).GetProperties();

            if (properties.Length != newProps.Length) throw new IncompatiblePropertiesException();

            int i = 0;
            foreach (PropertyInfo property in properties)
            {
                if (!property.PropertyType.Equals(newProps[i].GetType()) && !newProps[i].GetType().IsSubclassOf(property.PropertyType)) throw new IncompatiblePropertiesException();
                property.SetValue(Instance, newProps[i]);
                i++;
            }
        }

        public abstract void Populate(FieldsForm fieldsForm);

        public abstract void ApplyStyle(FieldsForm fieldsForm);

        public abstract void BtnClickedAction(FieldsForm fieldsForm);
    }
}