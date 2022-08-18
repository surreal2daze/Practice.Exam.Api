using Practice.Exam.Shared.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Exam.Shared
{
    /// <summary>
    /// Result of validation
    /// </summary>
    public class ValidationResultModel
    {
        /// <summary>
        /// Create new instance of class.
        /// </summary>
        public ValidationResultModel()
        {
        }

        /// <summary>
        /// Create new instance of class.
        /// </summary>
        /// <param name="validationErrors">Enumerable of validation errors.</param>
        public ValidationResultModel(IEnumerable<ValidationError> validationErrors)
        {
            ErrorMessage = Resources.Validation_Failed;
            Errors = validationErrors
                .GroupBy(x => x.Field)
                .ToDictionary(
                    error => error.Key,
                    error => error.Select(x => x.Message).ToList());
        }

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Re-grouped errors.
        /// </summary>
        public Dictionary<string, List<string>> Errors { get; set; }
    }
}
