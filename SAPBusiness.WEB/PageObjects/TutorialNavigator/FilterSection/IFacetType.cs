using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public interface IFacetType
    {
        IWebElement Type { get; }

        void ClickOnType(TileType type);
    }
}