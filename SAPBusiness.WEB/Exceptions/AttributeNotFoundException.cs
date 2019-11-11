namespace SAPBusiness.WEB.Exceptions
{
    using System;

    public class AttributeNotFoundException : Exception
    {
        public AttributeNotFoundException(string message)
            : base($"Attribute with title '{message}' was not found")
        {
        }
    }
}
