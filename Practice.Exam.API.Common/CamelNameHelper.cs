using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Exam.API.Common
{
    public static class CamelNameHelper
    {
        public static string AsCamel(this string s)
        {
            if (s == null)
            {
                return null;
            }

            return !string.IsNullOrEmpty(s)
                ? $"{s.ToLower()[0]}{s.Substring(1)}"
                : string.Empty;
        }

        public static string AsPascal(this string s)
        {
            if (s == null)
            {
                return null;
            }

            return !string.IsNullOrEmpty(s)
                ? $"{s.ToUpper()[0]}{s.Substring(1)}"
                : string.Empty;
        }
    }
}