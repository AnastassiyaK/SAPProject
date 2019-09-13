using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.WEB.PageObjects.Footer.Networks;

namespace SAPBusiness.WEB.PageObjects.Footer
{
    public class PageFooter : BasePageObject, IPageFooter
    {
        public PageFooter(WebDriver driver) : base(driver)
        {

        }

        private IWebElement Networks => _driver.FindElement(By.ClassName("social-networks__list"));

        private ISocialNetwork _socialNetwork;

        public void WaitForLoad()
        {
            base.WaitForPageLoad();
        }
    }
}
