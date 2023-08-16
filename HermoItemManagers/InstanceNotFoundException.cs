public class InstanceNotFoundException : Exception
{
    public InstanceNotFoundException() : base("Couldn't find the Instance property in your builder.") { }
}