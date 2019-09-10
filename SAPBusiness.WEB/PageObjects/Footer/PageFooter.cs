using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.WEB.PageObjects.Footer.Networks;

namespace SAPBusiness.WEB.PageObjects.Footer
{
    public class PageFooter : BasePageObject<PageFooter>, IPageFooter
    {
        public PageFooter(BaseWebDriver driver) : base(driver)
        {

        }

        private IWebElement Networks => _driver.FindElement(By.ClassName("social-networks__list"));

        private static By GetSocialNetworkByTitle(string type) => By.CssSelector($"a[data-share-channel='{type}']");

        private SocialNetwork _socialNetwork;

        public SocialNetwork GetSocialNetwork(NetworkType type)
        {
            return _socialNetwork ?? (_socialNetwork = new SocialNetwork(Networks.FindElement(GetSocialNetworkByTitle(type.ToString()))));
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
