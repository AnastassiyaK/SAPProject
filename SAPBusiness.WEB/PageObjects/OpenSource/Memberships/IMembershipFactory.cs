using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Memberships
{
    public interface IMembershipFactory
    {
        IMembership Create(IWebElement element);
    }
}
