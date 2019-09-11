namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public interface IFilterSection : IPageObject<IFilterSection>
    {
        FilterSection SelectTagByTitle(string title);
    }
}