namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    using System.Collections.Generic;
    using SAPBusiness.Enums;

    public interface ITutorialNavigator : IPageObject
    {
        List<TileElement> GetAllTilesCache();

        List<TileElement> GetAllTiles();

        List<TileElement> GetTiles(TutorialType type);

        void Open();

        void OpenWithTilesOnPage(int tileAmmount);

        bool HasTiles();

        bool HasTiles(TutorialType type);

        bool HasPagination();
    }
}