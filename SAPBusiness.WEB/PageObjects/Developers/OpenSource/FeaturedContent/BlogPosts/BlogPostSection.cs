namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.BlogPosts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.Enums;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.BlogPosts.FeedContent;

    public class BlogPostSection : BasePageObject, IBlogPostSection
    {
        private readonly IFeedFactory _feedFactory;

        private List<IFeed> _feeds;

        private FeedSortList _feedSortItem;

        public BlogPostSection(WebDriver driver, ILogger logger, IFeedFactory feedFactory)
            : base(driver, logger)
        {
            _feedFactory = feedFactory;
        }

        public string Icon
        {
            get
            {
                _logger.Debug($"Trying to get Icon of the BlogPostSection.");
                return _driver.FindElement(By.CssSelector("#order-id-3 .header-container .icon")).GetAttribute("url");
            }
        }

        public string Topic
        {
            get
            {
                _logger.Debug($"Trying to get Icon of the Topic.");
                return _driver.FindElement(By.CssSelector("#order-id-3 .header-container .header-topic")).Text;
            }
        }

        private List<IFeed> Feeds
        {
            get
            {
                _logger.Debug("Trying to get all feeds");
                return _feeds ??
                      (_feeds = _driver.FindElements(By.ClassName("feed-item"))
                      .Select(element => _feedFactory.Create(_driver, element, _logger))
                      .ToList());
            }
        }

        private FeedSortList FeedSort
        {
            get
            {
                return _feedSortItem ??
                    (_feedSortItem = new FeedSortList(_driver, _logger));
            }
        }

        public int GetFeedsAmount() => Feeds.Count;

        public List<IFeed> GetFeedsByType(FeedType type)
        {
            FeedSort.SelectFeedType(type);
            _logger.Debug("Returning all feeds from the page.");
            return Feeds;
        }

        public FeedType GetCurrentFeedType()
        {
            try
            {
                _logger.Debug($"Trying to get current Active filter of the feeds.");
                return (FeedType)Enum.Parse(typeof(FeedType), FeedSort.Active);
            }
            catch
            {
                _logger.Debug($"List of FeedSort items is not the same as {Enum.GetNames(typeof(FeedType))}.");
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
            _logger.Debug($"Page was successfully loaded.");
        }
    }
}
