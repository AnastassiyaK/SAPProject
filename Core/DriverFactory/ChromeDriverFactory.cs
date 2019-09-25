using Core.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core.DriverFactory
{
    public class ChromeDriverFactory : WebDriverFactory
    {
        public ChromeDriverFactory(IDriverConfiguration configuration) : base(configuration)
        {
        }

        protected override ICapabilities Capabilities
        {
            get
            {
                ChromeOptions options = new ChromeOptions();
                options.AddExcludedArgument("enable-automation");
                options.AddAdditionalCapability("useAutomationExtension", false);
                options.AddArguments("start-maximized");
                return options.ToCapabilities();
            }
        }

        protected override IWebDriver CreateLocalWebDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalCapability("useAutomationExtension", false);
            _driver = new ChromeDriver(options);
            return _driver;
        }
    }
}
