namespace Tateeda.Clires.Data.UOW
{
    using System;

    using Tateeda.Clires.Core.Data.EF;
    using Tateeda.Clires.Core.Utility;

    public class UtilUnitOfWork : IUtilUnitOfWork
    {
        private bool _disposed;

        private IErrorLogRepository _errorLogRepo;

        public UtilUnitOfWork(IDbContext context)
        {
            this.Context = context;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="UtilUnitOfWork" /> class.
        /// </summary>
        public UtilUnitOfWork()
        {
            this.Context = new Entities();
        }

        /// <summary>
        ///   Gets the context.
        /// </summary>
        public IDbContext Context { get; private set; }


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

        #region Implementation of IUtilUnitOfWork

        public IErrorLogRepository ErrorLogRepository
        {
            get
            {
                return _errorLogRepo ?? (_errorLogRepo = new ErrorLogRepository(this.Context));
            }
        }

        #endregion
    }
}