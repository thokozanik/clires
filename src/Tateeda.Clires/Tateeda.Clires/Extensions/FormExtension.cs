using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Tateeda.Clires.Core.Utility;

namespace Tateeda.Clires.Extensions
{
    using Tateeda.Clires.Areas.Admin.Model.Forms;
    using Tateeda.Clires.Core.Data.EF;
    using Tateeda.Clires.Data.UOW;

    public static class FormExtension
    {
        public static FormViewModel ToModel(this IForm form)
        {
            var formVm = new FormViewModel
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
                    ShowTotalScore = form.ShowTotalScore,
                    SortOrder = form.SortOrder,
                    Status = form.Status,
                    StudyId = form.StudyId,
                    Title = form.Title,
                    Trailer = form.Trailer,
                    UpdatedBy = form.UpdatedBy,
                    UpdatedOn = form.UpdatedOn,
                    NotifyOnChange = form.NotifyOnChange,
                    NotifyOnCompletion = form.NotifyOnCompletion
                };

            return formVm;
        }

        public static QuestionViewModel ToModel(this IQuestion question)
        {
            var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>();
            var fieldDataTypes = adminUow.CodeRepository.GetFieldDataTypes();
            var dataTypesList = fieldDataTypes as List<ICode> ?? fieldDataTypes.ToList();

            //TODO: [SK] Re factoring. I may need to undo this. Updated 01.30.2013
            var questionField = dataTypesList.FirstOrDefault(f => f.EnumId == question.FieldDataTypeId);
            if (questionField != null)
            {
                var qVm = new QuestionViewModel
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
                        UpdatedOn = question.UpdatedOn,
                        AnswersViewModel = new List<AnswerViewModel>(),
                        FieldDataTypeName = questionField.Name,
                        ValidationRule = question.ValidationRule
                    };

                foreach (var a in question.Answers)
                {
                    qVm.AnswersViewModel.Add(a.ToModel());
                }

                return qVm;
            }
            return new QuestionViewModel();
        }

        public static AnswerViewModel ToModel(this IAnswer answer)
        {
            var answerVm = new AnswerViewModel
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

            var childQuestionsIds = answer.AnswerChildQuestions.Select(childQuestion => childQuestion.QuestionId).ToList();
            answerVm.ChildQuestionIds = childQuestionsIds;

            return answerVm;
        }

    }
}