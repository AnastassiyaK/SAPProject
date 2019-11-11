namespace Core.DriverFactory
{
    using OpenQA.Selenium;

    public interface IDriverFactory
    {
        Browser Name { get; }

        IWebDriver CreateWebDriver();
    }
}
