namespace CustomSearchBars
{
    public class SearchMadeEventArgs : EventArgs
    {
        public SearchMadeEventArgs() : base()
        {
            Result = "";
        }

        public String Result { get; set; }
    }
}