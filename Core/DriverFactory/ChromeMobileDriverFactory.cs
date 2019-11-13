namespace Core.DriverFactory
{
    using Core.Configuration;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class ChromeMobileDriverFactory : WebDriverFactory
    {
        public ChromeMobileDriverFactory(DriverConfiguration configuration)
            : base(configuration)
        {
        }

        public override Browser Name { get; } = Browser.ChromeMobile;

        protected override ICapabilities Capabilities
        {
            get
            {
                ChromeOptions options = new ChromeOptions();

                options.AddExcludedArgument("enable-automation");
                options.AddAdditionalCapability("useAutomationExtension", false);
                options.AddArguments("start-maximized");
                options.EnableMobileEmulation("iPhone 6");
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
