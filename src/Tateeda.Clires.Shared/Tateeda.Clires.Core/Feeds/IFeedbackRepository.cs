// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFeedbackRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The FeedbackRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Feeds
{
    using Tateeda.Clires.Core.Data;
    using Tateeda.Clires.Core.Data.EF;

    /// <summary>
    /// The FeedbackRepository interface.
    /// </summary>
    public interface IFeedbackRepository : IRepository<Feedback>
    {
    }
}