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

        private String name;
        private String extension;

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