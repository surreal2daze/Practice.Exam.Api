using AutoMapper;
using Microsoft.OpenApi.Validations;
using Practice.Exam.Shared.Model;
using System.ComponentModel;
using System.Security.Claims;
using System.Xml.Linq;

namespace Practice.Exam.Api.Infrastructure
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            SetupAppConfigMapping();
        }

        private void SetupAppConfigMapping()
            => CreateMap<IAppConfig, AppConfigModel>();

    }
}