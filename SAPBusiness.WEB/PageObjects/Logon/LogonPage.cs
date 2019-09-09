using Core.WebDriver;
using SAPBusiness.Interfaces;
using SAPBusiness.UserData;

namespace SAPBusiness.WEB.PageObjects.Logon
{
    public class LogonPage : BasePageObject<LogonPage>, ILogonStrategy
    {
        private readonly LogonSection logOnSection;
        public LogonPage(BaseWebDriver driver) : base(driver)
        {
            logOnSection = new LogonSection(_driver);
        }

        public void LogOn(User user)
        {
            logOnSection.UserNameInput.SendKeys(user.Login);
            logOnSection.PasswordInput.SendKeys(user.Password);
            logOnSection.LogOnButton.Click();
        }

        protected override LogonPage WaitForLoad()
        {
            return this;
        }
    }
}
