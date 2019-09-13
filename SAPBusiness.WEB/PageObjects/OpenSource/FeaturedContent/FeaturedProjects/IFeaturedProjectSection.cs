namespace SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.FeaturedProjects
{
    interface IFeaturedProjectSection : IPageObject
    {
        string Description { get; }
        string Icon { get; }
        string Title { get; }
        string TitleLink { get; }
        string Topic { get; }
        string ViewAllLink { get; }
    }
}