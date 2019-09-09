using Core.WebDriver;
using OpenQA.Selenium;
using System;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Projects.Search
{
    public class SearchSection : BasePageObject<SearchSection>
    {
        public SearchSection(BaseWebDriver driver) : base(driver)
        {

        }

        public void SearchResultsByString(string searchString)
        {
            if (!IsEmpty())
            {
                ClearSearch();
            }

            _driver.FindElement(By.Id("projectSearchInput")).SendKeys(searchString);

        }

        public string GetSearchingString()
        {
            return _driver.FindElement(By.Id("projectSearchInput")).Text;
        }
        public void ClearSearch()
        {
            _driver.FindElement(By.Id("projectSearchInput")).SendKeys("");

        }

        public bool IsEmpty()
        {
            return String.IsNullOrEmpty(_driver.FindElement(By.Id("projectSearchInput")).Text) ? true : false;
        }

        protected override SearchSection WaitForLoad()
        {
            throw new NotImplementedException();
        }
    }
}
