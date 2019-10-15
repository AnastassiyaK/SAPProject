using System;
using System.Collections.Generic;
using System.Text;

namespace SAPBusiness.WEB.Exceptions
{
    public class PageIsNotAccessibleException : Exception
    {
        public PageIsNotAccessibleException(string message)
            : base($"Page with number '{message}' does not exists")
        {
        }
    }
}
