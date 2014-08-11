namespace Tateeda.Clires.Data.UOW
{
	using Core.Report;

	public interface IReportUnitOfWork : IUnitOfWork
	{
		IReportRepository ReportRepository { get; }
	}
}