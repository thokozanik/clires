namespace Tateeda.Clires.Areas.Admin.Controllers
{
	#region - Using -

	using global::System;
	using global::System.Collections.Generic;

	using global::System.Linq;

	using global::System.Text;

	using global::System.Threading.Tasks;

	using global::System.Web.Mvc;

	using global::System.Web.Script.Serialization;

	using Tateeda.Clires.Areas.Admin.Model.Forms;
	using Tateeda.Clires.Areas.Admin.Model.Matrix;
	using Tateeda.Clires.Core.Data.EF;
	using Tateeda.Clires.Core.Visits;
	using Tateeda.Clires.Data.UOW;
	using Tateeda.Clires.System;

	#endregion

	/// <summary>
	/// The mapping controller.
	/// </summary>
	[Authorize(Roles = GlobalVariables.RoleSystemAdmin)]
	public class MappingController : BaseController
	{
		#region Public Methods and Operators

		/// <summary>
		/// The index.
		/// </summary>
		/// <returns>
		/// The <see cref="ActionResult"/>.
		/// </returns>
		public ActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// The map.
		/// </summary>
		/// <param name="id">
		/// The id.
		/// </param>
		/// <returns>
		/// The <see cref="ActionResult"/>.
		/// </returns>
		public JsonResult Map(int id)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var visits = adminUow.VisitRepository.GetAllVisits(id);
				var allForms = adminUow.FormRepository.GetAllFormsPerStudy(id);
				var allFormsList = allForms as List<IForm> ?? allForms.ToList();
				var matrix = from v in visits
							 let forms = adminUow.VisitRepository.GetVisitForms(v.Id)
							 select new VisitFormsView { Forms = forms, Visit = v, AllForms = allFormsList };

				var tbl = string.Empty;
				var t = Task.Factory.StartNew(() => { tbl = GetMappingTable(allFormsList, matrix); });

				t.Wait();

				return this.Json(tbl, JsonRequestBehavior.AllowGet);
			}
		}

		/// <summary>
		/// The settings.
		/// </summary>
		/// <returns>
		/// The <see cref="ActionResult"/>.
		/// </returns>
		public ActionResult Settings()
		{
			return View();
		}

		/// <summary>
		/// The update settings.
		/// </summary>
		/// <param name="mapping">
		/// The mapping.
		/// </param>
		/// <returns>
		/// The <see cref="JavaScriptResult"/>.
		/// </returns>
		[HttpPost]
		public JavaScriptResult UpdateSettings(string mapping)
		{
			try
			{
				using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
				{
					var jss = new JavaScriptSerializer();
					var data = jss.Deserialize<List<FormViewModel>>(mapping);
					var settings = data.FirstOrDefault();
					if (settings != null)
					{
						var visitId = settings.VisitId;
						adminUow.VisitRepository.ClearVisitFormsAssosiation(visitId);
						adminUow.Commit();

						adminUow.VisitRepository.AssosiateVisitForms(visitId, data);
					}

					adminUow.Commit();
				}
			}
			catch (Exception ex)
			{
				_logger.LogException(NLog.LogLevel.Error, ex.Message, ex);
				return new JavaScriptResult { Script = "error" };
			}

			return new JavaScriptResult { Script = "success" };
		}

		#endregion

		#region Methods

		/// <summary>
		/// The get mapping table.
		/// </summary>
		/// <param name="allForms">
		/// The all forms.
		/// </param>
		/// <param name="visits">
		/// The visits.
		/// </param>
		/// <returns>
		/// The <see cref="string"/>.
		/// </returns>
		private string GetMappingTable(IEnumerable<IForm> allForms, IEnumerable<IVisitForms> visits)
		{
			var sb = new StringBuilder();
			sb.Append("<table class='highlight-row'>");
			sb.Append("<tr>");
			sb.Append("<th>Forms/Visits</th>");

			var visitFormses = visits as List<IVisitForms> ?? visits.ToList();
			var vs = visitFormses;
			var header = string.Empty;

			var taskH = Task.Factory.StartNew(() =>
			{
				if (visitFormses != null)
				{
					header = this.GetTopRowForMetrixMapping(visitFormses);
				}
			});
			taskH.Wait();

			sb.Append(header);

			sb.Append("</tr>");
			foreach (var f in allForms.AsParallel())
			{
				sb.Append("<tr>");
				sb.AppendFormat("<td class='cell-center-bold nowrap'>{0}</td>", f.Name);

				foreach (var v in vs)
				{
					sb.Append(v.Forms.Any(i => i.Id == f.Id) ? "<td class='cell-center-bold'>X</td>" : "<td class=cell-center-bold'>&nbsp;</td>");
				}

				sb.Append("</tr>");
			}

			sb.Append("</table>");

			return sb.ToString();
		}

		/// <summary>
		/// The get top row for metrix mapping.
		/// </summary>
		/// <param name="vs">
		/// The vs.
		/// </param>
		/// <returns>
		/// The <see cref="string"/>.
		/// </returns>
		private string GetTopRowForMetrixMapping(IEnumerable<IVisitForms> vs)
		{
			var sb = new StringBuilder();
			foreach (IVisitForms v in vs)
			{
				sb.AppendFormat("<th>{0}</th>", v.Visit.Name);
			}

			return sb.ToString();
		}

		#endregion
	}
}