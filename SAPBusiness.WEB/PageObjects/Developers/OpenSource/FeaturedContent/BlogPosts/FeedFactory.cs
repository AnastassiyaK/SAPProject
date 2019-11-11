namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.BlogPosts
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.BlogPosts.FeedContent;

    public class FeedFactory : IFeedFactory
    {
        public IFeed Create(WebDriver driver, IWebElement element, ILogger logger)
        {
            return new Feed(driver, element, logger);
        }
    }
}
