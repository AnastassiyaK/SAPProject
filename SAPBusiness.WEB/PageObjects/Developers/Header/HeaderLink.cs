namespace SAPBusiness.WEB.PageObjects.Developers.Header
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class HeaderLink : BaseDependentOnElementObject
    {
        public HeaderLink(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
        {
        }

        public string Text
        {
            get
            {
                return LinkElement.Text;
            }
        }

        private IWebElement LinkElement
        {
            get
            {
                return _element.FindElement(By.ClassName("link__title"));
            }
        }
    }
}
