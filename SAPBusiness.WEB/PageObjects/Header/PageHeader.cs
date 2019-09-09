using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.Header
{
    public class PageHeader : BasePageObject<PageHeader>
    {
        public PageHeader(BaseWebDriver driver) : base(driver)
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

        protected override PageHeader WaitForLoad()
        {
            return this;
        }
    }
}
