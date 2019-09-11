namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    public interface ITileLegend : IPageObject<ITileLegend>
    {
        int Group { get; }
        int Mission { get; }
        int Tutorial { get; }
    }
}