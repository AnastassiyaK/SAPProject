namespace SAPBusiness.WEB.PageObjects
{
    using Core.WebDriver;
    using NLog;

    public abstract class BasePageObject
    {
        protected WebDriver _driver;

        protected ILogger _logger;

        public BasePageObject(WebDriver driver, ILogger logger)
        {
            _driver = driver;
            _logger = logger;
        }

        public virtual void WaitForPageLoad()
        {
            _driver.WaitReadyState();
        }
    }
}
