namespace SAPBusiness.WEB.PageObjects.Header
{
    public interface IBreadCrumb
    {
        string RootLink { get; }
        string RootTitle { get; }
        string Title { get; }
    }
}