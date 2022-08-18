using FluentValidation.Validators;
using FluentValidation;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Practice.Exam.Api.Ioc
{
    /// <summary>
    /// Swagger <see cref="ISchemaFilter"/> that uses FluentValidation validators instead System.ComponentModel based attributes.
    /// </summary>
    public class FluentValidationRules : ISchemaFilter
    {
        private readonly IValidatorFactory _factory;

        public FluentValidationRules(IValidatorFactory factory)
        {
            _factory = factory;
        }

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            // use IoC or FluentValidatorFactory to get AbstractValidator<T> instance
            var validator = _factory.GetValidator(context.Type);
            if (validator == null)
            {
                return;
            }

            if (schema.Required == null)
            {
                schema.Required = new HashSet<string>();
            }

            var validatorDescriptor = validator.CreateDescriptor();
            foreach (var key in schema.Properties.Keys)
            {
                foreach (var propertyValidator in validatorDescriptor.GetValidatorsForMember(ToPascalCase(key)))
                {
                    if (propertyValidator is NotNullValidator || propertyValidator is NotEmptyValidator)
                    {
                        schema.Required.Add(key);
                    }

                    if (propertyValidator is LengthValidator lengthValidator)
                    {
                        if (lengthValidator.Max > 0)
                        {
                            schema.Properties[key].MaxLength = lengthValidator.Max;
                        }

                        schema.Properties[key].MinLength = lengthValidator.Min;
                    }

                    if (propertyValidator is RegularExpressionValidator expressionValidator)
                    {
                        schema.Properties[key].Pattern = expressionValidator.Expression;
                    }

                    // Add more validation properties here;
                }
            }
        }

        /// <summary>
        /// To convert case as swagger may be using lower camel case
        /// </summary>
        private static string ToPascalCase(string inputString)
        {
            if (inputString == null || inputString.Length < 2)
            {
                return inputString?.ToUpper();
            }

            return inputString.Substring(0, 1).ToUpper() + inputString.Substring(1);
        }
    }
}