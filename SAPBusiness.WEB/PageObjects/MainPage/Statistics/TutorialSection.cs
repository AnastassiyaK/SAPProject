using Core.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.MainPage.Statistics
{
    public class TutorialSection : BasePageObject, ITutorialSection
    {
        private List<Statistics> _statistics;

        public TutorialSection(WebDriver driver) : base(driver)
        {

        }

        private List<Statistics> Statistics
        {
            get
            {
                return _statistics ??
                    (_statistics = _driver.FindElements(By.CssSelector(".tutorial-stats"))
                      .Select(element => new Statistics(element))
                      .ToList()
                      );
            }
        }

        public IStatistics GetStatsByType(StatisticsType type)
        {
            foreach (var stats in Statistics)
            {
                if (stats.Subtitle.Contains(type.ToString()))
                {
                    return stats;
                }

            }
            throw new Exception();
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
            _driver.WaitForElement(By.CssSelector(".tutorial-stats"));
        }
    }
}
