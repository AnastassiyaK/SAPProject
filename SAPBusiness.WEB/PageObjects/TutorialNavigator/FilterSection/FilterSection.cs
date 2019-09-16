using Core.WebDriver;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public class FilterSection : BasePageObject, IFilterSection
    {
        public FilterSection(WebDriver driver) : base(driver)
        {
        }

        protected IWebElement GetOverviewElement()
        {
            return _driver.FindElement(By.Id("facets-options"));
        }

        protected List<IWebElement> TagElements => GetOverviewElement().FindElements(By.ClassName("filters__item")).ToList();

        protected static By GetTagLocatorWithTitle(string title) => By.XPath($".//div[text() = '{title}']");

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
    }
}
