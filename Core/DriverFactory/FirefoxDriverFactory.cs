namespace Core.DriverFactory
{
    using Core.Configuration;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;

    public class FirefoxDriverFactory : WebDriverFactory
    {
        public FirefoxDriverFactory(DriverConfiguration configuration)
            : base(configuration)
        {
        }

        public override Browser Name { get; } = Browser.Firefox;

        protected override ICapabilities Capabilities
        {
            get
            {
                FirefoxOptions options = new FirefoxOptions();
                options.AddArguments("start-maximized");
                return options.ToCapabilities();
            }
        }

        protected override IWebDriver CreateLocalWebDriver()
        {
            // FirefoxOptions options = new FirefoxOptions();
            // options.AddAdditionalCapability("useAutomationExtension", false);
            _driver = new FirefoxDriver();
            return _driver;
        }
    }
}
