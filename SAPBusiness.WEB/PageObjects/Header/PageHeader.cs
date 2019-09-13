using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.Header
{
    public class PageHeader : BasePageObject, IPageHeader
    {
        public PageHeader(WebDriver driver) : base(driver)
        {

        }

        private IWebElement Logon
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".authentication-wrapper"));
            }
        }

        public void OpenLogonFrame()
        {
            Logon.Click();
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
