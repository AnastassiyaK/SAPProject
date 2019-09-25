using Core.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace Core.DriverFactory
{
    public class IEDriverFactory : WebDriverFactory
    {
        public IEDriverFactory(IDriverConfiguration configuration) : base(configuration)
        {
        }

        protected override ICapabilities Capabilities
        {
            get
            {
                InternetExplorerOptions options = new InternetExplorerOptions();
                options.AddAdditionalCapability("useAutomationExtension", false);
                options.AddAdditionalCapability("ensureCleanSession", true);
                //options.AddAdditionalCapability("ignoreZoomSetting", true);
                //options.AddAdditionalCapability("ignoreProtectedModeSettings", true);
                options.AddAdditionalCapability("ignore-certificate-error", true);
                return options.ToCapabilities();
            }
        }

        protected override IWebDriver CreateLocalWebDriver()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddAdditionalCapability("ensureCleanSession", true);
            options.AddAdditionalCapability("ignore-certificate-error", true);
            _driver = new InternetExplorerDriver(options);
            return _driver;
        }
    }
}
