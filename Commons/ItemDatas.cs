using System.Text.RegularExpressions;

namespace CustomLists
{
    public class ItemDatas : ICloneable
    {
        public ItemDatas()
        {
            Id = 0;
        }

        public int Id { get; set; }

        public ItemDatas Clone() { return (ItemDatas)this.MemberwiseClone(); }
        object ICloneable.Clone() { return Clone(); }

        public String ClassNameToString()
        {
            String rawName = this.GetType().Name;
            return Regex.Replace(rawName, @"(\p{Lu})", " $1").TrimStart();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (this == obj)
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            ItemDatas other = (ItemDatas)obj;

            return other.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}