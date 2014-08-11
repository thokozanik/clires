namespace Tateeda.Clires.Extensions
{
    using Core.Data.EF;

    using Tateeda.Clires.Areas.Admin.Model.Study;

    public static class StudyExtension
    {
        public static StudyViewModel ToModel(this IStudy study)
        {
            return new StudyViewModel
                {
                    CreatedBy = study.CreatedBy,
                    CreatedOn = study.CreatedOn,
                    Description = study.Description,
                    Id = study.Id,
                    IsActive = study.IsActive,
                    Name = study.Name,
                    SortOrder = study.SortOrder,
                    Status = study.Status,
                    UpdatedBy = study.UpdatedBy,
                    UpdatedOn = study.UpdatedOn,
                    Budget = study.Budget,
                    EndDate = study.EndDate,
                    Goal = study.Goal,
                    StartDate = study.StartDate,
                    Target = study.Target
                };
        }

        public static ArmViewModel ToModel(this IArm arm)
        {
            return new ArmViewModel
                {
                    Id = arm.Id,
                    IsActive = arm.IsActive,
                    Name = arm.Name,
                    Code = arm.Code,
                    UpdatedBy = arm.UpdatedBy,
                    UpdatedOn = arm.UpdatedOn,
                    CreatedBy = arm.CreatedBy,
                    CreatedOn = arm.CreatedOn,
                    Description = arm.Description,
                    StudyId = arm.StudyId
                };
        }
        public static Arm ToEntity(this ArmViewModel arm)
        {
            return new Arm
            {
                Id = arm.Id,
                IsActive = arm.IsActive,
                Name = arm.Name,
                Code = arm.Code,
                UpdatedBy = arm.UpdatedBy,
                UpdatedOn = arm.UpdatedOn,
                CreatedBy = arm.CreatedBy,
                CreatedOn = arm.CreatedOn,
                Description = arm.Description,
                StudyId = arm.StudyId
            };
        }
        public static VisitStepModel ToModel(this IVisitStep step)
        {
            return new VisitStepModel
                {
                    Name = step.Name,
                    Directions = step.Directions,
                    SortOrder = step.SortOrder,
                    Status = step.Status,
                    CreatedOn = step.CreatedOn,
                    CreatedBy = step.CreatedBy,
                    UpdatedBy = step.UpdatedBy,
                    UpdatedOn = step.UpdatedOn,
                    IsActive = step.IsActive,
                    Id = step.Id
                };
        }

        public static VisitStepVisitSequenceViewModel ToModel(this IVisitStepVisitSequence entity)
        {
            return new VisitStepVisitSequenceViewModel
                {
                    DaysFromBase = entity.DaysFromBase,
                    Deviation = entity.Deviation,
                    Id = entity.Id,
                    IsActive = entity.IsActive,
                    SortOrder = entity.SortOrder,
                    VisitId = entity.VisitId,
                    VisitName = entity.Visit.Name,
                    VisitStepId = entity.VisitStepId,
                    IsTermination = entity.IsTermination
                };
        }
    }
}