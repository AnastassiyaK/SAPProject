namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Projects
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.WEB.Exceptions;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource.Projects.Search;

    public class ProjectsSection : BasePageObject, IProjectsSection
    {
        private readonly IProjectCardFactory _projectCardFactory;

        private SearchSection _searchSection;

        private List<IProjectCard> _projects;

        public ProjectsSection(WebDriver driver, ILogger logger, IProjectCardFactory projectCardFactory)
            : base(driver, logger)
        {
            _projectCardFactory = projectCardFactory;
        }

        public int All
        {
            get
            {
                return int.Parse(string.Join("", $"{InfoShowing.Substring(InfoShowing.IndexOf("/"), InfoShowing.Length)}"
                    .TakeWhile(x => char.IsDigit(x))));
            }
        }

        public int Shown
        {
            get
            {
                return int.Parse(string.Join("", $"{InfoShowing.Substring(0, InfoShowing.IndexOf("/"))}"
                    .TakeWhile(x => char.IsDigit(x))));
            }
        }

        public string InfoShowing
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".show-entries span")).Text;
            }
        }

        private SearchSection SearchSection
        {
            get
            {
                return _searchSection ?? (_searchSection = new SearchSection(_driver, _logger));
            }
        }

        private List<IProjectCard> Projects
        {
            get
            {
                return _projects ??
                    (_projects = _driver.FindElements(By.ClassName("feature-card-container"))
                    .Select(element => _projectCardFactory.Create(element))
                    .ToList());
            }
        }

        public int GetProjectsAmount() => Projects.Count;

        public IProjectCard GetProjectByTitle(string title)
        {
            foreach (var project in Projects)
            {
                if (project.Title == title)
                {
                    return project;
                }
            }

            throw new ProjectCardNotFoundException(title);
        }

        public List<IProjectCard> GetProjectsBySearchingString(string searchString)
        {
            SearchSection.SearchResultsByString(searchString);
            return Projects;
        }

        public List<IProjectCard> GetAllProjects()
        {
            return Projects;
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
