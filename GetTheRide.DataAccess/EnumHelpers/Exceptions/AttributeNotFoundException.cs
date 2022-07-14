namespace GetTheRide.DataAccess.EnumHelpers.Exceptions
{
    public class AttributeNotFoundException : Exception
    {
        public AttributeNotFoundException() { }
        public AttributeNotFoundException(string message) : base(message) { }
        public AttributeNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
