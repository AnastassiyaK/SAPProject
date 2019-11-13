namespace SAPBusiness.WEB.PageObjects.Developers.Footer
{
    using Core.WebDriver;
    using NLog;

    public class PageFooter : BasePageObject, IPageFooter
    {
        public PageFooter(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }

        public void WaitForLoad()
        {
            this.WaitForPageLoad();
        }
    }
}
