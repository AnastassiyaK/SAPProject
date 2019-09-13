using Newtonsoft.Json;
using SAPBusiness.Services.Interfaces.API_UserService;
using SAPBusiness.UserData.DeveloperCenter;
using System.Net;
using RestSharp;
using SeleniumCookie = OpenQA.Selenium.Cookie;
using Core.REST_API.Cookies;
using System.Collections.ObjectModel;
using SAPBusiness.Configuration;

namespace SAPBusiness.Services.API_Services.User
{
    public class RestSharpUserService : BaseUserService, IUserService
    {
        private readonly ICookiesConverter _cookiesConverter;

        private readonly IAppConfiguration _appConfiguration;

        public RestSharpUserService(ICookiesConverter cookiesConverter, IAppConfiguration appConfiguration)
        {
            _cookiesConverter = cookiesConverter;
            _appConfiguration = appConfiguration;
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
