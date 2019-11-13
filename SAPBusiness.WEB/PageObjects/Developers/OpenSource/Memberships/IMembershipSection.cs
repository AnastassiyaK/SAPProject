namespace SAPBusiness.WEB.PageObjects.Developers.OpenSource.Memberships
{
    using System.Collections.Generic;

    public interface IMembershipSection : IPageObject
    {
        string Description { get; }

        string Title { get; }

        List<IMembership> GetAllMemberships();

        IMembership GetMembershipContainerByTitle(string title);

        int GetMembershipsAmount();

        bool HasMemberships();
    }
}