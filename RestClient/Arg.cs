namespace RestClient
{
    public class Arg
    {
        public Arg()
        {
            this.name = "";
            this.value = "";
            isVariable = false;
        }

        public Arg(String name)
        {
            this.name = name;
            this.value = "";
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
            if (this.name == "")
            {
                return "";
            }

            return this.name + "=" + this.value;
        }

        internal String GetFormatted(String value)
        {
            return this.name + "=" + value;
        }
    }
}