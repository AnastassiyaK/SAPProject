using System.Collections.Generic;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public interface ITutorialNavigator : IPageObject
    {
        List<TileElement> GetAllTiles();

        void Open();
        bool HasTiles();
    }
}