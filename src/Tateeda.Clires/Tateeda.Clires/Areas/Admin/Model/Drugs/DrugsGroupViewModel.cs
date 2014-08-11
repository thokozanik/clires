namespace Tateeda.Clires.Areas.Admin.Model.Drugs {
    using Tateeda.Clires.Core.Data.EF;

    using global::System.Collections.Generic;

    public class DrugsGroupViewModel {
        public IEnumerable<IDrug> Drugs { get; set; }
        public int GroupTotal { get; set; }
    }
}