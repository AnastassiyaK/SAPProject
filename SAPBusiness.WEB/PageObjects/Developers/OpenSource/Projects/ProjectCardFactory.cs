namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Projects
{
    using OpenQA.Selenium;

    public class ProjectCardFactory : IProjectCardFactory
    {
        public IProjectCard Create(IWebElement element)
        {
            return new ProjectCard(element);
        }
    }
}
