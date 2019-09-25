using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    public class DoneButton : StepButton
    {
        public DoneButton(WebDriver driver, IWebElement element) : base(driver, element)
        {
        }

        protected override IWebElement Button
        {
            get
            {
                return _element.FindElement(By.CssSelector(".done-button .link-button"));
            }
        }
    }
}
