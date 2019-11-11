namespace SAPBusiness.WEB.PageObjects.Developers.Header
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class SideMenuBookmark : BaseDependentOnElementObject
    {
        public SideMenuBookmark(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
        {
        }

        public string Link
        {
            get
            {
                return LinkElement.GetAttribute("href");
            }
        }

        public string Title
        {
            get
            {
                return LinkElement.Text;
            }
        }

        protected IWebElement LinkElement
        {
            get
            {
                return _element.FindElement(By.CssSelector("a"));
            }
        }
    }
}
