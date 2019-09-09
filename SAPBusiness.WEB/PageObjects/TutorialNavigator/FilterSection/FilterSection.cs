using Core.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public class FilterSection : BasePageObject<FilterSection>
    {
        public FilterSection(BaseWebDriver driver) : base(driver)
        {

        }
        protected IWebElement _overviewElement => _driver.FindElement(By.Id("facets-options"));

        protected List<IWebElement> _tagElements => _overviewElement.FindElements(By.ClassName("filters__item")).ToList();

        protected static By GetTagLocatorWithTitle(string title) => By.XPath($".//div[text() = '{title}']");

        public FilterSection SelectTagByTitleImproved(string title)
        {

            _overviewElement.FindElement(GetTagLocatorWithTitle(title))
                .Click();

            WaitForPageLoad();
            return this;
        }

        public FilterSection SelectTagByTitle(string title)
        {
            var tag = _tagElements.FirstOrDefault(t => t.Text == title);

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
