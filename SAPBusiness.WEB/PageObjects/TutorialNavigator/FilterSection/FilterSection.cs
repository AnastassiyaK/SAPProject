namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class FilterSection : BasePageObject, IFilterSection
    {
        public FilterSection(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        protected List<IWebElement> TagElements => GetOverviewElement().FindElements(By.ClassName("filters__item")).ToList();

        private IWebElement ClearAllElement
        {
            get
            {
                return _driver.FindElement(By.Id("clear-all"));
            }
        }

        public void ClearAll()
        {
            if (SearchPerformed())
            {
                ClearAllElement.Click();
            }
        }

        public FilterSection SelectTagByTitle(string title)
        {
            GetOverviewElement().FindElement(GetTagLocatorWithTitle(title))
                .Click();

            return this;
        }

        public void SelectExperience(string experience)
        {
            SelectTagByTitle(experience);
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }

        protected static By GetTagLocatorWithTitle(string title) => By.XPath($".//div[text() = '{title}']");

        protected IWebElement GetOverviewElement()
        {
            return _driver.FindElement(By.Id("facets-options"));
        }

        private bool SearchPerformed()
        {
            return _driver.CanClickOnElement(By.Id("clear-all"));
        }
    }
}
