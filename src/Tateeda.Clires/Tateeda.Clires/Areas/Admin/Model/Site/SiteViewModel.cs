namespace Tateeda.Clires.Areas.Admin.Model.Site
{
    using Tateeda.Clires.Core.Data.EF;

    using global::System;
    using global::System.Collections.Generic;

    using TimeZone = Tateeda.Clires.Core.Data.EF.TimeZone;

    public class SiteViewModel : ISite
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public int TimeZoneId { get; set; }

        public string Directions { get; set; }

        public int SortOrder { get; set; }

        public int Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public bool IsActive { get; set; }

        public bool IsPrimary { get; set; }

        public ICollection<AppUser> AppUsers { get; set; }

        public TimeZone TimeZone { get; set; }

        public ICollection<Subject> Subjects { get; set; }

        public ICollection<Study> Studies { get; set; }

        public int StudyId { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }

        public string TimeZoneName { get; set; }
    }
}