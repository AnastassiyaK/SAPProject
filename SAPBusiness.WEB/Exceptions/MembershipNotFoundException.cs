using System;

namespace SAPBusiness.WEB.Exceptions
{
    public class MembershipNotFoundException : Exception
    {
        public MembershipNotFoundException(string message)
            : base($"Attribute with title '{message}' was not found")
        {
        }
    }
}
