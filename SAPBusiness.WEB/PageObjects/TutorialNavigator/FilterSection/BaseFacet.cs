namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public abstract class BaseFacet : BasePageObject
    {
        public BaseFacet(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        protected abstract By Selector { get; }

        protected IWebElement Facet
        {
            get
            {
                return _driver.FindElement(Selector);
            }
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }

        public abstract void SelectTag(string tag);
    }
}
