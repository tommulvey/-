using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiSpeedia.Objects;
using WikiSpeedia.Abstractions;
using WikiSpeedia.Repos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace WikiSpeedia.DI
{
    public class DependencyResolver
    {
        public IServiceProvider ServiceProvider { get; }
        public string CurrentDirectory { get; set; }
        public Action<IServiceCollection> RegisterServices { get; }

        public DependencyResolver(Action<IServiceCollection> regiserServices = null)
        {
            // DI
            var serviceCollection = new ServiceCollection();
            RegisterServices = regiserServices;
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //register end and config services
            services.AddTransient<IEnviornmentService, EnviornmentService>();
            services.AddTransient<IConfigurationService, ConfigurationService>
            (provider => new ConfigurationService(provider.GetService<IEnviornmentService>())
            {
                CurrentDirectory = CurrentDirectory
            });
            // register dbcontext bro
            services.AddTransient(provider =>
            {
                var configService = provider.GetService<IConfigurationService>();
                var connectionString = configService.GetConfiguration().GetConnectionString(nameof(MSSQLDbContext));
                var optionsBuilder = new DbContextOptionsBuilder<MSSQLDbContext>();
                optionsBuilder.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("NetCoreLambda.EF.Design"));
                return new MSSQLDbContext(optionsBuilder.Options);
            });

            // all other garbage>?
            RegisterServices?.Invoke(services);
        }
    }
}
