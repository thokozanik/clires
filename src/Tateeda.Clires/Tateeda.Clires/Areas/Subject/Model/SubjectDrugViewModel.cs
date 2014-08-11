namespace Tateeda.Clires.Areas.Subject.Model {
    using Tateeda.Clires.Core.Data.EF;

    using global::System;

    public interface ISubjectDrugViewModel : ISubjectDrug
    {
        string DrugName { get; set; }
    }

    public class SubjectDrugViewModel : ISubjectDrugViewModel
    {
        public string DrugName { get; set; }
        #region Implementation of ISubjectDrug

        public int SubjectId { get; set; }
        public int DrugId { get; set; }
        public int AppointmentId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MultipleTrialsId { get; set; }
        public int? DurationUsed { get; set; }
        public int ReasonStoppedId { get; set; }
        public int ReasonTypeId { get; set; }
        public int TreatmentInducedId { get; set; }
        public int DosageFrequencyId { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsChanged { get; set; }
        public bool IsStopped { get; set; }
        public bool IsBeforeStudy { get; set; }
        public string Dosage { get; set; }
        public string DosageType { get; set; }
        public string Notes { get; set; }
        public string MdNotes { get; set; }
        public string Comments { get; set; }
        public string Directions { get; set; }
        public int SortOrder { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public Drug Drug { get; set; }
        public Subject Subject { get; set; }
        public int Id { get; set; }

        #endregion
    }
}