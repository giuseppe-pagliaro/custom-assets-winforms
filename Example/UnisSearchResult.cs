using CustomLists;

namespace Example
{
    public class UnisSearchResult : ItemDatas
    {
        public UnisSearchResult() : base()
        {
            WebPages = Array.Empty<String>();
            Domains = Array.Empty<String>();
            Country = String.Empty;
            Name = String.Empty;
            StateOrProvince = String.Empty;
            AlphaTwoCode = String.Empty;
        }

        public String[] WebPages { get; set; }
        public String[] Domains { get; set; }
        public String Country { get; set; }
        public String Name { get; set; }
        public String StateOrProvince { get; set; }
        public String AlphaTwoCode { get; set; }

        public override String ToString()
        {
            return $"\"{Name}\" in {Country} ({AlphaTwoCode}), {StateOrProvince}. Pages: {WebPages}, Domains: {Domains}.";
        }
    }
}
