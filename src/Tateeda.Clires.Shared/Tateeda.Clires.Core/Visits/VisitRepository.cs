// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VisitRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The visit repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Visits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Tateeda.Clires.Core.Data.EF;
    using Tateeda.Clires.Core.Data.Enums;

    /// <summary>
    /// The visit repository.
    /// </summary>
    public class VisitRepository : IVisitRepository
    {
        #region Fields

        /// <summary>
        ///   The _context.
        /// </summary>
        private readonly IDbContext _context;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VisitRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context. 
        /// </param>
        public VisitRepository(IDbContext context)
        {
            _context = context;
            All = _context.Visits;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the all.
        /// </summary>
        public IQueryable<Visit> All { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The assosiate visit forms.
        /// </summary>
        /// <param name="visitId">
        /// The visit id.
        /// </param>
        /// <param name="forms">
        /// The forms.
        /// </param>
        public void AssosiateVisitForms(int visitId, IEnumerable<IForm> forms)
        {
            foreach (var form in forms)
            {
                _context.VisitForms.Add(new VisitForm { FormId = form.Id, VisitId = visitId });
            }
        }

        /// <summary>
        /// The clear visit forms assosiation.
        /// </summary>
        /// <param name="visitId">
        /// The visit id.
        /// </param>
        public void ClearVisitFormsAssosiation(int visitId)
        {
            var list = _context.VisitForms.Where(v => v.VisitId == visitId);
            foreach (var v in list)
            {
                _context.VisitForms.Remove(v);
            }
        }

        /// <summary>
        /// The commit.
        /// </summary>
        public void Commit()
        {
            _context.Commit();
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Delete(Visit entity)
        {
            var item = _context.Visits.FirstOrDefault(a => a.Id == entity.Id);
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
        /// The get all visits.
        /// </summary>
        /// <param name="studyId">
        /// The study id.
        /// </param>
        /// <param name="all">
        /// The all.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<IVisit> GetAllVisits(int studyId, bool all = false)
        {
            return all
                       ? _context.Visits.Where(v => v.Arm.StudyId == studyId).AsEnumerable()
                       : _context.Visits.Where(v => v.Arm.StudyId == studyId && v.IsActive).AsEnumerable();
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Visit"/>.
        /// </returns>
        public Visit GetById(object id)
        {
            return _context.Visits.FirstOrDefault(v => v.Id == (int)id);
        }

        /// <summary>
        /// The get visit forms.
        /// </summary>
        /// <param name="visitId">
        /// The visit id. 
        /// </param>
        /// <param name="all">
        /// The all. 
        /// </param>
        /// <returns>
        /// The visit forms list 
        /// </returns>
        public IEnumerable<IForm> GetVisitForms(int visitId, bool all = false)
        {
            _context.AutoDetectChangesEnabled = false;
            var visit = _context.VisitForms.Where(v => v.VisitId == visitId);
            _context.AutoDetectChangesEnabled = true;
            return visit.Select(v => v.Form).AsEnumerable();
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Insert(Visit entity)
        {
            _context.Visits.Add(entity);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public void Update(Visit entity)
        {
            var current = _context.Visits.FirstOrDefault(v => v.Id == entity.Id);
            if (current != null)
            {
                var parentId = current.ParentVisitId;

                if (parentId != null && (entity.ParentVisitId == null || entity.ParentVisitId == 0))
                {
                    var parent = GetById(parentId);
                    parent.HasChild = false;
                }

                current.ArmId = entity.ArmId;
                current.Code = entity.Code;
                current.Directions = entity.Directions;
                current.IsActive = entity.IsActive;
                current.Name = entity.Name;
                current.SortOrder = entity.SortOrder;
                current.Status = entity.Status;
                current.UpdatedBy = entity.UpdatedBy;
                current.UpdatedOn = DateTime.UtcNow;
                current.HasChild = entity.HasChild;
                current.IsBaseVisit = entity.IsBaseVisit;
                current.CanMove = entity.CanMove;
                current.CanRepeat = entity.CanRepeat;
                current.ParentVisitId = entity.ParentVisitId;
            }
        }

        #endregion
    }
}