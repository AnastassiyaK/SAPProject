using SAPTests.Configuration;
using SAPTests.REST_API.WebClients.RestSharpWebClient;
using SAPTests.REST_API.WebClients.WebInterfaces;
using Newtonsoft.Json;
using SAPBusiness.Services.Interfaces.API_UserService;
using SAPBusiness.UserData.DeveloperCenter;
using System.Net;

namespace SAPBusiness.Services.API_Services.User
{
    public class RestSharpUserService : IUserService
    {
        private IWebClient _webClient;
        public RestSharpUserService()
        {
            _webClient = new RestSharpWebClient();

        }
        public UserStatistics GetStatistics(CookieContainer cookies)
        {
            _webClient.CreateRequest(AppConfiguration.AppSetting["APIUserService:baseUrlUserStatistics"],
                AppConfiguration.AppSetting["APIUserService:resourceUserStatistics"],
            cookies);
            return JsonConvert.DeserializeObject<UserStatistics>(_webClient.GetResponse());
        }
    }
}
