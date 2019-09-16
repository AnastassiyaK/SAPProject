using OpenQA.Selenium;
using SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent;

namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts
{
    public class FeedFactory : IFeedFactory
    {
        public IFeed Create(IWebElement element)
        {
            return new Feed(element);
        }
    }
}
