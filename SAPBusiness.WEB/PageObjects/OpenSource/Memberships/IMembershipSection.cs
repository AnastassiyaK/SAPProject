using System.Collections.Generic;

namespace SAPBusiness.WEB.PageObjects.OpenSource.Memberships
{
    public interface IMembershipSection : IPageObject<IMembershipSection>
    {
        string Description { get; }
        string Title { get; }

        List<Membership> GetAllMemberships();
        Membership GetMembershipContainerByTitle(string title);
        int GetMembershipsAmount();
        bool HasMemberships();
    }
}