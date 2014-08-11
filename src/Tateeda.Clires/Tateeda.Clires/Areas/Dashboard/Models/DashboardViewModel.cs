namespace Tateeda.Clires.Areas.Dashboard.Models
{
	using global::System.Collections.Generic;
	using Admin.Model.Report;
	using Admin.Model.Users;
	using Core.Data.EF;

	public interface IDashboardViewModel
	{
		bool IsAdmin { get; set; }
		IEnumerable<IAppointment> Appointments { get; set; }
		IAppUserViewModel AppUserView { get; set; }
		IEnumerable<IMessageQueue> Messages { get; set; }
		ReportModel AdminReport { get; set; }
	}

	public class DashboardViewModel : IDashboardViewModel
	{
		public bool IsAdmin { get; set; }
		public IEnumerable<IAppointment> Appointments { get; set; }
		public IAppUserViewModel AppUserView { get; set; }
		public IEnumerable<IMessageQueue> Messages { get; set; }
		public ReportModel AdminReport { get; set; }
	}
}