using System;

namespace SAPBusiness.WEB.Exceptions
{
    public class CollapsedRangeNotFoundException : Exception
    {
        public CollapsedRangeNotFoundException()
            : base($"There is no collapsed elements on the page.")
        {
        }
    }
}
