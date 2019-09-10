using OpenQA.Selenium;

namespace SAPTests.Interfaces.WebDriver
{
    public interface IDriverFactory
    {
        IWebDriver CreateRemoteWebDriver();

        IWebDriver CreateLocalWebDriver();
    }
}
