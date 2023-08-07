namespace HermoItemManagers.Fields
{
    public class OpenDialogFilter
    {
        public OpenDialogFilter()
        {
            name = "";
            extension = "";
        }

        public OpenDialogFilter(string name, string extension)
        {
            this.name = name;
            this.extension = extension;
        }

        private string name;
        private string extension;

        public override string ToString()
        {
            if (name == "")
            {
                return "";
            }

            return name + " (" + extension + ")|" + extension;
        }
    }
}