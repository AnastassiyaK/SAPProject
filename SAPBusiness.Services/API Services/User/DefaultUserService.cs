using Newtonsoft.Json;
using SAPBusiness.Services.Interfaces.API_UserService;
using SAPBusiness.UserData.DeveloperCenter;
using System.Net;
using System.IO;
using SeleniumCookie = OpenQA.Selenium.Cookie;
using Core.REST_API.Cookies;
using System.Collections.ObjectModel;

namespace SAPBusiness.Services.API_Services.User
{
    public class DefaultUserService : BaseUserService, IUserService
    {
        public UserStatistics GetStatistics(ReadOnlyCollection<SeleniumCookie> cookies)
        {
            var defaultCookies = new CookiesConverter().ExtractCookies(cookies);

            var request = WebRequest.Create(baseUrl
                + "/" + resourceUrl) as HttpWebRequest;

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
