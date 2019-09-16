using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Memberships
{
    public class MembershipFactory : IMembershipFactory
    {
        public IMembership Create(IWebElement element)
        {
            return new Membership(element);
        }
    }
}
