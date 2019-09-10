using Core.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace Core.DriverFactory
{
    public class ChromeDriverFactory : BaseWebDriverFactory
    {        
        protected override ICapabilities Capabilities
        {
            get
            {
                ChromeOptions options = new ChromeOptions();
                options.AddExcludedArgument("enable-automation");//enable info-bar
                options.AddAdditionalCapability("useAutomationExtension", false);//enable extensions 
                return options.ToCapabilities();
            }
        }

        public override IWebDriver CreateLocalWebDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");//enable info-bar
            options.AddAdditionalCapability("useAutomationExtension", false);//enable extensions  
            _driver = new ChromeDriver(options);
            return _driver;
        }
    }
}
