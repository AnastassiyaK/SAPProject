using System.Collections.Generic;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Projects
{
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