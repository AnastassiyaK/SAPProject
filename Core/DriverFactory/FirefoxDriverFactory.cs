using Core.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Core.DriverFactory
{
    public class FirefoxDriverFactory : WebDriverFactory
    {
        public FirefoxDriverFactory(IDriverConfiguration configuration) : base(configuration)
        {
        }

        protected override ICapabilities Capabilities
        {
            get
            {
                FirefoxOptions options = new FirefoxOptions();
                return options.ToCapabilities();
            }
        }

        protected override IWebDriver CreateLocalWebDriver()
        {
            //FirefoxOptions options = new FirefoxOptions();
            //options.AddAdditionalCapability("useAutomationExtension", false);
            _driver = new FirefoxDriver();
            return _driver;
        }
    }
}
