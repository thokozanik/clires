// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbContext.cs" company="">
//   
// </copyright>
// <summary>
//   The DbContext interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Validation;
	using System.Data.Objects;
	using System.Diagnostics;

	/// <summary>
	/// The DbContext interface.
	/// </summary>
	public interface IDbContext
	{
		#region Public Properties

		/// <summary>
		/// Gets or sets the addresses.
		/// </summary>
		IDbSet<Address> Addresses { get; set; }

		/// <summary>
		/// Gets or sets the answer child questions.
		/// </summary>
		IDbSet<AnswerChildQuestion> AnswerChildQuestions { get; set; }

		/// <summary>
		/// Gets or sets the answers.
		/// </summary>
		IDbSet<Answer> Answers { get; set; }

		/// <summary>
		/// Gets or sets the app users.
		/// </summary>
		IDbSet<AppUser> AppUsers { get; set; }

		/// <summary>
		/// Gets or sets the appointment forms.
		/// </summary>
		IDbSet<AppointmentForm> AppointmentForms { get; set; }

		/// <summary>
		/// Gets or sets the appointments.
		/// </summary>
		IDbSet<Appointment> Appointments { get; set; }

		/// <summary>
		/// Gets or sets the arms.
		/// </summary>
		IDbSet<Arm> Arms { get; set; }

		/// <summary>
		///   Gets or sets a value indicating whether auto detect changes enabled.
		/// </summary>
		bool AutoDetectChangesEnabled { get; set; }

		/// <summary>
		/// Gets or sets the ct gov submissions.
		/// </summary>
		IDbSet<CTGovSubmission> CTGovSubmissions { get; set; }

		/// <summary>
		/// Gets or sets the codes.
		/// </summary>
		IDbSet<Code> Codes { get; set; }

		/// <summary>
		/// Gets or sets the contacts.
		/// </summary>
		IDbSet<Contact> Contacts { get; set; }

		/// <summary>
		/// Gets or sets the countries.
		/// </summary>
		IDbSet<Country> Countries { get; set; }

		/// <summary>
		/// Gets or sets the css types.
		/// </summary>
		IDbSet<CssType> CssTypes { get; set; }

		/// <summary>
		/// Gets or sets the drug categories.
		/// </summary>
		IDbSet<DrugCategory> DrugCategories { get; set; }

		/// <summary>
		/// Gets or sets the drug classes.
		/// </summary>
		IDbSet<DrugClass> DrugClasses { get; set; }

		/// <summary>
		/// Gets or sets the drugs.
		/// </summary>
		IDbSet<Drug> Drugs { get; set; }

		/// <summary>
		/// Gets or sets the emails.
		/// </summary>
		IDbSet<Email> Emails { get; set; }

		/// <summary>
		/// Gets or sets the feedbacks.
		/// </summary>
		IDbSet<Feedback> Feedbacks { get; set; }

		/// <summary>
		/// Gets or sets the files.
		/// </summary>
		IDbSet<File> Files { get; set; }

		/// <summary>
		/// Gets or sets the form answers.
		/// </summary>
		IDbSet<FormAnswer> FormAnswers { get; set; }

		/// <summary>
		/// Gets or sets the form in processes.
		/// </summary>
		IDbSet<FormInProcess> FormInProcesses { get; set; }

		/// <summary>
		/// Gets or sets the form verifications.
		/// </summary>
		IDbSet<FormVerification> FormVerifications { get; set; }

		/// <summary>
		/// Gets or sets the form visibility by visit for subjects.
		/// </summary>
		IDbSet<FormVisibilityByVisitForSubject> FormVisibilityByVisitForSubjects { get; set; }

		/// <summary>
		/// Gets or sets the forms.
		/// </summary>
		IDbSet<Form> Forms { get; set; }

		/// <summary>
		/// Gets or sets the languages.
		/// </summary>
		IDbSet<Language> Languages { get; set; }

		/// <summary>
		/// Gets or sets the library answers.
		/// </summary>
		IDbSet<LibraryAnswer> LibraryAnswers { get; set; }

		/// <summary>
		/// Gets or sets the library forms.
		/// </summary>
		IDbSet<LibraryForm> LibraryForms { get; set; }

		/// <summary>
		/// Gets or sets the library questions.
		/// </summary>
		IDbSet<LibraryQuestion> LibraryQuestions { get; set; }

		/// <summary>
		/// Gets or sets the locale string resources.
		/// </summary>
		IDbSet<LocaleStringResource> LocaleStringResources { get; set; }

		/// <summary>
		/// Gets or sets the memberships.
		/// </summary>
		IDbSet<Membership> Memberships { get; set; }

		/// <summary>
		/// Gets or sets the message providers.
		/// </summary>
		IDbSet<MessageProvider> MessageProviders { get; set; }

		/// <summary>
		/// Gets or sets the message queues.
		/// </summary>
		IDbSet<MessageQueue> MessageQueues { get; set; }

		/// <summary>
		/// Gets or sets the message templates.
		/// </summary>
		IDbSet<MessageTemplate> MessageTemplates { get; set; }

		IDbSet<Organization> Organizations { get; set; }

		/// <summary>
		/// Gets or sets the phones.
		/// </summary>
		IDbSet<Phone> Phones { get; set; }

		/// <summary>
		/// Gets or sets the profiles.
		/// </summary>
		IDbSet<Profile> Profiles { get; set; }

		/// <summary>
		/// Gets or sets the questions.
		/// </summary>
		IDbSet<Question> Questions { get; set; }

		/// <summary>
		/// Gets or sets the recreational drug or substances.
		/// </summary>
		IDbSet<RecreationalDrugOrSubstance> RecreationalDrugOrSubstances { get; set; }

		/// <summary>
		/// Gets or sets the roles.
		/// </summary>
		IDbSet<Role> Roles { get; set; }

		/// <summary>
		/// Gets or sets the schedule subject visits.
		/// </summary>
		IDbSet<ScheduleSubjectVisit> ScheduleSubjectVisits { get; set; }

		/// <summary>
		/// Gets or sets the settings.
		/// </summary>
		IDbSet<Setting> Settings { get; set; }

		/// <summary>
		/// Gets or sets the sites.
		/// </summary>
		IDbSet<Site> Sites { get; set; }

		/// <summary>
		/// Gets or sets the states.
		/// </summary>
		IDbSet<State> States { get; set; }

		/// <summary>
		/// Gets or sets the studies.
		/// </summary>
		IDbSet<Study> Studies { get; set; }

		/// <summary>
		/// Gets or sets the subject alt numbers.
		/// </summary>
		IDbSet<SubjectAltNumber> SubjectAltNumbers { get; set; }

		/// <summary>
		/// Gets or sets the subject drug histories.
		/// </summary>
		IDbSet<SubjectDrugHistory> SubjectDrugHistories { get; set; }

		/// <summary>
		/// Gets or sets the subject drugs.
		/// </summary>
		IDbSet<SubjectDrug> SubjectDrugs { get; set; }

		/// <summary>
		/// Gets or sets the subjects.
		/// </summary>
		IDbSet<Subject> Subjects { get; set; }

		/// <summary>
		/// Gets or sets the time zones.
		/// </summary>
		IDbSet<TimeZone> TimeZones { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether track changes.
		/// </summary>
		bool TrackChanges { get; set; }

		/// <summary>
		/// Gets or sets the users.
		/// </summary>
		IDbSet<User> Users { get; set; }

		/// <summary>
		/// Gets or sets the visit forms.
		/// </summary>
		IDbSet<VisitForm> VisitForms { get; set; }

		/// <summary>
		/// Gets or sets the visit step visit sequences.
		/// </summary>
		IDbSet<VisitStepVisitSequence> VisitStepVisitSequences { get; set; }

		/// <summary>
		/// Gets or sets the visit steps.
		/// </summary>
		IDbSet<VisitStep> VisitSteps { get; set; }

		/// <summary>
		/// Gets or sets the visits.
		/// </summary>
		IDbSet<Visit> Visits { get; set; }

		/// <summary>
		/// Log errors
		/// </summary>
		IDbSet<ErrorLog> ErrorLogs { get; set; }

		IDbSet<StudySetupMap> StudySetupMaps { get; set; }

		IDbSet<StudySetupStep> StudySetupSteps { get; set; }

		IDbSet<FormQuestionAnswerImport> FormQuestionAnswerImports { get; set; }

		IDbSet<UserSetting> UserSettings { get; set; }
		#endregion

		#region Public Methods and Operators

		/// <summary>
		///   The commit.
		/// </summary>
		/// <returns> The System.Int32. </returns>
		int Commit();

		/// <summary>
		/// The dispose.
		/// </summary>
		void Dispose();

		/// <summary>
		///   The set entity.
		/// </summary>
		/// <typeparam name="TEntity"> </typeparam>
		/// <returns> The System.Data.Entity.IDbSet`1[TEntity - &gt; TEntity]. </returns>
		IDbSet<TEntity> SetEntity<TEntity>() where TEntity : BaseEntity;

		/// <summary>
		/// The usp get subject by id.
		/// </summary>
		/// <param name="subjectId">
		/// The subject id.
		/// </param>
		/// <returns>
		/// The <see cref="ObjectResult"/>.
		/// </returns>
		ObjectResult<uspGetSubjectById_Result> uspGetSubjectById(int? subjectId);

		/// <summary>
		/// The usp get subject by site id.
		/// </summary>
		/// <param name="siteId">
		/// The site id.
		/// </param>
		/// <param name="studyId">
		/// The study id.
		/// </param>
		/// <returns>
		/// The <see cref="ObjectResult"/>.
		/// </returns>
		ObjectResult<uspGetSubjectBySiteId_Result> uspGetSubjectBySiteId(int? siteId, int? studyId);

		/// <summary>
		/// The usp subject find by first last name.
		/// </summary>
		/// <param name="siteId">
		/// The site id.
		/// </param>
		/// <param name="studyId">
		/// The study id.
		/// </param>
		/// <param name="firstName">
		/// The first name.
		/// </param>
		/// <param name="lastName">
		/// The last name.
		/// </param>
		/// <returns>
		/// The <see cref="ObjectResult"/>.
		/// </returns>
		ObjectResult<uspSubjectFindByFirstLastName_Result> uspSubjectFindByFirstLastName(int? siteId, int? studyId, string firstName, string lastName);

		/// <summary>
		/// The usp subject insert.
		/// </summary>
		/// <param name="siteId">
		/// The site id.
		/// </param>
		/// <param name="studyId">
		/// The study id.
		/// </param>
		/// <param name="nickname">
		/// The nickname.
		/// </param>
		/// <param name="familyId">
		/// The family id.
		/// </param>
		/// <param name="notes">
		/// The notes.
		/// </param>
		/// <param name="nIMHID">
		/// The n imhid.
		/// </param>
		/// <param name="gender">
		/// The gender.
		/// </param>
		/// <param name="yearBorn">
		/// The year born.
		/// </param>
		/// <param name="status">
		/// The status.
		/// </param>
		/// <param name="sortOrder">
		/// The sort order.
		/// </param>
		/// <param name="sSN">
		/// The s sn.
		/// </param>
		/// <param name="firstName">
		/// The first name.
		/// </param>
		/// <param name="lastName">
		/// The last name.
		/// </param>
		/// <param name="dateOfBirth">
		/// The date of birth.
		/// </param>
		/// <param name="contactTypeId">
		/// The contact type id.
		/// </param>
		/// <param name="street">
		/// The street.
		/// </param>
		/// <param name="city">
		/// The city.
		/// </param>
		/// <param name="zip">
		/// The zip.
		/// </param>
		/// <param name="stateId">
		/// The state id.
		/// </param>
		/// <param name="countryId">
		/// The country id.
		/// </param>
		/// <param name="countryCode">
		/// The country code.
		/// </param>
		/// <param name="addressTypeId">
		/// The address type id.
		/// </param>
		/// <param name="areaCode">
		/// The area code.
		/// </param>
		/// <param name="phoneNumber">
		/// The phone number.
		/// </param>
		/// <param name="telephone">
		/// The telephone.
		/// </param>
		/// <param name="phoneTypeId">
		/// The phone type id.
		/// </param>
		/// <param name="emailAddress">
		/// The email address.
		/// </param>
		/// <param name="createdBy">
		/// The created by.
		/// </param>
		/// <returns>
		/// The <see cref="ObjectResult"/>.
		/// </returns>
		ObjectResult<decimal?> uspSubjectInsert(
			int? siteId,
			int? studyId,
			string nickname,
			string familyId,
			string notes,
			string nIMHID,
			int? gender,
			int? yearBorn,
			int? status,
			int? sortOrder,
			string sSN,
			string firstName,
			string lastName,
			string dateOfBirth,
			int? contactTypeId,
			string street,
			string city,
			string zip,
			int? stateId,
			int? countryId,
			string countryCode,
			int? addressTypeId,
			int? areaCode,
			int? phoneNumber,
			string telephone,
			int? phoneTypeId,
			string emailAddress,
			string createdBy);

		/// <summary>
		/// The usp subject update.
		/// </summary>
		/// <param name="subjectId">
		/// The subject id.
		/// </param>
		/// <param name="siteId">
		/// The site id.
		/// </param>
		/// <param name="nickname">
		/// The nickname.
		/// </param>
		/// <param name="familyId">
		/// The family id.
		/// </param>
		/// <param name="notes">
		/// The notes.
		/// </param>
		/// <param name="nIMHID">
		/// The n imhid.
		/// </param>
		/// <param name="gender">
		/// The gender.
		/// </param>
		/// <param name="yearBorn">
		/// The year born.
		/// </param>
		/// <param name="status">
		/// The status.
		/// </param>
		/// <param name="sortOrder">
		/// The sort order.
		/// </param>
		/// <param name="sSN">
		/// The s sn.
		/// </param>
		/// <param name="firstName">
		/// The first name.
		/// </param>
		/// <param name="lastName">
		/// The last name.
		/// </param>
		/// <param name="dateOfBirth">
		/// The date of birth.
		/// </param>
		/// <returns>
		/// The <see cref="ObjectResult"/>.
		/// </returns>
		ObjectResult<int?> uspSubjectUpdate(
			int? subjectId,
			int? siteId,
			string nickname,
			string familyId,
			string notes,
			string nIMHID,
			int? gender,
			int? yearBorn,
			int? status,
			int? sortOrder,
			string sSN,
			string firstName,
			string lastName,
			string dateOfBirth);

		#endregion
	}

	/// <summary>
	/// The entities.
	/// </summary>
	public partial class Entities : IDbContext
	{
		#region Fields

		/// <summary>
		/// The _track changes.
		/// </summary>
		private bool _trackChanges;

		#endregion

		#region Public Properties

		/// <summary>
		///   Gets or sets a value indicating whether auto detect changes enabled.
		/// </summary>
		public bool AutoDetectChangesEnabled
		{
			get
			{
				return Configuration.AutoDetectChangesEnabled;
			}

			set
			{
				Configuration.AutoDetectChangesEnabled = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether track changes.
		/// </summary>
		public bool TrackChanges
		{
			get
			{
				return _trackChanges;
			}

			set
			{
				_trackChanges = value;
				Configuration.AutoDetectChangesEnabled = value;
			}
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>
		///   The commit.
		/// </summary>
		/// <returns> The System.Int32. </returns>
		public int Commit()
		{
			try
			{
				return SaveChanges();
			}
			catch (DbEntityValidationException ex)
			{
				Debug.WriteLine(ex.Message);
				try
				{
					this.ErrorLogs.Add(new ErrorLog { Message = ex.Message, StackTrace = ex.StackTrace });
					this.SaveChanges();
				}
				catch (Exception e)
				{
					Debug.WriteLine(e.Message);
				}
				throw;
			}
		}

		/// <summary>
		///   The set entity.
		/// </summary>
		/// <typeparam name="TEntity"> </typeparam>
		/// <returns> The System.Data.Entity.IDbSet`1[TEntity - &gt; TEntity]. </returns>
		public IDbSet<TEntity> SetEntity<TEntity>() where TEntity : BaseEntity
		{
			return Set<TEntity>();
		}

		#endregion
	}
}