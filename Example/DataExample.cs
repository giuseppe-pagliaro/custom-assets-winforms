using CustomLists;

namespace Example
{
    public class DataExample : ItemDatas
    {
        public DataExample() : base()
        {
            this.Value = "";
        }

        public DataExample(DataExample dataExample) : base(dataExample)
        {
            this.Value = dataExample.Value;
        }

        public String Value { get; set; }
    }
}