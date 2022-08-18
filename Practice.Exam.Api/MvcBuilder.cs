using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Practice.Exam.Api.Infrastructure;
using Practice.Exam.API.Common;

namespace Practice.Exam.Api
{
    public static class MvcBuilder
    {
        public static IMvcBuilder BuildMvc(this IServiceCollection services)
        {
            var mvcBuilder = services.AddControllers(opts =>
            {
                opts.Filters.Add(typeof(ErrorFilter));
                opts.Filters.Add(typeof(ModelValidatorFilter));
            })
            //.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            .AddFluentValidation(fv =>
            {
                ValidatorOptions.DisplayNameResolver = (type, member, arg3) => member?.Name?.AsCamel();
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Formatting = Formatting.Indented;
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });

            return mvcBuilder;
        }
    }
}