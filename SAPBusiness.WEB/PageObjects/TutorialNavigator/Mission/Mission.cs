namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Mission
{
    using Core.WebDriver;
    using NLog;
    using SAPBusiness.Configuration;

    public class Mission : BaseTutorialPage, IMission
    {
        private static readonly string _missionlUrl = "/mission.";

        public Mission(WebDriver driver, ILogger logger, EnvironmentConfig appConfiguration)
            : base(driver, logger, appConfiguration)
        {
        }

        private SummarySection SummarySection
        {
            get
            {
                return new SummarySection(_driver, _logger, _appConfiguration);
            }
        }

        public void AddBookmark()
        {
            SummarySection.AddBookmark();
        }

        public override void Open(string url)
        {
            _driver.NavigateToPage(string.Concat(_appConfiguration.ProdUrl, _missionlUrl, url));
        }
    }
}
