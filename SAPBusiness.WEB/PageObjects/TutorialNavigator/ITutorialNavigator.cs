using System.Collections.Generic;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public interface ITutorialNavigator : IPageObject<ITutorialNavigator>
    {
        List<TileElement> GetAllTiles();
        bool HasTiles();
        TutorialNavigator WaitForFilterLoad();
    }
}