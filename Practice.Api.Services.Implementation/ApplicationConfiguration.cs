using AutoMapper;
using Practice.Api.Services.Declaration;
using Practice.Exam.Shared.Model;
using System.Diagnostics;
using System.Reflection;

namespace Practice.Api.Services.Implementation
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        private readonly AppConfigModel _result;

        public ApplicationConfiguration(
            IMapper mapper,
            IAppConfig appConfig,
            string databaseName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            var version = fvi.FileVersion;

            _result = mapper.Map<AppConfigModel>(appConfig);
            _result.DbName = databaseName;
        }

        public AppConfigModel ApplicationConfig() => _result;
    }
}