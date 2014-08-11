namespace Tateeda.Clires.Core.Extensions
{
	using System.Collections.Generic;
	using System.Linq;

	using Data.EF;
	using Data.Enums;

	/// <summary>
	/// The subject extension.
	/// </summary>
	public static class SubjectExtension
	{
		#region Public Methods and Operators

		/// <summary>
		/// The to entity.
		/// </summary>
		/// <param name="sub">
		/// The sub.
		/// </param>
		/// <returns>
		/// The <see cref="ISubject"/>.
		/// </returns>
		public static ISubject ToEntity(this uspGetSubjectBySiteId_Result sub)
		{
			return new Subject
				{
					CreatedBy = sub.CreatedBy,
					CreatedOn = sub.CreatedOn,
					DateOfBirth = sub.DateOfBirth,
					Directions = sub.Directions,
					FamilyId = sub.FamilyId,
					GenderTypeId = sub.GenderTypeId,
					Id = sub.SubjectId,
					IsActive = sub.IsActive,
					NIMHID = sub.NIMHID,
					SSN = sub.SSN,
					Nickname = sub.Nickname,
					Notes = sub.Notes,
					SiteId = sub.SiteId,
					SortOrder = sub.SortOrder,
					Status = sub.Status,
					StudyId = sub.StudyId,
					UpdatedBy = sub.UpdatedBy,
					UpdatedOn = sub.UpdatedOn,
					Contact =
						new Contact
							{
								FirstName = sub.FirstName,
								LastName = sub.LastName,
								ContactTypeId = (int)ContactType.Subject,
								Phones = new List<Phone>
									{
										new Phone
											{
												Telephone = sub.Telephone,
												PhoneTypeId = sub.PhoneTypeId
											}
									},
								Addresses =
									new List<Address>
										{
											new Address
												{
													Street = sub.Street,
													City = sub.City,
													StateId = sub.StateId,
													CountryId = sub.CountryId,
													PostalCode = sub.PostalCode,
													AddressTypeId = sub.AddressTypeId.HasValue ? sub.AddressTypeId.Value : 0
												}
										},
								Emails = new List<Email> { new Email { Address = sub.Email } }
							}
				};
		}

		/// <summary>
		/// The to subject.
		/// </summary>
		/// <param name="sub">
		/// The sub.
		/// </param>
		/// <returns>
		/// The <see cref="ISubject"/>.
		/// </returns>
		public static ISubject ToSubject(this uspSubjectFindByFirstLastName_Result sub)
		{
			return new Subject
				{
					CreatedBy = sub.CreatedBy,
					CreatedOn = sub.CreatedOn,
					DateOfBirth = sub.DateOfBirth,
					Directions = sub.Directions,
					FamilyId = sub.FamilyId,
					GenderTypeId = sub.GenderTypeId,
					Id = sub.SubjectId,
					IsActive = sub.IsActive,
					NIMHID = sub.NIMHID,
					SSN = sub.SSN,
					Nickname = sub.Nickname,
					Notes = sub.Notes,
					SiteId = sub.SiteId,
					SortOrder = sub.SortOrder,
					Status = sub.Status,
					StudyId = sub.StudyId,
					UpdatedBy = sub.UpdatedBy,
					UpdatedOn = sub.UpdatedOn,
					Contact =
						new Contact
							{
								FirstName = sub.FirstName,
								LastName = sub.LastName,
								ContactTypeId = (int)ContactType.Subject,
								Phones = new List<Phone>
									{
										new Phone
											{
												Telephone = sub.Telephone,
												PhoneTypeId = sub.PhoneTypeId
											}
									},
								Addresses =
									new List<Address>
										{
											new Address
												{
													Street = sub.Street,
													City = sub.City,
													StateId = sub.StateId,
													CountryId = sub.CountryId,
													PostalCode = sub.PostalCode,
													AddressTypeId = sub.AddressTypeId.HasValue ? sub.AddressTypeId.Value : 0
												}
										},
								Emails = new List<Email> { new Email { Address = sub.Email } }
							}
				};
		}

		/// <summary>
		/// The to subject.
		/// </summary>
		/// <param name="sub">
		/// The sub.
		/// </param>
		/// <returns>
		/// The <see cref="ISubject"/>.
		/// </returns>
		public static ISubject ToSubject(this uspGetSubjectById_Result sub)
		{
			return new Subject
				{
					CreatedBy = sub.CreatedBy,
					CreatedOn = sub.CreatedOn,
					DateOfBirth = sub.DateOfBirth,
					Directions = sub.Directions,
					FamilyId = sub.FamilyId,
					GenderTypeId = sub.GenderTypeId,
					Id = sub.SubjectId,
					IsActive = sub.IsActive,
					NIMHID = sub.NIMHID,
					SSN = sub.SSN,
					Nickname = sub.Nickname,
					Notes = sub.Notes,
					SiteId = sub.SiteId,
					SortOrder = sub.SortOrder,
					Status = sub.Status,
					StudyId = sub.StudyId,
					UpdatedBy = sub.UpdatedBy,
					UpdatedOn = sub.UpdatedOn,
					Contact =
						new Contact
							{
								FirstName = sub.FirstName,
								LastName = sub.LastName,
								ContactTypeId = (int)ContactType.Subject,
								Phones = new List<Phone>
									{
										new Phone
											{
												Telephone = sub.Telephone,
												PhoneTypeId = sub.PhoneTypeId.HasValue ? sub.PhoneTypeId.Value : 0
											}
									},
								Addresses =
									new List<Address>
										{
											new Address
												{
													Street = sub.Street,
													City = sub.City,
													StateId = sub.StateId,
													CountryId = sub.CountryId,
													PostalCode = sub.PostalCode,
													AddressTypeId = sub.AddressTypeId.HasValue ? sub.PhoneTypeId.Value : 0
												}
										},
								Emails = new List<Email> { new Email { Address = sub.Email } }
							}
				};
		}

		/// <summary>
		/// The to subjects.
		/// </summary>
		/// <param name="result">
		/// The result.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		public static IEnumerable<ISubject> ToSubjects(this IEnumerable<uspSubjectFindByFirstLastName_Result> result)
		{
			return result.Select(s => s.ToSubject()).ToList();
		}

		/// <summary>
		/// The to subjects.
		/// </summary>
		/// <param name="result">
		/// The result.
		/// </param>
		/// <returns>
		/// The <see cref="IEnumerable"/>.
		/// </returns>
		public static IEnumerable<ISubject> ToSubjects(this IEnumerable<uspGetSubjectById_Result> result)
		{
			return result.Select(s => s.ToSubject()).ToList();
		}

		#endregion
	}
}