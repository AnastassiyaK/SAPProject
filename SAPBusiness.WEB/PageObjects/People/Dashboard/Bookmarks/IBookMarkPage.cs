namespace SAPBusiness.WEB.PageObjects.People.Dashboard.Bookmarks
{
    using System.Collections.Generic;

    public interface IBookmarkPage : IPageObject
    {
        void DeleteBookmarks();

        void DeleteBookmark(string title);

        List<Bookmark> GetAllBookMarks();

        Bookmark GetBookmark(string title);

        void Open();
    }
}