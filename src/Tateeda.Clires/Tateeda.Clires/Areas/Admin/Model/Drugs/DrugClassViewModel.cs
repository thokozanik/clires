// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DrugClassViewModel.cs" company="Tateeda Media Network">
//   Tateeda Media Network. http://tateeda.com
// </copyright>
// <summary>
//   Defines the DrugClassViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Areas.Admin.Model.Drugs {
    using Tateeda.Clires.Core.Data.EF;

    using global::System;
    using global::System.Collections.Generic;

    public class DrugClassViewModel : IDrugClass
    {
        #region Implementation of IDrugClass

        public int DrugCategoryId { get; set; }
        public string Name { get; set; }
        public string Directions { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Drug> Drugs { get; set; }
        public DrugCategory DrugCategory { get; set; }
        public int Id { get; set; }

        #endregion
    }
}