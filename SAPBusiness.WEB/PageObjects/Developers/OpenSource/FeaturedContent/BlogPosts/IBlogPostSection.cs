namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.BlogPosts
{
    using System.Collections.Generic;
    using SAPBusiness.Enums;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.BlogPosts.FeedContent;

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