using Practice.Api.Implementations.Queryable;
using Practice.Exam.API.Common;

namespace Practice.Exam.Api.Ioc
{
    public static class EntitySetsRegistration
    {
        public static IServiceCollection RegisterEntitySets(this IServiceCollection services)
        {
            var entitySetGenericType = typeof(EntitySet<>);

            var entitySetTypes = entitySetGenericType.Assembly.GetTypes()
                .Where(t =>
                    t != entitySetGenericType
                    && t.Name.Contains(InternalConstants.EntitySetPostfix)
                    && t.Namespace == entitySetGenericType.Namespace);

            foreach (var type in entitySetTypes)
            {
                var interfaces = type.BaseType.GetInterfaces();
                var serviceTypes = interfaces.Where(i => i.Name.Contains(InternalConstants.EntitySetPostfix));

                foreach (var serviceType in serviceTypes)
                {
                    services.AddScoped(serviceType, type);
                }

                services.AddScoped(type);
            }

            return services;
        }
    }
}