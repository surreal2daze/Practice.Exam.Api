using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Practice.Exam.Shared.Model;
using Practice.Exam.Shared.Properties;

namespace Practice.Exam.Api.Infrastructure
{
    public class ErrorFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _environment;

        public ErrorFilter(IWebHostEnvironment env)
        {
            _environment = env;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException)
            {
                context.ExceptionHandled = true;
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
            else
            {
                if (_environment.IsDevelopment())
                {
                    return;
                }

                context.ExceptionHandled = true;

                var errorReferenceId = Activity.Current?.RootId;
                var errorDetails = new ErrorDetailsWithReferenceId
                {
                    ErrorMessage = string.Format(Resources.ErrorOccured, errorReferenceId),
                    ErrorReferenceId = errorReferenceId
                };

                context.Result = new JsonResult(errorDetails)
                {
                    StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
