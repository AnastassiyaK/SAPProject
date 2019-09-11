using Newtonsoft.Json;
using SAPBusiness.Services.Interfaces.API_UserService;
using SAPBusiness.UserData.DeveloperCenter;
using System.Net;
using Core.Configuration;
using System.IO;
using SeleniumCookie = OpenQA.Selenium.Cookie;
using Core.REST_API.Cookies;
using System.Collections.ObjectModel;

namespace SAPBusiness.Services.API_Services.User
{
    public class DefaultUserService : IUserService
    {
        public UserStatistics GetStatistics(ReadOnlyCollection<SeleniumCookie> cookies)
        {
            var defaultCookies = new CookiesService().ExtractCookies(cookies);

            var request = WebRequest.Create(AppConfiguration.AppSetting["APIUserService:baseUrlUserStatistics"]
                + "/" + AppConfiguration.AppSetting["APIUserService:resourceUserStatistics"]) as HttpWebRequest;

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
            
            try
            {
                return JsonConvert.DeserializeObject<UserStatistics>(result);
            }
            catch
            {
                return new UserStatistics();//should return null object
            }           
        }      
    }
}
