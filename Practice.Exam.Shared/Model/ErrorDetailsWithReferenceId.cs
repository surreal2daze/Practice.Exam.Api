using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Exam.Shared.Model
{
    public class ErrorDetailsWithReferenceId : ErrorDetails
    {
        /// <summary>
        /// Reference Id
        /// </summary>
        public string ErrorReferenceId { get; set; }
    }
}