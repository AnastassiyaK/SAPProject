using System.Collections.Generic;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public interface ITutorialNavigator
    {
        TutorialNavigator FilterPageByTopic(string title);
        List<TileElement> GetAllTiles();
        bool HasTiles();
        TutorialNavigator WaitForFilterLoad();
    }
}