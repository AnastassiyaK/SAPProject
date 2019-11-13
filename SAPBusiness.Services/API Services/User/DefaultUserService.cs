namespace SAPBusiness.Services.API_Services.User
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Net;
    using Core.REST_API.Cookies;
    using Newtonsoft.Json;
    using SAPBusiness.Configuration;
    using SAPBusiness.Services.Exceptions;
    using SAPBusiness.Services.Interfaces.API_UserService;
    using SAPBusiness.UserData.DeveloperCenter;
    using SAPBusiness.UserData.History;
    using SeleniumCookie = OpenQA.Selenium.Cookie;

    public class DefaultUserService : BaseUserService, IUserService
    {
        public DefaultUserService(ICookiesConverter cookiesConverter, EnvironmentConfig appConfiguration)
            : base(cookiesConverter, appConfiguration)
        {
        }

        public UserStatistics GetStatistics(ReadOnlyCollection<SeleniumCookie> cookies)
        {
            string result = GetDeveloperProgressJson(cookies);

            return JsonConvert.DeserializeObject<UserStatistics>(result);
        }

        public IList<DeveloperHistory> GetUserHistory(ReadOnlyCollection<SeleniumCookie> cookies)
        {
            string result = GetDeveloperProgressJson(cookies);

            var history = JsonConvert.DeserializeObject<UserHistory>(result).History;
            foreach (var item in history)
            {
                item.TaskUrl = item.TaskUrl.Insert(0, _appConfiguration.ProdUrl);
            }

            return history;
        }

        public void DownloadHistory(ReadOnlyCollection<SeleniumCookie> cookies, string path)
        {
            var defaultCookies = _cookiesConverter.ExtractCookies(cookies);

            var request = WebRequest.Create(GetFullUrl(historyUrl))
                as HttpWebRequest;

            request.Method = "GET";

            if (cookies.Count != 0)
            {
                request.CookieContainer = defaultCookies;
            }

            var response = request.GetResponse() as HttpWebResponse;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader stream = new StreamReader(response.GetResponseStream());
                File.WriteAllText($@"{Directory.GetCurrentDirectory()}\TestData\{path}.csv", stream.ReadToEnd());
                stream.Close();
                response.Close();
            }
            else
            {
                throw new FileDownloadException("User History was not downloaded");
            }
        }

        private string GetDeveloperProgressJson(ReadOnlyCollection<SeleniumCookie> cookies)
        {
            var defaultCookies = _cookiesConverter.ExtractCookies(cookies);

            var request = WebRequest.Create(GetFullUrl(resourceUrl))
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

            return result;
        }

        private string GetFullUrl(string partialUrl)
        {
            return string.Concat(_appConfiguration.ProdUrl, "/", partialUrl);
        }
    }
}
