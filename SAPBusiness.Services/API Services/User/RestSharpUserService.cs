using Core.REST_API.Cookies;
using Newtonsoft.Json;
using RestSharp;
using SAPBusiness.Configuration;
using SAPBusiness.Services.Interfaces.API_UserService;
using SAPBusiness.UserData.DeveloperCenter;
using System.Collections.ObjectModel;
using System.Net;
using SeleniumCookie = OpenQA.Selenium.Cookie;

namespace SAPBusiness.Services.API_Services.User
{
    public class RestSharpUserService : BaseUserService, IUserService
    {
        public RestSharpUserService(ICookiesConverter cookiesConverter, IEnvironmentConfig appConfiguration)
            : base(cookiesConverter, appConfiguration)
        {
        }

        public UserStatistics GetStatistics(ReadOnlyCollection<SeleniumCookie> cookies)
        {
            var defaultCookies = _cookiesConverter.ExtractCookies(cookies);

            var client = new RestClient(_appConfiguration.ProdUrl);

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
