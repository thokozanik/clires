// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminUnitOfWork.cs" company="">
//   
// </copyright>
// <summary>
//   The AdminUnitOfWork interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Tateeda.Clires.Data.UOW
{
    using System;

    using Tateeda.Clires.Core.Appointments;
    using Tateeda.Clires.Core.Data.EF;
    using Tateeda.Clires.Core.Drugs;
    using Tateeda.Clires.Core.Feeds;
    using Tateeda.Clires.Core.Forms;
    using Tateeda.Clires.Core.Study;
    using Tateeda.Clires.Core.Subjects;
    using Tateeda.Clires.Core.Users;
    using Tateeda.Clires.Core.Utility;
    using Tateeda.Clires.Core.Visits;

    /// <summary>
    ///   The admin unit of work.
    /// </summary>
    public class AdminUnitOfWork : IAdminUnitOfWork
    {
        #region Fields

        /// <summary>
        ///   The _appointment repository.
        /// </summary>
        private IAppointmentRepository _appointmentRepository;

        /// <summary>
        ///   The _code repo.
        /// </summary>
        private ICodeRepository _codeRepo;

        /// <summary>
        ///   The _disposed.
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// The _feedback repository.
        /// </summary>
        private IFeedbackRepository _feedbackRepository;

        /// <summary>
        ///   The _file repo.
        /// </summary>
        private IFileRepository _fileRepo;

        /// <summary>
        ///   The _form repo.
        /// </summary>
        private IFormRepository _formRepo;

        /// <summary>
        ///   The _settings repo.
        /// </summary>
        private ISettingsRepository _settingsRepo;

        /// <summary>
        ///   The _study repo.
        /// </summary>
        private IStudyRepository _studyRepo;

        /// <summary>
        ///   The _subject repository.
        /// </summary>
        private ISubjectRepository _subjectRepository;

        /// <summary>
        ///   The _user repo.
        /// </summary>
        private IUserRepository _userRepo;

        /// <summary>
        ///   The _visit repo.
        /// </summary>
        private IVisitRepository _visitRepo;

        /// <summary>
        /// The drugs repository.
        /// </summary>
        private IDrugsRepository drugsRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminUnitOfWork"/> class.
        /// </summary>
        /// <param name="context">
        /// The context. 
        /// </param>
        public AdminUnitOfWork(IDbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AdminUnitOfWork" /> class.
        /// </summary>
        public AdminUnitOfWork()
        {
            Context = new Entities();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets the appointment repository.
        /// </summary>
        public IAppointmentRepository AppointmentRepository
        {
            get
            {
                return _appointmentRepository ?? (_appointmentRepository = new AppointmentRepository(Context));
            }
        }

        /// <summary>
        ///   Gets the code repository.
        /// </summary>
        public ICodeRepository CodeRepository
        {
            get
            {
                return _codeRepo ?? (_codeRepo = new CodeRepository(this.Context));
            }
        }

        /// <summary>
        ///   Gets the context.
        /// </summary>
        public IDbContext Context { get; private set; }

        /// <summary>
        /// Gets the drugs repository.
        /// </summary>
        public IDrugsRepository DrugsRepository
        {
            get
            {
                return drugsRepository ?? (drugsRepository = new DrugsRepository(Context));
            }
        }

        /// <summary>
        /// Gets the feedback repository.
        /// </summary>
        public IFeedbackRepository FeedbackRepository
        {
            get
            {
                return _feedbackRepository ?? (_feedbackRepository = new FeedbackRepository(Context));
            }
        }

        /// <summary>
        ///   Gets the file repository.
        /// </summary>
        public IFileRepository FileRepository
        {
            get
            {
                return _fileRepo ?? (_fileRepo = new FileRepository(this.Context));
            }
        }

        /// <summary>
        ///   Gets the form repository.
        /// </summary>
        public IFormRepository FormRepository
        {
            get
            {
                return _formRepo ?? (_formRepo = new FormRepository(Context));
            }
        }

        /// <summary>
        ///   Gets the settings repository.
        /// </summary>
        public ISettingsRepository SettingsRepository
        {
            get
            {
                return _settingsRepo ?? (_settingsRepo = new SettingsRepository(this.Context));
            }
        }

        /// <summary>
        ///   Gets the study repository.
        /// </summary>
        public IStudyRepository StudyRepository
        {
            get
            {
                return this._studyRepo ?? (_studyRepo = new StudyRepository(this.Context));
            }
        }

        /// <summary>
        ///   Gets the subject repository.
        /// </summary>
        public ISubjectRepository SubjectRepository
        {
            get
            {
                return _subjectRepository ?? (_subjectRepository = new SubjectRepository(Context));
            }
        }

        /// <summary>
        ///   Gets the user repository.
        /// </summary>
        public IUserRepository UserRepository
        {
            get
            {
                return _userRepo ?? (_userRepo = new UserRepository(this.Context));
            }
        }

        /// <summary>
        ///   Gets the visit repository.
        /// </summary>
        public IVisitRepository VisitRepository
        {
            get
            {
                return _visitRepo ?? (_visitRepo = new VisitRepository(Context));
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   The commit.
        /// </summary>
        public void Commit()
        {
            this.Context.Commit();
        }

        /// <summary>
        ///   The dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Methods

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

        #endregion
    }
}