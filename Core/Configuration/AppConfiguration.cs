using Microsoft.Extensions.Configuration;
using System.IO;

namespace Core.Configuration
{
    public static class AppConfiguration
    {
        public static IConfiguration AppSetting { get; }
        static AppConfiguration()
        {
            AppSetting = new ConfigurationBuilder()
                    .AddJsonFile($@"{Directory.GetCurrentDirectory()}\Configuration\appSettingsWebDriver.json")
                    .AddJsonFile($@"{Directory.GetCurrentDirectory()}\Configuration\appSettingsAPIServices.json")
                    .AddJsonFile($@"{Directory.GetCurrentDirectory()}\Configuration\appSettingsTests.json")
                    .Build();
        }
    }
}
