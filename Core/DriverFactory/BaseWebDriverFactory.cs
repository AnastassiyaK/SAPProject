using SAPTests.Configuration;
using SAPTests.Interfaces.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAPTests.DriverFactory
{
    public abstract class BaseWebDriverFactory : IDriverFactory
    {
        protected IWebDriver _driver;

        protected abstract ICapabilities Capabilities { get; }

        public abstract IWebDriver CreateLocalWebDriver();

        public IWebDriver CreateRemoteWebDriver()
        {
            _driver = new RemoteWebDriver(new Uri(AppConfiguration.AppSetting["SeleniumGrid:nodeUrl"]), Capabilities);

            return _driver;
        }
    }
}
