namespace Tateeda.Clires.Data.UOW
{
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
    ///   The AdminUnitOfWork interface.
    /// </summary>
    public interface IAdminUnitOfWork : IUnitOfWork
    {
        #region Public Properties

        /// <summary>
        ///   Gets the appointment repository.
        /// </summary>
        IAppointmentRepository AppointmentRepository { get; }

        /// <summary>
        ///   Gets the code repository.
        /// </summary>
        ICodeRepository CodeRepository { get; }

        /// <summary>
        ///   Gets the context.
        /// </summary>
        IDbContext Context { get; }

        /// <summary>
        /// Gets the drugs repository.
        /// </summary>
        IDrugsRepository DrugsRepository { get; }

        /// <summary>
        /// Gets the feedback repository.
        /// </summary>
        IFeedbackRepository FeedbackRepository { get; }

        /// <summary>
        ///   Gets the file repository.
        /// </summary>
        IFileRepository FileRepository { get; }

        /// <summary>
        ///   Gets the form repository.
        /// </summary>
        IFormRepository FormRepository { get; }

        /// <summary>
        ///   Gets the settings repository.
        /// </summary>
        ISettingsRepository SettingsRepository { get; }

        /// <summary>
        ///   Gets the study repository.
        /// </summary>
        IStudyRepository StudyRepository { get; }

        /// <summary>
        ///   Gets the subject repository.
        /// </summary>
        ISubjectRepository SubjectRepository { get; }

        /// <summary>
        ///   Gets the user repository.
        /// </summary>
        IUserRepository UserRepository { get; }

        /// <summary>
        ///   Gets the visit repository.
        /// </summary>
        IVisitRepository VisitRepository { get; }

        #endregion
    }
}