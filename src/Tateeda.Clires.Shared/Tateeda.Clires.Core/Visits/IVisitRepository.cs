// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVisitRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The VisitRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Visits
{
    using System.Collections.Generic;

    using Tateeda.Clires.Core.Data;
    using Tateeda.Clires.Core.Data.EF;

    /// <summary>
    /// The VisitRepository interface.
    /// </summary>
    public interface IVisitRepository : IRepository<Visit>
    {
        #region Public Methods and Operators

        /// <summary>
        /// The assosiate visit forms.
        /// </summary>
        /// <param name="visitId">
        /// The visit id.
        /// </param>
        /// <param name="forms">
        /// The forms.
        /// </param>
        void AssosiateVisitForms(int visitId, IEnumerable<IForm> forms);

        /// <summary>
        /// The clear visit forms assosiation.
        /// </summary>
        /// <param name="visitId">
        /// The visit id.
        /// </param>
        void ClearVisitFormsAssosiation(int visitId);

        /// <summary>
        /// The get all visits.
        /// </summary>
        /// <param name="studyId">
        /// The study id.
        /// </param>
        /// <param name="all">
        /// The all.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IVisit> GetAllVisits(int studyId, bool all = false);

        /// <summary>
        /// The get visit forms.
        /// </summary>
        /// <param name="visitId">
        /// The visit id.
        /// </param>
        /// <param name="all">
        /// The all.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IForm> GetVisitForms(int visitId, bool all = false);

        #endregion
    }
}