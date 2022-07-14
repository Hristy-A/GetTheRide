namespace GetTheRide.Domain;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class EnumDescriberAttribute : Attribute
{
    public readonly Type EnumType;
    public EnumDescriberAttribute(Type enumType)
    {
        EnumType = enumType;
    }
}