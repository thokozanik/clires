// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SubjectRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The subject repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Tateeda.Clires.Core.Subjects
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;

	using Tateeda.Clires.Core.Data.EF;
	using Tateeda.Clires.Core.Data.Enums;
	using Tateeda.Clires.Core.Extensions;

	/// <summary>
	///   The subject repository.
	/// </summary>
	public class SubjectRepository : ISubjectRepository
	{
		#region Fields

		/// <summary>
		///   The _context.
		/// </summary>
		private readonly IDbContext _context;

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="SubjectRepository"/> class.
		/// </summary>
		/// <param name="context">
		/// The context. 
		/// </param>
		public SubjectRepository(IDbContext context)
		{
			_context = context;
			All = _context.Subjects;
		}

		#endregion

		#region Public Properties

		/// <summary>
		///   Gets the table.
		/// </summary>
		public IQueryable<Subject> All { get; private set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// The add subject drug.
		/// </summary>
		/// <param name="drug">
		/// The drug.
		/// </param>
		public void AddSubjectDrug(ISubjectDrug drug)
		{
			_context.SubjectDrugs.Add(drug as SubjectDrug);
		}

		/// <summary>
		///   The commit.
		/// </summary>
		public void Commit()
		{
			_context.Commit();
		}

		/// <summary>
		/// The delete.
		/// </summary>
		/// <param name="entity">
		/// The entity. 
		/// </param>
		public void Delete(Subject entity)
		{
			var item = _context.Subjects.FirstOrDefault(a => a.Id == entity.Id);
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
		public IEnumerable<ISubject> FindSubjects(string what, AppUser curUser)
		{
			var elements = what.Split(new[] { " ", ",", "-", "\t" }, StringSplitOptions.RemoveEmptyEntries);
			var fn = string.Empty;
			var ln = string.Empty;
			var id = 0;
			var siteId = curUser != null ? curUser.SiteId : 0;

			var list = new List<ISubject>();
			if (elements.Count() == 2)
			{
				fn = elements[0];
				ln = elements[1];
			}

			if (elements.Count() == 1)
			{
				if (!int.TryParse(elements[0], out id))
				{
					ln = elements[0];
				}
			}

			_context.AutoDetectChangesEnabled = false;
			var subjects = _context.uspSubjectFindByFirstLastName(siteId, 0, fn, ln).ToSubjects();
			list.AddRange(subjects);
			if (id > 0)
			{
				var subjectsId = _context.uspGetSubjectById(id).ToSubjects();
				list.AddRange(subjectsId);
			}

			_context.AutoDetectChangesEnabled = true;
			return list;
		}

		/// <summary>
		/// The all site subjects.
		/// </summary>
		/// <param name="studyId">
		/// The study id. 
		/// </param>
		/// <param name="siteId">
		/// The site id. 
		/// </param>
		/// <returns>
		/// The System.Collections.Generic.IEnumerable`1[T - &gt; Tateeda.Clires.Core.Data.EF.ISubject]. 
		/// </returns>
		public IEnumerable<ISubject> GetAllSiteSubjects(int studyId, int siteId)
		{
			_context.AutoDetectChangesEnabled = false;
			var subjects = _context.uspGetSubjectBySiteId(siteId, studyId).Select(s => s.ToEntity()).AsEnumerable();
			_context.AutoDetectChangesEnabled = true;
			return subjects;
		}

		public IEnumerable<IAppointment> GetAllSubjectAppointements(int subjectId)
		{
			_context.AutoDetectChangesEnabled = false;
			var appointments = _context.Appointments.Where(a => a.SubjectId == subjectId);
			_context.AutoDetectChangesEnabled = true;
			return appointments.ToList();
		}

		public Contact GetSubjectContact(int subjectId)
		{
			var subject = _context.Subjects.FirstOrDefault(s => s.Id == subjectId);
			return subject.Contact;
		}

		public void UpdateSubjectContactInfo(Contact contact)
		{
			var ctx = _context.Contacts.FirstOrDefault(c => c.Id == contact.Id);
			if (ctx != null)
			{
				ctx.Emails = contact.Emails;
				ctx.Phones = contact.Phones;
				ctx.Addresses = contact.Addresses;
				ctx.FirstName = contact.FirstName;
				ctx.LastName = contact.LastName;
				ctx.UpdatedBy = contact.UpdatedBy;
				ctx.UpdatedOn = DateTime.UtcNow;
				ctx.MiddleName = contact.MiddleName;
				ctx.Status = contact.Status;
				ctx.IsActive = contact.IsActive;
				ctx.SortOrder = contact.SortOrder;
			}
		}


		/// <summary>
		/// The get by id.
		/// </summary>
		/// <param name="id">
		/// The id. 
		/// </param>
		/// <returns>
		/// The Tateeda.Clires.Core.Data.EF.Subject. 
		/// </returns>
		public Subject GetById(object id)
		{
			var subj = _context.Subjects.FirstOrDefault(sub => sub.Id == (int)id);
			var s = _context.uspGetSubjectById(subj.Id).FirstOrDefault();
			subj.Contact.FirstName = s.FirstName;
			subj.Contact.LastName = s.LastName;
			subj.SSN = s.SSN;
			subj.DateOfBirth = s.DateOfBirth;
			subj.YearBorn = s.YearBorn;

			return subj;
		}

		/// <summary>
		/// The insert.
		/// </summary>
		/// <param name="entity">
		/// The entity. 
		/// </param>
		public void Insert(Subject entity)
		{
			var address = entity.Contact.Addresses.FirstOrDefault() ?? new Address();
			var phone = entity.Contact.Phones.FirstOrDefault() ?? new Phone();
			var email = entity.Contact.Emails.FirstOrDefault() ?? new Email();

			_context.uspSubjectInsert(
				entity.SiteId,
				entity.StudyId,
				entity.Nickname,
				entity.FamilyId,
				entity.Notes,
				entity.NIMHID,
				entity.GenderTypeId,
				entity.YearBorn,
				entity.Status,
				entity.SortOrder,
				entity.SSN,
				entity.Contact.FirstName,
				entity.Contact.LastName,
				entity.DateOfBirth,
				(int)ContactType.Subject,
				address.Street,
				address.City,
				address.PostalCode,
				address.StateId,
				address.CountryId,
				phone.CountryCode,
				address.AddressTypeId,
				phone.AreaCode,
				phone.Number,
				phone.Telephone,
				phone.PhoneTypeId,
				email.Address,
				entity.CreatedBy ?? Thread.CurrentPrincipal.Identity.Name);
		}

		/// <summary>
		/// The update.
		/// </summary>
		/// <param name="entity">
		/// The entity. 
		/// </param>
		public void Update(Subject entity)
		{
			_context.uspSubjectUpdate(
				entity.Id,
				entity.SiteId,
				entity.Nickname,
				entity.FamilyId,
				entity.Notes,
				entity.NIMHID,
				entity.GenderTypeId,
				entity.YearBorn,
				entity.Status,
				entity.SortOrder,
				entity.SSN,
				entity.Contact.FirstName,
				entity.Contact.LastName,
				entity.DateOfBirth);
		}

		#endregion
	}
}