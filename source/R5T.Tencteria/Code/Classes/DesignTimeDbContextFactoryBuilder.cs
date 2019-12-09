using System;

using R5T.Gaul;


namespace R5T.Tencteria
{
    public static class DesignTimeDbContextFactoryBuilder
    {
        public static IServiceProvider UseStartup<TStartup>()
            where TStartup : ApplicationStartupBase, IDesignTimeDbContextFactoryStartup
        {
            var serviceProvider = ApplicationBuilder.UseStartup<TStartup>();
            return serviceProvider;
        }
    }
}
