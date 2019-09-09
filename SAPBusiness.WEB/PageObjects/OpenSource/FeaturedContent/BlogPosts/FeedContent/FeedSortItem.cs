using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.WEB.PageObjects;

namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent
{
    public class FeedSortItem : BasePageObject<FeedSortItem>
    {
        private IWebElement _feedSortingContainer => _driver.FindElement(By.ClassName("feed-sorting-container"));
        public FeedSortItem(BaseWebDriver driver) : base(driver)
        {

        }
        public string Active
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".feed-sorting-container .active")).Text;
            }

        }
        private static By GetTypeLocator(FeedType type) => By.XPath($"//div[@class='for-selection']//span[text() = '{type}']");
        public void SelectFeedType(FeedType type)
        {
            _driver.FindElement(By.CssSelector(".feed-sorting-container .active")).Click();
            //wait
            _feedSortingContainer.FindElement(GetTypeLocator(type)).Click();
        }

        protected override FeedSortItem WaitForLoad()
        {
            return this;
        }
    }
}
