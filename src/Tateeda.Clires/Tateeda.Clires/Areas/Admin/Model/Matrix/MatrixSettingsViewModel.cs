namespace Tateeda.Clires.Areas.Admin.Model.Matrix
{
    using Tateeda.Clires.Core.Data.EF;

    using global::System.Collections.Generic;

    /// <summary>
    /// The matrix settings view model.
    /// </summary>
    public class MatrixSettingsViewModel
    {
        /// <summary>
        /// Gets or sets the visits.
        /// </summary>
        public IEnumerable<IVisit> Visits { get; set; }

        /// <summary>
        /// Gets or sets the forms.
        /// </summary>
        public IEnumerable<IForm> Forms { get; set; }

        /// <summary>
        /// Gets or sets the labs.
        /// </summary>
        public IEnumerable<IForm> Labs { get; set; }

        /// <summary>
        /// Gets or sets the study id.
        /// </summary>
        public int StudyId { get; set; }
    }
}