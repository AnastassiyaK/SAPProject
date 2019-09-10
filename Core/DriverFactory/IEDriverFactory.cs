using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace Core.DriverFactory
{
    public class IEDriverFactory : BaseWebDriverFactory
    {
        protected override ICapabilities Capabilities
        {
            get
            {
                InternetExplorerOptions options = new InternetExplorerOptions();
                return options.ToCapabilities();
            }
        }

        public override IWebDriver CreateLocalWebDriver()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.AddAdditionalCapability("useAutomationExtension", false);//enable extensions  
            _driver = new InternetExplorerDriver(options);
            return _driver;
        }
    }
}
