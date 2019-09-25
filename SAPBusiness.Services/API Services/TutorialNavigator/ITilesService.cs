using SAPBusiness.TilesData;

namespace SAPBusiness.Services.API_Services.TutorialNavigator
{
    public interface ITilesService
    {
         TilesList GetTiles(TilesQuery tilesQuery);
    }
}
