namespace SAPBusiness.WEB.PageObjects.People.Dashboard.Bookmarks
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.Configuration;
    using SAPBusiness.WEB.Exceptions;

    public class BookmarkPage : BasePageObject, IBookmarkPage
    {
        private static readonly string _relativeUrl = "/#bookmarks";

        private readonly EnvironmentConfig _appConfiguration;

        public BookmarkPage(WebDriver driver, ILogger logger, EnvironmentConfig appConfiguration)
            : base(driver, logger)
        {
            _appConfiguration = appConfiguration;
        }

        public int BookmarkCount
        {
            get
            {
                return int.Parse(string.Concat(ResultsElement.Text.TakeWhile(c => char.IsDigit(c)).ToArray()));
            }
        }

        private List<Bookmark> Bookmarks
        {
            get
            {
                return _driver.FindElements(By.CssSelector(".dm-content-item"))
                    .Select(element => new Bookmark(_driver, element, _logger, new DeleteButton(_driver, element, _logger)))
                    .ToList();
            }
        }

        private IWebElement ResultsElement
        {
            get
            {
                return _driver.FindElement(By.ClassName("dm-filter-results__results"));
            }
        }

        private IWebElement HiddenAlert
        {
            get
            {
                return _driver.FindElement(By.CssSelector("div[class*='up-alert-section success']"));
            }
        }

        public void DeleteBookmarks()
        {
            int total = BookmarkCount;
            for (int i = 1; i <= total; i++)
            {
                Bookmarks.FirstOrDefault().Remove();
                WaitForDeletingBookmark();
            }
        }

        public void DeleteBookmark(string title)
        {
            GetBookmarkByTitle(title).Remove();
            WaitForDeletingBookmark();
        }

        public List<Bookmark> GetAllBookMarks()
        {
            return Bookmarks;
        }

        public Bookmark GetBookmark(string title)
        {
            return GetBookmarkByTitle(title);
        }

        public void Open()
        {
            _driver.NavigateTo(string.Concat(_appConfiguration.PeopleUrl + _relativeUrl));
        }

        public void WaitForLoad()
        {
            this.WaitForPageLoad();
        }

        private Bookmark GetBookmarkByTitle(string title)
        {
            var bookmark = Bookmarks.Where(b => b.Title == title).FirstOrDefault();
            if (bookmark != null)
            {
                return bookmark;
            }
            else
            {
                throw new BookmarkNotFoundException(title);
            }
        }

        private void WaitForDeletingBookmark()
        {
            var tempElement = HiddenAlert;
            tempElement.FindElement(By.ClassName("close")).Click();
            WaitForLoad();
        }
    }
}
