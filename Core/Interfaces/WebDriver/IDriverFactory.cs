using OpenQA.Selenium;

namespace Core.Interfaces.WebDriver
{
    public interface IDriverFactory
    {
        IWebDriver CreateRemoteWebDriver();

        IWebDriver CreateLocalWebDriver();
    }
}
