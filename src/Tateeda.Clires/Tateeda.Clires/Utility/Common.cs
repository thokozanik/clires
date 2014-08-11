using Tateeda.Clires.Areas.Admin.Model.Report;

namespace Tateeda.Clires.Utility
{
	using global::System;

	using global::System.Collections.Generic;
	using global::System.Linq;
	using global::System.Text;

	using global::System.Text.RegularExpressions;

	using global::System.Web;

	using global::System.Web.Mvc;

	using Areas.Admin.Model.Forms;
	using Data.UOW;

	public static class Common
	{
		const string Pattern = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

		#region - Report Helper
		public static void FillReportModel(ReportModel model, int studyId)
		{
			using (var uow = new ReportUnitOfWork())
			{
				model.SubjectsReportModel.TotalActiveSubjectsCount = uow.ReportRepository.GetTotalSubjectsCount(true);
				model.SubjectsReportModel.TotalInActiveSubjectsCount = uow.ReportRepository.GetTotalSubjectsCount(false);
				model.SubjectsReportModel.TotalSubjectsCount = uow.ReportRepository.GetTotalSubjectsCount(null);

				model.SubjectsReportModel.TotalSubjectsPerStydy = uow.ReportRepository.GetTotalSubjectsPerStydy(studyId);

				model.SubjectsReportModel.TotalCompletedAppointmentsPerStudy =
					uow.ReportRepository.GetTotalCompletedAppointmentsPerStudy(studyId);

				model.SubjectsReportModel.TotalInProgressAppointmentsPerStudy =
					uow.ReportRepository.GetTotalInProgressAppointmentsPerStudy(studyId);

				model.SubjectsReportModel.TotalScheduledAppointmentsPerStudy =
					uow.ReportRepository.GetTotalScheduledAppointmentsPerStudy(studyId);

				model.SubjectsReportModel.TotalSubjectsPerStudyForAllSites =
					uow.ReportRepository.GetTotalSubjectsPerStudyForAllSites(studyId);

				model.SubjectsReportModel.TotalActiveSubjectsPerStudyForAllSites =
					uow.ReportRepository.GetTotalActiveSubjectsPerStudyForAllSites(studyId);

				model.SubjectsReportModel.TotalCompletedFormsPerStudy =
					uow.ReportRepository.GetTotalCompletedFormsPerStudy(studyId);

				model.SubjectsReportModel.TotalInProgressFormsPerStudy =
					uow.ReportRepository.GetTotalInProgressFormsPerStudy(studyId);
			}
		}
		#endregion

		public static int GetAreaCodeFromTelephone(string telephone)
		{
			if (string.IsNullOrWhiteSpace(telephone)) return 0;

			var matches = Regex.Matches(telephone, Pattern);
			if (matches.Count > 0)
			{
				return int.Parse(matches[0].Groups[1].Value);
			}
			return 0;
		}

		public static int GetNumberFromTelephone(string telephone)
		{
			if (string.IsNullOrWhiteSpace(telephone)) return 0;
			var matches = Regex.Matches(telephone, Pattern);
			switch (matches.Count)
			{
				case 2:
					return int.Parse(matches[0].Groups[2].Value);
				case 3:
					return Int32.Parse(string.Format("{0}{1}", matches[0].Groups[2].Value, matches[0].Groups[3].Value));
				default:
					return 0;
			}
		}

		public static bool ProcessFormImportFile(HttpPostedFileBase file)
		{
			if (file == null) return false;

			if (file.FileName.EndsWith(".csv") && file.ContentLength > 0)
			{
				using (var fileStream = file.InputStream)
				{
					var fileLenth = file.ContentLength;
					var buffer = new byte[fileLenth];
					fileStream.Read(buffer, 0, fileLenth);
					var context = Encoding.ASCII.GetString(buffer);

					var importedForms = GetListOfImportedForms(context);
					using (var adminUow = DependencyResolver.Current.GetService<IAdminUnitOfWork>())
					{
						foreach (var form in importedForms)
						{
							adminUow.FormRepository.CreateNewForm(form);
							foreach (var question in form.Questions)
							{
								adminUow.FormRepository.CreateNewQuestion(question);
								foreach (var answer in question.Answers)
								{
									adminUow.FormRepository.CreateNewAnswer(answer);
								}
							}
						}

						adminUow.Commit();
					}
				}

				return true;
			}

			return false;
		}

