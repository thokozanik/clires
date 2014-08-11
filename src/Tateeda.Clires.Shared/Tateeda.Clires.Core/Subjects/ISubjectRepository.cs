// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISubjectRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The SubjectRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Subjects
{
	using System.Collections.Generic;

	using Tateeda.Clires.Core.Data;
	using Tateeda.Clires.Core.Data.EF;

	/// <summary>
	/// The SubjectRepository interface.
	/// </summary>
	public interface ISubjectRepository : IRepository<Subject>
	{
		#region Public Methods and Operators

		/// <summary>
		/// The add subject drug.
		/// </summary>
		/// <param name="drug">
		/// The drug.
		/// </param>
		void AddSubjectDrug(ISubjectDrug drug);

		/// <summary>
		/// The find subjects.
		/// </summary>
		/// <param name="what">
		/// The what.
		/// </param>
		/// <param name="curUser">
		/// The cur user.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		IEnumerable<ISubject> FindSubjects(string what, AppUser curUser);

		/// <summary>
		/// The get all site subjects.
		/// </summary>
		/// <param name="studyId">
		/// The study id.
		/// </param>
		/// <param name="siteId">
		/// The site id.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		IEnumerable<ISubject> GetAllSiteSubjects(int studyId, int siteId);

		IEnumerable<IAppointment> GetAllSubjectAppointements(int subjectId);

		#endregion

		Contact GetSubjectContact(int subjectId);

		void UpdateSubjectContactInfo(Contact contact);
	}
}