using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Exam.Shared.Model
{
    public class AppConfigModel : IAppConfig
    {

        public string DbName { get; set; }

        public string EnvironmentName { get; set; }

        public string EnvironmentUrl { get; set; }
    }

    public interface IAppConfig
    {
        string EnvironmentName { get; }
    }
}