using SAPTests.WebDriver;

namespace SAPBusiness.WEB.PageObjects
{
    public abstract class BasePageObject<PageObject> where PageObject : class
    {
        protected BaseWebDriver _driver;

        public BasePageObject(BaseWebDriver driver)
        {
            _driver = driver;
        }

        public virtual PageObject WaitForPageLoad()
        {
            _driver.WaitReadyState();
            return WaitForLoad();
        }

        protected abstract PageObject WaitForLoad();
    }
}
