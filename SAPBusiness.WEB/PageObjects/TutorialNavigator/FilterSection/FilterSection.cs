using Core.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection
{
    public class FilterSection : BasePageObject<FilterSection>, IFilterSection
    {
        private readonly IFacetExperience _facetExperience;

        private readonly IFacetTopic _facetTopic;

        private readonly IFacetType _facetType;
        public FilterSection(BaseWebDriver driver) : base(driver)
        {

        }

        protected IWebElement OverviewElement => _driver.FindElement(By.Id("facets-options"));

        protected List<IWebElement> TagElements => OverviewElement.FindElements(By.ClassName("filters__item")).ToList();

        protected static By GetTagLocatorWithTitle(string title) => By.XPath($".//div[text() = '{title}']");

        public FilterSection SelectTagByTitle(string title)
        {
            OverviewElement.FindElement(GetTagLocatorWithTitle(title))
                .Click();

            return this;
        }

        public void SelectExperience(string experience)
        {
            SelectTagByTitle(experience);
           
        }

        //public IFacetType SelectType(string type)
        //{
        //    SelectTagByTitle(type);
        //    return _facetType;
        //}

        //public IFacetTopic SelectTopic(string topic)
        //{
        //    SelectTagByTitle(topic);
        //    return _facetTopic;
        //}

        protected override FilterSection WaitForLoad()
        {
            return this;
        }

        public new IFilterSection WaitForPageLoad()
        {
            return base.WaitForPageLoad();
        }
    }
}
