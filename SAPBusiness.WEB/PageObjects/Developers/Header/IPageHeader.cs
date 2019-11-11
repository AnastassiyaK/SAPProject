namespace SAPBusiness.WEB.PageObjects.Developers.Header
{
    using System.Collections.Generic;

    public interface IPageHeader : IPageObject
    {
        void OpenLogonFrame();

        List<string> GetMenuLinks();
    }
}