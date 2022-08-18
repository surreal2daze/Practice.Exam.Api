using Microsoft.VisualBasic;
using Practice.Exam.API.Common;

namespace Practice.Exam.Api
{
    public static class EnvironmentHelper
    {
        public static bool IsTesting(this IWebHostEnvironment environment)
            => environment.EnvironmentName == InternalConstants.TestingEnvironmentName;
    }
}
