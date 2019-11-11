namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Projects.Search
{
    public interface ISearchSection : IPageObject
    {
        void ClearSearch();

        string GetSearchingString();

        bool IsEmpty();

        void SearchResultsByString(string searchString);
    }
}