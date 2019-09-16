namespace SAPBusiness.WEB.PageObjects.OpenSource.Attributes
{
    public interface IAttributesSection : IPageObject
    {
        IAttribute GetAttributeByTitle(string title);
        int GetAttributesAmount();
        bool HasAttributes();
    }
}