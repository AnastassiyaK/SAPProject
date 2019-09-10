using System.Net;

namespace SAPTests.REST_API.WebClients.WebInterfaces
{
    public interface IWebClient
    {
        void CreateRequest(string baseUrl, string resource, CookieContainer container);
        void CreateRequest(string baseUrl, string resource);

        string GetResponse();
    }
}
