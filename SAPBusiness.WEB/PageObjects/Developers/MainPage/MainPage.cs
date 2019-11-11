namespace SAPBusiness.WEB.PageObjects.Developers.MainPage
{
    using Core.WebDriver;
    using NLog;
    using SAPBusiness.Configuration;

    public class MainPage : BasePageObject, IMainPage
    {
        private readonly EnvironmentConfig _appConfiguration;

        public MainPage(WebDriver driver, ILogger logger, EnvironmentConfig appConfiguration)
            : base(driver, logger)
        {
            _appConfiguration = appConfiguration;
        }

        public void Open()
        {
            _driver.Navigate(_appConfiguration.ProdUrl);
        }

        public void WaitForLoad()
        {
            this.WaitForPageLoad();
        }
    }
}
