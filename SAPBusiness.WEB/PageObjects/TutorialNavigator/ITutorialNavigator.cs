using System.Collections.Generic;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public interface ITutorialNavigator : IPageObject
    {
        List<TileElement> GetAllTiles();

        void Open();
        void OpenWithTilesOnPage(int tileAmmount);
        bool HasTiles();

        bool HasPagination();
    }
}