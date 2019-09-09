using SAPBusiness.UserData.DeveloperCenter;
using System.Net;

namespace SAPBusiness.Services.Interfaces.API_UserService
{
    public interface IUserService
    {
        UserStatistics GetStatistics(CookieContainer cookies);
    }
}
