using Microsoft.Extensions.Configuration;
using System.IO;

namespace Core.Configuration
{
    public static class AppConfiguration
    {
        public static IConfiguration AppSetting { get; private set; }

        public static IConfigurationBuilder ConfigurationBuilder { get; }

        public static string NodeUrl { get; private set; }

        public static int TimeOutWebElement { get; private set; }

        static AppConfiguration()
        {
            ConfigurationBuilder = new ConfigurationBuilder();
        }

        public static void SetConfiguration()
        {
            AppSetting = ConfigurationBuilder.Build();

            NodeUrl = AppSetting["SeleniumGrid:nodeUrl"];

            TimeOutWebElement = int.Parse(AppSetting["Webdriver:WebElementTimeOut"]);
        }
    }
}
