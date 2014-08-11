namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Collections.Generic;

    public interface IOrganization
    {
        string Name { get; set; }

        string Description { get; set; }

        System.DateTime CreatedOn { get; set; }

        Nullable<DateTime> UpdatedOn { get; set; }

        string CreatedBy { get; set; }

        string UpdatedBy { get; set; }

        bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<Study> Studies { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }
    }

    public partial class Organization : BaseEntity, IOrganization
    {
    }
}
