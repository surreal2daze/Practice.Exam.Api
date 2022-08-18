using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Practice.Exam.Api.Infrastructure;

namespace Practice.Exam.Api.Ioc
{
    public static class AutoMapperRegistration
    {
        public static IServiceCollection RegisterMapper(this IServiceCollection services)
            => services.AddAutoMapper(x => x.AddProfile(new MappingConfiguration()), typeof(Startup));
    }
}