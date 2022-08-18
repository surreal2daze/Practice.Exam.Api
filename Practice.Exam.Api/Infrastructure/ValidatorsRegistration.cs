using FluentValidation;
using Practice.Exam.API.Common;
using Practice.Exam.Validation;

namespace Practice.Exam.Api.Infrastructure
{
    public static class ValidatorsRegistration
    {
        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            AssemblyScanner.FindValidatorsInAssemblyContaining<ValidationAssemblyRegister>().ForEach(pair =>
            {
                if (!pair.ValidatorType.GetInterfaces().Contains(typeof(INonRegisteredValidator)))
                {
                    services.Add(ServiceDescriptor.Transient(pair.InterfaceType, pair.ValidatorType));
                }
            });

            return services;
        }
    }
}
