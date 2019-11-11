namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public abstract class BasePageLink : BaseDependentOnElementObject
    {
        public BasePageLink(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
        {
        }

        public virtual string Link
        {
            get
            {
                return _element.FindElement(By.CssSelector("a")).GetAttribute("data-href");
            }
        }

        protected string Text
        {
            get
            {
                return _element.Text;
            }
        }

        public abstract void Click();

        public virtual bool ContainsPage(int number)
        {
            if (Link.Contains(number.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
