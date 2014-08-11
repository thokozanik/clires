// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudySetupUnitOfWork.cs" company="">
//   
// </copyright>
// <summary>
//   The study setup unit of work.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Data.UOW
{
    using System;

    using Tateeda.Clires.Core.Data.EF;
    using Tateeda.Clires.Core.StudySetup;

    /// <summary>
    /// The study setup unit of work.
    /// </summary>
    public class StudySetupUnitOfWork : IStudySetupUnitOfWork
    {
        #region Fields

        /// <summary>
        /// The _disposed.
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// The _study setup repo.
        /// </summary>
        private IStudySetupRepository _studySetupRepo;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StudySetupUnitOfWork"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public StudySetupUnitOfWork(IDbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StudySetupUnitOfWork"/> class. 
        ///   Initializes a new instance of the <see cref="UtilUnitOfWork"/> class.
        /// </summary>
        public StudySetupUnitOfWork()
        {
            this.Context = new Entities();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets the context.
        /// </summary>
        public IDbContext Context { get; private set; }

        /// <summary>
        /// Gets the study setup repository.
        /// </summary>
        public IStudySetupRepository StudySetupRepository
        {
            get
            {
                return _studySetupRepo ?? (_studySetupRepo = new StudySetupRepository(this.Context));
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
            this.Dispose(true);
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
            if (!this._disposed && disposing)
            {
                this.Context.Dispose();
            }

            this._disposed = true;
        }

        #endregion
    }
}