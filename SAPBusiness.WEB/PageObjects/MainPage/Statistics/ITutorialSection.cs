namespace SAPBusiness.WEB.PageObjects.MainPage.Statistics
{
    public interface ITutorialSection : IPageObject<ITutorialSection>
    {
        Statistics GetStatsByType(StatisticsType type);
    }
}