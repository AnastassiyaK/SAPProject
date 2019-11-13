namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Memberships
{
    using OpenQA.Selenium;

    public interface IMembershipFactory
    {
        IMembership Create(IWebElement element);
    }
}
