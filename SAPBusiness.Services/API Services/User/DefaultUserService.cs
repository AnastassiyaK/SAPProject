using Newtonsoft.Json;
using SAPBusiness.Services.Interfaces.API_UserService;
using SAPBusiness.UserData.DeveloperCenter;
using System.Net;
using System.IO;
using SeleniumCookie = OpenQA.Selenium.Cookie;
using Core.REST_API.Cookies;
using System.Collections.ObjectModel;
using SAPBusiness.Configuration;

namespace SAPBusiness.Services.API_Services.User
{
    public class DefaultUserService : BaseUserService, IUserService
    {
        private readonly ICookiesConverter _cookiesConverter;

        private readonly IAppConfiguration _appConfiguration;

        public DefaultUserService(ICookiesConverter cookiesConverter, IAppConfiguration appConfiguration)
        {
            _cookiesConverter = cookiesConverter;
            _appConfiguration = appConfiguration;
        }

        public UserStatistics GetStatistics(ReadOnlyCollection<SeleniumCookie> cookies)
        {
            var defaultCookies = _cookiesConverter.ExtractCookies(cookies);

            var request = WebRequest.Create(string.Concat(_appConfiguration.ProdUrl, "/", resourceUrl))
                as HttpWebRequest;

            request.Method = "GET";

            if (cookies.Count != 0)
            {
                request.CookieContainer = defaultCookies;
            }

            var response = request.GetResponse() as HttpWebResponse;

            string result = "";

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader stream = new StreamReader(response.GetResponseStream());
                result = stream.ReadToEnd();
                stream.Close();
                response.Close();
            }

            return JsonConvert.DeserializeObject<UserStatistics>(result);
        }
    }
}
