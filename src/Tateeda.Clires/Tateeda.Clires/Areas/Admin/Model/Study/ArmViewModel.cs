namespace Tateeda.Clires.Areas.Admin.Model.Study {
    using Tateeda.Clires.Core.Data.EF;

    using global::System;
    using global::System.Collections.Generic;

    public class ArmViewModel : IArm {
        public int StudyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public Core.Data.EF.Study Study { get; set; }
        public ICollection<Visit> Visits { get; set; }
        public int Id { get; set; }
    }
}