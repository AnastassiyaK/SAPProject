namespace SAPBusiness.Services.API_Services.TutorialNavigator
{
    using System.Collections.Generic;
    using SAPBusiness.TilesData;

    public interface ITilesService
    {
        TutorialNavigatorScope GetContext(ResultSingleTile tilesQuery);

        TutorialNavigatorLegend GetPageLegend(ResultSingleTile tilesQuery);

        IList<Tile> GetTiles(ResultSingleTile tilesQuery);

        IList<Tile> GetNewTiles(ResultSingleTile tilesQuery);

        int GetAllTutorialTypesAmount(ResultSingleTile tilesQuery);

        int GetMissionsAmount(ResultSingleTile tilesQuery);

        int GetGroupsAmount(ResultSingleTile tilesQuery);

        int GetTutorialsAmount(ResultSingleTile tilesQuery);
    }
}
