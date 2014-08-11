using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tateeda.Clires.Core.Data.EF;
using Tateeda.Clires.Core.Data.Enums;
using Tateeda.Clires.Core.Forms;

namespace Tateeda.Clires.CodeTest.EFFakes {
    internal class FormRepositoryFake : IFormRepository {
        private List<Form>_forms = new List<Form>(); 
        #region Implementation of IRepository<Form>

        public IQueryable<Form> All { get; private set; }
        public Form GetById(object id)
        {
            return _forms.FirstOrDefault(f => f.Id == (int) id);
        }

        public void Insert(Form entity)
        {
           _forms.Add(entity);
        }

        public void Update(Form entity)
        {
            var cur = GetById(entity.Id);
            Delete(cur);
            Insert(entity);
        }

        public void Delete(Form entity)
        {
            _forms.Remove(entity);
        }

        public void Commit()
        {
            
        }

        #endregion

        #region Implementation of IFormRepository

        public IEnumerable<int> GetCurrentStudyId()
        {
            throw new NotImplementedException();
        }

        public IForm GetForm(int formId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IForm> GetAllFormsPerStudy(int studyId, FormType formTypeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IForm> GetAllFormsPerStudy(int studyId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IForm> GetAllFormsPerStudy(int studyId, int size, int page)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IQuestion> GetFormQuestions(int formId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAnswer> GetQuestionAnswers(int questionId)
        {
            throw new NotImplementedException();
        }

        public void AddNewFormQuestion(IQuestion question)
        {
            throw new NotImplementedException();
        }

        public void AddNewQuestionAnswer(IAnswer answer)
        {
            throw new NotImplementedException();
        }

        public void UpdateForm(IForm form)
        {
            throw new NotImplementedException();
        }

        public void UpdateQuestion(IQuestion question)
        {
            throw new NotImplementedException();
        }

        public void UnlockFormFromReadOnly(IFormInProcess form)
        {
            throw new NotImplementedException();
        }

        public void UpdateAnswer(IAnswer answer)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(IQuestion question)
        {
            throw new NotImplementedException();
        }

        public void CreateNewQuestion(IQuestion question)
        {
            throw new NotImplementedException();
        }

        public void DeleteAnswer(IAnswer answer)
        {
            throw new NotImplementedException();
        }

        public IQuestion GetQuestion(int questionId)
        {
            throw new NotImplementedException();
        }

        public IAnswer GetAnswer(int answerId)
        {
            throw new NotImplementedException();
        }

        public void AddAnswerChildQuestionsMapping(int answerId, IEnumerable<int> questionsId)
        {
            throw new NotImplementedException();
        }

        public void ClearAnswerChildQuestions(int answerId)
        {
            throw new NotImplementedException();
        }

        public void CreateNewAnswer(IAnswer answer)
        {
            throw new NotImplementedException();
        }

        public void CreateNewForm(IForm form)
        {
            throw new NotImplementedException();
        }

        public bool CanOpenFormToWriteForSubject(int formId, int subjectId, int appUserId)
        {
            throw new NotImplementedException();
        }

        public bool CanOpenFormToWriteForSubject(int formId, int subjectId)
        {
            throw new NotImplementedException();
        }

        public void MarkSubjectFormAsReadOnly(int formId, int subjectId, int appUserId, int lockFor = 30)
        {
            throw new NotImplementedException();
        }

        public void MarkSubjectFormAsReadOnly(IFormInProcess form)
        {
            throw new NotImplementedException();
        }

        public void UnlockFormFromReadOnly(int formId, int subjectId, int appUserId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
