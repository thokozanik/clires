// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVisitForms.cs" company="">
//   
// </copyright>
// <summary>
//   The VisitForms interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Visits
{
    using System.Collections.Generic;

    using Tateeda.Clires.Core.Data.EF;

    /// <summary>
    /// The VisitForms interface.
    /// </summary>
    public interface IVisitForms
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the all forms.
        /// </summary>
        IEnumerable<IForm> AllForms { get; set; }

        /// <summary>
        /// Gets or sets the forms.
        /// </summary>
        IEnumerable<IForm> Forms { get; set; }

        /// <summary>
        /// Gets or sets the visit.
        /// </summary>
        IVisit Visit { get; set; }

        #endregion
    }
}