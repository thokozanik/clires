namespace Tateeda.Clires.Core.Utility
{
    using System;
    using System.Linq;

    using Tateeda.Clires.Core.Data.EF;

    public class ErrorLogRepository : IErrorLogRepository
    {

        /// <summary>
        /// The _context.
        /// </summary>
        private readonly IDbContext _context;

        public ErrorLogRepository(IDbContext context)
        {
            this._context = context;
        }

        #region Implementation of IErrorLog

        public void Log(string message, string stackTrace)
        {
            this._context.ErrorLogs.Add(new ErrorLog { Message = message, StackTrace = stackTrace, CreatedOn = DateTime.UtcNow });
        }

        #endregion

        #region Implementation of IRepository<ErrorLog>

        public IQueryable<ErrorLog> All { get; private set; }

        public void Delete(ErrorLog entity)
        {
            //Can't delete
        }

        public ErrorLog GetById(object id)
        {
            return _context.ErrorLogs.Find(id);
        }

        public void Insert(ErrorLog entity)
        {
            this.Log(entity.Message, entity.StackTrace);
        }

        public void Update(ErrorLog entity)
        {
            //Not used
        }

        #endregion
    }
}