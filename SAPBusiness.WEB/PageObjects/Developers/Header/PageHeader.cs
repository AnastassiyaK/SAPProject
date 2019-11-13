namespace SAPBusiness.WEB.PageObjects.Developers.Header
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public abstract class PageHeader : BasePageObject, IPageHeader
    {
        public PageHeader(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        private IWebElement Logon
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".authentication-wrapper"));
            }
        }

        private IWebElement Menu
        {
            get
            {
                return _driver.FindElement(By.ClassName("menu-wrapper"));
            }
        }

        private List<HeaderLink> Links
        {
            get
            {
                return _driver.FindElements(By.CssSelector("li[class='menu__item']"))
                    .Select(element => new HeaderLink(_driver, element, _logger))
                    .ToList();
            }
        }

        public virtual List<string> GetMenuLinks()
        {
            var linksText = Links.Select(link => link.Text).ToList();
            return linksText;
        }

        public virtual void OpenLogonFrame()
        {
            Logon.Click();
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
