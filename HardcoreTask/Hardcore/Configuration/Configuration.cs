using Microsoft.Extensions.Configuration;

namespace Hardcore.Tests.Configuration
{
    public static class Configuration
    {
        private static IConfigurationRoot _config;

        static Configuration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        public static string GetProjectConfig(string key)
        {
            return _config[key];
        }

        public static BrowserType ReadBrowserTypeFromConfig()
        {
            var result = GetProjectConfig("Browser");
            switch (result)
            {
                case "FIREFOX":
                    return BrowserType.FIREFOX;
                case "CHROME":
                    return BrowserType.CHROME;
                default:
                    throw new ArgumentException("Invalid driver name.");
            }
        }
    }
}