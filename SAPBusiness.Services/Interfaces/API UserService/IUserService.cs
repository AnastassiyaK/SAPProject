using SAPBusiness.UserData.DeveloperCenter;
using System.Collections.ObjectModel;
using SeleniumCookie = OpenQA.Selenium.Cookie;

namespace SAPBusiness.Services.Interfaces.API_UserService
{
    public interface IUserService
    {
        UserStatistics GetStatistics(ReadOnlyCollection<SeleniumCookie> cookies);
    }
}
