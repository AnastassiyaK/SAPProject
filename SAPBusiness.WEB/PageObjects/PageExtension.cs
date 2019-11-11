namespace SAPBusiness.WEB.PageObjects
{
    public static class PageExtension
    {
        public static T WaitForLoading<T>(this T page)
            where T : IPageObject
        {
            page.WaitForLoad();
            return page;
        }
    }
}
