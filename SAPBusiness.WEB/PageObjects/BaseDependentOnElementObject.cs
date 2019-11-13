namespace SAPBusiness.WEB.PageObjects
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class BaseDependentOnElementObject : BasePageObject
    {
        protected readonly IWebElement _element;

        public BaseDependentOnElementObject(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, logger)
        {
            _element = element;
        }
    }
}
