namespace SAPBusiness.WEB.PageObjects.Developers.MainPage.Statistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;
    using SAPBusiness.Enums;

    public class TutorialSection : BasePageObject, ITutorialSection
    {
        private List<Statistics> _statistics;

        public TutorialSection(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        private List<Statistics> Statistics
        {
            get
            {
                return _statistics ??
                    (_statistics = _driver.FindElements(By.CssSelector(".tutorial-stats"))
                      .Select(element => new Statistics(element))
                      .ToList());
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
