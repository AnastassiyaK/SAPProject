using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public interface IFacetTopic : IPageObject
    {
        void SelectTopic(string topic);
    }
}