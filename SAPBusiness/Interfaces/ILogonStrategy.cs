using SAPBusiness.UserData;

namespace SAPBusiness.Interfaces
{
    public interface ILogonStrategy
    {
        void LogOn(User user);
    }
}
