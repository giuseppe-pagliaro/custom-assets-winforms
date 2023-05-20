namespace CustomLists
{
    public class IncompatibleClassException : Exception
    {
        public IncompatibleClassException()
            : base("The class you provided isn't or doesn't extend \"CustomItemManagers.FieldsForm\".") { }
    }
}