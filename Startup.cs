using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

[assembly: FunctionsStartup(typeof(FunctionApp.Startup))]

namespace FunctionApp
{
    class Startup : FunctionsStartup
    {
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            // Add Azure App Configuration as additional configuration source
            builder.ConfigurationBuilder.AddAzureAppConfiguration(options =>
            {
                options.Connect(Environment.GetEnvironmentVariable("ConnectionString"))
                       // Load all keys that start with `TestApp:` and have no label
                       .Select("TestApp:*")
                       // Configure to reload configuration if the registered key 'TestApp:Settings:Sentinel' is modified.
                       // Use the default cache expiration of 30 seconds. It can be overridden via AzureAppConfigurationRefreshOptions.SetCacheExpiration.
                       .ConfigureRefresh(refreshOptions =>
                            refreshOptions.Register("TestApp:Settings:ConnectionString", refreshAll: true)
                                .SetCacheExpiration(TimeSpan.FromSeconds(30))
                        );
            });
            string cs = Environment.GetEnvironmentVariable("ConnectionString");
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddAzureAppConfiguration();
        }
    }
}