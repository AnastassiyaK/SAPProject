using Core.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace Core.DriverFactory
{
    public abstract class WebDriverFactory : IDriverFactory
    {
        protected IDriverConfiguration _configuration;

        protected IWebDriver _driver;

        public WebDriverFactory(IDriverConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected abstract ICapabilities Capabilities { get; }

        protected abstract IWebDriver CreateLocalWebDriver();

        protected virtual IWebDriver CreateRemoteWebDriver()
        {
            _driver = new RemoteWebDriver(new Uri(_configuration.HubUrl), Capabilities);
            return _driver;
        }

        public IWebDriver CreateWebDriver()
        {
            return _configuration.UseGrid
                ? CreateRemoteWebDriver()
                : CreateLocalWebDriver();
        }
    }
}
