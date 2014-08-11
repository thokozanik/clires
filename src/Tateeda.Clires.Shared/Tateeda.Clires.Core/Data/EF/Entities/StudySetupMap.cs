namespace Tateeda.Clires.Core.Data.EF
{
    using System;

    public interface IStudySetupMap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        Nullable<int> OrganizationId { get; set; }

        Nullable<int> StudyId { get; set; }

        Nullable<int> StudySetupStepId { get; set; }

        Nullable<int> StepSetupStatus { get; set; }

        string CreatedBy { get; set; }

        string UpdatedBy { get; set; }

        System.DateTime CreatedOn { get; set; }

        Nullable<System.DateTime> UpdatedOn { get; set; }

        bool IsActive { get; set; }

        StudySetupStep StudySetupStep { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }
    }

    public partial class StudySetupMap : BaseEntity, IStudySetupMap
    {

    }
}