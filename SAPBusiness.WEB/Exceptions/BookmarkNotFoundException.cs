namespace SAPBusiness.WEB.Exceptions
{
    using System;

    public class BookmarkNotFoundException : Exception
    {
        public BookmarkNotFoundException(string message)
          : base($"Bookmark with title '{message}' was not found")
        {
        }
    }
}
