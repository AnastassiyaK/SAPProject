using Core.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace Core.DriverFactory
{
    public class FirefoxDriverFactory : IDriverFactory
    {
        protected IWebDriver _driver;
        public IWebDriver CreateRemoteWebDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            //options.AddAdditionalCapability("useAutomationExtension", false);//enable extensions  
            _driver = new RemoteWebDriver(new Uri(AppConfiguration.AppSetting["SeleniumGrid:nodeUrl"]), options.ToCapabilities());
            return _driver;
        }
        public IWebDriver CreateLocalWebDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddAdditionalCapability("useAutomationExtension", false);//enable extensions  
            _driver = new FirefoxDriver(options);
            return _driver;
        }
    }
}
