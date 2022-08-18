using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Exam.Shared.Model
{
    public class ActionExecutionResult
    {
        /// <summary>
        /// Was action executed successful
        /// </summary>
        public bool Successful { get; set; }

        /// <summary>
        /// Information message to show user after executing action.
        /// </summary>
        public string InformationMessage { get; set; }
    }
}