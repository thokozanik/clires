// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FormRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The form repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Tateeda.Clires.Core.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Tateeda.Clires.Core.Data.EF;
    using Tateeda.Clires.Core.Data.Enums;
    using Tateeda.Clires.Extensions;

    /// <summary>
    ///   The form repository.
    /// </summary>
    public class FormRepository : IFormRepository
    {
        #region Fields

        /// <summary>
        ///   The _context.
        /// </summary>
        private readonly IDbContext _context;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FormRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context. 
        /// </param>
        public FormRepository(IDbContext context)
        {
            _context = context;
            All = _context.Forms.AsQueryable();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets the all.
        /// </summary>
        public IQueryable<Form> All { get; private set; }

        #endregion

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
        public void AddAnswerChildQuestionsMapping(int answerId, IEnumerable<int> questionsId)
        {
            ClearAnswerChildQuestions(answerId);

            var answer = _context.Answers.FirstOrDefault(a => a.Id == answerId && a.IsActive);
            if (answer == null) return;
            
            answer.Question.IsParent = true;

            foreach (var qId in questionsId)
            {
                // Make sure we do not assign parent Answer Question as child question
                if (answer.Question.Id != qId)
                {
                    var child = new AnswerChildQuestion { AnswerId = answerId, QuestionId = qId, IsActive = true };
                    _context.AnswerChildQuestions.Add(child);

                    var q = _context.Questions.FirstOrDefault(que => que.Id == qId && que.IsActive);
                    q.ParentQuestionId = answer.QuestionId;
                }
            }
        }

        /// <summary>
        /// The add new form question.
        /// </summary>
        /// <param name="question">
        /// The question. 
        /// </param>
        public void AddNewFormQuestion(IQuestion question)
        {
            _context.Questions.Add(question as Question);
        }

        /// <summary>
        /// The add new question answer.
        /// </summary>
        /// <param name="answer">
        /// The answer. 
        /// </param>
        public void AddNewQuestionAnswer(IAnswer answer)
        {
            _context.Answers.Add(answer as Answer);
        }

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
        public bool CanOpenFormToWriteForSubject(int formId, int subjectId, int appUserId)
        {
            var lockedForm = _context.FormInProcesses.FirstOrDefault(f => f.FormId == formId && f.SubjectId == subjectId);
            if (lockedForm == null)
            {
                lockedForm = new FormInProcess { AppUserId = 0, FormId = formId, SubjectId = subjectId, IsLocked = false, MaxLockTimeMin = 0 };
                _context.Commit();
            }

            if (lockedForm.IsLocked)
            {
                if ((DateTime.UtcNow - lockedForm.OpenendOn).Minutes > lockedForm.MaxLockTimeMin || lockedForm.AppUserId == appUserId)
                {
                    UnlockFormFromReadOnly(formId, subjectId, appUserId);
                    _context.Commit();
                }
            }

            return lockedForm.IsLocked;
        }

        /// <summary>
        /// The clear answer child questions.
        /// </summary>
        /// <param name="answerId">
        /// The answer id. 
        /// </param>
        public void ClearAnswerChildQuestions(int answerId)
        {
            var answers = _context.AnswerChildQuestions.Where(a => a.AnswerId == answerId).ToList();
            var answer = _context.Answers.FirstOrDefault(ans => ans.Id == answerId);
            answer.Question.IsParent = false;

            foreach (var a in answers)
            {
                var quest = _context.Questions.FirstOrDefault(q => q.Id == a.QuestionId);
                if (quest != null)
                {
                    quest.ParentQuestionId = null;
                }

                _context.AnswerChildQuestions.Remove(a);
            }
        }

        /// <summary>
        ///   The commit.
        /// </summary>
        public void Commit()
        {
            _context.Commit();
        }

        /// <summary>
        /// The create new answer.
        /// </summary>
        /// <param name="answer">
        /// The answer. 
        /// </param>
        public void CreateNewAnswer(IAnswer answer)
        {
            var ans = answer.ToEntity();
            ans.CreatedOn = DateTime.UtcNow;
            ans.UpdatedOn = DateTime.UtcNow;
            ans.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
            ans.CreatedBy = Thread.CurrentPrincipal.Identity.Name;
            ans.Header += string.Empty;
            ans.Directions += string.Empty;
            ans.Trailer += string.Empty;
            AddNewQuestionAnswer(ans);
        }

        /// <summary>
        /// The create new form.
        /// </summary>
        /// <param name="form">
        /// The form. 
        /// </param>
        public void CreateNewForm(IForm form)
        {
            var frm = form.ToEntity();

            frm.CreatedOn = DateTime.UtcNow;
            frm.UpdatedOn = DateTime.UtcNow;
            frm.CreatedBy = Thread.CurrentPrincipal.Identity.Name;
            frm.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
            frm.Header += string.Empty;
            frm.Title += string.Empty;
            frm.Description += string.Empty;
            frm.Directions += string.Empty;
            frm.Trailer += string.Empty;
            frm.StudyId = form.StudyId;
            Insert(frm);
        }

        /// <summary>
        /// The create new question.
        /// </summary>
        /// <param name="question">
        /// The question. 
        /// </param>
        public void CreateNewQuestion(IQuestion question)
        {
            var q = question.ToEntity();
            q.CreatedOn = DateTime.UtcNow;
            q.UpdatedOn = DateTime.UtcNow;
            q.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
            q.CreatedBy = Thread.CurrentPrincipal.Identity.Name;
            q.Description += string.Empty;
            q.Directions += string.Empty;
            q.Trailer += string.Empty;
            q.Header += string.Empty;
            q.ValidationRule = question.ValidationRule;

            AddNewFormQuestion(q);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity. 
        /// </param>
        public void Delete(Form entity)
        {
            var item = _context.Forms.FirstOrDefault(a => a.Id == entity.Id);
            if (item == null)
            {
                return;
            }

            item.IsActive = false;
            item.Status = (int)EntityStatusType.Deleted;
            item.UpdatedBy = entity.UpdatedBy ?? Thread.CurrentPrincipal.Identity.Name;
            item.UpdatedOn = DateTime.UtcNow;
        }

        /// <summary>
        /// The delete answer.
        /// </summary>
        /// <param name="answer">
        /// The answer. 
        /// </param>
        public void DeleteAnswer(IAnswer answer)
        {
            answer.IsActive = false;
            answer.Status = (int)EntityStatusType.Deleted;
            UpdateAnswer(answer);
        }

        /// <summary>
        /// The delete question.
        /// </summary>
        /// <param name="question">
        /// The question. 
        /// </param>
        public void DeleteQuestion(IQuestion question)
        {
            question.IsActive = false;
            question.Status = (int)EntityStatusType.Deleted;
            UpdateQuestion(question);
        }

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
        public IEnumerable<IForm> GetAllFormsPerStudy(int studyId, FormType formTypeId)
        {
            _context.AutoDetectChangesEnabled = false;
            var list = _context.Forms.Where(f => f.StudyId == studyId && f.FormTypeId == (int)formTypeId && f.IsActive).AsEnumerable();
            _context.AutoDetectChangesEnabled = true;
            return list.Cast<IForm>().ToList();
        }

        /// <summary>
        /// The get all forms per study.
        /// </summary>
        /// <param name="studyId">
        /// The study id. 
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/> . 
        /// </returns>
        public IEnumerable<IForm> GetAllFormsPerStudy(int studyId)
        {
            _context.AutoDetectChangesEnabled = false;
            var list = _context.Forms.Where(f => f.StudyId == studyId && f.IsActive).AsEnumerable();
            _context.AutoDetectChangesEnabled = true;
            return list.Cast<IForm>().ToList();
        }

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
        public IEnumerable<IForm> GetAllFormsPerStudy(int studyId, int size, int page)
        {
            _context.TrackChanges = false;
            var list = _context.Forms.Where(f => f.StudyId == studyId && f.IsActive).OrderBy(f => f.Id).Skip(size * page).Take(size).AsEnumerable();
            _context.TrackChanges = true;
            return list.Cast<IForm>().ToList();
        }

        /// <summary>
        /// The get answer.
        /// </summary>
        /// <param name="answerId">
        /// The answer id. 
        /// </param>
        /// <returns>
        /// The <see cref="IAnswer"/> . 
        /// </returns>
        public IAnswer GetAnswer(int answerId)
        {
            return _context.Answers.FirstOrDefault(a => a.Id == answerId && a.IsActive);
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id. 
        /// </param>
        /// <returns>
        /// The <see cref="Form"/> . 
        /// </returns>
        public Form GetById(object id)
        {
            _context.AutoDetectChangesEnabled = false;
            var frm = _context.Forms.FirstOrDefault(f => f.Id == (int)id);
            _context.AutoDetectChangesEnabled = true;
            return frm;
        }

        /// <summary>
        ///   The get current study id.
        /// </summary>
        /// <returns> The <see cref="IEnumerable" /> . </returns>
        public IEnumerable<int> GetCurrentStudyId()
        {
            return _context.Studies.Where(s => s.IsActive).Select(s => s.Id).AsEnumerable();
        }

        /// <summary>
        /// The get form.
        /// </summary>
        /// <param name="formId">
        /// The form id. 
        /// </param>
        /// <returns>
        /// The <see cref="IForm"/> . 
        /// </returns>
        public IForm GetForm(int formId)
        {
            var frm = GetById(formId);
            return frm;
        }

        /// <summary>
        /// The get form questions.
        /// </summary>
        /// <param name="formId">
        /// The form id. 
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/> . 
        /// </returns>
        public IEnumerable<IQuestion> GetFormQuestions(int formId)
        {
            _context.TrackChanges = false;
            var list = _context.Questions.Where(q => q.FormId == formId && q.IsActive).AsEnumerable();
            _context.TrackChanges = true;
            return list.Cast<IQuestion>().ToList();
        }

        /// <summary>
        /// The get question.
        /// </summary>
        /// <param name="questionId">
        /// The question id. 
        /// </param>
        /// <returns>
        /// The <see cref="IQuestion"/> . 
        /// </returns>
        public IQuestion GetQuestion(int questionId)
        {
            return _context.Questions.FirstOrDefault(q => q.Id == questionId && q.IsActive);
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity. 
        /// </param>
        public void Insert(Form entity)
        {
            _context.Forms.Add(entity.ToEntity());
        }

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
        public void MarkSubjectFormAsReadOnly(int formId, int subjectId, int appUserId, int lockFor = 30)
        {
            var lockedForm = _context.FormInProcesses.FirstOrDefault(f => f.FormId == formId && f.SubjectId == subjectId);
            if (lockedForm == null)
            {
                lockedForm = new FormInProcess();
                _context.FormInProcesses.Add(lockedForm);
            }

            lockedForm.FormId = formId;
            lockedForm.SubjectId = subjectId;
            lockedForm.AppUserId = appUserId;
            lockedForm.IsLocked = true;
            lockedForm.MaxLockTimeMin = lockFor;
            lockedForm.OpenendOn = DateTime.UtcNow;
        }

        /// <summary>
        /// The mark subject form as read only.
        /// </summary>
        /// <param name="form">
        /// The form. 
        /// </param>
        public void MarkSubjectFormAsReadOnly(IFormInProcess form)
        {
            MarkSubjectFormAsReadOnly(form.FormId, form.SubjectId, form.AppUserId, form.MaxLockTimeMin);
        }

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
        public void UnlockFormFromReadOnly(int formId, int subjectId, int appUserId)
        {
            var lockedForm = _context.FormInProcesses.FirstOrDefault(f => f.FormId == formId && f.SubjectId == subjectId);
            if (lockedForm == null)
            {
                lockedForm = new FormInProcess();
                _context.FormInProcesses.Add(lockedForm);
            }

            lockedForm.FormId = formId;
            lockedForm.SubjectId = subjectId;
            lockedForm.AppUserId = 0;
            lockedForm.IsLocked = false;
            lockedForm.ReleasedOn = DateTime.UtcNow;
            lockedForm.UnlockedByAppUserId = appUserId;
        }

        /// <summary>
        /// The unlock form from read only.
        /// </summary>
        /// <param name="form">
        /// The form. 
        /// </param>
        public void UnlockFormFromReadOnly(IFormInProcess form)
        {
            UnlockFormFromReadOnly(form.FormId, form.SubjectId, form.AppUserId);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity. 
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public void Update(Form entity)
        {
            var form = _context.Forms.FirstOrDefault(f => f.Id == entity.Id);
            if (form == null)
            {
                throw new Exception(string.Format("Record Id:{0} Not found", entity.Id));
            }

            form.Code = entity.Code;
            form.Description = entity.Description;
            form.IsDoubleChecked = entity.IsDoubleChecked;
            form.FormTypeId = entity.FormTypeId;
            form.Header = entity.Header;
            form.IsActive = entity.IsActive;
            form.IsFilledBySubject = entity.IsFilledBySubject;
            form.LayoutTypeId = entity.LayoutTypeId;
            form.Name = entity.Name;
            form.ShowTotalScore = entity.ShowTotalScore;
            form.SortOrder = entity.SortOrder;
            form.Status = entity.Status;
            form.StudyId = entity.StudyId;
            form.Title = entity.Title;
            form.Trailer = entity.Trailer;
            form.UpdatedBy = entity.UpdatedBy;
            form.UpdatedOn = entity.UpdatedOn;
        }

        /// <summary>
        /// The update answer.
        /// </summary>
        /// <param name="answer">
        /// The answer. 
        /// </param>
        public void UpdateAnswer(IAnswer answer)
        {
            var ans = _context.Answers.FirstOrDefault(a => a.Id == answer.Id);
            if (ans != null)
            {
                ans.Code = answer.Code;
                ans.Directions = answer.Directions;
                ans.Header = answer.Header;
                ans.IsActive = answer.IsActive;
                ans.OptionText = answer.OptionText;
                ans.Score = answer.Score;
                ans.SortOrder = answer.SortOrder;
                ans.Status = answer.Status;
                ans.Trailer = answer.Trailer;
                ans.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
                ans.UpdatedOn = DateTime.UtcNow;
            }
        }

        /****************************************************/

        /// <summary>
        /// The update form.
        /// </summary>
        /// <param name="form">
        /// The form. 
        /// </param>
        public void UpdateForm(IForm form)
        {
            form.UpdatedOn = DateTime.UtcNow;
            form.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
            Update(form.ToEntity());
        }

        /// <summary>
        /// The update question.
        /// </summary>
        /// <param name="question">
        /// The question. 
        /// </param>
        public void UpdateQuestion(IQuestion question)
        {
            var q = _context.Questions.FirstOrDefault(qu => qu.Id == question.Id);
            if (q != null)
            {
                q.Code = question.Code;
                q.Description = question.Description;
                q.Directions = question.Directions;
                q.FieldDataTypeId = question.FieldDataTypeId;
                q.Header = question.Header;
                q.IsActive = question.IsActive;
                q.IsRequired = question.IsRequired;
                q.IsParent = question.IsParent;
                q.ParentQuestionId = question.ParentQuestionId;
                q.QuestionText = question.QuestionText;
                q.SortOrder = question.SortOrder;
                q.Status = question.Status;
                q.Trailer = question.Trailer;
                q.UpdatedBy = Thread.CurrentPrincipal.Identity.Name;
                q.UpdatedOn = DateTime.UtcNow;
                q.ValidationRule = question.ValidationRule;
            }
        }

        #endregion

        ///// <summary>
        ///// The get question answers.
        ///// </summary>
        ///// <param name="questionId">
        ///// The question id.
        ///// </param>
        ///// <returns>
        ///// The <see cref="IEnumerable"/>.
        ///// </returns>
        #region Explicit Interface Methods

        /// <summary>
        /// The get question answers.
        /// </summary>
        /// <param name="questionId">
        /// The question id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<IAnswer> IFormRepository.GetQuestionAnswers(int questionId)
        {
            _context.TrackChanges = false;
            var list = _context.Answers.Where(a => a.QuestionId == questionId && a.IsActive).AsEnumerable();
            _context.TrackChanges = true;
            return list.Cast<IAnswer>().ToList();
        }

        #endregion
    }
}