namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.BlogPosts.FeedContent
{
    using SAPBusiness.Enums;

    public interface IFeedSortItem : IPageObject
    {
        string Active { get; }

        void SelectFeedType(FeedType type);
    }
}