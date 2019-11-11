namespace SAPBusiness.WEB.PageObjects.People.Dashboard.Bookmarks
{
    public interface ISearchSection : IPageObject
    {
        void ClearInput();

        string GetSearchingString();

        bool IsEmpty();

        void Search(string searchString);
    }
}