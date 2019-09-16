using System;

namespace SAPBusiness.WEB.Exceptions
{
    public class AttributeNotFoundException : Exception
    {
        public AttributeNotFoundException(string message) 
            : base($"Attribute with title '{message}' was not found")
        {

        }
    }
}
