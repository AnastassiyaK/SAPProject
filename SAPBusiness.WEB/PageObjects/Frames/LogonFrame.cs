using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.UserData;
using SAPBusiness.WEB.PageObjects.Logon;

namespace SAPBusiness.WEB.PageObjects.Frames
{
    public class LogonFrame : BasePageObject<LogonFrame>, ILogOnStrategy
    {
        private readonly LogOnSection logOnSection;
        public LogonFrame(BaseWebDriver driver) : base(driver)
        {
            logOnSection = new LogOnSection(_driver);
        }


        public void LogOn(User user)
        {
            _driver.WaitForElement(By.Id("IDS_UI_Window"), 15);

            _driver.SwitchToFrame(_driver.FindElement(By.Id("IDS_UI_Window")));

            logOnSection.UserNameInput.SendKeys(user.Login);
            logOnSection.PasswordInput.SendKeys(user.Password);
            logOnSection.LogOnButton.Click();

            _driver.SwitchToDefaultContent();

        }

        protected override LogonFrame WaitForLoad()
        {
            return this;
        }
    }
}
