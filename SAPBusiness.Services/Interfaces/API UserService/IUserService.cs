using SAPBusiness.UserData.DeveloperCenter;
using SAPBusiness.UserData.History;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SeleniumCookie = OpenQA.Selenium.Cookie;

namespace SAPBusiness.Services.Interfaces.API_UserService
{
    public interface IUserService
    {
        UserStatistics GetStatistics(ReadOnlyCollection<SeleniumCookie> cookies);

        IList<DeveloperHistory> GetUserHistory(ReadOnlyCollection<SeleniumCookie> cookies);

        void DownloadHistory(ReadOnlyCollection<SeleniumCookie> cookies);
    }
}
