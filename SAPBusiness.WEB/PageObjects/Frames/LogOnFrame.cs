using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.UserData;
using SAPBusiness.WEB.PageObjects.LogOn;

namespace SAPBusiness.WEB.PageObjects.Frames
{
    public class LogOnFrame : BasePageObject, ILogOnStrategy
    {
        private readonly ILogOnSection _logOnSection;

        public LogOnFrame(WebDriver driver, ILogOnSection logOnSection) : base(driver)
        {
            _logOnSection = logOnSection;
        }

        private IWebElement ElementLogOn
        {
            get
            {
                return _driver.FindElement(By.CssSelector(".authentication-wrapper"));
            }
        }
        public void LogOn(User user)
        {
            Open();
            _driver.WaitForElement(By.Id("IDS_UI_Window"));

            _driver.SwitchToFrame(_driver.FindElement(By.Id("IDS_UI_Window")));

            _logOnSection.UserNameInput.SendKeys(user.Login);
            _logOnSection.PasswordInput.SendKeys(user.Password);
            _logOnSection.LogOnButton.Click();

            _driver.SwitchToDefaultContent();

            WaitForProcessing();

        }

        private void Open()
        {
            ElementLogOn.Click();
        }

        public void WaitForProcessing()
        {
            _driver.WaitForElementDissapear(By.Id("IDS_UI_Window"));
        }
    }
}
