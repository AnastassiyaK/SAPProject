namespace SAPBusiness.WEB.Exceptions
{
    using System;

    public class TutorialBookmarkedException : Exception
    {
        public TutorialBookmarkedException(string message)
            : base($"Tutorial with title '{message}' has an active bookmark.")
        {
        }
    }
}
