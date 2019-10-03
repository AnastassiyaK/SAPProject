using System;

namespace SAPBusiness.Services.Exceptions
{
    public class FileDownloadException : Exception
    {
        public FileDownloadException(string message)
           : base($"Empty response from REST client. '{message}'")
        {

        }
    }
}
