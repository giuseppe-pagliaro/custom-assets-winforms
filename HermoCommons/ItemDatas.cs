using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace HermoCommons
{
    /*internal interface IItemDatas
    {
        private static readonly Lazy<ItemDatas> lazyDefaultItem = new(() => new ItemDatas());

        public int Id { get; }
        [JsonIgnore]
        public static ItemDatas DEFAULT_ITEM { get { return lazyDefaultItem.Value; } }
    }*/

    public class ItemDatas : ICloneable
    {
        public ItemDatas()
        {
            Id = 0;
        }

        private static readonly Lazy<ItemDatas> lazyDefaultItem = new(() => new ItemDatas());

        [JsonIgnore]
        public static ItemDatas DEFAULT_ITEM { get { return lazyDefaultItem.Value; } }
        [JsonPropertyName("id")]
        public int Id { get; set; }

        public ItemDatas Clone() { return (ItemDatas)this.MemberwiseClone(); }
        object ICloneable.Clone() { return Clone(); }

        public string ClassNameToString()
        {
            string rawName = this.GetType().Name;
            return Regex.Replace(rawName, @"(\p{Lu})", " $1").TrimStart();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (this == obj) return true;
            if (!obj.GetType().Equals(GetType())) return false;

            ItemDatas other = (ItemDatas)obj;

            return other.Id == Id;
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 31 * hash + GetType().GetHashCode();
            hash = 31 * hash + Id;

            return hash;
        }
    }
}