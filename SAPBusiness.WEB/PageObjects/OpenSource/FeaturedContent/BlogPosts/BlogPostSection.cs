using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts
{
    public class BlogPostSection : BasePageObject, IBlogPostSection
    {
        private readonly IFeedFactory _feedFactory;

        private List<IFeed> _feeds;

        private FeedSortList _feedSortItem;

        public BlogPostSection(WebDriver driver, IFeedFactory feedFactory) : base(driver)
        {
            _feedFactory = feedFactory;
        }

        private FeedSortList FeedSort
        {
            get
            {
                return _feedSortItem ??
                    (_feedSortItem = new FeedSortList(_driver));
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

        private List<IFeed> Feeds
        {
            get
            {
                return _feeds ??
                      (_feeds = _driver.FindElements(By.ClassName("feed-item"))
                      .Select(element => _feedFactory.Create(element))
                      .ToList()
                      );
            }
        }

        public int GetFeedsAmount() => Feeds.Count;

        public List<IFeed> GetFeedsByType(FeedType type)
        {
            FeedSort.SelectFeedType(type);
            return Feeds;
        }

        public FeedType GetCurrentFeedType()
        {
            try
            {
                return (FeedType)Enum.Parse(typeof(FeedType), FeedSort.Active);
            }
            catch
            {
                throw new ArgumentException("Cannot parse feed sort container value into Enum");
            }
        }

        public List<IFeed> GetAllFeeds()
        {
            return Feeds;
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
