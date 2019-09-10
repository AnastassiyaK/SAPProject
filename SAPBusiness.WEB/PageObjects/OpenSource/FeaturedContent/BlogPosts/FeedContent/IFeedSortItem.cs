namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent
{
    public interface IFeedSortItem
    {
        string Active { get; }

        void SelectFeedType(FeedType type);
    }
}