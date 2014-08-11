namespace Tateeda.Clires.Areas.Admin.Model.Drugs {
    using Tateeda.Clires.Core.Data.EF;

    using global::System;
    using global::System.Collections.Generic;

    public class DrugCategoryViewModel : IDrugCategory {
        #region Implementation of IDrugCategory

        public string Name { get; set; }
        public string Code { get; set; }
        public string Directions { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public ICollection<DrugClass> DrugClasses { get; set; }
        public int Id { get; set; }

        #endregion
    }
}