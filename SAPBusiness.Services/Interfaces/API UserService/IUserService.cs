namespace SAPBusiness.Services.Interfaces.API_UserService
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using SAPBusiness.UserData.DeveloperCenter;
    using SAPBusiness.UserData.History;
    using SeleniumCookie = OpenQA.Selenium.Cookie;

    public interface IUserService
    {
        UserStatistics GetStatistics(ReadOnlyCollection<SeleniumCookie> cookies);

        IList<DeveloperHistory> GetUserHistory(ReadOnlyCollection<SeleniumCookie> cookies);

        void DownloadHistory(ReadOnlyCollection<SeleniumCookie> cookies, string path);
    }
}
