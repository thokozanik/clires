namespace Tateeda.Clires.Areas.Subject.Model 
{
    using Tateeda.Clires.Core.Data.EF;

    using global::System;
    using global::System.Collections.Generic;
    using global::System.ComponentModel.DataAnnotations;

    public interface ISubjectViewModel : ISubject, IContact, IPhone, IEmail, IAddress, ISubjectDrug
    {
        IEnumerable<IAppointment> Appointments { get; set; }
    }

    public class SubjectViewModel : ISubjectViewModel
    {
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public int GenderTypeId { get; set; }
        [Required]
        public int YearBorn { get; set; }        
        public string SSN { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public Drug Drug { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Contact> Contacts { get; set; }

        public ICollection<File> Files { get; set; }
        public int Id { get; set; }
        public int SiteId { get; set; }
        public int ContactId { get; set; }
        public int StudyId { get; set; }
        public string Nickname { get; set; }
        public string FamilyId { get; set; }
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
        public string NIMHID { get; set; }
        public byte[] SSNEnc { get; set; }
        public byte[] FirstNameEnc { get; set; }
        public byte[] LastNameEnc { get; set; }
        public byte[] DateOfBirthEnc { get; set; }
        public string Directions { get; set; }
        public int ContactTypeId { get; set; }
        public string CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int Number { get; set; }
        public int? PhoneTypeId { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public int AddressTypeId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public int SortOrder { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public Contact Contact { get; set; }
        public Site Site { get; set; }
        public Study Study { get; set; }
        public ICollection<ISubjectDrugViewModel> SubjectDrugs { get; set; }

        #region Private 
        ICollection<SubjectDrug> ISubject.SubjectDrugs { get; set; }
        ICollection<Contact> IAddress.Contacts { get; set; }
        string IEmail.UpdatedBy { get; set; }
        bool IEmail.IsActive { get; set; }
        ICollection<Contact> IEmail.Contacts { get; set; }
        bool IPhone.IsActive { get; set; }
        DateTime IAddress.CreatedOn { get; set; }
        DateTime? IAddress.UpdatedOn { get; set; }
        DateTime IEmail.CreatedOn { get; set; }
        DateTime? IEmail.UpdatedOn { get; set; }
        string IEmail.CreatedBy { get; set; }
        DateTime IPhone.CreatedOn { get; set; }
        DateTime? IPhone.UpdatedOn { get; set; }
        string IPhone.CreatedBy { get; set; }
        string IPhone.UpdatedBy { get; set; }
        DateTime IContact.CreatedOn { get; set; }
        DateTime? IContact.UpdatedOn { get; set; }
        string IContact.CreatedBy { get; set; }
        string IContact.UpdatedBy { get; set; }
        bool IContact.IsActive { get; set; }
        DateTime ISubject.CreatedOn { get; set; }
        DateTime? ISubject.UpdatedOn { get; set; }
        string ISubject.CreatedBy { get; set; }
        string ISubject.UpdatedBy { get; set; }
        bool ISubject.IsActive { get; set; }
        #endregion

        #region Implementation of ISubjectViewModel

        public IEnumerable<IAppointment> Appointments { get; set; }

        #endregion
    }
}