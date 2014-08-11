// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFormRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The FormRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Tateeda.Clires.Core.Forms
{
    using System.Collections.Generic;

    using Tateeda.Clires.Core.Data;
    using Tateeda.Clires.Core.Data.EF;
    using Tateeda.Clires.Core.Data.Enums;

    /// <summary>
    ///   The FormRepository interface.
    /// </summary>
    public interface IFormRepository : IRepository<Form>
    {
        #region Public Methods and Operators

        /// <summary>
        /// The add answer child questions mapping.
        /// </summary>
        /// <param name="answerId">
        /// The answer id. 
        /// </param>
        /// <param name="questionsId">
        /// The questions id. 
        /// </param>
        void AddAnswerChildQuestionsMapping(int answerId, IEnumerable<int> questionsId);

        /// <summary>
        /// The add new form question.
        /// </summary>
        /// <param name="question">
        /// The question. 
        /// </param>
        void AddNewFormQuestion(IQuestion question);

        /// <summary>
        /// The add new question answer.
        /// </summary>
        /// <param name="answer">
        /// The answer. 
        /// </param>
        void AddNewQuestionAnswer(IAnswer answer);

        /// <summary>
        /// The can open form to write for subject.
        /// </summary>
        /// <param name="formId">
        /// The form id. 
        /// </param>
        /// <param name="subjectId">
        /// The subject id. 
        /// </param>
        /// <param name="appUserId">
        /// The app user id. 
        /// </param>
        /// <returns>
        /// The <see cref="bool"/> . 
        /// </returns>
        bool CanOpenFormToWriteForSubject(int formId, int subjectId, int appUserId);

        /// <summary>
        /// The clear answer child questions.
        /// </summary>
        /// <param name="answerId">
        /// The answer id. 
        /// </param>
        void ClearAnswerChildQuestions(int answerId);

        /// <summary>
        /// The create new answer.
        /// </summary>
        /// <param name="answer">
        /// The answer. 
        /// </param>
        void CreateNewAnswer(IAnswer answer);

        /// <summary>
        /// The create new form.
        /// </summary>
        /// <param name="form">
        /// The form. 
        /// </param>
        void CreateNewForm(IForm form);

        /// <summary>
        /// The create new question.
        /// </summary>
        /// <param name="question">
        /// The question. 
        /// </param>
        void CreateNewQuestion(IQuestion question);

        /// <summary>
        /// The delete answer.
        /// </summary>
        /// <param name="answer">
        /// The answer. 
        /// </param>
        void DeleteAnswer(IAnswer answer);

        /// <summary>
        /// The delete question.
        /// </summary>
        /// <param name="question">
        /// The question. 
        /// </param>
        void DeleteQuestion(IQuestion question);

        /// <summary>
        /// The get all forms per study.
        /// </summary>
        /// <param name="studyId">
        /// The study id. 
        /// </param>
        /// <param name="formTypeId">
        /// The form type id. 
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/> . 
        /// </returns>
        IEnumerable<IForm> GetAllFormsPerStudy(int studyId, FormType formTypeId);

        /// <summary>
        /// The get all forms per study.
        /// </summary>
        /// <param name="studyId">
        /// The study id. 
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/> . 
        /// </returns>
        IEnumerable<IForm> GetAllFormsPerStudy(int studyId);

        /// <summary>
        /// The get all forms per study.
        /// </summary>
        /// <param name="studyId">
        /// The study id. 
        /// </param>
        /// <param name="size">
        /// The size. 
        /// </param>
        /// <param name="page">
        /// The page. 
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/> . 
        /// </returns>
        IEnumerable<IForm> GetAllFormsPerStudy(int studyId, int size, int page);

        /// <summary>
        /// The get answer.
        /// </summary>
        /// <param name="answerId">
        /// The answer id. 
        /// </param>
        /// <returns>
        /// The <see cref="IAnswer"/> . 
        /// </returns>
        IAnswer GetAnswer(int answerId);

        /// <summary>
        ///   The get current study id.
        /// </summary>
        /// <returns> The <see cref="IEnumerable" /> . </returns>
        IEnumerable<int> GetCurrentStudyId();

        /// <summary>
        /// The get form.
        /// </summary>
        /// <param name="formId">
        /// The form id. 
        /// </param>
        /// <returns>
        /// The <see cref="IForm"/> . 
        /// </returns>
        IForm GetForm(int formId);

        /// <summary>
        /// The get form questions.
        /// </summary>
        /// <param name="formId">
        /// The form id. 
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/> . 
        /// </returns>
        IEnumerable<IQuestion> GetFormQuestions(int formId);

        /// <summary>
        /// The get question.
        /// </summary>
        /// <param name="questionId">
        /// The question id. 
        /// </param>
        /// <returns>
        /// The <see cref="IQuestion"/> . 
        /// </returns>
        IQuestion GetQuestion(int questionId);

        /// <summary>
        /// The get question answers.
        /// </summary>
        /// <param name="questionId">
        /// The question id. 
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/> . 
        /// </returns>
        IEnumerable<IAnswer> GetQuestionAnswers(int questionId);

        /// <summary>
        /// The mark subject form as read only.
        /// </summary>
        /// <param name="formId">
        /// The form id. 
        /// </param>
        /// <param name="subjectId">
        /// The subject id. 
        /// </param>
        /// <param name="appUserId">
        /// The app user id. 
        /// </param>
        /// <param name="lockFor">
        /// The lock for. 
        /// </param>
        void MarkSubjectFormAsReadOnly(int formId, int subjectId, int appUserId, int lockFor = 30);

        /// <summary>
        /// The mark subject form as read only.
        /// </summary>
        /// <param name="form">
        /// The form. 
        /// </param>
        void MarkSubjectFormAsReadOnly(IFormInProcess form);

        /// <summary>
        /// The unlock form from read only.
        /// </summary>
        /// <param name="formId">
        /// The form id. 
        /// </param>
        /// <param name="subjectId">
        /// The subject id. 
        /// </param>
        /// <param name="appUserId">
        /// The app user id. 
        /// </param>
        void UnlockFormFromReadOnly(int formId, int subjectId, int appUserId);

        /// <summary>
        /// The unlock form from read only.
        /// </summary>
        /// <param name="form">
        /// The form. 
        /// </param>
        void UnlockFormFromReadOnly(IFormInProcess form);

        /// <summary>
        /// The update answer.
        /// </summary>
        /// <param name="answer">
        /// The answer. 
        /// </param>
        void UpdateAnswer(IAnswer answer);

        /// <summary>
        /// The update form.
        /// </summary>
        /// <param name="form">
        /// The form. 
        /// </param>
        void UpdateForm(IForm form);

        /// <summary>
        /// The update question.
        /// </summary>
        /// <param name="question">
        /// The question. 
        /// </param>
        void UpdateQuestion(IQuestion question);

        #endregion
    }
}