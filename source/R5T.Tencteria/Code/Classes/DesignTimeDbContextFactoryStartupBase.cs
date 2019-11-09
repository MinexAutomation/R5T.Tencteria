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
        /// This must be called AFTER all service dependencies of <typeparamref name="TConnectionStringProvider"/> and <typeparamref name="TDatabaseContextOptionsBuilderConfigurator"/> have been registered.
        /// </summary>
        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            services.AddDatabaseContext<TDbContext, TConnectionStringProvider, TDatabaseContextOptionsBuilderConfigurator>();
        }
    }

    public class DesignTimeDbContextFactoryStartupBase<TConnectionStringProvider, TDatabaseContextOptionsBuilderConfigurator>
        : ApplicationStartupBase, IDesignTimeDbContextFactoryStartup
        where TConnectionStringProvider : class, IConnectionStringProvider
        where TDatabaseContextOptionsBuilderConfigurator : class, IDatabaseContextOptionsBuilderConfigurator
    {
        public DesignTimeDbContextFactoryStartupBase(ILogger<DesignTimeDbContextFactoryStartupBase<TConnectionStringProvider, TDatabaseContextOptionsBuilderConfigurator>> logger)
            : base(logger)
        {
        }

        protected void AddDatabaseContext<TDbContext>(IServiceCollection services)
            where TDbContext: DbContext
        {
            services.AddDatabaseContext<TDbContext, TConnectionStringProvider, TDatabaseContextOptionsBuilderConfigurator>();
        }
    }
}
