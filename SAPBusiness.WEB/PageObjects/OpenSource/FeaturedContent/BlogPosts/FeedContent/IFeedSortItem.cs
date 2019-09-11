namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent
{
    public interface IFeedSortItem : IPageObject<IFeedSortItem>
    {
        string Active { get; }

        void SelectFeedType(FeedType type);
    }
}