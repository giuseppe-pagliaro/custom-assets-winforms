using HermoCommons;
using HermoItemManagers.Fields;
using System.Text.Json.Serialization;

namespace Example
{
    public class DataExample : ItemDatas
    {
        public DataExample() : base()
        {
            Value = string.Empty;
        }

        [IsCopyable]
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}