// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudyRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The study repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Study
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;

	using Tateeda.Clires.Core.Data.EF;
	using Tateeda.Clires.Core.Data.Enums;

	/// <summary>
	///   The study repository.
	/// </summary>
	public class StudyRepository : IStudyRepository
	{
		#region Fields

		/// <summary>
		/// The _context.
		/// </summary>
		private readonly IDbContext _context;

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="StudyRepository"/> class.
		/// </summary>
		/// <param name="context">
		/// The context.
		/// </param>
		public StudyRepository(IDbContext context)
		{
			_context = context;
			All = _context.Studies.AsQueryable();
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the all.
		/// </summary>
		public IQueryable<Study> All { get; private set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// The add step visits.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		public void AddStepVisits(IVisitStepVisitSequence entity)
		{
			_context.VisitStepVisitSequences.Add((VisitStepVisitSequence)entity);
		}

		/// <summary>
		/// The commit.
		/// </summary>
		public void Commit()
		{
			_context.Commit();
		}

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
		public void CreateArmStep(int armId, string stepName, string description)
		{
			var step = new VisitStep
				{
					ArmId = armId,
					Directions = description,
					Name = stepName,
					CreatedOn = DateTime.UtcNow,
					CreatedBy = Thread.CurrentPrincipal.Identity.Name,
					IsActive = true,
					Status = (int)EntityStatusType.Current
				};
			_context.VisitSteps.Add(step);
		}

		/// <summary>
		/// The create site.
		/// </summary>
		/// <param name="site">
		/// The site.
		/// </param>
		public void CreateSite(Site site, int studyId)
		{
			var study = _context.Studies.FirstOrDefault(s => s.Id == studyId);
			if (study != null)
			{
				study.Sites.Add(site);
			}

			site.UpdatedBy = site.UpdatedBy ?? Thread.CurrentPrincipal.Identity.Name;
			site.UpdatedOn = DateTime.UtcNow;
			site.CreatedBy = site.CreatedBy ?? Thread.CurrentPrincipal.Identity.Name;
			site.CreatedOn = DateTime.UtcNow;
			_context.Sites.Add(site);
		}

		/// <summary>
		/// The delete.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		public void Delete(Study entity)
		{
			var item = _context.Studies.FirstOrDefault(a => a.Id == entity.Id);
			if (item == null)
			{
				return;
			}

			item.IsActive = false;
			item.Status = (int)EntityStatusType.Deleted;
			item.UpdatedBy = entity.UpdatedBy ?? Thread.CurrentPrincipal.Identity.Name;
			item.UpdatedOn = DateTime.UtcNow;
		}

		/// <summary>
		/// The delete step visits.
		/// </summary>
		/// <param name="stepVisitSequence">
		/// The step visit sequence.
		/// </param>
		public void DeleteStepVisits(VisitStepVisitSequence stepVisitSequence)
		{
			var entity =
				_context.VisitStepVisitSequences.FirstOrDefault(
					s => s.VisitStepId == stepVisitSequence.VisitStepId && s.VisitId == stepVisitSequence.VisitId && s.IsActive);
			if (entity != null)
			{
				_context.VisitStepVisitSequences.Remove(entity);
			}
		}

		/// <summary>
		/// The get all studies.
		/// </summary>
		/// <param name="showAll">
		/// The show all.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		public IEnumerable<IStudy> GetAllStudies(bool showAll)
		{
			return showAll ? _context.Studies.AsEnumerable() : _context.Studies.Where(s => s.IsActive).AsEnumerable();
		}

		/// <summary>
		/// The get arm.
		/// </summary>
		/// <param name="id">
		/// The id.
		/// </param>
		/// <returns>
		/// The <see cref="IArm"/>.
		/// </returns>
		public IArm GetArm(int id)
		{
			return _context.Arms.FirstOrDefault(a => a.Id == id);
		}

		/// <summary>
		/// The get arm steps.
		/// </summary>
		/// <param name="armId">
		/// The arm id.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		public IEnumerable<IVisitStep> GetArmSteps(int armId)
		{
			_context.AutoDetectChangesEnabled = false;
			var steps = _context.VisitSteps.Where(s => s.ArmId == armId && s.IsActive).AsEnumerable();
			_context.AutoDetectChangesEnabled = true;
			return steps;
		}

		/// <summary>
		/// The get by id.
		/// </summary>
		/// <param name="id">
		/// The id.
		/// </param>
		/// <returns>
		/// The <see cref="Study"/>.
		/// </returns>
		public Study GetById(object id)
		{
			return _context.Studies.FirstOrDefault(s => s.Id == (int)id && s.IsActive);
		}

		/// <summary>
		/// The get step visits.
		/// </summary>
		/// <param name="stepId">
		/// The step id.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		public IEnumerable<IVisitStepVisitSequence> GetStepVisits(int stepId)
		{
			_context.AutoDetectChangesEnabled = false;
			var visits = _context.VisitStepVisitSequences.Where(s => s.VisitStepId == stepId && s.IsActive).AsEnumerable();
			_context.AutoDetectChangesEnabled = true;
			return visits;
		}

		/// <summary>
		/// The get study arms.
		/// </summary>
		/// <param name="studyId">
		/// The study id.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		public IEnumerable<IArm> GetStudyArms(int studyId)
		{
			return _context.Arms.Where(a => a.StudyId == studyId && a.IsActive).AsEnumerable();
		}

		/// <summary>
		/// The insert.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		public void Insert(Study entity)
		{
			entity.CreatedBy = Thread.CurrentPrincipal.Identity.Name;
			entity.CreatedOn = DateTime.UtcNow;
			_context.Studies.Add(entity);
		}

		/// <summary>
		/// The update.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		/// <exception cref="Exception">
		/// </exception>
		public void Update(Study entity)
		{
			var study = _context.Studies.FirstOrDefault(s => s.Id == entity.Id);
			if (study == null)
			{
				throw new Exception(string.Format("Record Id:{0} Not found", entity.Id));
			}

			study.Budget = entity.Budget;
			study.Description = entity.Description;
			study.EndDate = entity.EndDate;
			study.Goal = entity.Goal;
			study.IsActive = entity.IsActive;
			study.Name = entity.Name;
			study.SortOrder = entity.SortOrder;
			study.StartDate = entity.StartDate;
			study.Status = entity.Status;
			study.Target = entity.Target;
			study.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
			study.UpdatedOn = DateTime.UtcNow;
		}

		/// <summary>
		/// The update site.
		/// </summary>
		/// <param name="site">
		/// The site.
		/// </param>
		/// <param name="studyId"> </param>
		public void UpdateSite(Site site, int studyId)
		{
			var entity = _context.Sites.FirstOrDefault(s => s.Id == site.Id);
			if (entity != null)
			{
				entity.IsActive = site.IsActive;
				entity.IsPrimary = site.IsPrimary;
				entity.Name = site.Name;
				entity.Directions = site.Directions;
				entity.Code = site.Code;
				entity.TimeZoneId = site.TimeZoneId;
				entity.UpdatedBy = site.UpdatedBy ?? Thread.CurrentPrincipal.Identity.Name;
				entity.UpdatedOn = DateTime.UtcNow;
			}
		}

		/// <summary>
		/// The update step visits.
		/// </summary>
		/// <param name="stepVisitSequence">
		/// The step visit sequence.
		/// </param>
		public void UpdateStepVisits(VisitStepVisitSequence stepVisitSequence)
		{
			var entity =
				_context.VisitStepVisitSequences.FirstOrDefault(
					s => s.VisitStepId == stepVisitSequence.VisitStepId && s.VisitId == stepVisitSequence.VisitId && s.IsActive);
			if (entity != null)
			{
				entity.DaysFromBase = stepVisitSequence.DaysFromBase;
				entity.Deviation = stepVisitSequence.Deviation;
				entity.SortOrder = stepVisitSequence.SortOrder;
				entity.IsTermination = stepVisitSequence.IsTermination;
			}
		}

		public void CreateOrUpdateArm(Arm arm)
		{
			var entity = _context.Arms.FirstOrDefault(a => a.Id == arm.Id);
			if (entity == null)
			{
				arm.CreatedBy = Thread.CurrentPrincipal.Identity.Name;
				arm.CreatedOn = DateTime.UtcNow;
				_context.Arms.Add(arm);
			}
			else
			{
				entity.Name = arm.Name;
				entity.Code = arm.Code;
				entity.Description = arm.Description;
				entity.IsActive = arm.IsActive;
				entity.StudyId = arm.StudyId;
				entity.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
				entity.UpdatedOn = DateTime.UtcNow;
			}
		}

		public int GetDefaultStudy()
		{
			var defaultStudy = _context.Settings.FirstOrDefault(s => s.Name == "CurrentStudyId");
			return defaultStudy != null ? int.Parse(defaultStudy.Value) : 0;
		}

		#endregion
	}
}