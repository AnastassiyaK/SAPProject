namespace SAPBusiness.WEB.PageObjects.MainPage.Statistics
{
    public interface ITutorialSection : IPageObject<ITutorialSection>
    {
        IStatistics GetStatsByType(StatisticsType type);
    }
}