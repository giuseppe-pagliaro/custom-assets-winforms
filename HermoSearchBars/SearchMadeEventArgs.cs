namespace HermoSearchBars
{
    public class SearchMadeEventArgs : EventArgs
    {
        public SearchMadeEventArgs() : base()
        {
            Result = Array.Empty<Object>();
        }

        public Object[] Result { get; set; }
    }
}