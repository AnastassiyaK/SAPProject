namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.BlogPosts
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.BlogPosts.FeedContent;

    public interface IFeedFactory
    {
        IFeed Create(WebDriver driver, IWebElement element, ILogger logger);
    }
}
