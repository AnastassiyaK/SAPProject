namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.BlogPosts.FeedContent
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.Enums;

    public class FeedSortList : BasePageObject, IFeedSortItem
    {
        public FeedSortList(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        public string Active
        {
            get
            {
                _logger.Debug($"Trying to get active feed sort item.");
                return _driver.FindElement(By.CssSelector(".feed-sorting-container .active")).Text;
            }
        }

        private IWebElement FeedSortingContainer
        {
            get
            {
                return _driver.FindElement(By.ClassName("feed-sorting-container"));
            }
        }

        public void SelectFeedType(FeedType type)
        {
            _driver.FindElement(By.CssSelector(".feed-sorting-container .active")).Click();

            FeedSortingContainer.FindElement(GetTypeLocator(type)).Click();
            _logger.Debug($"{type} type was chosen.");

            WaitForLoad();
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".spinner"));
        }

        private static By GetTypeLocator(FeedType type) => By.XPath($"//span[text() = '{type}']");
    }
}
