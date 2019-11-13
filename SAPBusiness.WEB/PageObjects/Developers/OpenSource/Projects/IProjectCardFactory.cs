namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Projects
{
    using OpenQA.Selenium;

    public interface IProjectCardFactory
    {
        IProjectCard Create(IWebElement element);
    }
}
