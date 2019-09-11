using Core.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace Core.DriverFactory
{
    public abstract class BaseWebDriverFactory : IDriverFactory
    {
        protected IWebDriver _driver;

        protected abstract ICapabilities Capabilities { get; }

        public abstract IWebDriver CreateLocalWebDriver();

        public IWebDriver CreateWebDriver()
        {
            _driver = new RemoteWebDriver(new Uri(AppConfiguration.NodeUrl), Capabilities);

            return _driver;
        }
    }
}
