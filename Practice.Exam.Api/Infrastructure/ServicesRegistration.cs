using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Practice.Api.Database;
using Practice.Api.Declarations;
using Practice.Api.Services.Declaration;
using Practice.Api.Services.Implementation;
using Practice.Exam.API.Common;
using Practice.Exam.Shared.Model;

namespace Practice.Exam.Api.Infrastructure
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IWebHostEnvironment environment)
        {
            if (environment.IsTesting())
            {
                services.AddSingleton<IApplicationConfiguration>(
                    provider => new ApplicationConfiguration(
                        provider.GetService<IMapper>(),
                        provider.GetService<IAppConfig>(),
                        provider.GetService<IDatabaseConnectionInfo>().DatabaseName));
            }
            else
            {
                services.AddSingleton<IApplicationConfiguration>(
                    provider => new ApplicationConfiguration(
                        provider.GetService<IMapper>(),
                        provider.GetService<IAppConfig>(),
                        provider.GetService<PracticeApiContext>().Database.GetDbConnection().Database));
            }

            services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();
            return services;
        }
    }
}