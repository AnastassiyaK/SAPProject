using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.WEB.Exceptions;
using SAPBusiness.WEB.PageObjects.OpenSource.Projects.Search;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Projects
{
    public class ProjectsSection : BasePageObject, IProjectsSection
    {
        private readonly IProjectCardFactory _projectCardFactory;

        public ProjectsSection(WebDriver driver, IProjectCardFactory projectCardFactory) : base(driver)
        {
            _projectCardFactory = projectCardFactory;
        }

        private SearchSection _searchSection;

        private SearchSection SearchSection
        {
            get
            {
                return _searchSection ?? (_searchSection = new SearchSection(_driver));
            }
        }

        public int All
        {
            get
            {
                return int.Parse(string.Join("", $"{InfoShowing.Substring(InfoShowing.IndexOf("/"), InfoShowing.Length)}"
                    .TakeWhile(x => Char.IsDigit(x))));
            }
        }

        public int Shown
        {
            get
            {
                return int.Parse(string.Join("", $"{InfoShowing.Substring(0, InfoShowing.IndexOf("/"))}"
                    .TakeWhile(x => Char.IsDigit(x))));
            }
        }

        public string InfoShowing
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".show-entries span")).Text;
            }
        }

        private List<IProjectCard> _projects;

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
            throw new ProjectCardNotFoundException(title;
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
