using SAPBusiness.UserData;

namespace SAPBusiness.Interfaces
{
    public interface ILogOnStrategy
    {
        void LogOn(User user);
    }
}