		private static IEnumerable<FormViewModel> GetListOfImportedForms(string context)
		{
			const int ImportCoulumnsCount = 12;
			var formsList = new List<FormViewModel>();
			var lines = context.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
			var header = lines[0].Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
			var headerIndexer = GetFileHeaderIndexer(header);

			var curForm = string.Empty;
			var curQuestion = string.Empty;
			var curAnswer = string.Empty;
			var nextForm = string.Empty;
			var nextQuestion = string.Empty;
			var nextAnswer = string.Empty;

			FormViewModel form = null;
			QuestionViewModel question = null;
			AnswerViewModel answer = null;

			for (int i = 1; i < lines.Length; i++)
			{
				try
				{
					var fields = CleanLineInput(lines[i]).Split(new[] { "," }, StringSplitOptions.None);

					if (fields.Length != ImportCoulumnsCount)
					{
						continue;
					}

					curForm = fields[headerIndexer["FormId"]];
					curQuestion = fields[headerIndexer["QuestionId"]];
					curAnswer = fields[headerIndexer["AnswerId"]];
					if (curForm != nextForm)
					{
						form = new FormViewModel
							{
								Name = fields[headerIndexer.FirstOrDefault(k => k.Key == "FormName").Value],
								Title = fields[headerIndexer["Title"]],
								Description = fields[headerIndexer["Description"]],
								FormTypeId = int.Parse(fields[headerIndexer["FormType"]]) + 1,
								StudyId = int.Parse(fields[headerIndexer.FirstOrDefault(k => k.Key == "StudyId").Value]),
								QuestionsViewModel = new List<QuestionViewModel>()
							};

						formsList.Add(form);
					}

					if (curQuestion != nextQuestion)
					{
						question = new QuestionViewModel
							{
								QuestionText = fields[headerIndexer["QuestionText"]],
								AnswersViewModel = new List<AnswerViewModel>(),
							};
						form.QuestionsViewModel.Add(question);
					}

					if (curAnswer != nextAnswer)
					{
						answer = new AnswerViewModel()
							{
								AnswerText = fields[headerIndexer["AnswerText"]],
								FieldDataTypeId = int.Parse(fields[headerIndexer["QuestionTypeId"]]),
							};
						question.AnswersViewModel.Add(answer);
					}
				}
				catch (Exception ex)
				{
					Console.Out.WriteLine(ex.Message);
				}
				nextForm = curForm;
				nextQuestion = curQuestion;
				nextAnswer = curAnswer;
			}

			return formsList;

		}

		private static string CleanLineInput(string @line)
		{
			int start = 0, next = 0, cnt = 0;
			string result = string.Empty;

			for (int i = 0; i < @line.Length; i++)
			{
				if (line[i] == '"')
				{
					if (cnt == 0)
					{
						start = i;
					}
					else
					{
						next = i;
						cnt = 0;
					}
					cnt++;
				}
				result += line[i];
				if (start > 0 && next > 0)
				{
					var quotedPart = result.Substring(start).Replace(',', '~');
					result = result.Substring(0, start) + quotedPart;
					start = 0;
					next = 0;
				}
			}
			return result;
		}

		private static Dictionary<string, int> GetFileHeaderIndexer(string[] header)
		{
			var indexer = new Dictionary<string, int>();

			for (var i = 0; i < header.Length; i++)
			{
				if (!indexer.ContainsKey(header[i]))
				{
					indexer.Add(header[i], i);
				}
			}

			return indexer;
		}
	}
}