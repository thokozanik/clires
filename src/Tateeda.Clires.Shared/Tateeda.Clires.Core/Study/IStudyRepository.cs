// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStudyRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The StudyRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Study
{
	using System.Collections.Generic;

	using Tateeda.Clires.Core.Data;
	using Tateeda.Clires.Core.Data.EF;

	/// <summary>
	/// The StudyRepository interface.
	/// </summary>
	public interface IStudyRepository : IRepository<Study>
	{
		#region Public Methods and Operators

		/// <summary>
		/// The add step visits.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		void AddStepVisits(IVisitStepVisitSequence entity);

		/// <summary>
		/// The create arm step.
		/// </summary>
		/// <param name="armId">
		/// The arm id.
		/// </param>
		/// <param name="stepName">
		/// The step name.
		/// </param>
		/// <param name="description">
		/// The description.
		/// </param>
		void CreateArmStep(int armId, string stepName, string description);

		/// <summary>
		/// The create site.
		/// </summary>
		/// <param name="site">
		/// The site.
		/// </param>
		void CreateSite(Site site, int studyId);

		/// <summary>
		/// The delete step visits.
		/// </summary>
		/// <param name="stepVisitSequence">
		/// The step visit sequence.
		/// </param>
		void DeleteStepVisits(VisitStepVisitSequence stepVisitSequence);

		/// <summary>
		/// The get all studies.
		/// </summary>
		/// <param name="showAll">
		/// The show all. 
		/// </param>
		/// <returns>
		/// The Study list 
		/// </returns>
		IEnumerable<IStudy> GetAllStudies(bool showAll);

		/// <summary>
		/// The get arm.
		/// </summary>
		/// <param name="id">
		/// The id.
		/// </param>
		/// <returns>
		/// The <see cref="IArm"/>.
		/// </returns>
		IArm GetArm(int id);

		/// <summary>
		/// The get arm steps.
		/// </summary>
		/// <param name="armId">
		/// The arm id.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		IEnumerable<IVisitStep> GetArmSteps(int armId);

		/// <summary>
		/// The get step visits.
		/// </summary>
		/// <param name="stepId">
		/// The step id.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		IEnumerable<IVisitStepVisitSequence> GetStepVisits(int stepId);

		/// <summary>
		/// The get study arms.
		/// </summary>
		/// <param name="studyId">
		/// The study id.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		IEnumerable<IArm> GetStudyArms(int studyId);

		/// <summary>
		/// The update site.
		/// </summary>
		/// <param name="site">
		/// The site.
		/// </param>
		void UpdateSite(Site site, int studyId);

		/// <summary>
		/// The update step visits.
		/// </summary>
		/// <param name="stepVisitSequence">
		/// The step visit sequence.
		/// </param>
		void UpdateStepVisits(VisitStepVisitSequence stepVisitSequence);

		#endregion

		void CreateOrUpdateArm(Arm arm);

		int GetDefaultStudy();
	}
}