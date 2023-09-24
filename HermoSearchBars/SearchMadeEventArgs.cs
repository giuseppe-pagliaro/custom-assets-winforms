using HermoCommons;

namespace HermoSearchBars
{
    public class SearchMadeEventArgs : EventArgs
    {
        public SearchMadeEventArgs() : base()
        {
            Result = Array.Empty<ItemDatas>();
        }

        public ItemDatas[] Result { get; set; }
    }
}