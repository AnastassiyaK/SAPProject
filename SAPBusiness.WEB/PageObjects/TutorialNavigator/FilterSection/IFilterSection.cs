namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public interface IFilterSection : IPageObject
    {
        void ClearAll();

        FilterSection SelectTagByTitle(string title);
    }
}