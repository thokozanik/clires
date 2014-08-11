namespace Tateeda.Clires.Data.UOW
{
    using Tateeda.Clires.Core.Utility;

    public interface IUtilUnitOfWork : IUnitOfWork
    {
        IErrorLogRepository ErrorLogRepository { get; }
    }
}