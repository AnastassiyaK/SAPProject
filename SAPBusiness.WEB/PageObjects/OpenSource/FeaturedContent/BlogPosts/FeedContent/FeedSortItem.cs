﻿using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent
{
    public class FeedSortItem : BasePageObject, IFeedSortItem
    {
        private IWebElement FeedSortingContainer => _driver.FindElement(By.ClassName("feed-sorting-container"));

        public FeedSortItem(WebDriver driver) : base(driver)
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

            FeedSortingContainer.FindElement(GetTypeLocator(type)).Click();
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
