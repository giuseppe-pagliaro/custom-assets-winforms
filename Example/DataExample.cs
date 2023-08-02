using HermoCommons;
using HermoItemManagers.Fields;
using System.Text.Json.Serialization;

namespace Example
{
    public class DataExample : ItemDatas
    {
        public DataExample() : base()
        {
            Value = String.Empty;
        }

        [IsCopyable]
        [JsonPropertyName("value")]
        public String Value { get; set; }
    }
}