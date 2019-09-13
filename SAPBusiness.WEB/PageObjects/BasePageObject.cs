using Core.WebDriver;

namespace SAPBusiness.WEB.PageObjects
{
    public abstract class BasePageObject
    {
        protected WebDriver _driver;

        public BasePageObject(WebDriver driver)
        {
            _driver = driver;
        }

        public virtual void WaitForPageLoad()
        {
            _driver.WaitReadyState();
        }
    }
}
