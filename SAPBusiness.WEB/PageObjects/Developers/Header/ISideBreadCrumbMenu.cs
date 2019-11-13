namespace SAPBusiness.WEB.PageObjects.Developers.Header
{
    using System.Collections.Generic;

    public interface ISideBreadCrumbMenu : IPageObject
    {
        List<SideMenuBookmark> Bookmarks { get; }

        void Open();

        void OpenBookmarkTab();
    }
}