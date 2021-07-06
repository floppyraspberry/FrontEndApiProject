using Microsoft.Extensions.Configuration;
using System.IO;

namespace Helpers.Configuration
{
    public static class ConfigurationRead
    {
        public static IConfiguration Create()
        {
            var directory = Directory.GetCurrentDirectory();
            
            return new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("Configuration/appsettings.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
