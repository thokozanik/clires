using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace Tateeda.Clires.Utility
{
	using Tateeda.Clires.Data.UOW;
	using Tateeda.Clires.Extensions;

	public class EnumerationHelper : IEnumerationHelper
	{
		private const string Select = "Select";

		public IEnumerable<SelectListItem> GetOptions(int typeId)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.CodeRepository.GetCodeTypeEnumeration(typeId);
				var list = new List<SelectListItem> { new SelectListItem { Value = null, Text = Select } };
				list.AddRange(options.Select(op => new SelectListItem { Value = op.EnumId.ToString(CultureInfo.InvariantCulture), Text = op.Name }));

				return list.AsEnumerable();
			}
		}

		public IEnumerable<SelectListItem> GetStudies(bool showAll)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.CodeRepository.GetStudyList(showAll);
				var list = new List<SelectListItem> { new SelectListItem { Value = null, Text = Select } };
				list.AddRange(options.Select(op => new SelectListItem { Value = op.Id.ToString(CultureInfo.InvariantCulture), Text = op.Name }));

				return list.AsEnumerable();
			}
		}

		public IEnumerable<SelectListItem> GetSites()
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.CodeRepository.GetSitesList();
				var list = new List<SelectListItem> { new SelectListItem { Value = null, Text = Select } };
				list.AddRange(options.Select(op => new SelectListItem { Value = op.Id.ToString(CultureInfo.InvariantCulture), Text = op.Name }));

				return list.AsEnumerable();
			}
		}

		public IEnumerable<SelectListItem> GetTimeZones()
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.CodeRepository.GetTimeZones();
				var list = new List<SelectListItem> { new SelectListItem { Value = null, Text = Select } };
				list.AddRange(options.Select(op => new SelectListItem { Value = op.Id.ToString(CultureInfo.InvariantCulture), Text = op.Name }));
				return list.AsEnumerable();
			}
		}

		public MultiSelectList GetFormQuestions(int formId, int excludeQuestionId = 0)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.FormRepository.GetFormQuestions(formId);
                if (excludeQuestionId > 0)
                {
                    options = options.Where(o => o.Id != excludeQuestionId);
                }

				var data = options.Select(op => new SelectListItem
							{
								Value = op.Id.ToString(),
								Text = string.Format(
										"{0}...",
										(op.Code + "-" + op.QuestionText).Length > 50
											? (op.Code + "-" + op.QuestionText).Substring(0, 50)
											: op.Code + "-" + op.QuestionText)
							}).AsEnumerable();

				return new MultiSelectList(data, "Value", "Text");
			}
		}

		public IEnumerable<SelectListItem> GetRoles()
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.CodeRepository.GetRolesList();
				var list = new List<SelectListItem>() { new SelectListItem { Value = null, Text = Select } };
				list.AddRange(options.Select(op => new SelectListItem { Value = op.RoleId.ToString(), Text = op.RoleName }));

				return list.AsEnumerable();
			}
		}

		public IEnumerable<SelectListItem> GetGender()
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.CodeRepository.GetGender();
				var list = new List<SelectListItem> { new SelectListItem { Value = null, Text = Select } };
				list.AddRange(options.Select(op => new SelectListItem { Value = op.EnumId.ToString(), Text = op.Name }));

				return list.AsEnumerable();
			}
		}

		public IEnumerable<SelectListItem> GetCountries()
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.CodeRepository.GetCountries();
				var list = new List<SelectListItem> { new SelectListItem { Value = null, Text = Select } };
				list.AddRange(options.Select(op => new SelectListItem { Value = op.Id.ToString(CultureInfo.InvariantCulture), Text = op.Name }));

				return list.AsEnumerable();
			}
		}

		public IEnumerable<SelectListItem> GetStates(int id = 1)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.CodeRepository.GetStates(id).ToList();
				var list = new List<SelectListItem> { new SelectListItem { Value = null, Text = Select } };
				list.AddRange(options.Select(op => new SelectListItem { Value = op.Id.ToString(CultureInfo.InvariantCulture), Text = op.Name }));

				return list.AsEnumerable();
			}
		}

		public IEnumerable<SelectListItem> GetPhoneTypes()
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.CodeRepository.GetPhoneTypes();
				var list = new List<SelectListItem> { new SelectListItem { Value = "0", Text = Select } };
				list.AddRange(options.Select(op => new SelectListItem { Value = op.EnumId.ToString(CultureInfo.InvariantCulture), Text = op.Name }));

				return list.AsEnumerable();
			}
		}

		public IEnumerable<SelectListItem> GetAddressTypes()
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.CodeRepository.GetAddressTypes();
				var list = new List<SelectListItem> { new SelectListItem { Value = "0", Text = Select } };
				list.AddRange(options.Select(op => new SelectListItem { Value = op.EnumId.ToString(CultureInfo.InvariantCulture), Text = op.Name }));

				return list.AsEnumerable();
			}
		}

		public IEnumerable<SelectListItem> GetSiteSubjects(int studyId, int siteId)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.SubjectRepository.GetAllSiteSubjects(studyId, siteId);
				var list = new List<SelectListItem> { new SelectListItem { Text = Select, Value = null } };
				list.AddRange(
					options.Select(
						op =>
						new SelectListItem { Value = op.Id.ToString(), Text = string.Format("{0} [{1} {2}]", op.Id, op.Contact.FirstName, op.Contact.LastName) }));

				return list.AsEnumerable();
			}
		}

		public IEnumerable<SelectListItem> GetSiteUsers(int siteId)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.UserRepository.GetSiteUsers(siteId);
				var list = new List<SelectListItem> { new SelectListItem { Text = Select, Value = null } };
				list.AddRange(
					options.Select(
						op => new SelectListItem { Value = op.Id.ToString(), Text = string.Format("{0} {1}", op.Contact.FirstName, op.Contact.LastName) }));

				return list.AsEnumerable();
			}
		}

		public IEnumerable<SelectListItem> GetStudyArms(int studyId)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.StudyRepository.GetStudyArms(studyId);
				var list = new List<SelectListItem> { new SelectListItem { Value = null, Text = Select } };
				list.AddRange(options.Select(op => new SelectListItem { Value = op.Id.ToString(), Text = op.Name }));

				return list.AsEnumerable();
			}
		}

		public IEnumerable<SelectListItem> GetVistis(int studyId)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.VisitRepository.GetAllVisits(studyId).Select(v => v.ToModel());

				var list = new List<SelectListItem> { new SelectListItem { Text = Select, Value = "-1" } };
				list.AddRange(options.Select(op => new SelectListItem { Value = op.Id.ToString(), Text = op.Name }));

				return list.AsEnumerable();
			}
		}

		public IEnumerable<SelectListItem> GetDrugCategories()
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.DrugsRepository.GetAllDrugCategories().Select(c => c.ToModel());
				var list = new List<SelectListItem> { new SelectListItem { Value = null, Text = Select } };
				list.AddRange(options.Select(op => new SelectListItem { Value = op.Id.ToString(), Text = op.Name }));

				return list.AsEnumerable();
			}
		}

		public IEnumerable<SelectListItem> GetDrugClasses(int categoryId)
		{
			using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
			{
				var options = adminUow.DrugsRepository.GetDrugClasses(categoryId).Select(c => c.ToModel());
				var list = new List<SelectListItem> { new SelectListItem { Value = null, Text = Select } };
				list.AddRange(options.Select(op => new SelectListItem { Value = op.Id.ToString(CultureInfo.InvariantCulture), Text = op.Name }));

				return list.AsEnumerable();
			}
		}
	}
}