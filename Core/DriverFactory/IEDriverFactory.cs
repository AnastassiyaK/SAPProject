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
                InternetExplorerOptions options = new InternetExplorerOptions
                {
                    EnsureCleanSession = true,
                    IntroduceInstabilityByIgnoringProtectedModeSettings=true                  
                };
                options.AddAdditionalCapability("useAutomationExtension", false);
                //options.AddAdditionalCapability("ignoreZoomSetting", true);
                options.AddAdditionalCapability("ignore-certificate-error", true);
                return options.ToCapabilities();
            }
        }

        protected override IWebDriver CreateLocalWebDriver()
        {
            InternetExplorerOptions options = new InternetExplorerOptions
            {
                EnsureCleanSession = true,
                IntroduceInstabilityByIgnoringProtectedModeSettings = false
            };
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddAdditionalCapability("ignore-certificate-error", true);
            _driver = new InternetExplorerDriver(options);
            return _driver;
        }
    }
}
