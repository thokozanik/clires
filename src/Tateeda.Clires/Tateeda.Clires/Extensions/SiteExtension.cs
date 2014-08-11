namespace Tateeda.Clires.Extensions
{
	using Tateeda.Clires.Areas.Admin.Model.Site;
	using Tateeda.Clires.Core.Data.EF;

	using global::System.Collections.Generic;
	using global::System.Diagnostics;
	using global::System.Linq;

	public static class SiteExtension
	{
		public static SiteViewModel ToModel(this ISite site)
		{
			Debug.Assert(site.Studies != null, "site.Studies != null");
			var studyId = site.Studies.FirstOrDefault() != null ? site.Studies.FirstOrDefault().Id : 0;
			return new SiteViewModel
				{
					Code = site.Code,
					CreatedBy = site.CreatedBy,
					CreatedOn = site.CreatedOn,
					Directions = site.Directions,
					Id = site.Id,
					IsActive = site.IsActive,
					IsPrimary = site.IsPrimary,
					Name = site.Name,
					SortOrder = site.SortOrder,
					Status = site.Status,
					TimeZoneId = site.TimeZoneId,
					UpdatedBy = site.UpdatedBy,
					UpdatedOn = site.UpdatedOn,
					TimeZoneName = string.Format("{0} [{1}]", site.TimeZone.Name, site.TimeZone.Offset),
					StudyId = studyId
				};
		}
	}
}