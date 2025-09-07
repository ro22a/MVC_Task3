using System.ComponentModel.DataAnnotations;

namespace ETicketsSystem.Models
{
	public class Cinema
	{ 
		public int Id { get; set; }
		[Required]
		[MinLength(2)]
		[MaxLength(255)]
		public string Name { get; set; }=string.Empty;

		public string? Description { get; set; }
		public string? CinemaLogo  { get; set; }
		[Required]
		[MinLength(5)]
		[MaxLength(255)]
		public string Address { get; set; }=string.Empty;
		public List<Movie>?	Movies { get; set; }

	}  
}
