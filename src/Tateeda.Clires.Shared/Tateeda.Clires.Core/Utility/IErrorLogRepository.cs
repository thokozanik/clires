namespace Tateeda.Clires.Core.Utility
{
    using Tateeda.Clires.Core.Data;
    using Tateeda.Clires.Core.Data.EF;

    public interface IErrorLogRepository : IRepository<ErrorLog>
    {
        void Log(string message, string stackTrace);
    }
}