using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Tateeda.Clires.Core.Utility;

namespace Tateeda.Clires.Areas.Utilities.Controllers
{
	using Tateeda.Clires.Data.UOW;

	using global::System.IO;
	using global::System.Text;

	public class UtilController : Controller
	{

		public UtilController()
		{

		}

		public FileResult FileViewer(int fileId)
		{
			using (var uow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var file = uow.FileRepository.GetFile(fileId);
				return new FileStreamResult(new MemoryStream(file.FielContent), file.FileType);
			}
		}

		public void UploadSubjectFile(HttpPostedFileBase file, int subjectId)
		{
			if (file != null)
			{
				if (IsValidFile(file))
				{
					var length = file.ContentLength;
					var tempFile = new byte[length];

					file.InputStream.Read(tempFile, 0, length);
					var fo = new global::Tateeda.Clires.Core.Data.EF.File
						{
							CreatedBy = User.Identity.Name,
							CreatedOn = DateTime.UtcNow,
							Name = file.FileName,
							FileType = file.ContentType,
							FielContent = tempFile
						};
					using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
					{
						adminUow.FileRepository.AddSubjectFile(subjectId, fo);
						adminUow.Commit();
					}
				}
			}
			var urlReferrer = this.Request.UrlReferrer != null ? Request.UrlReferrer.OriginalString : "~/";

			this.Response.Redirect(urlReferrer);
		}

		private bool IsValidFile(HttpPostedFileBase file)
		{
			var ext = file.FileName.Split(new[] { '.' });
			var valid = true;
			valid = !(ext.Contains("exe") || ext.Contains("js") || ext.Contains("vb") || ext.Contains("bat"));
			if (file.ContentLength > 10485760)
			{
				valid = false;
			}
			return valid;
		}
	}
}
