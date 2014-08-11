namespace Tateeda.Clires.Areas.Admin.Model.Study
{
    using Tateeda.Clires.Core.Data.EF;

    using global::System;
    using global::System.Collections.Generic;
    using global::System.ComponentModel.DataAnnotations;

    public interface IVisitViewModel
    {
        int StudyId { get; set; }
        string ArmName { get; set; }
        int FormsCount { get; set; }
        string ParentVisitName { get; set; }
    }

    public class VisitViewModel : IVisit, IVisitViewModel
    {
        [Required]
        public int StudyId { get; set;}
        
        public string ArmName { get; set; }
        public int FormsCount { get; set; }
        public string ParentVisitName { get; set; }

        #region Implementation of IVisit

        public int VisitTypeId { get; set; }
        [Required]
        public int ArmId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Directions { get; set; }
        public int SortOrder { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public int? ParentVisitId { get; set; }
        public bool IsBaseVisit { get; set; }
        public bool CanRepeat { get; set; }
        public bool CanMove { get; set; }
        public bool HasChild { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public Arm Arm { get; set; }
        public ICollection<FormVisibilityByVisitForSubject> FormVisibilityByVisitForSubjects { get; set; }
        public ICollection<ScheduleSubjectVisit> ScheduleSubjectVisits { get; set; }
        public ICollection<Visit> ChildVisit { get; set; }
        public Visit ParentVisit { get; set; }
        public ICollection<VisitStepVisitSequence> VisitStepVisitSequences { get; set; }
        public ICollection<VisitForm> VisitForms { get; set; }
        public ICollection<VisitStep> VisitSteps { get; set; }
        public int Id { get; set; }

        #endregion
    }
}