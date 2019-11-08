using System;

using Microsoft.Extensions.Configuration;

using R5T.Venetia;


namespace R5T.Tencteria.Configuration
{
    /// <summary>
    /// A default implementation of a configuration-based connection string provider service.
    /// The service directly provides the value in the configuration at the <see cref="DefaultConfigurationConnectionStringProvider.ConnectionStringConfigurationPath"/> location.
    /// </summary>
    public class DefaultConfigurationConnectionStringProvider : IConnectionStringProvider
    {
        public const string ConnectionStringConfigurationPath = "DatabaseConfiguration:ConnectionString";


        private IConfiguration Configuration { get; }


        public DefaultConfigurationConnectionStringProvider(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public string GetConnectionString()
        {
            var connectionString = this.Configuration[DefaultConfigurationConnectionStringProvider.ConnectionStringConfigurationPath];
            return connectionString;
        }
    }
}
