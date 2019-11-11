namespace Core.DriverFactory
{
    using System;
    using Core.Configuration;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;

    public abstract class WebDriverFactory : IDriverFactory
    {
        protected DriverConfiguration _configuration;

        protected IWebDriver _driver;

        public WebDriverFactory(DriverConfiguration configuration)
        {
            _configuration = configuration;
        }

        public abstract Browser Name { get; }

        protected abstract ICapabilities Capabilities { get; }

        public IWebDriver CreateWebDriver()
        {
            return _configuration.UseGrid
                ? CreateRemoteWebDriver()
                : CreateLocalWebDriver();
        }

        public override string ToString()
        {
            return Name.ToString();
        }

        protected abstract IWebDriver CreateLocalWebDriver();

        protected virtual IWebDriver CreateRemoteWebDriver()
        {
            _driver = new RemoteWebDriver(new Uri(_configuration.HubUrl), Capabilities);
            return _driver;
        }
    }
}
