using Core.WebDriver;
using SAPBusiness.Configuration;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Mission
{
    public class Mission : BaseTutorialPage, IMission
    {
        private readonly static string missionlUrl = "/mission.";

        public Mission(WebDriver driver, IEnvironmentConfig appConfiguration)
            : base(driver, appConfiguration)
        {
        }
        public override void Open(string url)
        {
            _driver.NavigateToPage(string.Concat(_appConfiguration.ProdUrl, missionlUrl, url));
        }
    }
}
