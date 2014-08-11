using System.Collections.ObjectModel;

namespace Tateeda.Clires.Extensions
{
	using Tateeda.Clires.Areas.Subject.Model;

	using global::System.Collections.Generic;
	using global::System.Linq;
	using Core.Data.EF;

	/// <summary>
	/// The subject extension.
	/// </summary>
	public static class SubjectExtension
	{
		/// <summary>
		/// The to entity.
		/// </summary>
		/// <param name="sub">
		/// The Subject View Model
		/// </param>
		/// <returns>
		/// The <see cref="Subject"/>.
		/// </returns>
		public static Subject ToEntity(this SubjectViewModel sub)
		{
			var contact = sub.Contact;
			return new Subject
				{
					ContactId = sub.ContactId,
					DateOfBirth = sub.DateOfBirth,
					FamilyId = sub.FamilyId,
					NIMHID = sub.NIMHID,
					Nickname = sub.Nickname,
					Notes = sub.Notes,
					Directions = sub.Directions,
					GenderTypeId = sub.GenderTypeId,
					Id = sub.Id,
					IsActive = sub.IsActive,
					SSN = sub.SSN,
					SiteId = sub.SiteId,
					SortOrder = sub.SortOrder,
					StudyId = sub.StudyId,
					YearBorn = sub.YearBorn,
					Contact = contact
				};
		}

		/// <summary>
		/// The to model.
		/// </summary>
		/// <param name="sub">
		/// The sub.
		/// </param>
		/// <returns>
		/// The <see cref="SubjectViewModel"/>.
		/// </returns>
		public static SubjectViewModel ToModel(this ISubject sub)
		{
			var contact = sub.Contact;
			var phone = contact.Phones.FirstOrDefault() ?? new Phone();
			var email = contact.Emails.FirstOrDefault() ?? new Email();
			var address = contact.Addresses.FirstOrDefault() ?? new Address();

			var model = new SubjectViewModel
				{
					CreatedBy = sub.CreatedBy,
					Id = sub.Id,
					IsActive = sub.IsActive,
					SiteId = sub.SiteId,
					SortOrder = sub.SortOrder,
					Status = sub.Status,
					UpdatedBy = sub.UpdatedBy,
					ContactId = sub.ContactId,
					DateOfBirth = sub.DateOfBirth,
					SSN = sub.SSN,
					NIMHID = sub.NIMHID,
					Nickname = sub.Nickname,
					GenderTypeId = sub.GenderTypeId,
					FirstName = contact.FirstName,
					LastName = contact.LastName,
					Contact = new Contact
						{
							FirstName = contact.FirstName,
							LastName = contact.LastName,
							ContactTypeId = contact.ContactTypeId,
							Phones = new List<Phone>
                                {
                                    new Phone
                                        {
                                            AreaCode = phone.AreaCode,
                                            Number = phone.Number,
                                            Telephone = phone.Telephone,
                                            PhoneTypeId = phone.PhoneTypeId
                                        }
                                },
							Addresses =
								new List<Address>
                                    {
                                        new Address
                                            {
                                                Street = address.Street ?? string.Empty,
                                                City = address.City ?? string.Empty,
                                                PostalCode = address.PostalCode ?? string.Empty,
                                                StateId = address.StateId,
                                                CountryId = address.CountryId,
                                                AddressTypeId = address.AddressTypeId
                                            }
                                    },
							Emails = new List<Email>
                                {
                                    new Email {Address = email.Address}
                                }
						},
					SubjectDrugs = LoadSubjectDrugs(sub)
				};

			model.Contacts = new List<Contact> { model.Contact };
			return model;
		}

		private static ISubjectDrugViewModel ToModel(this ISubjectDrug drug)
		{
			return new SubjectDrugViewModel
				{
					CreatedBy = drug.CreatedBy,
					CreatedOn = drug.CreatedOn,
					Directions = drug.Directions,
					Id = drug.Id,
					IsActive = drug.IsActive,
					DrugName = drug.Drug.Name,
					SortOrder = drug.SortOrder,
					Status = drug.Status,
					UpdatedBy = drug.UpdatedBy,
					UpdatedOn = drug.UpdatedOn,
					StartDate = drug.StartDate,
					EndDate = drug.EndDate,
					Dosage = drug.Dosage,
					DosageFrequencyId = drug.DosageFrequencyId,
					IsChanged = drug.IsChanged,
					IsBeforeStudy = drug.IsBeforeStudy,
					IsStopped = drug.IsStopped,
					IsCurrent = drug.IsCurrent,
					Notes = drug.Notes,
					MdNotes = drug.MdNotes,
					Comments = drug.Comments,
					SubjectId = drug.SubjectId,
					TreatmentInducedId = drug.TreatmentInducedId,
					MultipleTrialsId = drug.MultipleTrialsId,
					DrugId = drug.DrugId,
					ReasonTypeId = drug.ReasonTypeId,
					ReasonStoppedId = drug.ReasonStoppedId,
					DosageType = drug.DosageType
				};
		}

		private static ICollection<ISubjectDrugViewModel> LoadSubjectDrugs(ISubject sub)
		{
			var list = new Collection<ISubjectDrugViewModel>();
			foreach (var d in sub.SubjectDrugs)
			{
				list.Add(d.ToModel());
			}
			return list;
		}
	}
}