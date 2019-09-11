using Core.WebDriver;
using SAPBusiness.UserData;

namespace SAPBusiness.WEB.PageObjects.LogOn
{
    public class LogOnPage : BasePageObject<LogOnPage>, ILogOnStrategy
    {
        private readonly ILogOnSection _logOnSection;

        public LogOnPage(BaseWebDriver driver,ILogOnSection logOnSection) : base(driver)
        {
            _logOnSection = logOnSection;
        }

        public void LogOn(User user)
        {
            _logOnSection.UserNameInput.SendKeys(user.Login);
            _logOnSection.PasswordInput.SendKeys(user.Password);

            _logOnSection.LogOnButton.Click();
        }

        protected override LogOnPage WaitForLoad()
        {
            return this;
        }
    }
}
