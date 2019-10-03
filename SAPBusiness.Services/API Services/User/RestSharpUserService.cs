using Core.REST_API.Cookies;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Extensions;
using SAPBusiness.Configuration;
using SAPBusiness.Services.Exceptions;
using SAPBusiness.Services.Interfaces.API_UserService;
using SAPBusiness.UserData.DeveloperCenter;
using SAPBusiness.UserData.History;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

        private IRestResponse GetDeveloperProgressJson(ReadOnlyCollection<SeleniumCookie> cookies)
        {
            RestClient client = GetClient();
            var defaultCookies = _cookiesConverter.ExtractCookies(cookies);

            var request = new RestRequest(resourceUrl, Method.GET);

            if (defaultCookies.Count != 0)
            {
                client.CookieContainer = defaultCookies;
            }

            var response = client.Execute(request);
            return response;
        }

        private RestClient GetClient()
        {
            return new RestClient(_appConfiguration.ProdUrl);
        }

        public UserStatistics GetStatistics(ReadOnlyCollection<SeleniumCookie> cookies)
        {
            IRestResponse response = GetDeveloperProgressJson(cookies);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<UserStatistics>(response.Content);
            }
            else
            {
                throw new WebException($"{response.StatusCode}");
            }
        }

        public IList<DeveloperHistory> GetUserHistory(ReadOnlyCollection<SeleniumCookie> cookies)
        {
            IRestResponse response = GetDeveloperProgressJson(cookies);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var history = JsonConvert.DeserializeObject<UserHistory>(response.Content).History;
                foreach (var item in history)
                {
                    item.TaskUrl = item.TaskUrl.Insert(0, _appConfiguration.ProdUrl);
                }
                return history;
            }
            else
            {
                throw new WebException($"{response.StatusCode}");
            }
        }

        public void DownloadHistory(ReadOnlyCollection<SeleniumCookie> cookies)
        {
            RestClient client = GetClient();

            var defaultCookies = _cookiesConverter.ExtractCookies(cookies);
            if (defaultCookies.Count != 0)
            {
                client.CookieContainer = defaultCookies;
            }
            var request = new RestRequest(historyUrl, Method.GET);
            var result = client.DownloadData(request);
            if (result != null && result.Length > 0)
            {
                result.SaveAs($@"{Directory.GetCurrentDirectory()}\TestData\User\download.csv");
            }
            else
            {
                throw new FileDownloadException("User History was not downloaded");
            }
        }
    }
}
