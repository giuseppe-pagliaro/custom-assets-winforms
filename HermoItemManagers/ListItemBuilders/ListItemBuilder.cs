namespace HermoItemManagers.ListItemBuilders
{
    public abstract class ListItemBuilder<T> where T : ListItemBuilder<T>
    {
        private static T InstantiateBuilder()
        {
            object? obj = Activator.CreateInstance(typeof(T), true);

            return obj is null ? throw new BuilderNotInstantiatedException() : (T)obj;
        }

        private static readonly Lazy<T> lazy = new(() => InstantiateBuilder());

        public static T Instance { get { return lazy.Value; } }

        public abstract void Populate(ListItem listItem);

        public abstract void ApplyStyle(ListItem listItem);

        public abstract void ListItemClickedAction(ListItem listItem);
    }
}