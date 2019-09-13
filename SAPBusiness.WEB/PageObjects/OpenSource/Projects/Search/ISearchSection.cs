namespace SAPBusiness.WEB.PageObjects.OpenSource.Projects.Search
{
    public interface ISearchSection : IPageObject
    {
        void ClearSearch();
        string GetSearchingString();
        bool IsEmpty();
        void SearchResultsByString(string searchString);
    }
}