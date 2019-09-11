namespace SAPBusiness.WEB.PageObjects.OpenSource.Projects.Search
{
    public interface ISearchSection : IPageObject<ISearchSection>
    {
        void ClearSearch();
        string GetSearchingString();
        bool IsEmpty();
        void SearchResultsByString(string searchString);
    }
}