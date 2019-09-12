using Newtonsoft.Json;
using SAPBusiness.Services.Interfaces.API_UserService;
using SAPBusiness.UserData.DeveloperCenter;
using System.Net;
using RestSharp;
using SeleniumCookie = OpenQA.Selenium.Cookie;
using Core.REST_API.Cookies;
using System.Collections.ObjectModel;

namespace SAPBusiness.Services.API_Services.User
{
    public class RestSharpUserService : BaseUserService, IUserService
    {
        public UserStatistics GetStatistics(ReadOnlyCollection<SeleniumCookie> cookies)
        {
            var defaultCookies = new CookiesConverter().ExtractCookies(cookies);

            var client = new RestClient(baseUrl);

            var request = new RestRequest(resourceUrl, Method.GET);

            if (cookies.Count != 0)
            {
                client.CookieContainer = defaultCookies;
            }

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<UserStatistics>(response.Content);
            }
            else
            {
                throw new WebException($"{response.StatusCode}");
            }
        }
    }
}
