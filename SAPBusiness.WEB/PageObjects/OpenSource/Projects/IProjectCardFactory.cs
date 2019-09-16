using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Projects
{
    public interface IProjectCardFactory
    {
        IProjectCard Create(IWebElement element);
    }
}
