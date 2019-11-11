namespace SAPBusiness.Services.Exceptions
{
    using System;

    public class FileDownloadException : Exception
    {
        public FileDownloadException(string message)
           : base($"Empty response from REST client. '{message}'")
        {
        }
    }
}
