namespace Practice.Exam.Shared
{
    /// <summary>
    /// Wrapper for action execution. 
    /// </summary>
    /// <typeparam name="T">Type of data to return</typeparam>
    public class CommandResult<T>
    {
        /// <summary>
        /// Error info
        /// </summary>
        public ErrorDetails ErrorDetails { get; set; }

        /// <summary>
        /// Code result of request
        /// </summary>
        public ProcessResult ProcessResult { get; set; }

        /// <summary>
        /// Result data of operation execution
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Create successful result
        /// </summary>
        /// <param name="data">Data that will be returned.</param>
        /// <returns></returns>
        public static CommandResult<T> Success(T data)
        {
            return new CommandResult<T>
            {
                Data = data,
                ProcessResult = ProcessResult.Ok
            };
        }

        /// <summary>
        /// Create unsuccessful result
        /// </summary>
        /// <param name="error">error message</param>
        /// <param name="processResult">code result</param>
        /// <returns></returns>
        public static CommandResult<T> Fail(string error, ProcessResult processResult)
        {
            return new CommandResult<T>
            {
                ProcessResult = processResult,
                ErrorDetails = new ErrorDetails
                {
                    ErrorMessage = error
                }
            };
        }

        /// <summary>
        /// Create unsuccessful result
        /// </summary>
        /// <param name="errorDetails">error info</param>
        /// <param name="processResult">code result</param>
        /// <returns></returns>
        public static CommandResult<T> Fail(ErrorDetails errorDetails, ProcessResult processResult)
        {
            return new CommandResult<T>
            {
                ProcessResult = processResult,
                ErrorDetails = errorDetails
            };
        }
    }
}