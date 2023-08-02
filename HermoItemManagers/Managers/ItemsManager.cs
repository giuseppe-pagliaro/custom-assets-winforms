using HermoCommons;

namespace HermoItemManagers.Managers
{
    public class ItemsManager
    {
        private class Entity
        {
            public Entity()
            {
                Item = ItemDatas.DEFAULT_ITEM;
                RefCount = 1;
            }

            public Entity(ItemDatas item)
            {
                Item = item;
                RefCount = 1;
            }

            public ItemDatas Item;
            public int RefCount;
        }

        private ItemsManager()
        {
            entities = new();
        }

        private static readonly Lazy<ItemsManager> lazy = new(() => new ItemsManager());
        private readonly Dictionary<int, Entity> entities;

        public static ItemsManager Instance { get { return lazy.Value; } }

        public T[] AddReference<T>(T[] items) where T : ItemDatas
        {
            T[] ret = new T[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                int itemHash = items[i].GetHashCode();

                if (entities.ContainsKey(itemHash))
                {
                    ret[i] = (T)entities[itemHash].Item;
                    entities[itemHash].RefCount++;
                }
                else
                {
                    ret[i] = items[i];
                    entities.Add(itemHash, new(items[i]));
                }
            }

            return ret;
        }

        public void Edit<T>(T newItem) where T : ItemDatas
        {
            int itemHash = newItem.GetHashCode();
            if (!entities.ContainsKey(itemHash)) return;

            entities[itemHash].Item = newItem;

            // Throw an event to edit in every place.
        }

        public void RemoveReference<T>(T[] items) where T : ItemDatas
        {
            for (int i = 0; i < items.Length; i++)
            {
                int itemHash = items[i].GetHashCode();
                if (!entities.ContainsKey(itemHash)) continue;

                if (entities[itemHash].RefCount > 1)
                {
                    entities[itemHash].RefCount--;
                }
                else
                {
                    entities.Remove(itemHash);
                }
            }
        }

        public void Delete<T>(T item) where T : ItemDatas
        {
            entities.Remove(item.GetHashCode());

            // Throw an event to remove from every place.
        }
    }

    public class ItemEditedEventArgs : EventArgs
    {
        public ItemEditedEventArgs(ItemDatas newItem) : base()
        {
            NewItem = newItem;
        }

        public ItemDatas NewItem { get; }
    }
}