namespace Tateeda.Clires.Areas.Admin.Model.Study
{
    using Tateeda.Clires.Core.Data.EF;

    using global::System;
    using global::System.Collections.Generic;

    public class StudyViewModel : IStudy
    {
        #region Implementation of IStudy

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Target { get; set; }
        public string Goal { get; set; }
        public decimal? Budget { get; set; }
        public int SortOrder { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Arm> Arms { get; set; }
        public ICollection<Drug> Drugs { get; set; }
        public ICollection<Site> Sites { get; set; }
        public ICollection<Form> Forms { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<File> Files { get; set; }
        public int Id { get; set; }

        #endregion
    }
}