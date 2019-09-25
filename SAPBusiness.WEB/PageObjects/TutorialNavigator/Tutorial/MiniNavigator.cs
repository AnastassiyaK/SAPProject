using Core.WebDriver;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    public class MiniNavigator : BasePageObject, IMiniNavigator
    {
        public MiniNavigator(WebDriver driver) : base(driver)
        {
        }

        private List<MiniNavigatorLink> _links;

        private List<MiniNavigatorLink> Links
        {
            get
            {
                return _links ??
                    (_links = _driver.FindElements(By.CssSelector(".miniNavigator section .tutorial-miniNavigator__links-item"))
                    .Select(element => new MiniNavigatorLink(_driver, element))
                    .ToList());
            }
        }

        public List<MiniNavigatorLink> GetLinks()
        {
            return Links;
        }

        private IWebElement NextButton
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".miniNavigator section .tutorial-miniNavigator__btn_next"));
            }
        }

        public string NextStepLink
        {
            get
            {
                return NextButton.GetAttribute("href");
            }
        }
    }
}
