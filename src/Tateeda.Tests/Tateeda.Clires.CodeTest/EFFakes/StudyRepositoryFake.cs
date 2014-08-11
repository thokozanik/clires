using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tateeda.Clires.Core.Data.EF;
using Tateeda.Clires.Core.Study;

namespace Tateeda.Clires.CodeTest.EFFakes
{
	internal class StudyRepositoryFake : IStudyRepository
	{
		#region Implementation of IRepository<Study>

		public IQueryable<Study> All { get; private set; }
		public Study GetById(object id)
		{
			throw new NotImplementedException();
		}

		public void Insert(Study entity)
		{
			throw new NotImplementedException();
		}

		public void Update(Study entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(Study entity)
		{
			throw new NotImplementedException();
		}

		public void Commit()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IStudyRepository

		public IEnumerable<IStudy> GetAllStudies(bool showAll)
		{
			throw new NotImplementedException();
		}

		public void CreateSite(Site site)
		{
			throw new NotImplementedException();
		}

		public void UpdateSite(Site site)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IArm> GetStudyArms(int studyId)
		{
			throw new NotImplementedException();
		}

		public void UpdateSite(Site site, int studyId)
		{
			throw new NotImplementedException();
		}

		public IArm GetArm(int id)
		{
			throw new NotImplementedException();
		}

		public void CreateArmStep(int armId, string stepName, string description)
		{
			throw new NotImplementedException();
		}

		public void CreateSite(Site site, int studyId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IVisitStep> GetArmSteps(int armId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IVisitStepVisitSequence> GetStepVisits(int stepId)
		{
			throw new NotImplementedException();
		}

		public void AddStepVisits(IVisitStepVisitSequence entity)
		{
			throw new NotImplementedException();
		}

		public void DeleteStepVisits(VisitStepVisitSequence stepVisitSequence)
		{
			throw new NotImplementedException();
		}

		public void UpdateStepVisits(VisitStepVisitSequence stepVisitSequence)
		{
			throw new NotImplementedException();
		}

		public void CreateOrUpdateArm(Arm arm)
		{
			throw new NotImplementedException();
		}

		public int GetDefaultStudy()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IDisposable

		public void Dispose()
		{

		}

		#endregion
	}
}
