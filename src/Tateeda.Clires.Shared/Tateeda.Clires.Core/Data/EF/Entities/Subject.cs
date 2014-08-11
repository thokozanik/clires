// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Subject.cs" company="">
//   
// </copyright>
// <summary>
//   The Subject interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The Subject interface.
    /// </summary>
    public interface ISubject
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the contact.
        /// </summary>
        Contact Contact { get; set; }

        /// <summary>
        /// Gets or sets the contact id.
        /// </summary>
        int ContactId { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        string DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the date of birth enc.
        /// </summary>
        byte[] DateOfBirthEnc { get; set; }

        /// <summary>
        /// Gets or sets the directions.
        /// </summary>
        string Directions { get; set; }

        /// <summary>
        /// Gets or sets the family id.
        /// </summary>
        string FamilyId { get; set; }

        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<File> Files { get; set; }

        /// <summary>
        /// Gets or sets the first name enc.
        /// </summary>
        byte[] FirstNameEnc { get; set; }

        /// <summary>
        /// Gets or sets the gender type id.
        /// </summary>
        int GenderTypeId { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the last name enc.
        /// </summary>
        byte[] LastNameEnc { get; set; }

        /// <summary>
        /// Gets or sets the nimhid.
        /// </summary>
        string NIMHID { get; set; }

        /// <summary>
        /// Gets or sets the nickname.
        /// </summary>
        string Nickname { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        string Notes { get; set; }

        /// <summary>
        /// Gets or sets the ssn.
        /// </summary>
        string SSN { get; set; }

        /// <summary>
        /// Gets or sets the ssn enc.
        /// </summary>
        byte[] SSNEnc { get; set; }

        /// <summary>
        /// Gets or sets the site.
        /// </summary>
        Site Site { get; set; }

        /// <summary>
        /// Gets or sets the site id.
        /// </summary>
        int SiteId { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// Gets or sets the study.
        /// </summary>
        Study Study { get; set; }

        /// <summary>
        /// Gets or sets the study id.
        /// </summary>
        int StudyId { get; set; }

        /// <summary>
        /// Gets or sets the subject drugs.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<SubjectDrug> SubjectDrugs { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the year born.
        /// </summary>
        int YearBorn { get; set; }

        #endregion
    }

    /// <summary>
    /// The subject.
    /// </summary>
    public partial class Subject : BaseEntity, ISubject
    {
    }
}