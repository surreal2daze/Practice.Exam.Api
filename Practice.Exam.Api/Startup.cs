using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Practice.Exam.Api.Infrastructure;
using Practice.Exam.Api.Ioc;
using System;
using System.Text;

namespace Practice.Exam.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;
        public Startup(IWebHostEnvironment environment, IConfiguration config)
        {
            _environment = environment;
            _configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddMyServices(_environment, _configuration);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Practice Admin API"));
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static void AddMyServices(
        this IServiceCollection services,
            IWebHostEnvironment environment,
            IConfiguration configuration)
        {
            services
                .AddServices(environment)
                //.RegisterCodes()
                .RegisterValidators()
                //.RegisterHelpers()
                //.RegisterBuilders()
                //.RegisterAppSettings(configuration)
                //.RegisterIdentity(configuration)
                //.RegisterConverters()
                .RegisterEntitySets()
                //.RegisterProviders()
                .RegisterSwagger(configuration)
                .RegisterMapper()
                .RegisterMediatr()
                //.AddHttpContextAccessor()
                .RegisterDatabase(environment,configuration)
                .BuildMvc();
        }
    }
}
