// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VisitForms.cs" company="">
//   
// </copyright>
// <summary>
//   The visit forms.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Visits
{
    using System.Collections.Generic;

    using Tateeda.Clires.Core.Data.EF;

    /// <summary>
    /// The visit forms.
    /// </summary>
    public class VisitForms : IVisitForms
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the all forms.
        /// </summary>
        public IEnumerable<IForm> AllForms { get; set; }

        /// <summary>
        /// Gets or sets the forms.
        /// </summary>
        public IEnumerable<IForm> Forms { get; set; }

        /// <summary>
        /// Gets or sets the visit.
        /// </summary>
        public IVisit Visit { get; set; }

        #endregion
    }
}