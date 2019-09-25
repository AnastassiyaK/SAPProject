using Core.WebDriver;
using OpenQA.Selenium;

namespace SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial
{
    public class Step : BasePageObject
    {
        private IWebElement _element;

        private IStepButton _stepButton;

        public Step(WebDriver driver, IWebElement element ,IStepButton stepButton) : base(driver)
        {
            _element = element;
            _stepButton = stepButton;
        }

        private IWebElement ElementTitle
        {
            get
            {
                return _element.FindElement(By.CssSelector(".icon-arrow-down03"));
            }
        }

        public int Number
        {
            get
            {
                return int.Parse(ElementTitle.GetAttribute("data-step"));
            }
        }

        public string Id
        {
            get
            {
                return _element.GetAttribute("id");
            }
        }

        public void Finish()
        {
            _stepButton.Complete();
        }
    }
}
