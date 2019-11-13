namespace SAPBusiness.WEB.Exceptions
{
    using System;

    public class NextStepNotFoundException : Exception
    {
        public NextStepNotFoundException(string message)
          : base(message)
        {
        }
    }
}
