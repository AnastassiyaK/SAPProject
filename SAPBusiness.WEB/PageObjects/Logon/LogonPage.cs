using Core.WebDriver;
using SAPBusiness.UserData;

namespace SAPBusiness.WEB.PageObjects.Logon
{
    public class LogOnPage : BasePageObject<LogOnPage>, ILogOnStrategy
    {
        private readonly LogOnSection logOnSection;

        public LogOnPage(BaseWebDriver driver) : base(driver)
        {
            logOnSection = new LogOnSection(_driver);
        }

        public void LogOn(User user)
        {
            logOnSection.UserNameInput.SendKeys(user.Login);
            logOnSection.PasswordInput.SendKeys(user.Password);

            logOnSection.LogOnButton.Click();
        }

        protected override LogOnPage WaitForLoad()
        {
            return this;
        }
    }
}
