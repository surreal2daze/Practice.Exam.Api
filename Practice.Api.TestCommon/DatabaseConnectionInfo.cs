using Practice.Exam.API.Common;

namespace Practice.Api.TestCommon
{
    public class DatabaseConnectionInfo : IDatabaseConnectionInfo
    {
        public DatabaseConnectionInfo() => Init();

        public void Init() => DatabaseName = Guid.NewGuid().ToString("N");

        public string DatabaseName { get; set; }
    }
}