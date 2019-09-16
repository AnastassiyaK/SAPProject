using OpenQA.Selenium;
using SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent;

namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts
{
    public interface IFeedFactory
    {
        IFeed Create(IWebElement element);
    }
}
