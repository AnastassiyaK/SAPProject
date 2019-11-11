namespace SAPBusiness.WEB.PageObjects.Developers.Header
{
    using Core.WebDriver;
    using NLog;

    public class DefaultPageHeader : PageHeader
    {
        public DefaultPageHeader(WebDriver driver, ILogger logger)
            : base(driver, logger)
        {
        }
    }
}
