using System.Collections.Generic;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Projects
{
    public interface IProjectsSection
    {
        int All { get; }
        string InfoShowing { get; }
        int Shown { get; }

        List<ProjectCard> GetAllProjects();
        ProjectCard GetProjectByTitle(string title);
        int GetProjectsAmount();
        List<ProjectCard> GetProjectsBySearchingString(string searchString);
    }
}