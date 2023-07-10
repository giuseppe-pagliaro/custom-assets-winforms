using CustomLists;
using Newtonsoft.Json;

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
            AlphaTwoCode = String.Empty;
        }

        [JsonProperty(PropertyName = "web_pages")]
        public String[] WebPages { get; set; }

        [JsonProperty(PropertyName = "domains")]
        public String[] Domains { get; set; }

        [JsonProperty(PropertyName = "country")]
        public String Country { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "alpha_two_code")]
        public String AlphaTwoCode { get; set; }

        public override String ToString()
        {
            return $"\"{Name}\" in {Country} ({AlphaTwoCode}). Pages: {string.Join(",", WebPages)}. Domains: {string.Join(",", Domains)}.";
        }
    }
}