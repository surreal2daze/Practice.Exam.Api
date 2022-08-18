using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Exam.Shared
{
    /// <summary>
    /// Validation error
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Create new instance of class.
        /// </summary>
        /// <param name="field">Invalid field name</param>
        /// <param name="message">Error message</param>
        public ValidationError(string field, string message)
        {
            Field = !string.IsNullOrEmpty(field) ? field.ToLower()[0] + field.Substring(1) : string.Empty;
            Message = message;
        }

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Invalid field name
        /// </summary>
        public string Field { get; }
    }
}