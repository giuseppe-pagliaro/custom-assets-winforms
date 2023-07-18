namespace HermoItemManagers
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IsCopyable : Attribute {}

    [AttributeUsage(AttributeTargets.Property)]
    public class IsNotMandatory : Attribute {}
}