namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection
{
    using System.Collections.Generic;

    public interface IPaginationSection : IPageObject
    {
        PageLink CurrentPage { get; }

        void OpenPage(int page);

        List<PageLink> GetExpandedRange();

        string GetCurrentPagination();

        EndCollapsedRange GetFirstCollapsedRange();

        int GetNumberOfPagesInExpandedArea();

        int GetTotalNumberOfPages();

        int GetNumberOfActivePage();

        List<StartCollapsedRange> GetStartCollapsedElements();

        List<EndCollapsedRange> GetEndCollapsedElements();

        bool IsVisible();
    }
}