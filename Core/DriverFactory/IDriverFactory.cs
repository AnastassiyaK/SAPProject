using OpenQA.Selenium;

namespace Core.DriverFactory
{
    public interface IDriverFactory
    {
        IWebDriver CreateRemoteWebDriver();

        IWebDriver CreateLocalWebDriver();
    }
}
