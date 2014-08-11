// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Question.cs" company="">
//   
// </copyright>
// <summary>
//   The Question interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// The Question interface.
    /// </summary>
    public interface IQuestion
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the answer child questions.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<AnswerChildQuestion> AnswerChildQuestions { get; set; }

        /// <summary>
        /// Gets or sets the answers.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<Answer> Answers { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        string Code { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on.
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the css type.
        /// </summary>
        CssType CssType { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the directions.
        /// </summary>
        string Directions { get; set; }

        /// <summary>
        /// Gets or sets the field data type id.
        /// </summary>
        int FieldDataTypeId { get; set; }

        /// <summary>
        /// Gets or sets the form.
        /// </summary>
        Form Form { get; set; }

        /// <summary>
        /// Gets or sets the form id.
        /// </summary>
        int FormId { get; set; }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        string Header { get; set; }

        /// <summary>
        ///   Gets or sets the entity identifier
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is parent.
        /// </summary>
        bool IsParent { get; set; }

        string ValidationRule { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is required.
        /// </summary>
        bool IsRequired { get; set; }

        /// <summary>
        /// Gets or sets the parent question id.
        /// </summary>
        int? ParentQuestionId { get; set; }

        /// <summary>
        /// Gets or sets the question text.
        /// </summary>
        string QuestionText { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// Gets or sets the trailer.
        /// </summary>
        string Trailer { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        string UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on.
        /// </summary>
        DateTime? UpdatedOn { get; set; }

        #endregion
    }

    /// <summary>
    /// The question.
    /// </summary>
    public partial class Question : BaseEntity, IQuestion
    {
    }
}