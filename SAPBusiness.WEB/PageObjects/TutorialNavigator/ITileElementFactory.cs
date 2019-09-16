using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public interface ITileElementFactory
    {
        ITileElement CreateTile(IWebElement element);
    }
}
