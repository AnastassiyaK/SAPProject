namespace SAPBusiness.WEB.PageObjects.Developers.Footer.Networks
{
    using SAPBusiness.Enums;

    public interface ISocialNetworkSection : IPageObject
    {
        string HeadLine { get; }

        void OpenNetwork(NetworkType type);

        string GetNetworkLink(NetworkType type);
    }
}
