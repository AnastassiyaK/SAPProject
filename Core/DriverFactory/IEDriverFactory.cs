using SAPTests.Configuration;
using SAPTests.Interfaces.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;

namespace SAPTests.DriverFactory
{
    public class IEDriverFactory : IDriverFactory
    {
        private IWebDriver _driver;
        public IWebDriver CreateRemoteWebDriver()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.AddAdditionalCapability("useAutomationExtension", false);//enable extensions  
            _driver = new RemoteWebDriver(new Uri(AppConfiguration.AppSetting["SeleniumGrid:nodeUrl"]), options.ToCapabilities());
            return _driver;
        }

        public IWebDriver CreateLocalWebDriver()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.AddAdditionalCapability("useAutomationExtension", false);//enable extensions  
            _driver = new InternetExplorerDriver(options);
            return _driver;
        }
    }
}
