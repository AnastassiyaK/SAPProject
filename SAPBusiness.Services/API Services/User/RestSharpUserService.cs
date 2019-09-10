using Newtonsoft.Json;
using SAPBusiness.Services.Interfaces.API_UserService;
using SAPBusiness.UserData.DeveloperCenter;
using System.Net;
using Core.Configuration;
using RestSharp;
using System;

namespace SAPBusiness.Services.API_Services.User
{
    public class RestSharpUserService : IUserService
    {
        public UserStatistics GetStatistics(CookieContainer cookies)
        {
            var client = new RestClient(AppConfiguration.AppSetting["APIUserService:baseUrlUserStatistics"]);

            var request = new RestRequest(AppConfiguration.AppSetting["APIUserService:resourceUserStatistics"], Method.GET);

            if (cookies.Count != 0)
            {
                client.CookieContainer = cookies;
            }

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    return JsonConvert.DeserializeObject<UserStatistics>(response.Content);
                }
                catch
                {
                    return new UserStatistics();//should return null object
                }
            }
            else
            {
                throw new Exception();//implement exeption if status code was not OK
            }
        }
    }
}
