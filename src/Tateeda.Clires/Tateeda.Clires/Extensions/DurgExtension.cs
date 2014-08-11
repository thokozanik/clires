// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DurgExtension.cs" company="Tateeda Media Network">
//   Tateeda Media Network. http://tateeda.com
// </copyright>
// <summary>
//   Defines the DurgExtension type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Extensions {
    using global::System.Collections.Generic;

    using global::System.Linq;

    using Tateeda.Clires.Areas.Admin.Model.Drugs;
    using Tateeda.Clires.Core.Data.EF;

    public static class DurgExtension {

        public static IEnumerable<DrugViewModel> ToModel(this IEnumerable<IDrug> entities)
        {
            IEnumerable<DrugViewModel> list = entities.Select(d => d.ToModel()).ToList();
            return list;
        }

        public static DrugViewModel ToModel(this IDrug entity)
        {
            return new DrugViewModel
                {
                   CreatedBy = entity.CreatedBy,
                   CreatedOn = entity.CreatedOn,
                   Directions = entity.Directions,
                   Description = entity.Description,
                   DrugClassId = entity.DrugClassId,
                   DrugTypeId = entity.DrugTypeId,
                   Id = entity.Id,
                   IsActive = entity.IsActive,
                   Name = entity.Name,
                   SortOrder = entity.SortOrder,
                   Status = entity.Status,
                   StudyId = entity.StudyId,
                   UpdatedBy = entity.UpdatedBy,
                   UpdatedOn = entity.UpdatedOn,
                   DrugCategoryId = entity.DrugClass.DrugCategoryId
                };
        }

        public static DrugClassViewModel ToModel(this IDrugClass entity)
        {
            return new DrugClassViewModel
                {
                    CreatedBy = entity.CreatedBy,
                    CreatedOn = entity.CreatedOn,
                    Directions = entity.Directions,
                    Description = entity.Description,
                    Id = entity.Id,
                    IsActive = entity.IsActive,
                    Name = entity.Name,
                    SortOrder = entity.SortOrder,
                    Status = entity.Status,
                    UpdatedBy = entity.UpdatedBy,
                    UpdatedOn = entity.UpdatedOn,
                    DrugCategoryId = entity.DrugCategoryId
                };
        }

        public static DrugCategoryViewModel ToModel(this IDrugCategory entity)
        {
            return new DrugCategoryViewModel
                {
                    CreatedBy = entity.CreatedBy,
                    CreatedOn = entity.CreatedOn,
                    Directions = entity.Directions,
                    Description = entity.Description,
                    Id = entity.Id,
                    IsActive = entity.IsActive,
                    Name = entity.Name,
                    SortOrder = entity.SortOrder,
                    Status = entity.Status,
                    UpdatedBy = entity.UpdatedBy,
                    UpdatedOn = entity.UpdatedOn,
                    Code = entity.Code
                };
        }
    }
}