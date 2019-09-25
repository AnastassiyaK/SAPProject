using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    public class SubmitButton : StepButton
    {
        public SubmitButton(WebDriver driver, IWebElement element) : base(driver, element)
        {
        }

        protected override IWebElement Button
        {
            get
            {
                return _element.FindElement(By.ClassName("validate-submit"));
            }
        }
    }
}
