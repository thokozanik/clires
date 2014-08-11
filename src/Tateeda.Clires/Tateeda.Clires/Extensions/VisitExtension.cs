namespace Tateeda.Clires.Extensions
{
    using Core.Data.EF;

    using Tateeda.Clires.Areas.Admin.Model.Study;

    public static class VisitExtension
    {
        public static VisitViewModel ToModel(this IVisit visit)
        {
            return new VisitViewModel
                {
                    ArmId = visit.ArmId,
                    Code = visit.Code,
                    CreatedBy = visit.CreatedBy,
                    CreatedOn = visit.CreatedOn,
                    Directions = visit.Directions,
                    Id = visit.Id,
                    IsActive = visit.IsActive,
                    Name = visit.Name,
                    SortOrder = visit.SortOrder,
                    Status = visit.Status,
                    StudyId = visit.Arm.StudyId,
                    UpdatedBy = visit.UpdatedBy,
                    UpdatedOn = visit.UpdatedOn,
                    VisitTypeId = visit.VisitTypeId,
                    CanMove = visit.CanMove,
                    CanRepeat = visit.CanRepeat,
                    HasChild = visit.HasChild,
                    ParentVisitId = visit.ParentVisitId,
                    IsBaseVisit = visit.IsBaseVisit,
                    FormsCount = visit.VisitForms.Count,
                    ArmName = visit.Arm.Name,
                    ParentVisitName = visit.ParentVisit != null ? visit.ParentVisit.Name : ""
                };
        }

        public static Visit ToEntity(this VisitViewModel visit)
        {
            return new Visit {
                ArmId = visit.ArmId,
                Code = visit.Code,
                CreatedBy = visit.CreatedBy,
                CreatedOn = visit.CreatedOn,
                Directions = visit.Directions,
                Id = visit.Id,
                IsActive = visit.IsActive,
                Name = visit.Name,
                SortOrder = visit.SortOrder,
                Status = visit.Status,
                UpdatedBy = visit.UpdatedBy,
                UpdatedOn = visit.UpdatedOn,
                VisitTypeId = visit.VisitTypeId,
                CanMove = visit.CanMove,
                CanRepeat = visit.CanRepeat,
                HasChild = visit.HasChild,
                ParentVisitId = visit.ParentVisitId,
                IsBaseVisit = visit.IsBaseVisit
            };
        }
    }
}