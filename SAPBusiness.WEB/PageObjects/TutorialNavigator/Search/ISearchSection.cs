namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Search
{
    public interface ISearchSection : IPageObject
    {
        void ClearInput();

        string GetSearchingString();

        bool IsEmpty();

        void Search(string searchString);
    }
}
