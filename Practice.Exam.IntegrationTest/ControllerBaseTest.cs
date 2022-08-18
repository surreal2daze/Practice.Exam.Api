using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Practice.Exam.API.Common;
using Practice.Api.Database;
using Practice.Api.TestCommon;

namespace Practice.Exam.IntegrationTest
{
    public abstract class ControllerBaseTest
    {
        private HttpClient _httpClient;
        public static IServiceScopeFactory ScopeFactory { get; private set; }
        private CustomWebApplicationFactory Factory { get; set; }

        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            Factory = new CustomWebApplicationFactory();
            Factory.ConfigureTestServices(ConfigureTestServices);

            _httpClient = Factory.CreateClient();
            ScopeFactory = Factory.Server.Host.Services.GetService<IServiceScopeFactory>();
            
        }

        [SetUp]
        public virtual void Init()
        {
            Factory.Server.Host.Services.GetService<IDatabaseConnectionInfo>().Init();
        }

        [TearDown]
        public void Down()
        {
            var practiceApiContext = Factory.Server.Host.Services.GetService<PracticeApiContext>();
            practiceApiContext.Database.EnsureDeleted();
            Factory.Server.Host.Services.GetService<IDatabaseConnectionInfo>().Init();
        }

        protected virtual void ConfigureTestServices(IServiceCollection services)
        {
            services.AddSingleton<IDatabaseConnectionInfo, DatabaseConnectionInfo>();
        }

        protected async Task<HttpResponseMessage> PostAsync<T>(string url, T data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync(url, content);
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await _httpClient.DeleteAsync(url);
        }

        protected async Task<HttpResponseMessage> PutAsync<T>(string url, T data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync(url, content);
        }

        protected Task<HttpResponseMessage> GetAsync(string url)
        {
            var message = new HttpRequestMessage(new HttpMethod("GET"), url);
            return SendAsync(message);
        }

        private async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await _httpClient.SendAsync(request);
        }
    }
}