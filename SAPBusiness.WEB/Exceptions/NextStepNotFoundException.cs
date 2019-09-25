using System;

namespace SAPBusiness.WEB.Exceptions
{
    public class NextStepNotFoundException : Exception
    {
        public NextStepNotFoundException(string message)
          : base(message)
        {
        }
    }
}
