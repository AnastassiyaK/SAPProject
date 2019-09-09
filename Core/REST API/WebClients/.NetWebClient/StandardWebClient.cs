using Core.REST_API.WebClients.WebInterfaces;
using System.IO;
using System.Net;

namespace Core.REST_API.WebClients.NetWebClient
{
    public class StandardWebClient : IWebClient
    {
        private HttpWebRequest _request;

        private HttpWebResponse _response;

        public void CreateRequest(string baseUrl, string resource, CookieContainer container)
        {
            _request = WebRequest.Create(baseUrl + "/" + resource) as HttpWebRequest;
            _request.Method = "GET";

            if (container.Count != 0)
            {
                _request.CookieContainer = container;
            }
        }

        public void CreateRequest(string baseUrl, string resource)
        {
            _request = WebRequest.Create(baseUrl + "/" + resource) as HttpWebRequest;
            _request.Method = "GET";
        }

        public string GetResponse()
        {
            _response = _request.GetResponse() as HttpWebResponse;
            string result;
            if (_response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader stream = new StreamReader(_response.GetResponseStream());
                result = stream.ReadToEnd();
                stream.Close();
                _response.Close();
                return result;
            }
            return "";

        }
    }
}
