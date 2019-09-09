using Core.Configuration;
using Core.Interfaces.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace Core.DriverFactory
{
    public class ChromeDriverFactory : IDriverFactory
    {
        protected IWebDriver _driver;
        public IWebDriver CreateRemoteWebDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");//enable info-bar
            options.AddAdditionalCapability("useAutomationExtension", false);//enable extensions  
            _driver = new RemoteWebDriver(new Uri(AppConfiguration.AppSetting["SeleniumGrid:nodeUrl"]), options.ToCapabilities());

            return _driver;
        }
        public IWebDriver CreateLocalWebDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");//enable info-bar
            options.AddAdditionalCapability("useAutomationExtension", false);//enable extensions  
            _driver = new ChromeDriver(options);
            return _driver;
        }
    }
}
