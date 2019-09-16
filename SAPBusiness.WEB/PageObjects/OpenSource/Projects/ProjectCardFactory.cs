using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Projects
{
    public class ProjectCardFactory : IProjectCardFactory
    {
        public IProjectCard Create(IWebElement element)
        {
            return new ProjectCard(element);
        }
    }
}
