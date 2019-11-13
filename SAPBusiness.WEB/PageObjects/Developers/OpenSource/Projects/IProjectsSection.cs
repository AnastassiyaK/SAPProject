namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Projects
{
    using System.Collections.Generic;

    public interface IProjectsSection : IPageObject
    {
        int All { get; }

        string InfoShowing { get; }

        int Shown { get; }

        List<IProjectCard> GetAllProjects();

        IProjectCard GetProjectByTitle(string title);

        int GetProjectsAmount();

        List<IProjectCard> GetProjectsBySearchingString(string searchString);
    }
}