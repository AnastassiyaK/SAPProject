using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Core.DriverFactory
{
    public class FirefoxDriverFactory : BaseWebDriverFactory
    {
        protected override ICapabilities Capabilities
        {
            get
            {
                FirefoxOptions options = new FirefoxOptions();
                return options.ToCapabilities();
            }
        }

        public override IWebDriver CreateLocalWebDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddAdditionalCapability("useAutomationExtension", false);//enable extensions  
            _driver = new FirefoxDriver(options);
            return _driver;
        }
    }
}
