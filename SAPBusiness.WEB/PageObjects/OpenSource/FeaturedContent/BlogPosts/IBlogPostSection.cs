using System.Collections.Generic;
using SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent;

namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts
{
    public interface IBlogPostSection : IPageObject<IBlogPostSection>
    {
        string Icon { get; }
        string Topic { get; }

        List<Feed> GetAllFeeds();
        FeedType GetCurrentFeedType();
        Feed GetFeedByTitle(string title);
        int GetFeedsAmount();
        List<Feed> GetFeedsByType(FeedType type);
    }
}