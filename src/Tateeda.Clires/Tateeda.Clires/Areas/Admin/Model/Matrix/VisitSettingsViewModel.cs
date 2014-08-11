namespace Tateeda.Clires.Areas.Admin.Model.Matrix
{
    using Tateeda.Clires.Core.Data.EF;

    using global::System.Collections.Generic;

    public class VisitSettingsViewModel
    {
        public IEnumerable<IForm> Forms { get; set; }

        public IEnumerable<IForm> Labs { get; set; }

        public int VisitId { get; set; }

        public string VisitName { get; set; }
    }
}