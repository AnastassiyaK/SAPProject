namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Memberships
{
    using OpenQA.Selenium;

    public class MembershipFactory : IMembershipFactory
    {
        public IMembership Create(IWebElement element)
        {
            return new Membership(element);
        }
    }
}
