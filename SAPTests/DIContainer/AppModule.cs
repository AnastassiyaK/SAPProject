using Autofac;
using SAPBusiness.WEB.PageObjects;
using SAPBusiness.WEB.PageObjects.Frames;
using SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts;
using SAPBusiness.WEB.PageObjects.OpenSource.FeaturedContent.BlogPosts.FeedContent;
using SAPBusiness.WEB.PageObjects.OpenSource.Memberships;
using SAPBusiness.WEB.PageObjects.OpenSource.Projects;
using SAPBusiness.WEB.PageObjects.OpenSource.Projects.Search;
using TNavigator = SAPBusiness.WEB.PageObjects.TutorialNavigator.TutorialNavigator;
using SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection;
using SAPBusiness.WEB.PageObjects.Header;
using SAPBusiness.WEB.PageObjects.TutorialNavigator;
using SAPBusiness.UserData;
using SAPBusiness.Services.API_Services.User;
using SAPBusiness.UserData.DeveloperCenter;
using SAPBusiness.WEB.PageObjects.MainPage.Statistics;
using SAPBusiness.WEB.PageObjects.Footer;
using SAPBusiness.WEB.PageObjects.Footer.Networks;
using Core.WebDriver;
using SAPBusiness.Services.Interfaces.API_UserService;
using Core.DriverFactory;
using SAPBusiness.WEB.PageObjects.LogOn;
using Core.Configuration;
using Microsoft.Extensions.Configuration;
using Core.REST_API.Cookies;
using SAPBusiness.Configuration;
using SAPBusiness.WEB.PageObjects.MainPage;
using SAPBusiness.WEB.PageObjects.OpenSource;
using OpenSourcePage = SAPBusiness.WEB.PageObjects.OpenSource.OpenSource;
using SAPBusiness.WEB.PageObjects.OpenSource.Attributes;

namespace SAPTests.Autofac
{
    class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConfigurationBuilder>().As<IConfigurationBuilder>().SingleInstance();

            builder.RegisterType<DriverConfiguration>().As<IDriverConfiguration>().SingleInstance();

            builder.RegisterType<EnvironmentConfig>().As<IEnvironmentConfig>().SingleInstance(); 

            builder.RegisterType<WebDriver>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<CookiesConverter>().As<ICookiesConverter>();

            builder.RegisterType<BasePageObject>().AsSelf().InstancePerDependency();

            builder.RegisterType<WebDriverFactory>().AsSelf().InstancePerDependency();

            builder.RegisterType<MainPage>().As<IMainPage>().InstancePerDependency();

            builder.RegisterType<OpenSourcePage>().As<IOpenSource>().InstancePerDependency(); 

            builder.RegisterType<CookiesFrame>().As<ICookiesFrame>();

            builder.RegisterType<ProjectsSection>().As<IProjectsSection>();

            builder.RegisterType<SearchSection>().As<ISearchSection>();

            builder.RegisterType<FeedSortList>().As<IFeedSortItem>();

            builder.RegisterType<BlogPostSection>().As<IBlogPostSection>();

            builder.RegisterType<MembershipSection>().AsSelf().InstancePerDependency();

            builder.RegisterType<MembershipSection>().As<IMembershipSection>();

            builder.RegisterType<FilterSection>().As<IFilterSection>();

            builder.RegisterType<TNavigator>().As<ITutorialNavigator>().InstancePerDependency();

            builder.RegisterType<PageHeader>().As<IPageHeader>();

            builder.RegisterType<PageFooter>().As<IPageFooter>();

            builder.RegisterType<TileLegend>().As<ITileLegend>();

            builder.RegisterType<UserPool>().AsSelf().InstancePerDependency();

            builder.RegisterType<LogOnFrame>().AsSelf().InstancePerDependency();

            builder.RegisterType<UserStatistics>().AsSelf().InstancePerDependency();

            builder.RegisterType<TutorialSection>().As<ITutorialSection>();

            builder.RegisterType<SocialNetwork>().As<ISocialNetwork>();

            builder.RegisterType<RestSharpUserService>().As<IUserService>();

            builder.RegisterType<LogOnSection>().As<ILogOnSection>();

            builder.RegisterType<FacetExperience>().As<IFacetExperience>();

            builder.RegisterType<FacetTopic>().As<IFacetTopic>();

            builder.RegisterType<FacetType>().As<IFacetType>();

            builder.RegisterType<SocialNetworkSection>().As<ISocialNetworkSection>();

            builder.RegisterType<TileElementFactory>().As<ITileElementFactory>();

            builder.RegisterType<FeedFactory>().As<IFeedFactory>();

            builder.RegisterType<AttributesSection>().As<IAttributesSection>();

            builder.RegisterType<AttributeFactory>().As<IAttributeFactory>();

            builder.RegisterType<Membership>().As<IMembership>();

            builder.RegisterType<ProjectCardFactory>().As<IProjectCardFactory>();

            builder.RegisterType<MembershipFactory>().As<IMembershipFactory>(); 
        }
    }
}
