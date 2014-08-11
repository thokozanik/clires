// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The FileRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tateeda.Clires.Core.Utility
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Tateeda.Clires.Core.Data;
	using Tateeda.Clires.Core.Data.EF;

	/// <summary>
	/// The FileRepository interface.
	/// </summary>
	public interface IFileRepository : IRepository<File>
	{
		#region Public Methods and Operators

		/// <summary>
		/// The add study file.
		/// </summary>
		/// <param name="studyId">
		/// The study id. 
		/// </param>
		/// <param name="file">
		/// The file. 
		/// </param>
		void AddStudyFile(int studyId, File file);

		/// <summary>
		/// The add subject file.
		/// </summary>
		/// <param name="subjectId">
		/// The subject id. 
		/// </param>
		/// <param name="file">
		/// The file. 
		/// </param>
		void AddSubjectFile(int subjectId, File file);

		void ImportFormQuestionAnswer(IEnumerable<FormQuestionAnswerImport> formSets);

		File GetFile(int id);

		#endregion
	}

	/// <summary>
	/// The file repository.
	/// </summary>
	public class FileRepository : IFileRepository
	{
		#region Static Fields

		/// <summary>
		/// The _locker.
		/// </summary>
		private static readonly object _locker = new object();

		#endregion

		#region Fields

		/// <summary>
		/// The _context.
		/// </summary>
		private readonly IDbContext _context;

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="FileRepository"/> class.
		/// </summary>
		/// <param name="context">
		/// The context.
		/// </param>
		public FileRepository(IDbContext context)
		{
			_context = context;
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the all.
		/// </summary>
		public IQueryable<File> All { get; private set; }

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// The add study file.
		/// </summary>
		/// <param name="studyId">
		/// The study id.
		/// </param>
		/// <param name="file">
		/// The file.
		/// </param>
		public void AddStudyFile(int studyId, File file)
		{
			lock (_locker)
			{
				var max = _context.Files.Any() ? _context.Files.Max(f => f.Id) : 0;
				int maxId = max + 1;
				var study = _context.Studies.FirstOrDefault(s => s.Id == studyId);
				file.Id = maxId;
				file.FileGuid = Guid.NewGuid();
				file.Studies.Add(study);
				_context.Files.Add(file);
			}
		}

		public File GetFile(int id)
		{
			return _context.Files.FirstOrDefault(f => f.Id == id);
		}

		/// The add subject file.
		/// </summary>
		/// <param name="subjectId">
		/// The subject id.
		/// </param>
		/// <param name="file">
		/// The file.
		/// </param>
		public void AddSubjectFile(int subjectId, File file)
		{
			lock (_locker)
			{
				var max = _context.Files.Any() ? _context.Files.Max(f => f.Id) : 0;
				int maxId = max + 1;
				var subject = _context.Subjects.FirstOrDefault(s => s.Id == subjectId);

				file.Id = maxId;
				file.FileGuid = Guid.NewGuid();
				file.Subjects.Add(subject);
				_context.Files.Add(file);
			}
		}

		public void ImportFormQuestionAnswer(IEnumerable<FormQuestionAnswerImport> formSets)
		{
			foreach (var frm in formSets)
			{
				_context.FormQuestionAnswerImports.Add(frm);
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
		public void Delete(File entity)
		{
			_context.Files.Remove(entity);
		}

		/// <summary>
		/// The get by id.
		/// </summary>
		/// <param name="id">
		/// The id.
		/// </param>
		/// <returns>
		/// The <see cref="File"/>.
		/// </returns>
		/// <exception cref="Exception">
		/// </exception>
		public File GetById(object id)
		{
			throw new Exception("Use GetById with Guid");
		}

		/// <summary>
		/// The get by id.
		/// </summary>
		/// <param name="id">
		/// The id.
		/// </param>
		/// <returns>
		/// The <see cref="File"/>.
		/// </returns>
		public File GetById(Guid id)
		{
			return _context.Files.FirstOrDefault(f => f.FileGuid.Equals(id));
		}

		/// <summary>
		/// The insert.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		public void Insert(File entity)
		{
			_context.Files.Add(entity);
		}

		/// <summary>
		/// The update.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		public void Update(File entity)
		{
			// NO File updates at this time
		}



		#endregion
	}
}