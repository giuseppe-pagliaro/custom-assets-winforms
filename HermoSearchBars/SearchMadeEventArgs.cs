namespace HermoSearchBars
{
    public class SearchMadeEventArgs : EventArgs
    {
        public SearchMadeEventArgs() : base()
        {
            Result = Array.Empty<object>();
        }

        public object[] Result { get; set; }
    }
}