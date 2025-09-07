using System.ComponentModel.DataAnnotations;

namespace ETicketsSystem.ViewModels
{
	public class CategoryWithCinemaVM
	{
		[Required]
		public int? CategoryId { get; set; }

		[Required]
		public int? CinemaId { get; set; }

		public List<Category>? Categories { get; set; }
		public List<Cinema>? Cinemas { get; set; }
		
		public Movie? Movie { get; set; } 
	}
}
