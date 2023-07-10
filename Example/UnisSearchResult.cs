using CustomLists;

namespace Example
{
    public class UnisSearchResult : ItemDatas
    {
        public UnisSearchResult() : base()
        {
            Web_Pages = Array.Empty<String>();
            Domains = Array.Empty<String>();
            Country = String.Empty;
            Name = String.Empty;
            Alpha_Two_Code = String.Empty;
        }

        public String[] Web_Pages { get; set; }
        public String[] Domains { get; set; }
        public String Country { get; set; }
        public String Name { get; set; }
        public String Alpha_Two_Code { get; set; }

        public override String ToString()
        {
            return $"\"{Name}\" in {Country} ({Alpha_Two_Code}). Pages: {string.Join(",", Web_Pages)}. Domains: {string.Join(",", Domains)}.";
        }
    }
}