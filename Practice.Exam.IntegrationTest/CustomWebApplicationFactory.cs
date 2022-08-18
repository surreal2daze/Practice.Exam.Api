using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Practice.Exam.Api;

namespace Practice.Exam.IntegrationTest
{
    public class CustomWebApplicationFactory : 
        WebApplicationFactory<Startup>
    {
        private Action<IServiceCollection> _servicesConfiguration;

        public void ConfigureTestServices(Action<IServiceCollection> servicesConfiguration)
            => _servicesConfiguration = servicesConfiguration;

        protected override TestServer CreateServer(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(_servicesConfiguration);
            builder.UseEnvironment("TESTING");
            return base.CreateServer(builder);
        }
    }
}