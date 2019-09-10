using SAPTests.Configuration;
using SAPTests.REST_API.Cookies;
using OpenQA.Selenium;
using SAPBusiness.Services.Interfaces.API_UserService;
using SAPBusiness.UserData.DeveloperCenter;
using System.Collections.ObjectModel;

namespace SAPBusiness.Services.API_Services.User
{
    public class UserService
    {
        protected IUserService _userService;
        public UserService()
        {

            if (AppConfiguration.AppSetting["APIUserService:UserService"] == "RestSharp")
            {
                _userService = new RestSharpUserService();
            }
            if (AppConfiguration.AppSetting["APIUserService:UserService"] == ".NetStandard")
            {
                _userService = new DefaultUserService();
            }
        }
        public UserStatistics GetUserStatistics(ReadOnlyCollection<Cookie> cookies)
        {
            var _cookies = new CookiesService().ExtractCookies(cookies);
            return _userService.GetStatistics(_cookies);
        }
    }
}
