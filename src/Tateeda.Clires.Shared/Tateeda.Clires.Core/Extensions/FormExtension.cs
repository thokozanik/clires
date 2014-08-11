// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormExtension.cs" company="">
//   
// </copyright>
// <summary>
//   The form extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Extensions
{
    using Tateeda.Clires.Core.Data.EF;

    /// <summary>
    /// The form extension.
    /// </summary>
    public static class FormExtension
    {
        #region Public Methods and Operators

        /// <summary>
        /// The to entity.
        /// </summary>
        /// <param name="form">
        /// The form.
        /// </param>
        /// <returns>
        /// The <see cref="Form"/>.
        /// </returns>
        public static Form ToEntity(this IForm form)
        {
            return new Form
                {
                    Code = form.Code,
                    CreatedBy = form.CreatedBy,
                    CreatedOn = form.CreatedOn,
                    Description = form.Description,
                    Directions = form.Directions,
                    IsDoubleChecked = form.IsDoubleChecked,
                    FormTypeId = form.FormTypeId,
                    Header = form.Header,
                    Id = form.Id,
                    IsActive = form.IsActive,
                    IsFilledBySubject = form.IsFilledBySubject,
                    LayoutTypeId = form.LayoutTypeId,
                    Name = form.Name,
                    NotifyOnChange = form.NotifyOnChange,
                    NotifyOnCompletion = form.NotifyOnCompletion,
                    ShowTotalScore = form.ShowTotalScore,
                    SortOrder = form.SortOrder,
                    Status = form.Status,
                    StudyId = form.StudyId,
                    Title = form.Title,
                    Trailer = form.Trailer,
                    UpdatedBy = form.UpdatedBy,
                    UpdatedOn = form.UpdatedOn
                };
        }

        /// <summary>
        /// The to entity.
        /// </summary>
        /// <param name="question">
        /// The question.
        /// </param>
        /// <returns>
        /// The <see cref="Question"/>.
        /// </returns>
        public static Question ToEntity(this IQuestion question)
        {
            return new Question
                {
                    Code = question.Code,
                    CreatedBy = question.CreatedBy,
                    CreatedOn = question.CreatedOn,
                    Description = question.Description,
                    Directions = question.Directions,
                    FieldDataTypeId = question.FieldDataTypeId,
                    FormId = question.FormId,
                    Header = question.Header,
                    Id = question.Id,
                    IsActive = question.IsActive,
                    IsRequired = question.IsRequired,
                    IsParent = question.IsParent,
                    ParentQuestionId = question.ParentQuestionId,
                    QuestionText = question.QuestionText,
                    SortOrder = question.SortOrder,
                    Status = question.Status,
                    Trailer = question.Trailer,
                    UpdatedBy = question.UpdatedBy,
                    UpdatedOn = question.UpdatedOn
                };
        }

        /// <summary>
        /// The to entity.
        /// </summary>
        /// <param name="answer">
        /// The answer.
        /// </param>
        /// <returns>
        /// The <see cref="Answer"/>.
        /// </returns>
        public static Answer ToEntity(this IAnswer answer)
        {
            return new Answer
                {
                    Code = answer.Code,
                    CreatedBy = answer.CreatedBy,
                    CreatedOn = answer.CreatedOn,
                    Directions = answer.Directions,
                    Header = answer.Header,
                    Id = answer.Id,
                    IsActive = answer.IsActive,
                    OptionText = answer.OptionText,
                    QuestionId = answer.QuestionId,
                    Score = answer.Score,
                    SortOrder = answer.SortOrder,
                    Status = answer.Status,
                    Trailer = answer.Trailer,
                    UpdatedBy = answer.UpdatedBy,
                    UpdatedOn = answer.UpdatedOn
                };
        }

        #endregion
    }
}