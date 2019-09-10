using SAPTests.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.WEB.PageObjects.Footer.Networks;

namespace SAPBusiness.WEB.PageObjects.Footer
{
    public class PageFooter : BasePageObject<PageFooter>
    {
        public PageFooter(BaseWebDriver driver) : base(driver)
        {
        }
        private IWebElement _networks => _driver.FindElement(By.ClassName("social-networks__list"));

        private static By GetSocialNetworkByTitle(string type) => By.CssSelector($"a[data-share-channel='{type}']");

        private SocialNetwork _socialNetwork;

        public SocialNetwork GetSocialNetwork(NetworkType type)
        {
            return _socialNetwork ?? (_socialNetwork = new SocialNetwork(_networks.FindElement(GetSocialNetworkByTitle(type.ToString()))));
        }

        public void OpenSocialNetWorkPage(NetworkType type)
        {
            GetSocialNetwork(type).GoToLink.Click();
            _driver.SwitchToLastTab();
        }

        protected override PageFooter WaitForLoad()
        {
            return this;
        }
    }
}
