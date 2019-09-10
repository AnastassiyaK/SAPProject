using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.Logon
{
    public interface ILogOnSection
    {
        IWebElement LogOnButton { get; }
        IWebElement PasswordInput { get; }
        IWebElement UserNameInput { get; }
    }
}