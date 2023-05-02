using System.Text.RegularExpressions;

namespace CustomLists
{
    public class ItemDatas : ICloneable
    {
        public ItemDatas()
        {
            this.Id = 0;
        }

        public int Id { get; set; }

        public ItemDatas Clone() { return (ItemDatas)this.MemberwiseClone(); }
        object ICloneable.Clone() { return Clone(); }

        public String ClassNameToString()
        {
            String rawName = this.GetType().Name;
            return Regex.Replace(rawName, @"(\p{Lu})", " $1").TrimStart();
        }
    }
}