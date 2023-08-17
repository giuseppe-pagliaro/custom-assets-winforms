namespace HermoItemManagers.ListItemBuilders
{
    public abstract class ListItemBuilder<T> where T : ListItemBuilder<T>
    {
        private static T InstantiateBuilder()
        {
            object? obj = Activator.CreateInstance(typeof(T), true);

            return obj is null ? throw new MissingMethodException() : (T)obj;
        }

        private static readonly Lazy<T> lazy = new(() => InstantiateBuilder());

        private string propIsNullMsg = "(Null Property)";
        private string editBtnTxt = "Edit";
        private Type? viewerBuilderType;
        private Type? editorBuilderType;

        public static T Instance { get { return lazy.Value; } }

        public string PropIsNullMsg
        {
            get { return propIsNullMsg; }
            set { propIsNullMsg = value; }
        }

        public string EditBtnTxt
        {
            get { return editBtnTxt; }
            set { editBtnTxt = value; }
        }

        public Type? ViewerBuilderType
        {
            get => viewerBuilderType;

            set
            {
                if (value is null) return;
                if (!value.IsSubclassOf(typeof(FieldsFormBuilders.FieldsFormBuilder<>))) return;

                viewerBuilderType = value;
            }
        }

        public Type? EditorBuilderType
        {
            get => editorBuilderType;

            set
            {
                if (value is null) return;
                if (!value.IsSubclassOf(typeof(FieldsFormBuilders.FieldsFormBuilder<>))) return;

                editorBuilderType = value;
            }
        }

        public abstract void Populate(ListItem listItem);

        public abstract void ApplyStyle(ListItem listItem);

        public abstract void ListItemClickedAction(ListItem listItem);

        public abstract void ButtonEditClickedAction(ListItem listItem);
    }
}