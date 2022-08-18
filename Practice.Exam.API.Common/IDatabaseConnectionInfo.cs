namespace Practice.Exam.API.Common
{
    public interface IDatabaseConnectionInfo
    {
        string DatabaseName { get; set; }
        void Init();
    }
}