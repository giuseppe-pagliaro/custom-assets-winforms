namespace RestClient
{
    public class Arg
    {
        public Arg()
        {
            name = "";
            value = "";
            isVariable = false;
        }

        public Arg(String name)
        {
            this.name = name;
            value = "";
            isVariable = true;
        }

        public Arg(String name, String value)
        {
            this.name = name;
            this.value = value;
            isVariable = false;
        }

        private String name;
        private String value;
        internal bool isVariable;

        internal String GetFormatted()
        {
            if (name == "")
            {
                return "";
            }

            return name + "=" + value;
        }

        internal String GetFormatted(String value)
        {
            return name + "=" + value;
        }
    }
}