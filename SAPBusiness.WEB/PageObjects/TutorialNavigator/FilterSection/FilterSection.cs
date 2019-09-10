using Core.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public class FilterSection : BasePageObject<FilterSection>, IFilterSection
    {
        public FilterSection(BaseWebDriver driver) : base(driver)
        {

        }

        protected IWebElement OverviewElement => _driver.FindElement(By.Id("facets-options"));

        protected List<IWebElement> TagElements => OverviewElement.FindElements(By.ClassName("filters__item")).ToList();

        protected static By GetTagLocatorWithTitle(string title) => By.XPath($".//div[text() = '{title}']");

        public FilterSection SelectTagByTitleImproved(string title)
        {
            OverviewElement.FindElement(GetTagLocatorWithTitle(title))
                .Click();

            WaitForPageLoad();
            return this;
        }

        public FilterSection SelectTagByTitle(string title)
        {
            var tag = TagElements.FirstOrDefault(t => t.Text == title);

            if (tag is null)
            {
                throw new Exception("tag not found");
            }

            tag.Click();

            WaitForPageLoad();
            return this;
        }

        protected override FilterSection WaitForLoad()
        {
            return this;
        }
    }
}
