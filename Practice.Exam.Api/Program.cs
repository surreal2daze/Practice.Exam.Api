using Microsoft.AspNetCore;

namespace Practice.Exam.Api
{
    public class Program
    {
        public static void Main(string[] args) => CreateWebHostBuilder(args).Build().Run();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost
                .CreateDefaultBuilder(args)
                .UseDefaultServiceProvider((context, options) => options.ValidateScopes = false)
                .UseStartup<Startup>();
    }
}