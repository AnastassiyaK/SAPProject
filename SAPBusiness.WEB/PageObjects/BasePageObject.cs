using Core.WebDriver;

namespace SAPBusiness.WEB.PageObjects
{
    public interface IPageObject<PageObject> where PageObject : class
    {
        PageObject WaitForPageLoad();
    }

    public abstract class BasePageObject<PageObject> : IPageObject<PageObject> where PageObject : class
    {
        protected BaseWebDriver _driver;

        public BasePageObject(BaseWebDriver driver)
        {
            _driver = driver;
        }

        public PageObject WaitForPageLoad()
        {
            _driver.WaitReadyState();
            return WaitForLoad();
        }

        protected abstract PageObject WaitForLoad();
    }


}
