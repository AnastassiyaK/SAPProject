namespace SAPBusiness.WEB.PageObjects.Developers.Header
{
    using System.Collections.Generic;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class MobilePageHeader : PageHeader
    {
        public MobilePageHeader(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        private IWebElement IconMenu
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".menu__icon-mobile"));
            }
        }

        public override List<string> GetMenuLinks()
        {
            IconMenu.Click();
            return base.GetMenuLinks();
        }
    }
}
