using SAPBusiness.WEB.PageObjects.Footer.Networks;

namespace SAPBusiness.WEB.PageObjects.Footer
{
    public interface IPageFooter : IPageObject<IPageFooter>
    {
        SocialNetwork GetSocialNetwork(NetworkType type);
        void OpenSocialNetWorkPage(NetworkType type);
    }
}