namespace HermoItemManagers
{
    public class BuilderNotInstantiatedException : Exception
    {
        public BuilderNotInstantiatedException() : base("Couldn't create your factory, make sure it implements a default constructor.") { }
    }

    public class IncompatiblePropertiesException : Exception
    {
        public IncompatiblePropertiesException() : base("The properties you provided in SetProps don't correspond to the props of the factory.") { }
    }
}