using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent
{
    public class FeedSortList : BasePageObject, IFeedSortItem
    {
        public FeedSortList(WebDriver driver) : base(driver)
        {
        }

        private IWebElement FeedSortingContainer
        {
            get
            {
                return _driver.FindElement(By.ClassName("feed-sorting-container"));
            }
        }

        public string Active
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".feed-sorting-container .active")).Text;
            }
        }

        private static By GetTypeLocator(FeedType type) => By.XPath($"//span[text() = '{type}']");

        public void SelectFeedType(FeedType type)
        {
            _driver.FindElement(By.CssSelector(".feed-sorting-container .active")).Click();

            FeedSortingContainer.FindElement(GetTypeLocator(type)).Click();
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
