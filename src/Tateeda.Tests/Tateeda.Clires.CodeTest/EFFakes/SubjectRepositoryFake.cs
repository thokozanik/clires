using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tateeda.Clires.Core.Data.EF;
using Tateeda.Clires.Core.Subjects;

namespace Tateeda.Clires.CodeTest.EFFakes
{
	internal class SubjectRepositoryFake : ISubjectRepository
	{
		#region Implementation of IRepository<Subject>

		public IQueryable<Subject> All { get; private set; }
		public Subject GetById(object id)
		{
			throw new NotImplementedException();
		}

		public void Insert(Subject entity)
		{
			throw new NotImplementedException();
		}

		public void Update(Subject entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(Subject entity)
		{
			throw new NotImplementedException();
		}

		public void Commit()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ISubject> GetAllSiteSubjects(int studyId, int siteId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IAppointment> GetAllSubjectAppointements(int subjectId)
		{
			throw new NotImplementedException();
		}

		public Contact GetSubjectContact(int subjectId)
		{
			throw new NotImplementedException();
		}

		public void UpdateSubjectContactInfo(Contact contact)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ISubject> FindSubjects(string what, AppUser curUser)
		{
			throw new NotImplementedException();
		}

		public void AddSubjectDrug(ISubjectDrug drug)
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
