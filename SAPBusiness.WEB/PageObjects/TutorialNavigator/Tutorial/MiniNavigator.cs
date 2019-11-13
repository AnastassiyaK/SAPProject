namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    using System.Collections.Generic;
    using System.Linq;
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public class MiniNavigator : BasePageObject, IMiniNavigator
    {
        private List<MiniNavigatorLink> _links;

        public MiniNavigator(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        public string NextStepLink
        {
            get
            {
                return NextButton.GetAttribute("href");
            }
        }

        private IWebElement NextButton
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".miniNavigator section .tutorial-miniNavigator__btn_next"));
            }
        }

        private List<MiniNavigatorLink> Links
        {
            get
            {
                return _links ??
                    (_links = _driver.FindElements(By.CssSelector(".miniNavigator section .tutorial-miniNavigator__links-item"))
                    .Select(element => new MiniNavigatorLink(_driver, element, _logger))
                    .ToList());
            }
        }

        public List<MiniNavigatorLink> GetLinks()
        {
            return Links;
        }
    }
}
