namespace HermoRestClient
{
    public class Arg
    {
        public Arg(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        private string name;
        private string value;

        internal string GetFormatted()
        {
            if (name == "")
            {
                return "";
            }

            return name + "=" + value;
        }
    }
}