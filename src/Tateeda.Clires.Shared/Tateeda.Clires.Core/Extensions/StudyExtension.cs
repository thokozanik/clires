// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudyExtension.cs" company="">
//   
// </copyright>
// <summary>
//   The study extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Extensions
{
    using Tateeda.Clires.Core.Data.EF;

    /// <summary>
    /// The study extension.
    /// </summary>
    public static class StudyExtension
    {
        #region Public Methods and Operators

        /// <summary>
        /// The to entity.
        /// </summary>
        /// <param name="study">
        /// The study.
        /// </param>
        /// <returns>
        /// The <see cref="Study"/>.
        /// </returns>
        public static Study ToEntity(this IStudy study)
        {
            return new Study
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

        #endregion
    }
}