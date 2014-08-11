namespace Tateeda.Clires.Areas.Admin.Model.Matrix
{
    using Tateeda.Clires.Core.Data.EF;
    using Tateeda.Clires.Core.Visits;

    using global::System.Collections.Generic;

    /// <summary>
    /// The visit forms view.
    /// </summary>
    public class VisitFormsView : IVisitForms
    {
        /// <summary>
        /// Gets or sets the visit.
        /// </summary>
        public IVisit Visit { get; set; }

        /// <summary>
        /// Gets or sets the forms.
        /// </summary>
        public IEnumerable<IForm> Forms { get; set; }

        public IEnumerable<IForm> AllForms { get; set; }
    }
}