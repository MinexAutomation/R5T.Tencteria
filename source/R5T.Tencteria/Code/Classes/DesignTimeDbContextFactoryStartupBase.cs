using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;

using R5T.Gaul;
using R5T.Venetia;
using R5T.Venetia.Extensions;


namespace R5T.Tencteria
{
    public class DesignTimeDbContextFactoryStartupBase<TDbContext, TConnectionStringProvider, TDatabaseContextOptionsBuilderConfigurator>
        : ApplicationStartupBase, IDesignTimeDbContextFactoryStartup
        where TDbContext : DbContext
        where TConnectionStringProvider : class, IConnectionStringProvider
        where TDatabaseContextOptionsBuilderConfigurator : class, IDatabaseContextOptionsBuilderConfigurator
    {
        public DesignTimeDbContextFactoryStartupBase(ILogger<DesignTimeDbContextFactoryStartupBase<TDbContext, TConnectionStringProvider, TDatabaseContextOptionsBuilderConfigurator>> logger)
            : base(logger)
        {
        }

        /// <summary>
        /// Adds the database context, connection string provider, and database context options builder configurator.
        /// </summary>
        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            services.AddDatabaseContext<TDbContext, TConnectionStringProvider, TDatabaseContextOptionsBuilderConfigurator>();
        }
    }
}
