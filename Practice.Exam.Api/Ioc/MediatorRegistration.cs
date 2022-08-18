using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Practice.Exam.Services.Implementation;
using System.Reflection;

namespace Practice.Exam.Api.Ioc
{
    public static class MediatorRegistration
    {
        public static IServiceCollection RegisterMediatr(this IServiceCollection services)
        {
            //services.AddTransient(
            //    typeof(IPipelineBehavior<,>),
            //    typeof(UnitOfWorkBehavior<,>));

            //services.AddTransient(
            //    typeof(IPipelineBehavior<,>),
            //    typeof(LoggingBehavior<,>));

            services.AddMediatR(typeof(MediatorHandler).GetTypeInfo().Assembly,
            typeof(IRegistrationHandler).GetTypeInfo().Assembly);

            return services;
        }
    }
}
