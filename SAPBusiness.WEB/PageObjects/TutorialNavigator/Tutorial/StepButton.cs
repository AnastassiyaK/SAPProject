using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    public abstract class StepButton : BasePageObject, IStepButton
    {
        protected IWebElement _element;

        public StepButton(WebDriver driver, IWebElement element) : base(driver)
        {
            _element = element;
        }

        protected abstract IWebElement Button { get; }

        public void Complete()
        {
            int i = 50;
            do
            {
                Button.Click();
                i--;
                if(i==0)
                {
                    break;
                }
            }
            while (!_element.FindElement(By.CssSelector(".done-button .link-button"))
            .GetAttribute("class").Contains("answer-success"));            
        }
    }
}
