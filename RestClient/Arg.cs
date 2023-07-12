namespace RestClient
{
    public class Arg
    {
        public Arg(String name, String value)
        {
            this.name = name;
            this.value = value;
        }

        private String name;
        private String value;

        internal String GetFormatted()
        {
            if (name == "")
            {
                return "";
            }

            return name + "=" + value;
        }
    }
}