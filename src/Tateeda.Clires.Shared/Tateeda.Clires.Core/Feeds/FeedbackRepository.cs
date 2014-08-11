// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FeedbackRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The feedback repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Feeds
{
    using System.Linq;

    using Tateeda.Clires.Core.Data.EF;

    /// <summary>
    /// The feedback repository.
    /// </summary>
    public class FeedbackRepository : IFeedbackRepository
    {
        #region Fields

        /// <summary>
        /// The _context.
        /// </summary>
        private readonly IDbContext _context;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public FeedbackRepository(IDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the all.
        /// </summary>
        public IQueryable<Feedback> All { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The commit.
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
        public void Delete(Feedback entity)
        {
            // keep all of them for now.
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Feedback"/>.
        /// </returns>
        public Feedback GetById(object id)
        {
            return _context.Feedbacks.FirstOrDefault(a => a.Id == (int)id);
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Insert(Feedback entity)
        {
            _context.Feedbacks.Add(entity);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Update(Feedback entity)
        {
            // no need to update feedback
        }

        #endregion
    }
}