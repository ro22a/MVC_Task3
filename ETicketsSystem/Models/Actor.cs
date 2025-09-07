using System.ComponentModel.DataAnnotations;

namespace ETicketsSystem.Models
{
	public class Actor
	{
		public int Id { get; set; }
		[Required]
		[MinLength(2)]
		[MaxLength(255)]
		public string FirstName { get; set; }=string.Empty;
		public string LastName { get; set; }=string.Empty;
		[Required]
		public string? Bio { get; set; }
		public string? ProfilePicture { get; set; }
		public string? News { get; set; }

		public List<Movie> Movies { get; set; }

	}
}
