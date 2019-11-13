namespace SAPBusiness.WEB.PageObjects.People.Dashboard.Bookmarks
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class SearchSection : BasePageObject, ISearchSection
    {
        public SearchSection(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        private IWebElement SubmitSearch
        {
            get
            {
                return _driver.FindElement(By.CssSelector("button[type='submit']"));
            }
        }

        private IWebElement ClearSearch
        {
            get
            {
                return _driver.FindElement(By.CssSelector("button[type='reset']"));
            }
        }

        private IWebElement SearchInput
        {
            get
            {
                return _driver.FindElement(By.Name("filter-search"));
            }
        }

        public void Search(string searchString)
        {
            if (!IsEmpty())
            {
                ClearInput();
            }

            SearchInput.SendKeys(searchString);

            SubmitSearch.Click();

            WaitForLoad();
        }

        public string GetSearchingString()
        {
            return SearchInput.GetAttribute("value");
        }

        public void ClearInput()
        {
            ClearSearch.Click();
            WaitForLoad();
        }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(SearchInput.GetAttribute("value")) ? true : false;
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".section-loading"));

            this.WaitForPageLoad();
        }
    }
}
