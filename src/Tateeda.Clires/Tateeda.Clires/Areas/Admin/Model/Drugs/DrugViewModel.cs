// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DrugViewModel.cs" company="Tateeda Media Network">
//   Tateeda Media Network. http://tateeda.com
// </copyright>
// <summary>
//   Defines the DrugViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Areas.Admin.Model.Drugs {
    using Tateeda.Clires.Core.Data.EF;

    using global::System;
    using global::System.Collections.Generic;

    public class DrugViewModel : IDrug
    {
        public int DrugCategoryId { get; set; }

        #region Implementation of IDrug

        public int DrugClassId { get; set; }
        public int? DrugTypeId { get; set; }
        public string Name { get; set; }
        public string Directions { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public int StudyId { get; set; }
        public DrugClass DrugClass { get; set; }
        public ICollection<SubjectDrug> SubjectDrugs { get; set; }
        public Study Study { get; set; }
        public int Id { get; set; }

        #endregion
    }
}