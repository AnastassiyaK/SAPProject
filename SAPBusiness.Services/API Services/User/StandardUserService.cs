using Core.Configuration;
using Core.REST_API.WebClients.NetWebClient;
using Core.REST_API.WebClients.WebInterfaces;
using Newtonsoft.Json;
using SAPBusiness.Services.Interfaces.API_UserService;
using SAPBusiness.UserData.DeveloperCenter;
using System.Net;

namespace SAPBusiness.Services.API_Services.User
{
    public class StandardUserService : IUserService
    {
        private IWebClient _webClient;
        public StandardUserService()
        {
            _webClient = new StandardWebClient();
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
