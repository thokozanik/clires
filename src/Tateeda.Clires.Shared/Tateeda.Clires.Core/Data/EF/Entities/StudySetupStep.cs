namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Collections.Generic;

    public interface IStudySetupStep
    {
        Nullable<int> OrganizationId { get; set; }

        string Name { get; set; }

        string ContextUrl { get; set; }

        string CreatedBy { get; set; }

        string UpdatedBy { get; set; }

        string CreatedOn { get; set; }

        Nullable<System.DateTime> UpdatedOn { get; set; }

        Nullable<bool> IsActive { get; set; }

        Nullable<int> SortOrder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<StudySetupMap> StudySetupMaps { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }
    }

    public partial class StudySetupStep : BaseEntity, IStudySetupStep
    {
    }
}
