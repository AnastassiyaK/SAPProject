namespace SAPTests.Autofac
{
    using Core.Configuration;
    using Core.DriverFactory;
    using Core.REST_API.Cookies;
    using Core.WebDriver;
    using global::Autofac;
    using Microsoft.Extensions.Configuration;
    using SAPBusiness.Configuration;
    using SAPBusiness.Services.API_Services.Tutorial;
    using SAPBusiness.Services.API_Services.TutorialNavigator;
    using SAPBusiness.Services.API_Services.User;
    using SAPBusiness.Services.Interfaces.API_UserService;
    using SAPBusiness.TilesData;
    using SAPBusiness.UserData;
    using SAPBusiness.UserData.DeveloperCenter;
    using SAPBusiness.WEB.PageObjects;
    using SAPBusiness.WEB.PageObjects.Developers.Footer;
    using SAPBusiness.WEB.PageObjects.Developers.Footer.Networks;
    using SAPBusiness.WEB.PageObjects.Developers.Frames;
    using SAPBusiness.WEB.PageObjects.Developers.Header;
    using SAPBusiness.WEB.PageObjects.Developers.MainPage;
    using SAPBusiness.WEB.PageObjects.Developers.MainPage.Statistics;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource.Attributes;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.BlogPosts;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource.FeaturedContent.BlogPosts.FeedContent;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource.Memberships;
    using SAPBusiness.WEB.PageObjects.Developers.OpenSource.Projects;
    using SAPBusiness.WEB.PageObjects.LogOn;
    using SAPBusiness.WEB.PageObjects.People.Dashboard.Bookmarks;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator.FilterSection;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator.Mission;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator.PaginationSection;
    using SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial;
    using SAPTests.TestData.TutorialNavigator;
    using ISearchSectionDevelopers = SAPBusiness.WEB.PageObjects.Developers.OpenSource.Projects.Search.ISearchSection;
    using ISearchSectionPeople = SAPBusiness.WEB.PageObjects.People.Dashboard.Bookmarks.ISearchSection;
    using ITNavigatorSearch = SAPBusiness.WEB.PageObjects.TutorialNavigator.Search.ISearchSection;
    using MPage = SAPBusiness.WEB.PageObjects.Developers.MainPage.MainPage;
    using OpenSourcePage = SAPBusiness.WEB.PageObjects.Developers.OpenSource.OpenSource;
    using SearchSectionDevelopers = SAPBusiness.WEB.PageObjects.Developers.OpenSource.Projects.Search.SearchSection;
    using SearchSectionPeople = SAPBusiness.WEB.PageObjects.People.Dashboard.Bookmarks.SearchSection;
    using TNavigator = SAPBusiness.WEB.PageObjects.TutorialNavigator.TutorialNavigator;
    using TNavigatorSearch = SAPBusiness.WEB.PageObjects.TutorialNavigator.Search.SearchSection;
    using TutorialPage = SAPBusiness.WEB.PageObjects.TutorialNavigator.Tutorial.Tutorial;

    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // builder.RegisterAssemblyTypes(typeof(CheckTutorialNavigatorSearchFeature).Assembly).SingleInstance();
            builder.RegisterType<ConfigurationBuilder>().As<IConfigurationBuilder>().SingleInstance();

            RegisterDriverConfiguration(builder);

            RegisterEnvironmentConfiguration(builder);

            builder.RegisterType<WebDriver>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<CookiesConverter>().As<ICookiesConverter>();

            builder.RegisterType<BasePageObject>().AsSelf().InstancePerDependency();

            builder.RegisterType<BaseDependentOnElementObject>().AsSelf().InstancePerDependency();

            builder.RegisterType<WebDriverFactory>().AsSelf().InstancePerDependency();

            builder.RegisterType<MPage>().As<IMainPage>().InstancePerDependency();

            builder.RegisterType<OpenSourcePage>().As<IOpenSource>().InstancePerDependency();

            builder.RegisterType<CookiesFrame>().As<ICookiesFrame>();

            builder.RegisterType<ProjectsSection>().As<IProjectsSection>();

            builder.RegisterType<SearchSectionDevelopers>().As<ISearchSectionDevelopers>();

            builder.RegisterType<FeedSortList>().As<IFeedSortItem>();

            builder.RegisterType<BlogPostSection>().As<IBlogPostSection>();

            builder.RegisterType<MembershipSection>().AsSelf().InstancePerDependency();

            builder.RegisterType<MembershipSection>().As<IMembershipSection>();

            builder.RegisterType<FilterSection>().As<IFilterSection>();

            builder.RegisterType<TNavigator>().As<ITutorialNavigator>().InstancePerDependency();

            builder.RegisterType<DefaultPageHeader>().As<IPageHeader>();

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

            builder.RegisterType<FeedFactory>().As<IFeedFactory>();

            builder.RegisterType<AttributesSection>().As<IAttributesSection>();

            builder.RegisterType<AttributeFactory>().As<IAttributeFactory>();

            builder.RegisterType<Membership>().As<IMembership>();

            builder.RegisterType<ProjectCardFactory>().As<IProjectCardFactory>();

            builder.RegisterType<MembershipFactory>().As<IMembershipFactory>();

            builder.RegisterType<SocialNetworkFactory>().As<ISocialNetworkFactory>();

            builder.RegisterType<SummarySection>().As<ISummarySection>();

            builder.RegisterType<TNavigatorSearch>().As<ITNavigatorSearch>();

            builder.RegisterType<RestSharpTilesService>().As<ITilesService>();

            builder.RegisterType<TutorialPage>().As<ITutorial>();

            builder.RegisterType<Mission>().As<IMission>();

            builder.RegisterType<MiniNavigator>().As<IMiniNavigator>();

            builder.RegisterType<BreadCrumb>().As<IBreadCrumb>();

            builder.RegisterType<NextStepSection>().As<INextStepSection>();

            builder.RegisterType<ContextService>().As<IContextService>();

            builder.RegisterType<SummaryProgress>().As<ISummaryProgress>();

            builder.RegisterType<TimeConverter>().As<ITimeConverter>();

            builder.RegisterType<PaginationSection>().As<IPaginationSection>();

            builder.RegisterType<TutorialNavigatorConfiguration>().AsSelf().SingleInstance();

            builder.RegisterType<BookmarkPage>().As<IBookmarkPage>();

            builder.RegisterType<DeleteButton>().AsSelf();

            builder.RegisterType<SearchSectionPeople>().As<ISearchSectionPeople>();

            builder.RegisterType<BaseFacet>().AsSelf().InstancePerDependency();

            builder.RegisterType<FacetType>().AsSelf().InstancePerDependency();

            builder.RegisterType<SideBreadCrumbMenu>().As<ISideBreadCrumbMenu>();
        }

        private void RegisterDriverConfiguration(ContainerBuilder builder)
        {
            builder.RegisterInstance(new DriverConfiguration()).SingleInstance();
        }

        private void RegisterEnvironmentConfiguration(ContainerBuilder builder)
        {
            builder.RegisterInstance(new EnvironmentConfig()).SingleInstance();
        }
    }
}
