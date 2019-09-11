﻿using Core.WebDriver;
using OpenQA.Selenium;
using SAPBusiness.UserData;
using SAPBusiness.WEB.PageObjects.LogOn;

namespace SAPBusiness.WEB.PageObjects.Frames
{
    public class LogOnFrame : BasePageObject<LogOnFrame>, ILogOnStrategy
    {
        private readonly ILogOnSection _logOnSection;

        public LogOnFrame(BaseWebDriver driver, ILogOnSection logOnSection) : base(driver)
        {
            _logOnSection = logOnSection;
        }

        public void LogOn(User user)
        {
            _driver.WaitForElement(By.Id("IDS_UI_Window"), 15);

            _driver.SwitchToFrame(_driver.FindElement(By.Id("IDS_UI_Window")));

            _logOnSection.UserNameInput.SendKeys(user.Login);
            _logOnSection.PasswordInput.SendKeys(user.Password);
            _logOnSection.LogOnButton.Click();

            _driver.SwitchToDefaultContent();

        }

        protected override LogOnFrame WaitForLoad()
        {
            return this;
        }
    }
}
