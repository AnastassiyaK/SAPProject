namespace SAPBusiness.WEB.PageObjects.OpenSource.Attributes
{
    public interface IAttributesSection
    {
        Attribute GetAttributeByTitle(string title);
        int GetAttributesAmount();
        bool HasAttributes();
    }
}