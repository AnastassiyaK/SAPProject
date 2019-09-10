using SAPBusiness.WEB.PageObjects.LogOn;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAPBusiness.WEB.PageObjects.Frames
{
    public class LogOnFrame : BasePageObject<LogOnFrame>, ILogOnStrategy
    {
        private readonly LogOnSection logOnSection;

        public LogOnFrame(BaseWebDriver driver) : base(driver)
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

        protected override LogOnFrame WaitForLoad()
        {
            return this;
        }
    }
}
