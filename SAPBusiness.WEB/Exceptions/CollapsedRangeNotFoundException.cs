namespace SAPBusiness.WEB.Exceptions
{
    using System;

    public class CollapsedRangeNotFoundException : Exception
    {
        public CollapsedRangeNotFoundException()
            : base($"There is no collapsed elements on the page.")
        {
        }
    }
}
