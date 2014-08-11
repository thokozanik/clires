// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CliresEnums.cs" company="">
//   
// </copyright>
// <summary>
//   The entity status type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.Enums
{
	/// <summary>
	/// The entity status type.
	/// </summary>
	public enum EntityStatusType
	{
		/// <summary>
		/// The not set.
		/// </summary>
		NotSet = 0,

		/// <summary>
		/// The current.
		/// </summary>
		Current = 1,

		/// <summary>
		/// The deleted.
		/// </summary>
		Deleted = 2,

		/// <summary>
		/// The disabled.
		/// </summary>
		Disabled = 3,

		/// <summary>
		/// The archive.
		/// </summary>
		Archive = 4,

		/// <summary>
		/// Use for terminated subjects
		/// </summary>
		Terminated = 5
	}

	/// <summary>
	/// The form type.
	/// </summary>
	public enum FormType
	{
		/// <summary>
		/// The not set.
		/// </summary>
		NotSet = 0,

		/// <summary>
		/// The default form.
		/// </summary>
		DefaultForm = 1,

		/// <summary>
		/// The lab form.
		/// </summary>
		LabForm = 2
	}

	/// <summary>
	/// The appt form status type.
	/// </summary>
	public enum ApptFormStatusType
	{
		/// <summary>
		/// The not set.
		/// </summary>
		NotSet = 0,

		/// <summary>
		/// The completed.
		/// </summary>
		Completed = 1,

		/// <summary>
		/// The in progress.
		/// </summary>
		InProgress = 2,

		/// <summary>
		/// The canceled.
		/// </summary>
		Canceled = 3,

		/// <summary>
		/// The not started.
		/// </summary>
		NotStarted = 4,

		/// <summary>
		/// The forced closed.
		/// </summary>
		ForcedClosed = 5,

		/// <summary>
		/// The needs review.
		/// </summary>
		NeedsReview = 6,

		/// <summary>
		/// The needs approval.
		/// </summary>
		NeedsApproval = 7
	}

	/// <summary>
	/// The visit type.
	/// </summary>
	public enum VisitType
	{
		/// <summary>
		/// The not set.
		/// </summary>
		NotSet = 0,

		/// <summary>
		/// The office visit.
		/// </summary>
		OfficeVisit = 1,

		/// <summary>
		/// The walk in.
		/// </summary>
		WalkIn = 2,

		/// <summary>
		/// The online remote.
		/// </summary>
		OnlineRemote = 3,

		/// <summary>
		/// The on behalf of.
		/// </summary>
		OnBehalfOf = 4
	}

	/// <summary>
	/// The appointment status type.
	/// </summary>
	public enum AppointmentStatusType
	{
		/// <summary>
		/// The not set.
		/// </summary>
		NotSet = 0,

		/// <summary>
		/// The scheduled.
		/// </summary>
		Scheduled = 1,

		/// <summary>
		/// The in progress.
		/// </summary>
		InProgress = 2,

		/// <summary>
		/// The needs follow up visit.
		/// </summary>
		NeedsFollowUpVisit = 3,

		/// <summary>
		/// The completed.
		/// </summary>
		Completed = 4,

		/// <summary>
		/// The require more data.
		/// </summary>
		RequireMoreData = 5,

		/// <summary>
		/// The canceled.
		/// </summary>
		Canceled = 6,

		/// <summary>
		/// The no show.
		/// </summary>
		NoShow = 7
	}

	/// <summary>
	/// The contact type.
	/// </summary>
	public enum ContactType
	{
		/// <summary>
		/// The not set.
		/// </summary>
		NotSet = 0,

		/// <summary>
		/// The subject.
		/// </summary>
		Subject = 1,

		/// <summary>
		/// The app user.
		/// </summary>
		AppUser = 2,

		/// <summary>
		/// The other.
		/// </summary>
		Other = 3
	}

	/// <summary>
	/// The phone type.
	/// </summary>
	public enum PhoneType
	{
		/// <summary>
		/// The not set.
		/// </summary>
		NotSet = 0,

		/// <summary>
		/// The office.
		/// </summary>
		Office = 1,

		/// <summary>
		/// The home.
		/// </summary>
		Home = 2,

		/// <summary>
		/// The cell.
		/// </summary>
		Cell = 3
	}

	/// <summary>
	/// The gender type.
	/// </summary>
	public enum GenderType
	{
		/// <summary>
		/// The not set.
		/// </summary>
		NotSet = 0,

		/// <summary>
		/// The male.
		/// </summary>
		Male = 1,

		/// <summary>
		/// The female.
		/// </summary>
		Female = 2
	}
}