using Newtonsoft.Json;

namespace Practice.Exam.Shared
{
    /// <summary>
    /// Describes error details
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// Error message
        /// </summary>
        [JsonProperty(PropertyName = "errorMessage")]
        public virtual string ErrorMessage { get; set; }
    }
}