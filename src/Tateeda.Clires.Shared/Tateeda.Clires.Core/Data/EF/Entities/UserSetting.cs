namespace Tateeda.Clires.Core.Data.EF
{
	using System;

	public interface IUserSetting
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		int AppUserId { get; set; }

		string SettingName { get; set; }

		string SettingValue { get; set; }

		System.DateTime CreatedOn { get; set; }

		Nullable<System.DateTime> UpdatedOn { get; set; }

		string CreatedBy { get; set; }

		string UpdatedBy { get; set; }

		bool IsActive { get; set; }

		AppUser AppUser { get; set; }

		/// <summary>
		///   Gets or sets the entity identifier
		/// </summary>
		int Id { get; set; }
	}

	public partial class UserSetting : BaseEntity, IUserSetting
	{
	}
}
