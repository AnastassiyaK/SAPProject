namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.FeaturedProjects
{
    public interface IFeaturedProjectSection : IPageObject
    {
        string Description { get; }

        string Icon { get; }

        string Title { get; }

        string TitleLink { get; }

        string Topic { get; }

        string ViewAllLink { get; }
    }
}