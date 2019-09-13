using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public interface IFacetType : IPageObject
    {
        void SelectType(string type);
    }
}