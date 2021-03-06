﻿namespace SAPBusiness.WEB.PageObjects.TutorialNavigator
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class TileLegend : BasePageObject, ITileLegend
    {
        public TileLegend(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        public int Mission
        {
            get
            {
                return int.Parse(TileMission.GetAttribute("data-number-items"));
            }
        }

        public int Tutorial
        {
            get
            {
                return int.Parse(TileTutorial.GetAttribute("data-number-items"));
            }
        }

        public int Group
        {
            get
            {
                return int.Parse(TileGroup.GetAttribute("data-number-items"));
            }
        }

        private IWebElement TileMission
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".tiles-legend__option.mission"));
            }
        }

        private IWebElement TileTutorial
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".tiles-legend__option.tutorial"));
            }
        }

        private IWebElement TileGroup
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".tiles-legend__option.group"));
            }
        }

        public void WaitForLoad()
        {
            _driver.WaitForElementDissapear(By.CssSelector(".loader"));
        }
    }
}
