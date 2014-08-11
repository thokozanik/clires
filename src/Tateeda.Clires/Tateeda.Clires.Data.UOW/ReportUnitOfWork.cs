namespace Tateeda.Clires.Data.UOW
{
	using System;
	using Core.Data.EF;
	using Core.Report;

	public class ReportUnitOfWork : IReportUnitOfWork
	{
		private bool _disposed;

		public ReportUnitOfWork()
		{
			Context = new Entities();
			Context.TrackChanges = false;
			ReportRepository = new ReportRepository(Context);
		}

		public IDbContext Context { get; private set; }

		public void Commit()
		{
			//Not used for this Repository
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// The dispose.
		/// </summary>
		/// <param name="disposing">
		/// The disposing. 
		/// </param>
		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed && disposing)
			{
				this.Context.Dispose();
			}

			_disposed = true;
		}

		public IReportRepository ReportRepository { get; private set; }
	}
}
