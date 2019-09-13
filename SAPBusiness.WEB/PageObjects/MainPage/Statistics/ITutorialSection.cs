namespace SAPBusiness.WEB.PageObjects.MainPage.Statistics
{
    public interface ITutorialSection : IPageObject
    {
        IStatistics GetStatsByType(StatisticsType type);
    }
}