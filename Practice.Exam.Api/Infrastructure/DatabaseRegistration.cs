using System;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Practice.Api.Database;
using Practice.Api.Declarations;
using Practice.Exam.API.Common;

namespace Practice.Exam.Api.Infrastructure
{
    public static class DatabaseRegistration
    {
        public static IServiceCollection RegisterDatabase(
            this IServiceCollection services,
            IWebHostEnvironment environment,
            IConfiguration configuration)
        {
            if (environment.IsTesting())
            {
                services.AddScoped<Func<PracticeApiContext>>(
                    serviceProvider => serviceProvider.GetService<PracticeApiContext>);

                services.AddDbContext<PracticeApiContext>((serviceProvider, opts) =>
                    opts.AsInMemoryDatabase(serviceProvider));

                services.AddScoped<IDbContextTransaction>(provider =>
                    new TestingCustomDbContextTransaction(
                        provider.GetService<PracticeApiContext>().Database.BeginTransaction(),
                        provider.GetService<IUnitOfWorkService>()));
            }
            else
            {

                services.AddDbContext<PracticeApiContext>(
                    opts => opts.AsSqlServerDatabase(configuration));

                services.AddSingleton<Func<PracticeApiContext>>(
                    () =>
                    {
                        var optionsBuilder = new DbContextOptionsBuilder<PracticeApiContext>();
                        optionsBuilder.AsSqlServerDatabase(configuration);
                        return new PracticeApiContext(optionsBuilder.Options);
                    });

                services.AddScoped<IDbContextTransaction>(
                    provider => new TestingCustomDbContextTransaction(
                        provider.GetService<PracticeApiContext>().Database.BeginTransaction(),
                        provider.GetService<IUnitOfWorkService>()));
            }

            return services;
        }
    }

    public static class DatabaseSettingsExtensions
    {
        public static DbContextOptionsBuilder AsSqlServerDatabase(
            this DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
            => optionsBuilder.UseSqlite(
                configuration.GetConnectionString("Database"),
                builder => builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));

        public static DbContextOptionsBuilder AsInMemoryDatabase(
            this DbContextOptionsBuilder optionsBuilder, IServiceProvider serviceProvider)
        {
            // https://github.com/dotnet/efcore/issues/6872
            var databaseName = serviceProvider.GetService<IDatabaseConnectionInfo>().DatabaseName;

            optionsBuilder
                .UseInMemoryDatabase(databaseName)
                .EnableSensitiveDataLogging()
                .ConfigureWarnings(warn => warn.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            return optionsBuilder;
        }
    }
}
