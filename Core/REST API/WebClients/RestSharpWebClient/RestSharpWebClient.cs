using Core.REST_API.WebClients.WebInterfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core.REST_API.WebClients.RestSharpWebClient
{
    public class RestSharpWebClient: IWebClient
    {
        private RestClient _client;

        private RestRequest _restRequest;
        public void CreateRequest(string baseUrl, string resource, CookieContainer container)
        {
            _client = new RestClient(baseUrl);
            if (container.Count != 0)
            {
                _client.CookieContainer = container;
            }
            //_client.Authenticator = new HttpBasicAuthenticator("wcms","wcms");
            _restRequest = new RestRequest(resource, Method.GET);
        }

        public void CreateRequest(string baseUrl, string resource)
        {
            _client = new RestClient(baseUrl);
            _restRequest = new RestRequest(resource, Method.GET);
        }

        public string GetResponse()
        {
            var response = _client.Execute(_restRequest);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Content;
            }
            return "";
        }
    }
}
