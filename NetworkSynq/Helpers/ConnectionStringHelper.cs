using Microsoft.Extensions.Configuration;
using System.IO;

namespace NetworkSynq.Helpers
{
    public static class ConnectionStringHelper
    {
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            return configuration.GetConnectionString("ConnectionString");
        }

    }
}
