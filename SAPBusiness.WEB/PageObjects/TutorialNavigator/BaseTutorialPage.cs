using Core.WebDriver;
using SAPBusiness.Configuration;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public abstract class BaseTutorialPage : BasePageObject, IBaseTutorialPage
    {
        protected readonly IEnvironmentConfig _appConfiguration;
        public BaseTutorialPage(WebDriver driver, IEnvironmentConfig appConfiguration)
            : base(driver)
        {
            _appConfiguration = appConfiguration;
        }

        public abstract void Open(string url);

        public void WaitForLoad()
        {
            base.WaitForPageLoad();
        }
    }
}
