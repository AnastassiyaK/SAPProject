namespace SAPBusiness.WEB.PageObjects.Developers.MainPage.Statistics
{
    using SAPBusiness.Enums;

    public interface ITutorialSection : IPageObject
    {
        IStatistics GetStatsByType(StatisticsType type);
    }
}