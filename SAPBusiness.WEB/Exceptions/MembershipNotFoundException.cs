namespace SAPBusiness.WEB.Exceptions
{
    using System;

    public class MembershipNotFoundException : Exception
    {
        public MembershipNotFoundException(string message)
            : base($"Attribute with title '{message}' was not found")
        {
        }
    }
}
