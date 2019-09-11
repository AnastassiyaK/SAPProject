using Core.Configuration;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace SAPTests
{
    [SetUpFixture]
    public class SetUpGlobal
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            AppConfiguration.ConfigurationBuilder
               .AddJsonFile(@"Configuration\appSettingsWebDriver.json")
               .AddJsonFile(@"Configuration\appSettingsAPIServices.json")
               .AddJsonFile(@"Configuration\appSettingsTests.json");

            AppConfiguration.SetConfiguration();
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {

        }

    }
}
