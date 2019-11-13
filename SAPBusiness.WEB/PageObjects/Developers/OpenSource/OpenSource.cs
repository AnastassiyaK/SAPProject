namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource
{
    using Core.WebDriver;
    using NLog;
    using SAPBusiness.Configuration;

    public class OpenSource : BasePageObject, IOpenSource
    {
        private readonly string relativeUrl = "/open-source";

        private readonly EnvironmentConfig _appConfiguration;

        public OpenSource(WebDriver driver, ILogger logger, EnvironmentConfig appConfiguration)
            : base(driver, logger)
        {
            _appConfiguration = appConfiguration;
        }

        public void Open()
        {
            _driver.NavigateToPage(string.Concat(_appConfiguration.ProdUrl, relativeUrl));
        }
    }
}
