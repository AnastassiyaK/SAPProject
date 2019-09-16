using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public class TileElementFactory : ITileElementFactory
    {
        public ITileElement CreateTile(IWebElement element)
        {
            return new TileElement(element);
        }
    }
}
