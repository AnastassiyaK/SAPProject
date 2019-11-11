namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class FeaturedContentSection : BasePageObject, IFeaturedContentSection
    {
        public FeaturedContentSection(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        public string Title
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".featured-content-title")).Text;
            }
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
