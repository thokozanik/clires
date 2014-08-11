namespace Tateeda.Clires.Models
{
	using global::System.ComponentModel.DataAnnotations;

	public class DemoRequestModel
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Organization { get; set; }
		[Required]
		public string ContactEmail { get; set; }

		public string ContactPhone { get; set; }

		public string Comment { get; set; }
	}
}