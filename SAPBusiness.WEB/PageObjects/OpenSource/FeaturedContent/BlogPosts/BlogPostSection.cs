using OpenQA.Selenium;
using SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.WebDriver;

namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts
{
    public class BlogPostSection : BasePageObject<BlogPostSection>, IBlogPostSection
    {

        public BlogPostSection(BaseWebDriver driver) : base(driver)
        {

        }

        private FeedSortItem _feedSortItem;

        private FeedSortItem FeedSortItem
        {
            get
            {
                return _feedSortItem ??
                    (_feedSortItem = new FeedSortItem(_driver));
            }
        }
        public string Icon
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#order-id-3 .header-container .icon")).GetAttribute("url");
            }
        }
        public string Topic
        {
            get
            {
                return _driver.FindElement(By.CssSelector("#order-id-3 .header-container .header-topic")).Text;
            }
        }

        private List<Feed> _feeds;
        private List<Feed> Feeds
        {
            get
            {
                return _feeds ??
                      (_feeds = _driver.FindElements(By.ClassName("feed-item"))
                      .Select(element => new Feed(element))
                      .ToList()
                      );
            }
        }

        public int GetFeedsAmount() => Feeds.Count;

        public Feed GetFeedByTitle(string title)
        {
            return Feeds[0];
        }

        public List<Feed> GetFeedsByType(FeedType type)
        {
            FeedSortItem.SelectFeedType(type);
            return Feeds;

        }

        public FeedType GetCurrentFeedType()
        {
            try
            {
                return (FeedType)Enum.Parse(typeof(FeedType), FeedSortItem.Active);
            }
            catch (Exception e)
            {
                throw new Exception();//return new exception
            }

        }

        public List<Feed> GetAllFeeds()
        {
            return Feeds;
        }

        protected override BlogPostSection WaitForLoad()
        {
            return this;
        }
    }
}
