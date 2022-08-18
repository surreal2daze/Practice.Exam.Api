using Microsoft.OpenApi.Models;
using Practice.Exam.Shared;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Practice.Exam.Api.Ioc
{
    public class SwaggerExcludeFilter : ISchemaFilter
    {
        #region ISchemaFilter Members

        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            var type = context.Type;
            if (model?.Properties == null || type == null)
            {
                return;
            }

            var excludedProperties = type.GetProperties()
                .Where(propertyInfo => propertyInfo.GetCustomAttribute<SwaggerExcludeAttribute>() != null);

            foreach (var excludedProperty in excludedProperties)
            {
                if (model.Properties.ContainsKey(excludedProperty.Name))
                {
                    model.Properties.Remove(excludedProperty.Name);
                }
            }
        }

        #endregion
    }
}