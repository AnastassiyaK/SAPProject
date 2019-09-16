using System.Collections.Generic;
using SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent;

namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts
{
    public interface IBlogPostSection : IPageObject
    {
        string Icon { get; }
        string Topic { get; }

        List<IFeed> GetAllFeeds();
        FeedType GetCurrentFeedType();
        int GetFeedsAmount();
        List<IFeed> GetFeedsByType(FeedType type);
    }
}