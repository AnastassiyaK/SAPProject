namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    using Core.WebDriver;
    using NLog;
    using SAPBusiness.Configuration;

    public abstract class BaseTutorialPage : BasePageObject, IBaseTutorialPage
    {
        protected readonly EnvironmentConfig _appConfiguration;

        public BaseTutorialPage(WebDriver driver, ILogger logger, EnvironmentConfig appConfiguration)
            : base(driver, logger)
        {
            _appConfiguration = appConfiguration;
        }

        public abstract void Open(string url);

        public void WaitForLoad()
        {
            this.WaitForPageLoad();
        }
    }
}
