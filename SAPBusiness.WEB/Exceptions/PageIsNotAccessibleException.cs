namespace SAPBusiness.WEB.Exceptions
{
    using System;

    public class PageIsNotAccessibleException : Exception
    {
        public PageIsNotAccessibleException(string message)
            : base($"Page with number '{message}' does not exists")
        {
        }
    }
}
