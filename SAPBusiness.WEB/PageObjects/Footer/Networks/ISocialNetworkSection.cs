namespace SAPBusiness.WEB.PageObjects.Footer.Networks
{
    public interface ISocialNetworkSection : IPageObject
    {
        string HeadLine { get; }
        void OpenNetwork(NetworkType type);

        string GetNetworkLink(NetworkType type);

    }
}
