using System.Reflection;

namespace HermoItemManagers
{
    public abstract class FieldsFormBuilder<T> where T : FieldsFormBuilder<T>
    {
        private static T InstantiateFactory()
        {
            object? obj = Activator.CreateInstance(typeof(T), true);

            if (obj is null) throw new FactoryNotInstantiatedException();

            return (T)obj;
        }

        private static readonly Lazy<T> lazy = new(() => InstantiateFactory());

        private String propIsNullMsg = "(Null Property)";
        private String actionBtnText = "Action";

        public static T Instance { get { return lazy.Value; } }

        public String PropIsNullMsg
        {
            get { return propIsNullMsg; }
            set { propIsNullMsg = value; }
        }

        public String ActionBtnText
        {
            get { return actionBtnText; }
            set { actionBtnText = value; }
        }

        public void SetProps(params Object[] newProps)
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

    public class FactoryNotInstantiatedException : Exception
    {
        public FactoryNotInstantiatedException() : base("Couldn't create your factory, make sure it implements a default constructor.") { }
    }

    public class IncompatiblePropertiesException : Exception
    {
        public IncompatiblePropertiesException() : base("The properties you provided in SetProps don't correspond to the props of the factory.") { }
    }
}