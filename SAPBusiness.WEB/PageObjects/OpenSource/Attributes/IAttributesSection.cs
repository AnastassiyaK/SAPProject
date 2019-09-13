namespace SAPBusiness.WEB.PageObjects.OpenSource.Attributes
{
    public interface IAttributesSection : IPageObject
    {
        Attribute GetAttributeByTitle(string title);
        int GetAttributesAmount();
        bool HasAttributes();
    }
}