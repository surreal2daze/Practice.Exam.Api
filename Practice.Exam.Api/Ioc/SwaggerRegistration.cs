using Microsoft.OpenApi.Models;
using Practice.Exam.Api.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Practice.Exam.Api.Ioc
{
    public static class SwaggerRegistration
    {
        public static IServiceCollection RegisterSwagger(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSwaggerGen(opts =>
            {
                opts.ResolveConflictingActions(s => s.First());
                opts.RegisterSwaggerFilters();
                opts.SwaggerDoc("v1", new OpenApiInfo { Title = $"Admin 1.0", Version = "v1" });
                
            });

            return services;
        }

        private static void RegisterSwaggerFilters(this SwaggerGenOptions options)
        {
            options.SchemaFilter<SwaggerExcludeFilter>();
            options.SchemaFilter<FluentValidationRules>();
        }
    }
}