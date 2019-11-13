namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    using Core.WebDriver;
    using NLog;
    using OpenQA.Selenium;

    public abstract class StepButton : BaseDependentOnElementObject, IStepButton
    {
        public StepButton(WebDriver driver, IWebElement element, ILogger logger)
            : base(driver, element, logger)
        {
        }

        protected abstract IWebElement Button { get; }

        public void Complete()
        {
            int i = 50;
            do
            {
                Button.Click();
                i--;
                if (i == 0)
                {
                    break;
                }
            }
            while (!_element.FindElement(By.CssSelector(".done-button .link-button"))
            .GetAttribute("class").Contains("answer-success"));
        }
    }
}
